import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { FirmaData } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { Faktura, ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { findInvalidControlsRecursive, getFakturaErrorMessage } from '../../../../@core/tools/functions';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { ObrabotkiForms } from '../../forms/monorder.edit.form';

@Component({
  selector: 'ngx-demfakturi-edit',
  templateUrl: './demfakturi-edit.component.html',
  styleUrls: ['./demfakturi-edit.component.scss']
})
export class DemfakturiEditComponent implements OnInit {

  _VID: number = 1;
  isDisabled = false;
  mainForm: FormGroup;
  click: boolean = false;

  vliststatus: ViewNom[];
  vmonfirmi: ViewNom[];
  vmonfirmidogovor: ViewNom[];
  vdoguredi: ViewNom[];

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
  }

  loadLists() {
    this.firmiService
        .getFirmi(2)
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
          this.loadDeMonDogovorFirma (result.idfirma);

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
              vidfirma:2,
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

  loadDeMonDogovorFirma (idfirma: number) {
    this.firmiService.loadDeMonDogovorFirma(idfirma).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));

      if (this.vmonfirmidogovor.length > 0) {
        this.mainForm
            .get('iddogovorfirma')
            .patchValue(String(this.vmonfirmidogovor[0].id), {emitEvent: true});

        this.loadDeMonDogovorUredi(this.vmonfirmidogovor[0].id)            
      }
    });  
  }

  loadDeMonDogovorUredi (iddogovor: number) {
    this.firmiService
        .loadDeMonDogovorUredi(iddogovor)
        .subscribe((result) => {
            this.vdoguredi =result.map(item => new ViewNom().convertDogUred(item));
    });  
  }

  onFirmItemSelected(firma: ViewNom) {
    this.loadDeMonDogovorFirma (firma.id);
  }

  onDogovorItemSelected(dogovorfirma: ViewNom) {
    this.loadDeMonDogovorUredi (dogovorfirma.id);
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

  importexcel(){

  }

  back() {
    this.router.navigateByUrl('pages/obrabotki/demfakturi');
  }
}
