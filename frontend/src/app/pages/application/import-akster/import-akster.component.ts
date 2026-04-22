import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Workbook } from 'exceljs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs/internal/Observable';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { Subject } from 'rxjs/internal/Subject';
import moment from 'moment';
import Swal from 'sweetalert2';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { LiceData} from '../../../@core/interfaces/common/lica';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';

interface ImportData {
  nomer: string,
  data: string,
  korespondent: string,
  otnosno: string,
}

@Component({
  selector: 'ngx-import-akster',
  templateUrl: './import-akster.component.html',
  styleUrls: ['./import-akster.component.scss'],  
})
export class ImportAksterComponent implements OnInit {
  dataImport: ImportData[] = new Array();
  click: boolean = false;
  page = 1;
  pageSize = 15;

  protected readonly unsubscribe$ = new Subject<void>();

  constructor(
    private router: Router,
    private excelService: ExportExcelService,
    private licaService: LiceData,
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
    const DATE_FORMAT_IN  = 'D.M.YYYY'; 
    const DATE_FORMAT_OUT = 'DD.MM.YYYY'; 
    let dataImport: ImportData[] = new Array();

    const workbook = new Workbook();
    const blob = new Blob([filename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);

    const worksheet = workbook.getWorksheet(1);

    worksheet.eachRow(function (row, rowNumber) {
      if (rowNumber > 1) {
          let d = row.getCell('B').value.toString();
          if (d.indexOf("г.") > -1)
              d = d.slice(0,d.indexOf("г.")-1);

          if (d.length < 10)    
              d = moment(moment(d,DATE_FORMAT_IN).toDate()).format(DATE_FORMAT_OUT) ;

          let obj: ImportData = {
            nomer: (row.getCell('A').value ? row.getCell('A').value.toString():''),
            data: d,
            korespondent: (row.getCell('C').value ? row.getCell('C').value.toString(): ''),
            otnosno: (row.getCell('D').value ? row.getCell('D').value.toString().trim():''),
          };

          dataImport.push(obj)      
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
        0,    // nqma OPOS
        0,    // greshen format
        0,    // без dogovor
        0,    // razlichen reg.nomer
      ];

      for await (const e of this.dataImport) {
          counters[0]++;

          let obj = {
            nomer: e.nomer,
            data: e.data ,
            otnosno: e.otnosno,
            status: '',
          }      

          let result = await this.licaService
              .updOposDogovorNomer(e.nomer, e.data, e.otnosno)
              .toPromise();

          if (result == 0) {      
            counters [1]++;           
          } else {
            counters [2]++;           
            if (result == -1) {
              obj.status = 'Няма ОПОС';    
              counters [3]++;           
            } else if  (result == -2) {
              obj.status = 'Грешен формат';    
              counters [4]++;           
            } else if  (result == -3) {
              obj.status = 'Няма договор';    
              counters [5]++;          
            } else if  (result == -4) {
              obj.status = 'Различни рег. номера';    
              counters [6]++;          
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
        ime: 'Грешни, в.т.ч.',
        status: counters [2],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Грешен формат',
        status: counters [4],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Няма ОПОС',
        status: counters [3],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Няма договор',
        status: counters [5],
      }      
      dataForExcel.push(Object.values(obj))      

      obj = {
        ime: 'Различни рег. номера ',
        status: counters [6],
      }      
      dataForExcel.push(Object.values(obj))      

      let reportData = {
        title: 'Резултат от обработката на файл от Акстер',
        sheet: 'Справка',
        colsizes: [0,30,30,20,30],
        header: ['Номер','Дата на Регистрация','Относно','Резултат'],
        data: dataForExcel,
        filename: 'Обработка-Акстър',
      };

      this.excelService.exportExcel(reportData);  

      this.spinner.hide();  
      this.toasterService.success("", `Успешен запис. Проверете протокола.`);
    }
 
}


