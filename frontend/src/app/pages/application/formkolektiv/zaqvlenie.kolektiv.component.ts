import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormGroup} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbRoleProvider } from '@nebular/security';
import { NbDialogService, NbStepperComponent } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { ROLES } from '../../../@auth/roles';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { RoutingState } from '../../../@core/backend/common/services/RoutingState.service';
import { Address, Formulqr, LiceData } from '../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { findInvalidControlsRecursive, getErrorMessage } from '../../../@core/tools/functions';
import { PagesComponent } from '../../pages.component';
import { LiceForm } from '../formclasses/lice.form';
import { ZaqvlenieForm } from '../formclasses/zaqvlenie.form';
import { AddressEditDialogComponent } from '../address-dialog/address-dialog.component';

@Component({
  selector: 'ngx-zaqvlenie',
  templateUrl: './zaqvlenie.kolektiv.component.html',
  styleUrls: ['./zaqvlenie.kolektiv.component.scss'],
})
export class ZaqvlenieKolektivComponent implements OnInit {
  @ViewChild('stepper') stepper!: NbStepperComponent;
  _VID: number = 2;
  isDisabled: boolean=false;
  canDelete = false;
  click : boolean = false;

  id: number = 0;
  name: string = '';
  errors: string[] = [];
  messages: string[] = [];
  submitted = false;
  showMessages = true;
  realunom:string = '';
  idformulqr: number = 0;

  nomsuffix: string = 'К';
  mainForm: FormGroup;
  vliststatus:  ViewNom[];
  raioni:  ViewNom[];

  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
      private route: ActivatedRoute,
      private router: Router,
      private licaService: LiceData,
      private toasterService: CustomToastrService,
      private routingState: RoutingState,
      private nomenclatureService: NomenclatureData,
      private roleProvider :NbRoleProvider,
      private dialogService: NbDialogService,      
  ) {
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      if (this.name === 'null') this.name = 'нов';

      this.isDisabled = String(params.get('disable')) === 'true';
    });
   }

  ngOnInit(): void {
    this.canDeleteFormulqr();
    this.mainForm = new ZaqvlenieForm().create(this._VID,this.isDisabled);

    this.nomenclatureService
      .getNomenStatusi('Status_F')
      .subscribe(result => {
          this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));

          if (this.id == 0)
            this.vliststatus = this.vliststatus.filter(x => x.id ==1) 
    });    

    this.nomenclatureService.getNomenRaioni().subscribe((result) => {
      if (PagesComponent.raion.length > 0) {
        this.raioni = result.filter(e => e.nkod == PagesComponent.raion)
                            .map(item => new ViewNom().convertNomRaion(item));
      } else
        this.raioni = result.map((item) => new ViewNom().convertNomRaion(item));
    });
        
    if (this.id !== 0) {
      this.loadApp();
    }
  }

  loadApp() {
    this.licaService
      .getFormulqr(this.id)
      .subscribe(result => {
        this.idformulqr = result.idformulqr ? result.idformulqr : 0;
        this.realunom = result.unom ? result.unom : '';

        if (result.uredi && result.uredi.length>0) {
          (this.mainForm.get('uredi') as FormArray).removeAt(0);
  
           result.uredi.forEach (t => {
             var ured: FormGroup =  new ZaqvlenieForm().createUredItem();
             (this.mainForm.get('uredi') as FormArray).push(ured);
           })
        }

        if (result.olduredi && result.olduredi.length>0) {
          (this.mainForm.get('olduredi') as FormArray).removeAt(0);
  
           result.olduredi.forEach (t => {
             var oldured: FormGroup =  new ZaqvlenieForm().createUredItem();
             (this.mainForm.get('olduredi') as FormArray).push(oldured);
           })
        }
  
        if (result.dokumenti && result.dokumenti.length > 0) {
          (this.mainForm.get("dokumenti") as FormArray).removeAt(0);
  
          result.dokumenti.forEach((t) => {
            var docs: FormGroup = new ZaqvlenieForm().createDocumentItem();
            (this.mainForm.get("dokumenti") as FormArray).push(docs);
          });
        }
  
        if (result.systav && result.systav.length > 0) {  
          result.systav.forEach (t => {
            var ured: FormGroup =  new LiceForm().create(4,false);
            (this.mainForm.get('systav') as FormArray).push(ured);
          })
        }

        this.mainForm.patchValue({
          idformulqr: result.idformulqr ? result.idformulqr : 0,
          unom:  result.unom ? result.unom : '',
          unomer: result.unomer ? result.unomer: 0,
          faza: result.faza,
          status: result.status ? result.status : 1,
          statusF: result.statusF ? String(result.statusF) : '1',
          statusDL: result.statusDL ? String(result.statusDL) : "0",
          lice: {
            idl: result.lice.idl,
            vidLice: result.lice.vidLice
                    ? result.lice.vidLice
                    : String(this._VID),
            vidIdent: result.lice.vidIdent ? String(result.lice.vidIdent) : null,
            idlice: result.lice.idlice,
            ident: result.lice.ident ? result.lice.ident : '',
            ime: result.lice.ime ? result.lice.ime : '',
            nomLk: result.lice.nomLk ? result.lice.nomLk : '',
            dataIzdavane: result.lice.dataIzdavane,
            admRaion: result.lice.admRaion ? result.lice.admRaion : '',
            nasMqsto: result.lice.nasMqsto ? result.lice.nasMqsto : '',
            kvartal: result.lice.kvartal ? result.lice.kvartal : '',
            jk: result.lice.jk ? result.lice.jk : '',
            ulica: result.lice.ulica ? result.lice.ulica : '',
            nomer: result.lice.nomer ? result.lice.nomer : '',
            blok: result.lice.blok ? result.lice.blok : '',
            vhod: result.lice.vhod ? result.lice.vhod : '',
            etaj: result.lice.etaj ? result.lice.etaj : '',
            apart: result.lice.apart ? result.lice.apart : '',
            email: result.lice.email ? result.lice.email : '',
            telefon: result.lice.telefon ? result.lice.telefon : '',
            postKode: result.lice.postKode ? result.lice.postKode : '',
            status: result.lice.status ? result.lice.status : 1,
            statusL: result.lice.statusL ? String(result.lice.statusL) : 1,
            nv8: result.lice.nv8  ?  String(result.lice.nv8)  : null,
            tochki1: result.lice.tochki1 ? result.lice.tochki1  : 0,
            tochki2: result.lice.tochki2 ? result.lice.tochki2  : 0,
            tochki3: result.lice.tochki3 ? result.lice.tochki3  : 0,
            tochki4: result.lice.tochki4 ? result.lice.tochki4  : 0,
            tochki5: result.lice.tochki5 ? result.lice.tochki5  : 0,
            tochki6: result.lice.tochki6 ? result.lice.tochki6  : 0,
            tochki7: result.lice.tochki7 ? result.lice.tochki7  : 0,
            total: result.lice.total ? result.lice.total  : 0,
          },
          nv9: result.nv9 ? String(result.nv9) : null,
          nv10: result.nv10  ? String(result.nv10)  : '0',
          v11: result.v11  ? result.v11  : 0,
          v12: result.v12  ? result.v12  : 0,
          v13: result.v13  ? result.v13  : 0,
          v14: result.v14  ? result.v14  : 0,
          v15: result.v15  ? result.v15  : 0,
          v16: result.v16  ? result.v16  : 0,
          v17: result.v17  ? result.v17  : 0,
          nv19: result.nv19  ?  String(result.nv19)  : '0',
          v20: result.v20  ? result.v20  : 0,
          v211: result.v211  ? result.v211  : 0,
          v212: result.v212  ? result.v212  : 0,
          v213: result.v213  ? result.v213  : 0,
          v22: result.v22  ? result.v22  : 0,
          v23: result.v23  ? result.v23  : 0,
          v24: result.v24  ? result.v24  : 0,
          v25: result.v25  ? result.v25  : 0,
          v26: result.v26  ? result.v26  : 0,
          v27: result.v27  ? result.v27  : 0,
          v28: result.v28  ? result.v28  : 0,
          nv29: result.nv29  ? String(result.nv29)  : '0',
          v30: result.v30  ? result.v30  : 0,
          v31: result.v31  ? result.v31  : 0,
          v32: result.v32  ? result.v32  : 0,
          v33: result.v33  ? result.v33  : 0,
          v34: result.v34  ? result.v34  : 0,
          v35: result.v35  ? result.v35  : 0,
          v36: result.v36  ? result.v36  : 0,
          v37: result.v37  ? result.v37  : 0,
          v38: result.v38  ? result.v38  : 0,
          v391: result.v391  ? result.v391  : 0,
          v392: result.v392  ? result.v392  : 0,
          v401: result.v401  ? result.v401  : 0,
          v402: result.v402  ? result.v402  : 0,
          v41: result.v41  ? result.v41  : 0,
          v421: result.v421  ? result.v421  : 0,
          v422: result.v422  ? result.v422  : 0,
          v423: result.v423  ? result.v423  : 0,
          uredi: result.uredi,
          olduredi: result.olduredi,
          systav: result.systav,
          dokumenti: result.dokumenti,
          comentar: result.comentar ? result.comentar : '',
        });

        let systav = <FormArray>this.mainForm.get('systav');

        systav.controls.forEach((form: FormGroup) => {
          let vidident = form.get('vidIdent').value;      
          form.get('vidIdent').setValue(String(vidident));   
        });        

        this.statusChange(this.mainForm.get('statusF').value) 

        if (this.mainForm.get('statusF').value == 8) {
          this.vliststatus = this.vliststatus.filter(e => e.id > 7);
        } else if (this.mainForm.get('statusF').value == 9) {
          this.vliststatus = this.vliststatus.filter(e => e.id == 9);
        } else if (this.mainForm.get('statusDL').value > 1) {
          this.vliststatus = this.vliststatus.filter(e => e.id > 1);
        } 

        if (!this.canDelete) {
          this.vliststatus = this.vliststatus.filter(e => e.id < 9);
        }  
      });
  }

  save() {
    if (this.mainForm.get('statusF').value == 9) {
      this.licaService
          .setFormulqrStatus(this.mainForm.get('idformulqr').value,9)
          .subscribe(result => {
              this.toasterService.success("", `Успешен запис.`);
      });  
      return;

    } else {
      if (!this.mainForm.valid) {
        let errors = findInvalidControlsRecursive(this.mainForm);
        errors.forEach (e=>{
          let message = getErrorMessage(e,'');
          if (message) 
              this.toasterService.showToast("danger",message);  
        })
        return;
      }
    }
    
    if (this.isDisabled) {
      this.mainForm.enable();
    }  
    
    const item: Formulqr = this.convertToFormulqr(this.mainForm.value);
    this.licaService
        .checkFormulqrUnomer(item.unom)
        .subscribe((result) => {
            if (result>0 && result != this.mainForm.get('idformulqr').value) {
              this.toasterService.showToast("danger","Съществува формуляр с номер: "+item.unom);  
            } else {
              let adres: Address = {
                id: item.lice.idl,
                raionid:  item.lice.admRaion,
                nm: item.lice.nasMqsto,
                kv: item.lice.kvartal,
                jk: item.lice.jk,
                ul: item.lice.ulica,
                nomer: item.lice.nomer,
                blok: item.lice.blok,
                vh: item.lice.vhod,
                etaj: item.lice.etaj,
                ap: item.lice.apart,
                opos: ''
             }
             
             this.licaService
             .checkFormulqrAdres(adres)
             .subscribe((result) => {      
                 if (result > 0) {
                  this.dialogService
                    .open(AddressEditDialogComponent
                          , { hasBackdrop: true,
                              closeOnBackdropClick: true,
                              hasScroll: false,
                              context: {
                                id: result,
                              },
                          })
                    .onClose.subscribe(x => {
                        if (x) false;
                    });                      
                 } else if (result < 0) {
                   this.toasterService.showToast("danger","Дублиране на адрес с aдрес, участващ в друг проект!");  
                 } else {
                    let rez = this.checkControls(item);
                    if (rez >= 0) {
                      if (rez > 0) {
                        Swal.fire({
                          title:'<h5 style="padding-left:0px;color:#000000">Моля изберете!</h5> ',
                          html: '<a style="color:#000000" >Запис или корекция на формуляра?</a>',
                          icon: 'warning',
                          showCancelButton: true,
                          confirmButtonColor: '#3085d6',
                          cancelButtonColor: '#d33',
                          confirmButtonText: 'Запис',
                          cancelButtonText: 'Коригиране',
                        }).then((result) => {
                            if (result.isConfirmed) {
                              this.saveFormular (item)
                            }
                        });
                      } else {
                        this.saveFormular (item)
                      }
                    }
                  }
                });   
            }    
    });  


    if (this.isDisabled) {
      this.mainForm.disable()
      this.mainForm.get('statusF').enable();  
      this.mainForm.get('comentar').enable(); 
    }  
  }
  
  checkControls(item: Formulqr): number {
    let rez:number = 0;

    if (item.v23 == 1 && item.v24==0) {
      this.toasterService.showToast("warning","Грешен въпрос 24");  
      rez = 1;
    }       
    if (item.v25 == 1 && item.v26==0) {
        this.toasterService.showToast("warning","Грешен въпрос 26");  
        rez = 1;
    }   
    if (item.v27 == 1 && item.v28==0) {
        this.toasterService.showToast("warning","Грешен въпрос 28");  
        rez = 1;
    }

    //premahnat e kontrola na uredite
    return rez;
  }

  saveFormular (item: Formulqr) {
    this.click  = !this.click;

    if (item.idformulqr && item.statusF == 2) {
      this.licaService
          .getLiceDogovorStatus(item.lice.idl)
          .subscribe((result) => {
              if (result == 2) {
                this.toasterService.showToast("warning"
                ,`ВНИМАНИЕ: Уредите от формуляра не са прехвърлени към договора, 
                защото договорът е Сключен!.`);
        }
      });
    }

    let observable = new Observable<Formulqr>();
    observable = item.idformulqr
      ? this.licaService.setFormulqr(item)
      : this.licaService.addFormulqr(item);

    observable.pipe(takeUntil(this.unsubscribe$)).subscribe(
      () => {
        this.handleSuccessResponse();
      },
      (err) => {
        this.handleWrongResponse();  
      }
    );          

    this.click  = !this.click;
  }
    
  convertToFormulqr(value: any): Formulqr {
    const formulqr: Formulqr = value;
    
    formulqr.lice.faza = formulqr.faza;
    formulqr.lice.vidLice = this._VID;
    formulqr.lice.statusL = (formulqr.lice.statusL==null || formulqr.lice.statusL==0 ? 1 : formulqr.lice.statusL);
    formulqr.statusF = (formulqr.statusF==0 ? 1 : formulqr.statusF);
 
    return formulqr;
  }

  statusChange($event) {
    if ($event > 1) {
      this.mainForm.disable();
      this.isDisabled = true;
    } else {
      this.mainForm.enable();  
      this.isDisabled = false;
    }
    this.mainForm.get('statusF').enable();  
    this.mainForm.get('comentar').enable(); 
    this.mainForm.get('lice').get('statusL').enable();  
  }

  canDeleteFormulqr()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);
      if (role.toLowerCase() === ROLES.ADMIN)
          this.canDelete = true;
      else
          this.canDelete = false;
    });
  }
  
  back() {
    if (this.router.url === this.routingState.getPreviousUrl())
       this.router.navigate(['pages/register/register/'+this._VID]);
    else
      this.router.navigateByUrl(this.routingState.getPreviousUrl());
  }
    
  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

}
