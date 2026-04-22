import { Component, DoCheck, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { FirmaData } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { Faktura, ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { findInvalidControlsRecursive, getFakturaErrorMessage } from '../../../../@core/tools/functions';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { ObrabotkiForms } from '../../forms/monorder.edit.form';
import { Dokument } from '../../../../@core/interfaces/common/documents';
import Swal from 'sweetalert2';
import { NbDialogService } from '@nebular/theme';
import { FileFackturaUploadDialogComponent } from '../fileupload-dialog/fileupload-dialog.component';

@Component({
  selector: 'ngx-monfakturi-edit',
  templateUrl: './monfakturi-edit.component.html',
  styleUrls: ['./monfakturi-edit.component.scss']
})
export class MonfakturiEditComponent implements OnInit, DoCheck {

  _VID: number = 1;
  isDisabled = false;
  mainForm: FormGroup;
  click: boolean = false;

  vliststatus: ViewNom[];
  vmonfirmi: ViewNom[];
  vmonfirmidogovor: ViewNom[];
  vdoguredi: ViewNom[];
  vlistv43:  ViewNom[];
  dokumenti: Dokument[]

  id: number = 0;
  name: string = '';
  idfaktura: number = 0;
  disable: boolean = false;
  faktura: Faktura;
  fakturaitems: FormArray;

  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
    public ete: ExportExcelService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: CustomToastrService,
    private obrabotkiService: ObrabotkaData,
    private firmiService: FirmaData,
    private nomenclatureService: NomenclatureData,
    private dialogService: NbDialogService,
  ) {
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      this.idfaktura = Number(params.get('idfaktura'));
      this.disable = String(params.get('disable'))==='true';       
    });
  }

   ngOnInit(): void {
    this.mainForm = new ObrabotkiForms().createFakturiEdit(1,this.disable);
    this.fakturaitems = <FormArray>this.mainForm.get('fakturaitems');
    this.vdoguredi = [];

    this.loadLists();
    this.loadFaktura();    
    this.loadDocuments();
  }

  loadLists() {
    this.nomenclatureService
      .getNomenUredi()
      .subscribe(result => {
        this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item));
    });
 
    this.firmiService
        .getFirmi(1)
        .subscribe((result) => {
          this.vmonfirmi = result.map(item => new ViewNom().convertFirmi(item));
    });  

    this.nomenclatureService
        .getNomenStatusi('Status_DF')
        .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });
  }


  ngDoCheck() {
    (this.mainForm.get('fakturaitems') as FormArray).controls.forEach( t=>{
      t.get('total').disable();
    });
  }

  loadFaktura() {
    this.obrabotkiService
        .getFaktura(this.idfaktura)
        .subscribe(result => {
          this.faktura = result;
          this.loadMonDogovorFirma (result.idfirma);

          if (result.fakturaitems && result.fakturaitems.length>0) {
            (this.mainForm.get('fakturaitems') as FormArray).removeAt(0);
 
             result.fakturaitems.forEach (t => {
               var ured: FormGroup =  new ObrabotkiForms().createFakturaUredItem();
               (this.mainForm.get('fakturaitems') as FormArray).push(ured);
             })
          }

          this.mainForm.patchValue(
          {
              idfactura: result.idfactura ? result.idfactura : 0,
              vidfirma:1,
              facnomer: result.facnomer ? result.facnomer : '',
              facdata: result.facdata ? result.facdata : null,
              idfirma:result.idfirma ? String(result.idfirma) : null,
              iddogovorfirma:result.iddogovorfirma ? String(result.iddogovorfirma) : null,
              suma: result.suma ? Number(result.suma).toFixed(2) : Number(0).toFixed(2),
              dds: result.dds ?Number(result.dds).toFixed(2) : Number(0).toFixed(2),
              total: result.total ? Number(result.total).toFixed(2) : Number(0).toFixed(2),
              status: result.status ? result.status : 0,
              vidpayment: result.vidpayment ? result.vidpayment : '',
              forperiod: result.forperiod ? result.forperiod : '',
              fakturaitems: result.fakturaitems,
          });                

    });
  }

  loadMonDogovorFirma (idfirma: number) {
    this.firmiService.loadMonDogovorFirma(idfirma).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));

      if (this.vmonfirmidogovor.length > 0) {
        this.mainForm
            .get('iddogovorfirma')
            .patchValue(String(this.vmonfirmidogovor[0].id), {emitEvent: true});

        this.loadMonDogovorUredi(this.vmonfirmidogovor[0].id)            
      }
    });  
  }

  loadMonDogovorUredi (iddogovor: number) {
    this.firmiService
        .loadMonDogovorUredi(iddogovor)
        .subscribe((result) => {
            this.vdoguredi =result.map(item => new ViewNom().convertDogUred(item));
    });  
  }

  onFirmItemSelected(firma: ViewNom) {
    this.loadMonDogovorFirma (firma.id);
  }

  onDogovorItemSelected(dogovorfirma: ViewNom) {
    this.loadMonDogovorUredi (dogovorfirma.id);
  }

  save() {
    if (!this.mainForm.valid) {
      let errors = findInvalidControlsRecursive(this.mainForm);
      errors.forEach (e=>{
        let message = getFakturaErrorMessage(e);
        if (message) 
            this.toasterService.danger(message,"Грешка!");  
      })

    } else {
      const item: Faktura = this.convertToFaktura();
      if (this.checkControls(item) == 0) {
        this.click  = !this.click;
 
        let observable = new Observable<number>();
        observable = this.obrabotkiService.setFaktura(item)
        
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
  
  checkControls (item: Faktura) {
    let sum: number = 0;
    item.fakturaitems.forEach (x=> {
      if (x.id != null) sum = sum + (x.edcena*x.broi);
    })

    //1 ************
    if (sum != Number(item.suma)) {
      this.toasterService.showToast("danger","Грешна сума на цена без ДДС");  
      return -1;
    }

    if (Number((item.suma*0.2).toFixed(2)) != item.dds) {
      this.toasterService.showToast("danger","Грешен размер на данъка");  
      return -1;
    }
    
    if (Number((item.suma*1.2).toFixed(2)) != item.total) {
      this.toasterService.showToast("danger","Грешна сума за плащане");  
      return -1;
    }

    return 0;
  }

  convertToFaktura(): Faktura {
    const l: Faktura = this.mainForm.value;
    l.status = (l.status===0 ? 1 : l.status);
    return l;
  }

  calculatePrice(item: FormGroup) {
    let rez = item.get('broi').value * item.get('edcena').value;
    item.get('total').setValue (Number(rez).toFixed(2));
  }


  addItem() {
      this.fakturaitems.push(new ObrabotkiForms().createFakturaUredItem());    
  }

  removeItem(index: number) {
        this.fakturaitems.removeAt(index);
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

  back() {
    this.router.navigateByUrl('pages/obrabotki/monfakturi');
  }

  loadDocuments() {
    this.obrabotkiService
        .getDocuments(this.idfaktura,0)
        .subscribe(result => {
            this.dokumenti = result;                          
        });
  }

  addDokumentItem() {
    this.dialogService
        .open(FileFackturaUploadDialogComponent
                , { hasBackdrop: true,
                    closeOnBackdropClick: true,
                    hasScroll: false,
                    context: {
                      idDog: this.idfaktura,
                      typeDoc: 0
                    },
                })
        .onClose.subscribe(x => {
            if (x) this.loadDocuments()
        });                      
  }

  removeDokumentItem(item: Dokument) {
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
          this.obrabotkiService
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

    this.obrabotkiService      
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

}
