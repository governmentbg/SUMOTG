import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbStepperComponent } from '@nebular/theme';
import {Observable, Subject} from 'rxjs';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { takeUntil } from 'rxjs/operators';
import { ProfordereditDialogComponent } from './proforderedit-dialog/proforderedit-dialog.component';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';
import { ObrabotkaData, ProfOrderItem } from '../../../@core/interfaces/common/obrabotki';
import { ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { ExportProfilaktikaExcelService } from '../../../@theme/services/export-profilaktika-excel.service';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { FirmaData, Izpylnitel } from '../../../@core/interfaces/common/firmi';

const DATE_FORMAT = 'DD.MM.YYYY';

interface ExportProfItem {
  chksum: string,
  nomer: string,
  opos: string,
  kodured: string,
  imeured: string,
  broi: number,
  ime: string,
  adres: string,
  profdata: string,
  repdata: string,
  status_pf: string,
  model: string,
  dogfirma: string,
  note: string,
  recno: number,
}


@Component({
  selector: 'ngx-proforderedit',
  templateUrl: './proforderedit.component.html',
  styleUrls: ['./proforderedit.component.scss']
})
export class ProfOrderEditComponent implements OnInit {
  @ViewChild("stepper") stepper!: NbStepperComponent;

  filter: FilterA;

  _VID: number = 1; 
  isDisabled = false;
  mainForm: FormGroup;
  click: boolean = false;
  
  disable: boolean = false;
  page = 1;
  pageSize = 15;
  countItems:number = 0;

  proforderitems: ProfOrderItem[] = new Array();
  raioni: ViewNom[];
  firma: Izpylnitel;
  selected: number[] =[];
  idprofilaktika: number;

  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
    private ete: ExportProfilaktikaExcelService,
    private router: Router,
    private route: ActivatedRoute,
    private orderService: ObrabotkaData,
    private toasterService: CustomToastrService,
    private spinner: NgxSpinnerService, 
    private dialogService: NbDialogService,
    private firmiService: FirmaData,
  ) {
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
  }

  ngOnInit(): void {
    this.loadProfOrder();    

    this.firmiService
    .getFirmi(1)
    .subscribe((result) => {
      let vmonfirmi = result;
      this.firma =  vmonfirmi.find(x=> x.idfirma == this.filter.firma); 
    });      
  }


  loadProfOrder () {
    this.orderService.getProfOrder(this.filter).subscribe((result) => { 
      this.proforderitems = result;
      this.countItems = this.proforderitems.length;
    });
  }


  editItem(item: ProfOrderItem) {
    this.dialogService
        .open(ProfordereditDialogComponent
                          , { hasBackdrop: true,
                              closeOnBackdropClick: true,
                              hasScroll: false,
                              context: {
                                item: item, 
                              },
                            })
        .onClose.subscribe(async x => {
            if (x) {
 //             await this.addPorychkaItems(x);
            }
        });                         
  }

  exportexcel(): void {
    let md5 = require("md5")

    let obj: ExportProfItem;
    let dataForExcel = [];

    this.orderService
      .getProfilaktikaNextId()
      .subscribe((result) => {
          this.idprofilaktika = result;

          this.proforderitems.forEach((item: ProfOrderItem) => {          
            if (item.status_pf==0 && !this.selected.includes(item.idporychka)) {    

              let chksum =  md5(String(item.idporychkamain)+ '|'+
              String(item.idporychka)+'|'+
              String(item.nomer)); 

              obj = {
                  chksum:  chksum,
                  nomer: '',
                  opos: item.unom,
                  kodured: item.nkod,
                  imeured: item.ured,
                  broi: item.broi,
                  ime: item.ime,
                  adres: item.adres,
                  profdata: (moment(item.plandata)).format('DD.MM.yyyy'),
                  repdata: null,
                  status_pf: null,
                  model: item.model,
                  dogfirma: item.dogfirma,
                  note: item.note,
                  recno: 0,
              }      

              dataForExcel.push(Object.values(obj))
            }
          })

          dataForExcel = dataForExcel.sort(function(a, b) {
            var oposA = a[2].toUpperCase();
            var oposB = b[2].toUpperCase();

            return (oposA < oposB ? -1 : 1);
          });

          let oldunom = ''; 
          let cntopos = 0;     
          let reccount = 0;
        
          dataForExcel.forEach (x => {
            x[14] = ++reccount;
            if (oldunom != x[2]) {
              oldunom = x[2];
              x[1] = String(++cntopos);
            } else {
              x[1] = ''
            }
          })

          let reportData = {
            data: dataForExcel.map(function(val) {
                              return val.slice(0, -1);
                  }),
            firma: (this.firma.ime == undefined ? "" : this.firma.ime),
            eik: this.firma.eik,
            idprofilaktika: this.idprofilaktika,      
            filename: 'ПМУ_'+this.firma.eik+'_'+moment(new Date()).format('DDMMYYYY_HHmmss')
          }

          this.ete.exportProfilaktila(reportData);  
          
          this.save();
      });
  }

  async save() {
    this.click  = !this.click;
    let hasError = false;
    this.spinner.show();  

    for (const item of this.proforderitems) {          
      if (item.status_pf==0 && !this.selected.includes(item.idporychka)) {    
        let id = item.id;
        let otchdata = '';
        let note = ''
        let status_pf = 1;

        const responce = await this.orderService.setMonProfilaktika(id, 
                                    (otchdata.indexOf('Invalid') > -1 ? '' : otchdata)
                                    , note
                                    , status_pf
                                    ,this.idprofilaktika
                                  ).toPromise();          
      }
    };

    this.loadProfOrder();
    
    this.spinner.hide();  
    this.click  = !this.click;          

    if (hasError)
      this.handleWrongResponse();
    else  
      this.handleSuccessResponse();    
  }

  onItemClick(item: ProfOrderItem) {
    if (this.selected.includes(item.idporychka)){
      this.selected = this.selected.filter(obj => {return obj !== item.idporychka});
    } else
      this.selected.push(item.idporychka)    
  }

  handleSuccessResponse() {
    this.toasterService.success("", `Успешен запис.`);
  }

  handleWrongResponse() {
    this.toasterService.danger("", `Грешка при запис!`);
  }

  back() {
    this.router.navigateByUrl('/pages/register/sprfiltera/12/Профилактика');
  }


}
