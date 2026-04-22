import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';
import * as logo from './logo.js';

const DATE_TIME_FORMAT = 'DD-MM-YYYY HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class ExportSpravki11Service {

  constructor() { }

  exportSpravka(excelData, tip) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    let subtitle = [
      '','ПОРЪЧКА','ГРАФИК','ОТЧЕТ','КАНДИДАТ',
    ];

    let header = [
      'Поръчка №','Фирма-изпълнител','Договор','ОПОС','Код',
      'Уред','Брой','Дата','От час', 'До час','Статус','Заб.',
      'Дата','Статус','Заб.', 'Име', 'Адрес','Модел','Сериен №',
      'Гар.карта №', 'Дата на Гар.карта', 
      'Дата на Приемо-пред. протокол'
    ];

    let filename = excelData.filename;
    let colsizes = [0,10,20,20,20,7,30,7,10,7,7,10,20,10,10,20,30,40, 20,20,15,15,15]
    
    if (tip == 2) {
      filename = 'Справка 12';

      header = [
        'Поръчка №','Фирма-изпълнител','Договор','ОПОС','Код',
        'Уред','Брой','Дата','Статус','Заб.',
        'Дата','Статус','Заб.', 'Име', 'Адрес'
      ];
  
      colsizes = [0,10,20,20,20,7,30,7,10,10,20,10,10,20,30,40]
    }


    const title = excelData.title;
    const sheet = excelData.sheet;
    const data = excelData.data;

    //Create a workbook with a worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col =1; col <  colsizes.length; col++) {
      worksheet.getColumn(col).width = colsizes[col];
    }
    
    //Add Row and formatting
    worksheet.mergeCells('A1', 'Q1');
    let titleRow = worksheet.getCell('A1');
    titleRow.value = title
    titleRow.font = {
      name: 'Calibri',
      size: 16,
      bold: true,
      color: { argb: '0085A3' }
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }
 
    //Blank Row 
    worksheet.addRow([]);
    let row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)
              +' '+(excelData.filter?excelData.filter:'')]);
    
    row1.alignment = { vertical: 'middle', horizontal: 'left' }
    worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header.length).toUpperCase()}${row1.number}`);
    
    //Adding Header Row
    if (tip == 2) {
        worksheet.getCell('A4').value = subtitle[0];

        worksheet.mergeCells('B4', 'G4');
        worksheet.getCell('B4').value = subtitle[1];

        worksheet.mergeCells('H4', 'J4');
        worksheet.getCell('J4').value = subtitle[2];

        worksheet.mergeCells('K4', 'M4');
        worksheet.getCell('K4').value = subtitle[3];

        worksheet.mergeCells('N4', 'O4');
        worksheet.getCell('N4').value = subtitle[4];
    } else {  
        worksheet.getCell('A4').value = subtitle[0];

        worksheet.mergeCells('B4', 'G4');
        worksheet.getCell('B4').value = subtitle[1];

        worksheet.mergeCells('H4', 'L4');
        worksheet.getCell('H4').value = subtitle[2];

        worksheet.mergeCells('M4', 'O4');
        worksheet.getCell('M4').value = subtitle[3];

        worksheet.mergeCells('P4', 'Q4');
        worksheet.getCell('P4').value = subtitle[4];
    }

    let range = {start: {row: 4, col: 1}, end: {row: 4, col:  colsizes.length-1}};
      for (let col = range.start.col; col <= range.end.col; col++) {    
        let s = worksheet.getCell(4, col)
        this.createCellHeader(s,'');        
      }

    //Adding Header Row
    let row = worksheet.addRow(header);
    row.height = (excelData.headersize ? excelData.headersize : 25);

    for (let i = 1; i <= header.length; i++) {    
      let s = row.getCell(i);
      this.createCellHeader(s,header[i-1]);        
    };


    // Adding Data with Conditional Formatting
    data.forEach(d => {
      let row = worksheet.addRow(d);
      row.height = 25;

      for (let col = 1; col < colsizes.length; col++) {    
        let s = row.getCell(col);
        s.border = {
          top:    { style: 'thin' }, 
          left:   { style: 'thin' }, 
          bottom: { style: 'thin' }, 
          right:  { style: 'thin' } 
        };
     
        s.font   = { 
          name: 'Calibri', 
          bold: false,
          size: 10
        }

        s.alignment = {
          vertical: 'top',  
          wrapText: true
        }
      };
    });
    
    worksheet.addRow([]);

    //Footer Row
    let footerRow = worksheet.addRow(['Файлът е генериран от Столична община на ' +  moment(new Date()).format(DATE_TIME_FORMAT)]);
    footerRow.getCell(1).fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: { argb: 'FFB050' }
    };

    //Merge Cells
    worksheet.mergeCells(`A${footerRow.number}:${alphabet.charAt(header.length).toUpperCase()}${footerRow.number}`);

    //Generate & Save Excel File
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, filename + '.xlsx');
    })
  }


  createCellHeader (s: any, celltxt: string) {
    if (celltxt)
      s.value = celltxt;

    s.border = {
      top:    { style: 'thin' }, 
      left:   { style: 'thin' }, 
      bottom: { style: 'thin' }, 
      right:  { style: 'thin' } 
    };
    
    s.font   = {
      name: 'Calibri', 
      bold: true, 
      size: 10, 
      color: { argb: 'ffffff' }
    }
    
    s.alignment = {
        vertical: 'top', 
        horizontal: 'center',  
        wrapText: true
    }

    s.fill   = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: '0085A3' },
        bgColor: { argb: '' }
    }
  }
}
