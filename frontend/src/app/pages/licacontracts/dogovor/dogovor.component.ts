import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbRoleProvider } from '@nebular/security';
import { NbDialogService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { ROLES } from '../../../@auth/roles';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { RoutingState } from '../../../@core/backend/common/services/RoutingState.service';
import { DocumentsData, Dokument } from '../../../@core/interfaces/common/documents';
import { LiceData, LiceDogovor } from '../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { findInvalidControlsRecursive} from '../../../@core/tools/functions';
import { FileUploadDialogComponent } from '../../application/components/fileupload-dialog/fileupload-dialog.component';
import { PagesComponent } from '../../pages.component';
import { LiceDogovorForm } from '../formclasses/dogovor.form';

@Component({
  selector: 'ngx-dogovor',
  templateUrl: './dogovor.component.html',
  styleUrls: ['./dogovor.component.scss']
})
export class DogovorComponent implements OnInit {
  mainForm: FormGroup;
  previousUrl: string = '';
  oldstatus: number;

  arhuredi: FormArray;
  olduredi: FormArray;
  uredi: FormArray;
  dopsp: FormArray;
  vlistv18:  ViewNom[];
  vlistv43:  ViewNom[];
  vliststatus:  ViewNom[];
  vliststatusU:  ViewNom[];
  vliststatusDU:  ViewNom[];
  vlistdopsp:  ViewNom[];
  dokumenti: Dokument[]

  id: number = 0;
  name: string = '';
  idformulqr: number = 0;
  disable: boolean = false;
  isAdmin: boolean = false;
  licedogovor: LiceDogovor;
  iddog: number;
  click: boolean = false;

  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
    private router: Router,
    private route: ActivatedRoute,
    private licaService: LiceData,
    private nomenclatureService: NomenclatureData,
    private routingState: RoutingState,
    private toasterService: CustomToastrService,
    private documentService: DocumentsData,
    private dialogService: NbDialogService,
    private roleProvider : NbRoleProvider,
  ) {    
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      this.idformulqr = Number(params.get('idformulqr'));
      this.disable = String(params.get('disable'))==='true';        
    });
    
    this.loadLists();
  }

  ngOnInit(): void {
    this.previousUrl = this.routingState.getPreviousUrl()

    this.mainForm = new LiceDogovorForm().create(this.disable);
    this.arhuredi =  <FormArray>this.mainForm.get('arhuredi');
    this.olduredi =  <FormArray>this.mainForm.get('olduredi');
    this.uredi =  <FormArray>this.mainForm.get('uredi');
    this.dopsp =  <FormArray>this.mainForm.get('dopsp');

    this.getUserType();
    this.loadLiceDogovor();    
    this.loadDocuments();
    this.prepareStatusDl();
  }

  loadLists() {
    this.nomenclatureService
      .getNomenStatusi('Status_DL')
      .subscribe(result => {
          this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
          this.prepareStatusDl();
    });

    this.nomenclatureService
      .getNomenUredi()
      .subscribe(result => {
        this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item));
    });

    this.nomenclatureService
      .getNomenObshti('06')
      .subscribe(result => {
        this.vlistv18 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenObshti('12')
      .subscribe(result => {
        this.vlistdopsp = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_U')
        .subscribe(result => {
        this.vliststatusU = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_DU')
        .subscribe(result => {
        this.vliststatusDU = result.map(item => new ViewNom().convertNomStatusi(item));
    });
  }

  prepareStatusDl () {
    let hasUredStatus3 = false;
    let hasUredStatus5 = false;

    let uredi = this.mainForm.get('uredi') as FormArray; 
    uredi.controls.forEach (t => {
      if (t.get('statusU').value == '3') {
          hasUredStatus3 = true;
      } else if (t.get('statusU').value == '5') {
          hasUredStatus5 = true;
      }
    })

    // TEST 6-1 premahnato
    // if (!hasUredStatus3 && !hasUredStatus5) {
    //   let olduredi = this.mainForm.get('olduredi') as FormArray;
    //   olduredi.controls.forEach (t => {
    //       if (t.get('statusU').value == '3') {
    //           hasUredStatus3 = true;
    //       } else if (t.get('statusU').value == '5' && t.get('id').value != '22' ) {
    //           hasUredStatus5 = true;
    //       }  
    //   })
    // }

    if (this.vliststatus) {
      if (hasUredStatus5) {  
        this.vliststatus = this.vliststatus.filter(e => e.id == 2);
      } else if (hasUredStatus3) {  
        this.vliststatus = this.vliststatus.filter(e => e.id > 1 && e.id != 4);
      }                         
    }
  }

  loadLiceDogovor() {
    this.licaService
        .getLiceDogovor(this.id)
        .subscribe(result => {
          this.licedogovor = result;

          if (result.uredi) {
            (this.mainForm.get('uredi') as FormArray).removeAt(0);

              result.uredi.forEach (t => {
                var ured: FormGroup =  new LiceDogovorForm().createUredItem();
                (this.mainForm.get('uredi') as FormArray).push(ured);
              })
          }

          if (result.olduredi) {
              (this.mainForm.get('olduredi') as FormArray).removeAt(0);

              result.olduredi.forEach (t => {
                  var ured: FormGroup =  new LiceDogovorForm().createOldUredItem();
                  (this.mainForm.get('olduredi') as FormArray).push(ured);
              })
          }
             
          if (result.arhuredi) {
             (this.mainForm.get('arhuredi') as FormArray).removeAt(0);

             result.arhuredi.forEach (t => {
                 var ured: FormGroup =  new LiceDogovorForm().createArhUredItem();
                 (this.mainForm.get('arhuredi') as FormArray).push(ured);
             })
          }

          if (result.dopsp) {
            (this.mainForm.get('dopsp') as FormArray).removeAt(0);

            result.dopsp.forEach (t => {
                var dopsp: FormGroup =  new LiceDogovorForm().createDopSpItem();
                (this.mainForm.get('dopsp') as FormArray).push(dopsp);
            })
          }

          this.mainForm.patchValue(
          {
                iddog: result.iddog,
                idl: result.idl,
                faza: result.faza,
                regnom: result.regnom ? result.regnom : '',
                regnomdata: result.regnomdata ? result.regnomdata : null,
                status_DL: result.status_DL ? String(result.status_DL) : '0',
                status: result.status ? result.status : 1,
                uredi: result.uredi,
                olduredi: result.olduredi,    
                arhuredi: result.arhuredi,    
                comentar: result.comentar ? result.comentar : '',
                dopsp: result.dopsp,
                vid: result.vid ? result.vid: 0,
                srokDogovor : result.srokDogovor ? result.srokDogovor: 24,
                srokSobstvenost : result.srokSobstvenost ? result.srokSobstvenost: 24,
          });   
             
          this.oldstatus = result.status_DL ? result.status_DL : 0;

          // this.mainForm.get("status_DL").valueChanges.subscribe(selectedValue => {
          //     this.prepareStatusDl();
          // })          

          this.onStatusChanged(this.mainForm.get('status_DL').value);
          this.prepareStatusDl();
        });
  }

 
  print() {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#4d0099;">Печат на договор?</h5> ',
      text: 'Искате ли да се генерира договор за избранoто Лице!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        let filename = 'Договор_'+this.name+ '.docx';

        this.licaService
          .genDogovorFile(this.id)
          .subscribe((response: any) =>{
              let dataType = response.type;
              let binaryData = [];
              binaryData.push(response);
              let downloadLink = document.createElement('a');
              downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
              if (filename)
                  downloadLink.setAttribute('download', filename);
              document.body.appendChild(downloadLink);
              downloadLink.click();
          },
          error => {
            this.handleWrongResponse();
          });
      }
    });
  }
  
  save() {    
    if (this.mainForm.get('status_DL').value == 9) {
      let hasUredStatus3 = false;
      let uredi = this.mainForm.get('uredi') as FormArray;

      uredi.controls.forEach (t => {
        if (t.get('statusU').value == '3' || t.get('statusU').value == '5') {
          hasUredStatus3 = true;
        }
      })

      if (!hasUredStatus3) {
        let olduredi = this.mainForm.get('olduredi') as FormArray;
        olduredi.controls.forEach (t => {
            if (t.get('statusU').value == '3' || t.get('statusU').value == '5') {
            hasUredStatus3 = true;
          }  
        })
      }

      if (hasUredStatus3) {
        this.toasterService.showToast("danger","Уред включен в поръчка");  
      } else {
        this.licaService
            .setFormulqrStatus(this.idformulqr,9)
            .subscribe(result => {
                this.toasterService.success("", `Успешен запис.`);
        });  
      }
      return;

    } else {  
      if (!this.mainForm.valid) {
        let errors = findInvalidControlsRecursive(this.mainForm);      
        errors.forEach (e=>{
          let message = '';

          if (e == 'regnom')
              message = "Не е попълнен номер на договора."
          else if (e == 'regnomdata')
              message = "Не е попълнена дата на договора"
          else if (e.indexOf(':broi') > -1 )
              message = "Не са попълнени уреди за отопление"
          
          if (message) 
              this.toasterService.danger(message,"Грешка!");  
        })
        return;
      }
    }

    if (this.disable) {
      this.mainForm.enable();
    }  

    const item: LiceDogovor = this.convertToDogovor(this.mainForm.value);
    let rez = this.checkControls(item);

    if (rez == 0) {
      this.click  = !this.click;
      let observable = new Observable<number>();
      observable = this.licaService.setLiceDogovor(item)
    
      observable
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(() => {
            this.handleSuccessResponse();
          },
          err => {
            this.handleWrongResponse();
      });
      this.click  = !this.click;
    }

    if (this.disable) {
      this.mainForm.disable();
      this.mainForm.get('status_DL').enable();  
    }  
  }
  
  convertToDogovor(value: any): LiceDogovor {
    const l: LiceDogovor = value;

    let uredi = this.mainForm.get('uredi') as FormArray; 
    uredi.controls.forEach (t => {
      let idx = l.uredi.findIndex (x => x.id  == t.get('id').value)
      if (idx > -1) 
        l.uredi[idx].statusU = t.get('statusU').value;
    })

    let olduredi = this.mainForm.get('olduredi') as FormArray;
    olduredi.controls.forEach (t => {
      let idx = l.olduredi.findIndex (x => x.id  == t.get('id').value)
      if (idx > -1) 
        l.olduredi[idx].statusU = t.get('statusU').value;
    });
    
    if (l.regnom && l.status_DL < 2) {
       l.status_DL = 2;

       l.olduredi.forEach (t => {
          t.statusU = (t.statusU < '3' ? (t.id == '22' ? '5': '2') : t.statusU)
       })

        l.uredi.forEach (t => {
        t.statusU = (t.statusU < '3' ? '2' : t.statusU)
        })   
    }

    return l;
  }

  checkControls(item: LiceDogovor): number {
    //proverqwa se samo individualniq dogovor
    if (item.vid > 1)
      return 0;

    let rez:number = 0;

    let cnt0219 = 0;
    let cnt2021 = 0;
    let cnt2328 = 0;
    let cnt0619 = 0;
    let cnt3249 = 0;
    let cnt0205 = 0;
    let cnt3031 = 0;
    let cnt5152 = 0;
    
    item.uredi.forEach (x=> {
        let id = Number(x.id);
        let broi= Number(x.broi);

        if (x.statusU < '3') {
          if (id >= 2 && id <= 5)  cnt0205 = cnt0205 + broi;
          if (id >= 2 && id <= 19) cnt0219 = cnt0219 + broi;
          if (id >= 6 && id <= 19) cnt0619 = cnt0619 + broi;
          if (id >= 20 && id <= 21) cnt2021 = cnt2021 + broi;
          if (id >= 23 && id <= 28) cnt2328 = cnt2328 + broi;
          if (id >= 30 && id <= 31) cnt3031 = cnt3031 + broi;        
          if (id >= 32 && id <= 49) cnt3249 = cnt3249 + broi;        
          if (id >= 51 && id <= 52) cnt5152 = cnt5152 + broi;        
        }
    })

//1 ************
    if (cnt0219 > 1) {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//2 ************
    if (cnt2021 > 3) {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//3 ************
    if (cnt0219 > 0 && cnt2021 > 0) {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//4 ************
    if (cnt2328 > 3) {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//5 ************
  if (cnt2328 > 0 && (cnt0219 > 0 || cnt2021 > 0) ) {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//6 ************
    if (cnt0619 > 0 && cnt3249 > 3)  {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

    if (cnt0619 > 0 && cnt3031 > 3)  {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

    if (cnt0619 > 0 && cnt5152 > 3)  {
      this.toasterService.showToast("danger","Грешен избор на уреди");  
      return -1;
    }

//7 ************
    if (cnt3249 > 3 || cnt3031 > 3 || cnt5152 > 3 ) {
      this.toasterService.showToast("danger","Грешен избор на радиатори");  
      return -1;
    }

//8 ************
    if ((cnt3249+cnt3031+cnt5152) > 0 && (cnt0205 > 0 || cnt2021 > 0 || cnt2328 > 0) ) {
      this.toasterService.showToast("danger","Грешен избор на радиатори");  
      return -1;
    }    
/*********************/

    // if (this.mainForm.get('status_DL').value != 2) {
    //   let hasUredStatus3 = false;
    //   item.olduredi.forEach (t => {
    //     if (t.statusU == '3') hasUredStatus3 = true;
    //   })
      
    //   if (!hasUredStatus3) {
    //     item.uredi.forEach (t => {
    //       if (t.statusU == '3') hasUredStatus3 = true;
    //     })
    //   }  

    //   if (hasUredStatus3) {
    //     this.toasterService.showToast("danger","Уред включен в поръчка");  
    //     return -1;
    //   }
    // }

    return rez;
  }

  onStatusChanged(item: number) {  
    if (item == 6 && this.oldstatus != 6) {
      let mustAsk = false;
      let uredi = this.mainForm.get('uredi') as FormArray; 
      uredi.controls.forEach (t => {
        let statusU  = t.get('statusU').value;
        
        if (statusU == '3' || statusU == '5') {
           mustAsk = true; 
        }
      });

      if (mustAsk) {
        Swal.fire({
          title:'<h5 style="padding-left:0px;color:#F8BB86">ВНИМАНИЕ!</h5> ',
          html: '<span style="color:white">'+
                'По договора има поне един уред, включен в поръчка! '+
                'Преди да  промените статуса на договора на „Отказан“, е необходимо съдействие '+
                'и потвърждение от експерта, отговорен за съответната поръчка! '+
                'Искате ли да продължите? '+ 
                '</span>',
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Продължи!',
          cancelButtonText: 'Отказ',
        }).then((result) => {
          if (result.isConfirmed) {
            this.changeStatus(item); 
          } else {
            this.mainForm.get('status_DL').setValue('2');
          }
        });                
      } else {
        this.changeStatus(item); 
      }

    } else {
      if (item == 0 || item == 4 || (item == 1 && this.isAdmin)) {
        this.mainForm.enable();  
        this.disable = false;
      } else {
        this.mainForm.disable();
        this.disable = true;
      }
      
      this.changeStatus(item);
    } 
  }

  changeStatus(item: number) {
    if (this.isAdmin || (item == 0 || item == 4)) {
      this.mainForm.get('status_DL').enable();  
      this.mainForm.get('comentar').enable();  

      this.dopsp.controls.forEach (t => {
        (this.mainForm.get('dopsp') as FormArray).enable();
      })
    }

    let uredi = this.mainForm.get('uredi') as FormArray; 
    uredi.controls.forEach (t => {
      t.get('statusU').disable();

      let statusU  = t.get('statusU').value;
      if ((item == 1 || item == 4 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('1');
      } else if (item == 2  && statusU < '3') {      
          t.get('statusU').setValue('2');
      } else if ((item == 6 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('6');
      } else if ((item == 9 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('9');
      }
    })

    let olduredi = this.mainForm.get('olduredi') as FormArray;
    olduredi.controls.forEach (t => {
      t.get('statusU').disable();

      let statusU  = t.get('statusU').value;
      if ((item == 1 || item == 4 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('1');
      } else if (item == 2  && statusU <'3') {      
          t.get('statusU').setValue('2');
      } else if ((item == 6 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('6');
      } else if ((item == 9 ) && !(statusU == '3' || statusU == '5')) {
          t.get('statusU').setValue('9');
      }
    })
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

  addItemUredi() {
    let canadd: boolean = true;
    let uredi = (this.mainForm.get('uredi') as FormArray);

    uredi.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd && !this.disable) {
      let ured = new LiceDogovorForm().createUredItem();
      ured.get('statusU').setValue('1');
      this.uredi.push(ured);
    }
  }

  removeItemUredi(index: number) {
    const uredi = (this.mainForm.get('uredi') as FormArray);
    const ured = uredi.controls[index];

    if (!this.disable && !(ured.get('statusU').value == '3' || ured.get('statusU').value == '5'))
      this.uredi.removeAt(index);
  }

  addItemOldUredi() {
    let canadd: boolean = true;
    const uredi = (this.mainForm.get('olduredi') as FormArray);

    uredi.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd && !this.disable) {
      let ured = new LiceDogovorForm().createOldUredItem();
      ured.get('statusU').setValue('1');
      this.olduredi.push(ured);
    }
  }

  removeItemOldUredi(index: number) {
    const uredi = (this.mainForm.get('uredi') as FormArray);

    if (!this.disable && !(uredi.get('statusU').value == '3' || uredi.get('statusU').value == '5'))
      this.olduredi.removeAt(index);
  }

  loadDocuments() {
    this.documentService
        .getDocuments(this.id,1)
        .subscribe(result => {
            this.dokumenti = result;                          
        });
  }

  addItem() {
    this.dialogService
        .open(FileUploadDialogComponent
                , { hasBackdrop: true,
                    closeOnBackdropClick: true,
                    hasScroll: false,
                    context: {
                      idDog: this.id,
                      typeDoc: 1
                    },
                })
        .onClose.subscribe(x => {
            if (x) this.loadDocuments()
        });                      
  }

  removeItem(item: Dokument) {
      Swal.fire({
        title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
        text: 'Искате да изтриете избраният формуляр!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Да, изтриване!',
        cancelButtonText: 'Отказ',
      }).then((result) => {
        if (result.isConfirmed) {
          this.documentService
              .removeFile(item.id)
              .subscribe(result => {
                this.toasterService.success("", `Файлът е изтрит успешно.`);
                this.loadDocuments();
              });  
        }
      });      
  }


  downloadItem(item: Dokument) {
    let filename = item.filename;
    let id = item.id;

    this.documentService      
        .downloadFile(id)
        .subscribe((response: any) =>{
          let dataType = response.type;
          let binaryData = [];
          binaryData.push(response);
          let downloadLink = document.createElement('a');
          downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
          if (filename)
              downloadLink.setAttribute('download', filename);
          document.body.appendChild(downloadLink);
          downloadLink.click();
    });  
  }

  addItemDopSp() {
    let canadd: boolean = true;
    const dopsp = (this.mainForm.get('dopsp') as FormArray);

    dopsp.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd)
      this.dopsp.push(new LiceDogovorForm().createDopSpItem());
  }

  removeItemDopSp(index: number) {
    this.dopsp.removeAt(index);
  }

  getUserType()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);

      if (role.toLowerCase() === ROLES.ADMIN  || (role==ROLES.USER && PagesComponent.raion.length==0))
        this.isAdmin = true;
      else
        this.isAdmin = false;
    });
  }

  back() {
    if (this.router.url === this.previousUrl)
      this.router.navigateByUrl('pages/licacontracts');
    else
      this.router.navigateByUrl(this.previousUrl);
  }


}
