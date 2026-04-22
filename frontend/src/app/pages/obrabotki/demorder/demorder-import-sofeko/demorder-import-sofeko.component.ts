import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Workbook } from 'exceljs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs/internal/Subject';
import moment from 'moment';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { Screens } from '../../../../@core/tools/screens';
import { ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';

interface ImportData {
  opos: string,
  dogovor: string,
  ime: string,
  adres: string,
  ured: string,
  data: string,
  note: string,
}

@Component({
  selector: 'ngx-demorder-import-sofeko',
  templateUrl: './demorder-import-sofeko.component.html',
  styleUrls: ['./demorder-import-sofeko.component.scss'],  
})
export class DemorderImportSofEkoComponent implements OnInit {
  dataImport: ImportData[] = new Array();
  click: boolean = false;
  page = 1;
  pageSize = 15;

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


  //grafik
  async importexcel(event) {
    const md5 = require("md5")
    const DATE_FORMAT = 'DD.MM.YYYY';           
    const target: DataTransfer = <DataTransfer>(event.target);

    if (target.files.length === 0) {
      this.toasterService.showToast("danger",'Не е избран файл!');
      return;
    }

    if (target.files.length !== 1) {
      this.toasterService.showToast("danger",'Избрани са повече от един файл!');
      return;
    }

    const filename = target.files[0];
    if (await this.checkImport(filename) == 0) {
        //todo
    }  else {
      this.toasterService.danger('', `Грешни данни! Проверете протокола.`);
    }
  };  

  async checkImport(filename: any) {
    const DATE_FORMAT = 'DD.MM.YYYY';
    const TIME_FORMAT = 'HH:mm';

    let dataImport: ImportData[] = new Array();

    const workbook = new Workbook();
    const blob = new Blob([filename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);

    const worksheet = workbook.getWorksheet(1);
    var obj = this;
    let stopread = false;

    worksheet.eachRow(function (row, rowNumber) {
      if (rowNumber == 3) {
         let s =  row.getCell('A').value.toString()

         if (s != 'Договор: СОА21-ДГ55-468/13.07.2021г.') {
            obj.toasterService.showToast("danger",'Това не е отчет!');
            return;
         }
      } else if (rowNumber >= 18) {
          let d = row.getCell('B').value ? row.getCell('B').value.toString() : '';
          if (d.lastIndexOf('-') > -1)
              d = d.slice(0,d.lastIndexOf('-'));

          let obj: ImportData = {
            opos: row.getCell('A').value ? row.getCell('A').value.toString() : '',
            dogovor: d,
            ime: row.getCell('C').value ? row.getCell('C').value.toString() : '',
            adres: row.getCell('D').value ? row.getCell('D').value.toString() : '',
            ured: row.getCell('E').value ? row.getCell('E').value.toString() : '',
            data: moment(row.getCell('F').value as Date).format(DATE_FORMAT) ,
            note: row.getCell('G').value ? row.getCell('G').value.toString() : '',
          };

          if (obj.opos.indexOf('Дейностите са изпълнени') > -1)
              stopread = true;

          if (obj.opos.length > 0 && !stopread)
              dataImport.push(obj);  
      }
    });

    this.dataImport = dataImport;    
    return 0;
  }

  async save() {
      this.spinner.show();  
      this.click  = !this.click;

      let dataForExcel = [];  
      let counters = [
        0,    //all records
        0,    //correct
        0,    //wrong
        0,    // nqma dogowor
        0,    // greshen OPOS
        0,    // Отказан договор
        0,    // nqma porychka
        0,    // ime komentar
      ];

      for await (const e of this.dataImport) {
          counters[0]++;

          let obj = {
            nomer: e.opos,
            dogovor: e.dogovor,
            ime: e.ime,
            data: e.data ,
            status: '',
          }      

          if (e.note.length > 0) {
            counters [2]++;           
            obj.status = 'с коментар ';    
            counters [7]++;           
          } else if (e.dogovor.length == 0) {
            counters [2]++;           
            obj.status = 'Няма Договор';    
            counters [3]++;           
          } else {
            let result = await this.orderService
                .setDemonOtchetUredi(e.opos, e.dogovor, e.data)
                .toPromise();

            if (result == 0) {      
              counters [1]++;           
            } else {
              counters [2]++;           
              if (result == -1) {
                obj.status = 'Няма ОПОС';    
                counters [4]++;           
              } else if  (result == -2) {
                obj.status = 'Няма договор';    
                counters [3]++;           
              } else if  (result == -4) {
                obj.status = 'Отказан договор';    
                counters [5]++;           
              } else if  (result == -3) {
                obj.status = 'Няма поръчка';    
                counters [6]++;        
              }   
            }
          }  

          if (obj.status.length > 0) {
            dataForExcel.push(Object.values(obj))      
          }            
      };

      //add summary counters
      let obj = {
        ime: ' Общо редове',
        status: counters [0],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Верни',
        status: counters [1],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Грешни,  в.т.ч.',
        status: counters [2],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'с коментар ',
        status: counters [7],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Няма ОПОС',
        status: counters [4],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Няма Договор',
        status: counters [3],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Отказан договор',
        status: counters [5],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Няма поръчка',
        status: counters [6],
      }      
      dataForExcel.push(Object.values(obj))      

      let reportData = {
        title: 'Резултат от обработката на отчет за демонтаж',
        sheet: 'Справка',
        colsizes: [0,30,30,40,20,20],
        header: ['ОПОС','Договор','Име по възлагателно писмо','Дата на демонтаж', 'Резултат'],
        data: dataForExcel,
        filename: 'Обработка-Демонтаж',
      };

      this.excelService.exportExcel(reportData);  

      this.spinner.hide();  
      this.toasterService.success("", `Успешен запис. Проверете протокола.`);
    }  
  }


