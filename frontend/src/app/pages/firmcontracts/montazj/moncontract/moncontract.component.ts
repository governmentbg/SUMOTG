import { Component, DoCheck, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService } from '@nebular/theme';
import moment from 'moment';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/internal/Subject';
import { takeUntil } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { RoutingState } from '../../../../@core/backend/common/services/RoutingState.service';
import { DocumentsData, Dokument } from '../../../../@core/interfaces/common/documents';
import { FirmaData, FirmaDogovor, Izpylnitel } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { findInvalidControlsRecursive, getDogovorErrorMessage } from '../../../../@core/tools/functions';
import { HeaderComponent } from '../../../../@theme/components';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { FileUploadDialogComponent } from '../../../application/components/fileupload-dialog/fileupload-dialog.component';
import { FirmDogovorForm } from '../../firmdogovor.form';

interface ExportOrderItem {
  nrow: number,
  uredname: string,
  broi: number,
  edcena: number,
  total: number,
}

@Component({
  selector: 'ngx-moncontract',
  templateUrl: './moncontract.component.html',
  styleUrls: ['./moncontract.component.scss']
})
export class MonContractComponent implements OnInit, DoCheck  {
  mainForm: FormGroup;
  previousUrl: string = '';
  click: boolean = false;

  uredi: FormArray;
  payments: FormArray;
  frmraioni: FormArray;

  vlistv43:  ViewNom[];
  firma: Izpylnitel;
  vlistpayment: ViewNom[];
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  vliststatus: ViewNom[];
  kid: ViewNom[];
  dokumenti: Dokument[];
  
  idfirma: number = 0;
  name: string = '';
  iddog: number = 0;
  disable: boolean = false;
  firmadogovor: FirmaDogovor;

  protected readonly unsubscribe$ = new Subject<void>();
  minDate: Date;
  maxDate: Date;

  constructor (
    private ete: ExportExcelService,
    private router: Router,
    private route: ActivatedRoute,
    private firmaService: FirmaData,
    private nomenclatureService: NomenclatureData,
    private routingState: RoutingState,
    private toasterService: CustomToastrService,
    private documentService: DocumentsData,
    private dialogService: NbDialogService,
  ) {
    this.route.paramMap.subscribe( params => {
      this.idfirma = Number(params.get('idfirma'));
      this.name = String(params.get('name'));
      this.iddog = Number(params.get('iddog'));
      this.disable = String(params.get('disable'))==='true';       
    });

    this.minDate = new Date(2020,1,1);
    this.maxDate = new Date(2030,12,31);;    
   }

  ngOnInit(): void {
    this.previousUrl = this.routingState.getPreviousUrl()

    this.mainForm = new FirmDogovorForm().create(this.disable);
    this.uredi =  <FormArray>this.mainForm.get('uredi');
    this.frmraioni =  <FormArray>this.mainForm.get('raioni');
    this.payments =  <FormArray>this.mainForm.get('payments');

    this.loadLists();
    this.loadFirmaDogovor();   
    this.loadDocuments();
  }

  loadLists() {
    this.nomenclatureService
      .getNomenStatusi('Status_DF')
      .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
      .getAllNomenUredi(false)
      .subscribe(result => {
        this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item));
    });

    this.nomenclatureService
        .getNomenNsMesta()
        .subscribe(result => {
          this.nasmesta = result.map(item => new ViewNom().convertNomNsMqsto(item));
    });

    this.nomenclatureService
        .getNomenJk()
        .subscribe(result => {
          this.kvartali = result.map(item => new ViewNom().convertNomKvartal(item));
    });

    this.nomenclatureService
        .getNomenRaioni()
        .subscribe(result => {
        this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService
        .getNomenObshti('14')
        .subscribe(result => {
      this.vlistpayment = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenKID()
      .subscribe(result => {
        this.kid = result.map(item => new ViewNom().convertNomKID(item));
    });

  }

  loadFirmaDogovor() {
    this.firmaService
        .getMonDogovor(this.iddog)
        .subscribe(result => {
          this.firmadogovor = result;

          if (result.uredi && result.uredi.length>0) {
            (this.mainForm.get('uredi') as FormArray).removeAt(0);
 
             result.uredi.forEach (t => {
               var ured: FormGroup =  new FirmDogovorForm().createUredItem();
               (this.mainForm.get('uredi') as FormArray).push(ured);
             })
          }

          if (result.raioni && result.raioni.length>0) {
            (this.mainForm.get('raioni') as FormArray).removeAt(0);
 
             result.raioni.forEach (t => {
               var raion: FormGroup =  new FirmDogovorForm().createRaionItem();
               (this.mainForm.get('raioni') as FormArray).push(raion);
             })
          }

          if (result.payments && result.payments.length>0) {
            (this.mainForm.get('payments') as FormArray).removeAt(0);
 
             result.payments.forEach (t => {
               var raion: FormGroup =  new FirmDogovorForm().createPaymentItem();
               (this.mainForm.get('payments') as FormArray).push(raion);
             })
          }
       
          this.mainForm.patchValue(
          {
              iddog: result.iddog,
              faza: result.faza,
              regnom: result.regnom ? result.regnom : '',
              regnomdata: result.regnomdata ? result.regnomdata : null,
              nomdgsudso: result.nomdgsudso ? result.nomdgsudso : '',
              nachalnadata: result.nachalnadata ? result.nachalnadata : null,
              srokgrafic: result.srokgrafic ? result.srokgrafic : 0,
              cenabezdds: result.cenabezdds ? Number(result.cenabezdds).toFixed(2) : Number(0).toFixed(2),
              cenadds: result.cenadds ? Number(result.cenadds).toFixed(2) : Number(0).toFixed(2),
              status_DM: result.status_DM ? String(result.status_DM)  : '1',
              status: result.status ? result.status : 0,
              uredi: result.uredi,
              raioni: result.raioni,
              payments: result.payments,
              firma: result.firma ? {
                idfirma: result.firma.idfirma,
                vidFirma: result.firma.vidFirma ? String(result.firma.vidFirma) : null,
                rolq: result.firma.rolq ? result.firma.rolq : 1,
                eik: result.firma.eik ? result.firma.eik : '',
                ime: result.firma.ime ? result.firma.ime : '',
                adres: result.firma.adres ? result.firma.adres : '',
                manager: result.firma.manager ? result.firma.manager : '',
                mname: result.firma.mname ? result.firma.mname : '',
                email: result.firma.email ? result.firma.email : '',
                telefon: result.firma.telefon ? result.firma.telefon : '',
                postKode: result.firma.postKode ? result.firma.postKode : '',
                status: result.firma.status ? result.firma.status : 1,
                statusDM: result.firma.statusDM ? String(result.firma.statusDM) : '1',
              } : new FirmDogovorForm().createFirmForm(this.disable),              
          }); 
                
          this.onStatusChanged(this.mainForm.get('status_DM').value) 

          if (this.vliststatus) {
            if (this.mainForm.get('status_DM').value == 8) {
              this.vliststatus = this.vliststatus.filter(e => e.id > 7);
            } else if (this.mainForm.get('status_DM').value == 9) {
              this.vliststatus = this.vliststatus.filter(e => e.id == 9);
            } else if (this.mainForm.get('status_DM').value > 1) {
              this.vliststatus = this.vliststatus.filter(e => e.id > 1);
            }             
          }  
        });
  }

  ngDoCheck() {
    (this.mainForm.get('uredi') as FormArray).controls.forEach( t=>{
      t.get('profilaktika').disable();
      t.get('total').disable();
    });
  }

  save() {
    if (!this.mainForm.valid) {
      let errors = findInvalidControlsRecursive(this.mainForm);
      errors.forEach (e=>{
        let message = getDogovorErrorMessage(e);
        if (message) 
            this.toasterService.danger(message,"Грешка!");  
      })
    } else {
      const item: FirmaDogovor = this.convertToDogovor();
      if (this.checkControls(item) == 0) {
        this.click  = !this.click;
        
        let observable = new Observable<number>();
        observable = this.firmaService.setMonDogovor(item)
        
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
    }            
  }
  
  checkControls (item: FirmaDogovor) {
    if (Number((item.cenabezdds*1.2).toFixed(2)) != item.cenadds) {
      this.toasterService.showToast("danger","Грешна цена с ДДС");  
      return -1;
    }
    return 0;
  }

  convertToDogovor(): FirmaDogovor {
    if (this.disable) {
      this.mainForm.enable();
    }  

    const l: FirmaDogovor = this.mainForm.value;
    l.faza = HeaderComponent.faza
    l.status = (l.status===0 ? 1 : l.status);

    l.firma.rolq = 1
    l.firma.status = 1;

    if (l.status < 3) {
      l.uredi.forEach (t => {
        t.statusU = l.status;
      })
    }
    
    if (this.disable) {
      this.mainForm.disable();
      this.mainForm.get('status_DM').enable();  
    }  

    return l;
  }


  onChangeEvent(event: any){
    this.firmaService
    .getFirma(event.target.value)
    .subscribe(result => {
   
      if (result.idfirma > 0) {
          this.mainForm.get('firma').patchValue(
          {
              idfirma: result.idfirma,
              vidFirma: result.vidFirma ? String(result.vidFirma) : null,
              eik: result.eik ? result.eik : '',
              ime: result.ime ? result.ime : '',
              manager: result.manager ? result.manager : '',
              mname: result.mname ? result.mname :'',
              adres: result.adres ? result.adres : '',
              email: result.email ? result.email : '',
              telefon: result.telefon ? result.telefon : '',
              postKode: result.postKode ? result.postKode : '',
              status: result.status ? result.status : 1,
              statusDM: result.statusDM ? String(result.statusDM) : '1',
          });                
        }   
      });    
  }
  
  addItem() {
    let canadd: boolean = true;
    const uredi = (this.mainForm.get('uredi') as FormArray);

    uredi.controls.forEach (t=> {
        if (!t.get('idured').value) {
            canadd = false;
        }
    })

    if (canadd && !this.disable)        
      this.uredi.push(new FirmDogovorForm().createUredItem());
  }

  removeItem(index: number) {
    if (!this.disable)
      this.uredi.removeAt(index);
  }
  
  addRaionItem () {
    let canadd: boolean = true;
    const raioni = (this.mainForm.get('raioni') as FormArray);

    raioni.controls.forEach (t=> {
        if (!t.get('nkod').value) {
            canadd = false;
        }
    })

    if (canadd && !this.disable)        
      this.frmraioni.push(new FirmDogovorForm().createRaionItem());
  }

  removeRaionItem (index: number) {
    if (!this.disable)
      this.frmraioni.removeAt(index);
  }


  loadDocuments() {
    this.documentService
        .getDocuments(this.iddog,2)
        .subscribe(result => {
            this.dokumenti = result;                          
        });
  }

  addDocItem() {
    this.dialogService
        .open(FileUploadDialogComponent
                , { hasBackdrop: true,
                    closeOnBackdropClick: true,
                    hasScroll: false,
                    context: {
                      idDog: this.iddog,
                      typeDoc: 2
                    },
                })
        .onClose.subscribe(x => {
            if (x) this.loadDocuments()
        });                      
  }

  removeDocItem(item: Dokument) {
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

  calculatePrice(item: FormGroup) {
    let rez = item.get('broi').value * item.get('edcena').value;
    item.get('total').setValue (Number(rez).toFixed(2));
  }

  getDogovorNomer() {
      const DATE_FORMAT = 'DD.MM.YYYY'; 
      const data = (this.mainForm.get('regnomdata').value ? 
                    moment(this.mainForm.get('regnomdata').value as Date).format(DATE_FORMAT) : 
                    '');
      if (this.mainForm.get('regnom').value)
        return this.mainForm.get('regnom').value+'/'+data;
      else
        return "";  
  }

  exportexcel(): void {
    let firma = this.mainForm.get('firma');
    let fname = firma ?  firma.get('ime').value : ''
    
    let obj: ExportOrderItem;
    let i = 0;
    let dataForExcel = [];
    let items =  (this.mainForm.get("uredi") as FormArray) 
    items.controls.forEach((form: FormGroup) => {  
      
      obj = {
          nrow: ++i,
          uredname: this.vlistv43.find(e => e.nkod === form.get('idured').value).name,
          broi: form.get('broi').value,
          edcena: form.get('edcena').value,
          total: form.get('total').value,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: 'Задание за монтаж',
      sheet: 'Задание',
      colsizes: [0,5,60,10,10,10],
      header: ['No','Уред за монтаж','Количество','Ед. цена без ДДС','Обща цена без ДДС'],
      data: dataForExcel,
      dogovor: this.getDogovorNomer(),
      fname: fname,
      filename: 'ТЗ_'+ this.mainForm.get('regnom').value 
    }

    this.ete.exportExcel(reportData);  
  }

  onStatusChanged($event) {
    if ($event > 1) {
      this.mainForm.disable();
      this.disable = true;
    } else {
      this.mainForm.enable();  
      this.disable = false;
    }

    this.mainForm.get('status_DM').enable();  
    
    this.payments.controls.forEach (t => {
      (this.mainForm.get('payments') as FormArray).enable();
    })
  }

  addItemPayment() {
    let canadd: boolean = true;
    const payments = (this.mainForm.get('payments') as FormArray);

    payments.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd)        
      this.payments.push(new FirmDogovorForm().createPaymentItem());
  }

  removeItemPayment(index: number) {
      this.payments.removeAt(index);
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

  back() {
    this.router.navigateByUrl('pages/firmcontracts/montazj');
 }

}
