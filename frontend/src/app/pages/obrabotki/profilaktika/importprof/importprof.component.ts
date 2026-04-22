import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Workbook } from 'exceljs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs/internal/Subject';
import moment from 'moment';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { Screens } from '../../../../@core/tools/screens';
import { ObrabotkaData, ProfOrderItem } from '../../../../@core/interfaces/common/obrabotki';
import { Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

const DATE_FORMAT = 'DD.MM.YYYY';

interface ImportData {
  nomer: string,
  data: string,
  korespondent: string,
  otnosno: string,
}

interface ImportProfilaktika {
  chksum: string,
  otchetdata: string,
  note: string,
  status_pf: number,
  status_txtpf: string,
}


@Component({
  selector: 'ngx-import-profilaktika',
  templateUrl: './importprof.component.html',
  styleUrls: ['./importprof.component.scss'],  
})
export class ImportProfiComponent implements OnInit {
  dataImport: ImportData[] = new Array();
  click: boolean = false;
  page = 1;
  pageSize = 15;
  proforderitems: ProfOrderItem[] = new Array();
  dataImportGrafik: ImportProfilaktika[] = new Array();
  idprofilaktika: number = 0;
  eik: string = ''

  protected readonly unsubscribe$ = new Subject<void>();

  constructor(
    private router: Router,
    private excelService: ExportExcelService,
    private orderService: ObrabotkaData,
    private spinner: NgxSpinnerService,
    private toasterService: CustomToastrService,
  ) { 
    this.pageSize = Screens.setPageSize(window.innerHeight);  
  }

  ngOnInit(): void {
  }
 
  back() {
    this.router.navigate(['pages'])
  }


  async importexcel(event) {
    const md5 = require("md5")
    const target: DataTransfer = <DataTransfer>(event.target);
  
    if (target.files.length === 0) {
      this.toasterService.showToast("danger",'Не е избран файл!');
      return;
    }

    if (target.files.length !== 1) {
      this.toasterService.showToast("danger",'Избрани са повече от един файл!');
      return;
    }
    
    const lcfilename = target.files[0];
    const workbook = new Workbook();
    const blob = new Blob([lcfilename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);
    const worksheet = workbook.getWorksheet(1);

    //find idprofilaktika
    let lcx = '0';
    worksheet.eachRow(function (row, rowNumber) {
      if (rowNumber == 12) {
          lcx = row.getCell('O').value.toString();        
      }  
    });
    this.idprofilaktika =  Number(lcx);

    if (this.idprofilaktika > 0) {      
      this.spinner.show();  

      await this.orderService.getProfOrderById(this.idprofilaktika)
                    .toPromise()
                    .then ((res) => { // Success
                        this.proforderitems = res;
                    })        
  
      let rez = await this.checkImportProfilaktika(lcfilename);
      if ( rez == 0) {
        
        this.dataImportGrafik.forEach(x=> {    
            let indx = this.proforderitems
                            .findIndex (t=> md5(String(t.idporychkamain)+'|'+
                                                String(t.idporychka)+'|'+
                                                String(t.nomer)) == x.chksum); 

            if (indx > -1) {
              let item = this.proforderitems[indx];
              item.otchdata =  (x.otchetdata.length>0 ? moment.utc(x.otchetdata,DATE_FORMAT).toDate(): null);
              item.note = x.note;
              item.status_pf = x.status_pf;
              item.status_pfstr = x.status_txtpf;
              item.changed = 1;
              this.proforderitems[indx] = item;
            }  
        });           
        this.spinner.hide();

      } else if ( rez == -1) {
        this.spinner.hide();
        this.toasterService.danger('', `Грешнен БУЛСТАТ.`);

      } else {
        this.spinner.hide();
        this.toasterService.danger('', `Грешни данни! Проверете протокола.`);
      }


    } else {
      this.toasterService.danger('', `Грешнен файл.`);
    }
  };
  
 
  async checkImportProfilaktika(prmfilename: any) {
    const md5 = require("md5")
    let dataImportGrafik = new Array();

    const workbook = new Workbook();
    const blob = new Blob([prmfilename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);

    const worksheet = workbook.getWorksheet(1);

    let dataForExcel = [];  
    let counters = [
        0,    //all records
        0,    //correct
        0,    //wrong
        0,    //doubled
        0,    //bez otchet
        0,    //greshna data       
    ];

    let proforderitems = this.proforderitems;
      worksheet.eachRow(function (row, rowNumber) {
        if (rowNumber > 15) {
          let obj = {
            nomer: row.getCell('B').value ,
            unom: row.getCell('C').value ,
            ime: row.getCell('G').value,
            ured: row.getCell('E').value,
            status: '',
          }      

          let chksum  =  (row.getCell('A').value ? String(row.getCell('A').value) : '');
          
          if (chksum.length>0 && chksum.indexOf('Файлът') == -1) {                     
            counters [0]++;

            let indx = proforderitems
                  .findIndex (t=> md5(String(t.idporychkamain)+'|'+
                                      String(t.idporychka)+'|'+
                                      String(t.nomer)) == chksum); 

            if (indx > -1) {
                let lstatus = row.getCell('K').value ? row.getCell('K').value.toString(): '0';
                let item = proforderitems[indx];

                let lotchetdata = moment(row.getCell('J').value as Date).format(DATE_FORMAT);

                if (lstatus.substring(0,1) === '0' && lotchetdata.indexOf('Invalid') > -1) {
                    obj.status = 'Данни без отчет';    
                    counters [4]++;
                } else if (lstatus.substring(0,1) === '2' && lotchetdata.indexOf('Invalid') > -1) {
                    obj.status = 'Невалидна дата';  
                    counters [5]++;
                } else if (lstatus.substring(0,1) === '8' && lotchetdata.indexOf('Invalid') == -1) {
                    obj.status = 'Грешен статус';  
                    counters [2]++;
                } else if (lstatus.substring(0,1) === String(item.status_pf)) {
                    counters [3]++;
                    obj.status = 'Дублиран запис';    
                } else {
                  counters [1]++;
                  obj.status = 'За регистрация';

                  let lnote   = row.getCell('M').value ? row.getCell('M').value.toString() : '';

                  let d: ImportProfilaktika = {
                    chksum: chksum,
                    otchetdata: (lotchetdata.indexOf('Invalid') > -1 ? '' : lotchetdata),
                    note: lnote,
                    status_pf: Number(lstatus.substring(0,1)),
                    status_txtpf: lstatus.substring(2),
                  }      

                  dataImportGrafik.push(d);
                }
            } else {
              counters [2]++;
              obj.status = 'Невалиден идентификатор'    
            }
            
            if (obj.status.length > 0) {
              dataForExcel.push(Object.values(obj))      
            }  
          }    
        }  
      });


      //add summary counters
      let obj = {
        raion: '',
        unom: '' ,
        ime: 'За регистрация',
        status: counters [1],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        raion: '',
        unom: '' ,
        ime: 'Грешен статус',
        status: counters [2],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        raion: '',
        unom: '' ,
        ime: 'Без отчет',
        status: counters [4],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        raion: '',
        unom: '' ,
        ime: 'Грешна дата',
        status: counters [5],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        raion: '',
        unom: '' ,
        ime: 'Дублирани записи',
        status: counters [3],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        raion: '',
        unom: '' ,
        ime: 'Всичко',
        status: counters [0],
      }      
      dataForExcel.push(Object.values(obj))      

      let reportData = {
        title: 'Резултат от обработката на профилактика',
        sheet: 'Справка',
        colsizes: [0,5,15,35,50],
        header: ['№','№ ОПОС','Имена','Уред', 'Резултат'],
        data: dataForExcel,
        fname: this.getFileNameWithExt(prmfilename),
        dogovor: '',
        filename: this.getFileNameWithExt(prmfilename) + '_' + 'РезултатГМ_',
      };
      
      this.excelService.exportExcel(reportData);  
      this.dataImportGrafik = dataImportGrafik;        
      return counters [2];      
  }

  async save() {
    let hasError = false;
    this.spinner.show();  

    this.click  = !this.click;

    for (const item of this.proforderitems) {          
      if (item.changed==1) {                      
        let id = item.id;
        let otchdata = moment(item.otchdata).format(DATE_FORMAT);
        let note = item.note
        let status_pf = item.status_pf;

        const responce = await this.orderService.setMonProfilaktika(
                                          id, 
                                          (otchdata.indexOf('Invalid') > -1 ? '' : otchdata), 
                                          note, 
                                          status_pf, 
                                          this.idprofilaktika)
                                        .toPromise();
      }
    };

    this.spinner.hide();  
    this.click  = !this.click;    

    if (hasError)
      this.handleWrongResponse();
    else  
      this.handleSuccessResponse();
  }

  handleSuccessResponse() {
    this.toasterService.success("", `Успешен запис.`);
  }

  handleWrongResponse() {
    this.toasterService.danger("", `Грешка при запис!`);
  }

  getFileNameWithExt(event) {
    const name = event.name;
    const lastDot = name.lastIndexOf('.');
    const fileName = name.substring(0, lastDot);
    return fileName;    
  }
}


