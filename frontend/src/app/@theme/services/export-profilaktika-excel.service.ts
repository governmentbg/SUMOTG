import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';
//import * as logo from './logo.js';
import * as logo1 from './logo1.js';
import * as logo2 from './logo2.js';
import * as logo3 from './logo3.js';
import { DocumentsData, FileToUpload } from '../../@core/interfaces/common/documents';

const DATE_TIME_FORMAT = 'DD-MM-YYYY HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class ExportProfilaktikaExcelService {

  constructor(
    private documentService: DocumentsData,
  ) { }

  exportProfilaktila(excelData) {
    //Title, Header & Data
      let subtitle = [
        'Служебен','ИНФОРМАТИВНИ ДАННИ','ПРОФИЛАКТИКА',					
      ];
  
      let header = [
        '','№',
        'ОПОС','Код Уред','Уред','Брой','ИМЕНА','Адрес',
        'Планова дата','Отчетна дата','Статус','Модел',	'Договор с изпълнител',
        'Забележка'
      ];
  
      const colsizes = [
        0,0,
        5,15,10,20,15,20,20,
        10,10,10,30,20,30
      ]
  
      const title_row1 = `изпълнител: ${excelData.firma}`;
      const title_row2 = `Списък на уреди за профилактика - график`;
      // const title_row3 = `с предмет: "Доставка, монтаж, въвеждане в експлоатация и гаранционно обслужване на отоплителни устройства `;
      // const title_row4 = `за битово отопление на пелети и радиатори.`;
      const title_row3 = ``;
      const title_row4 = ``;
  
      const foother_1  = 'Документът е изготвен в изпълнение на проект № BG16M1ОP002-5.003-0001 „Подобряване качеството на атмосферния въздух ';
      const foother_2  = 'в Столична община чрез подмяна на отоплителни устройства на твърдо гориво с екологични алтернативи”,';
      const foother_3  = 'финансиран по Оперативна програма „Околна среда 2014-2020г.“, съфинансирана от Европейския съюз ';
      const foother_4  = 'чрез Кохезионния фонд и от националния бюджет на Република България ';
      const sheet = 'Профилактика';
      const data = excelData.data;
      const filename = excelData.filename;
      const firmaeik = excelData.eik;
      const idprofilaktika = excelData.idprofilaktika;
      
      //Create a workbook with a worksheet
      let workbook = new Workbook();
      let worksheet = workbook.addWorksheet(sheet);
  
      //set columns size
      for (let col =1; col <  colsizes.length; col++) {
        worksheet.getColumn(col).width = colsizes[col];
      }
  
      //Add Image
      let myLogoImage = workbook.addImage({
        base64: logo1.logo1,
        extension: 'png',
      });
      worksheet.mergeCells('E1:E6');
      worksheet.addImage(myLogoImage, 'E1:E6');
      
      myLogoImage = workbook.addImage({
        base64: logo2.logo2,
        extension: 'png',
      });
      worksheet.mergeCells('G1:G6');
      worksheet.addImage(myLogoImage, 'G1:G6');
  
      myLogoImage = workbook.addImage({
        base64: logo3.logo3,
        extension: 'png',
      });
      worksheet.mergeCells('I1:J6');
      worksheet.addImage(myLogoImage, 'I1:J6');
  
      //Blank Row 
      worksheet.addRow([]);
    
      worksheet.mergeCells('E9', 'J9');
      let titleRow = worksheet.getCell('F9');
      titleRow.value = title_row2
      titleRow.font = {
        name: 'Calibri',
        size: 14,
        bold: true
      }
      titleRow.alignment = { vertical: 'middle', horizontal: 'center' }
  
      worksheet.mergeCells('F10', 'J10');
      titleRow = worksheet.getCell('F10');
      titleRow.value = title_row3
      titleRow.font = {
        name: 'Calibri',
        size: 11,
      }
      titleRow.alignment = { vertical: 'middle', horizontal: 'left' }
    
      //Blank Row 
      worksheet.addRow([]);
      worksheet.mergeCells(`A11:J11`);
      worksheet.getCell('A11').value = `${title_row1}`;
  
      //bulstat
      worksheet.addRow([]);
      worksheet.mergeCells(`A12:J12`);
      worksheet.getCell('A12').value = `БУЛСТАТ: ${firmaeik}`;
      worksheet.getCell('O12').value = `${idprofilaktika}`;
      
      let c = worksheet.getColumn(15);
      c.hidden = true;

      //Adding Subtitle Row
      worksheet.addRow([]);
      worksheet.getCell('A13').value = subtitle[0];
  
      worksheet.mergeCells('B13', 'G13');
      worksheet.getCell('B13').value = subtitle[1];
  
      worksheet.mergeCells('I13', 'N13');
      worksheet.getCell('I13').value = subtitle[2];
  
      //Adding Header Row
      let row = worksheet.addRow(header);
      row.height = 30;

      //system range
      let range = {start: {row: 13, col: 1}, end: {row: 15, col: 1}};
      for (let row = range.start.row; row <= range.end.row; row++) {
        for (let col = range.start.col; col <= range.end.col; col++) {    
            let c = worksheet.getColumn(col);
            c.hidden = true;

            let s = worksheet.getCell(row, col)
            s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
            s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'ffc000' },bgColor: { argb: '' }}
            s.font   = {name: 'Calibri', bold: true,size: 10}
            s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
        };
      }
  
      //Informativni danni range
      range = {start: {row: 13, col: 2}, end: {row: 15, col: 7}};
      for (let row = range.start.row; row <= range.end.row; row++) {
        for (let col = range.start.col; col <= range.end.col; col++) {    
          let s = worksheet.getCell(row, col)
          s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
          s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'eeeeee' },bgColor: { argb: '' }}
          s.font   = {name: 'Calibri', bold: true,size: 10}
          s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
        };
      }
  
      //profilaktika range
      range = {start: {row: 13, col: 8}, end: {row: 15, col: 14}};
      for (let row = range.start.row; row <= range.end.row; row++) {
        for (let col = range.start.col; col <= range.end.col; col++) {    
          let s = worksheet.getCell(row, col)
          s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
          s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'ffff00' },bgColor: { argb: '' }}
          s.font   = {name: 'Calibri', bold: true,size: 10}
          s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
        };
      }
      
      let cntcol = 0;
      range = {start: {row: 15, col: 1}, end: {row: 15, col: colsizes.length-1}};
      for (let col = range.start.col; col <= range.end.col; col++) {
        worksheet.getCell(range.start.row, col).value = cntcol;
        cntcol++;
      }
  
      let datarow = 16
  
      // Adding Data with Conditional Formatting
      data.forEach(d => {
        let row = worksheet.addRow(d);
        row.height = 40;
  
        for (let col = 1; col < colsizes.length; col++) {    
          let s = worksheet.getCell(row.number,col)
          s.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
          if (col == 1) {
            s.font   = { 
              name: 'Calibri', 
              bold: false, 
              size: 12, 
              color: { argb: 'cc0000' }
            }
            s.alignment = {vertical: 'top',  horizontal: 'center'}
          } else {
            s.font   = { name: 'Calibri', bold: false,size: 10}
            s.alignment = {vertical: 'top',  wrapText: true}
          }
        };
      });
  
      for( let i =datarow; i < data.length+datarow; i++) {
        //status pf
        worksheet.getCell(`K${i}`).dataValidation = {
          type: 'list',
          allowBlank: true,
          formulae: ['"2-Изпълнена, 8-Отказана"'],
          showInputMessage: true,
          showErrorMessage: true,
          errorStyle: 'stop',
          errorTitle: 'Избор на статус',
          error: 'Трябва да изберете позиция от списъка'
        };
  
        //planirana za
        worksheet.getCell(`I${i}`).numFmt = 'dd.mm.yyyy'; 
  
        //otchetena na
        worksheet.getCell(`J${i}`).numFmt = 'dd.mm.yyyy'; 
      }
  
      worksheet.addRow([]);
  
      //Footer Rows
      let footerRow = worksheet.addRow([]);
      worksheet.mergeCells(`B${footerRow.number}:L${footerRow.number}`);
      footerRow.getCell(5).value = foother_1;
  
      footerRow = worksheet.addRow([]);
      worksheet.mergeCells(`B${footerRow.number}:L${footerRow.number}`);
      footerRow.getCell(5).value = foother_2;
  
      footerRow = worksheet.addRow([]);
      worksheet.mergeCells(`B${footerRow.number}:L${footerRow.number}`);
      footerRow.getCell(5).value = foother_3;
  
      footerRow = worksheet.addRow([]);
      worksheet.mergeCells(`B${footerRow.number}:L${footerRow.number}`);
      footerRow.getCell(5).value = foother_4;
  
      footerRow = worksheet.addRow([]);
  
      footerRow = worksheet.addRow([]);
      worksheet.mergeCells(`A${footerRow.number}:I${footerRow.number}`);
      footerRow.getCell(1).value = 'Файлът е генериран от Столична община на ' +  moment(new Date()).format(DATE_TIME_FORMAT);
      footerRow.getCell(1).fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'FFB050' }
      };
  
      //Generate & Save Excel File
      workbook.xlsx.writeBuffer().then((data) => {
        let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        fs.saveAs(blob, filename + '.xlsx');
        this.readAndUploadFile (blob, filename + '.xlsx');

      })
    }

    private readAndUploadFile(blob: Blob, filename: string) {
      let file = new FileToUpload();    
      file.fileName = filename;
  
      file.idDog = 0;
      file.docType = 0;
      file.fileSize = 0;
      file.fileType = '';
      file.description = '';  

      let reader = new FileReader();  
      reader.onload = () => {
          file.fileAsBase64 = reader.result.toString();          
          this.documentService.putFile(file).subscribe(resp => { 
          });    
      }
      reader.readAsDataURL(blob);
    }

}
