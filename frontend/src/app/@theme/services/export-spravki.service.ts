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
export class ExportSpravkiService {

  constructor() { }

  exportSpravka6(excelData, tip) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    let header = [
      'Име на фирма','Договор','Код на уред','Уред','Ед. цена',
      'Включени в Техн. спец.','Включени в поръчка'
      ,'Изключени от поръчка чрез График/Отчет','Остатък за поръчка'
      ,'Монтирани','Остатък за монтаж по договор'
    ];

    let header1 = [
      'Брой','Обща стойност','Брой','Брой','Брой','Брой','Обща стойност','Брой','Обща стойност'
    ];

    let filename = excelData.filename;
    let colsizes = [0,20,15,7,40,7,7,10,10,15,15,7,10,7,10]
    
    if (tip == 2) {
      filename = 'Справка 10';
      colsizes = [0,20,15,7,40,7,7,10,10,15,10,7,10,7,10]

      header = [
        'Име на фирма','Договор','Код на уред','Уред','Средно тегло',
        'Включени в Техн. спец.','Включени в поръчка'
        ,'Изключени от поръчка чрез График/Отчет','Остатък за поръчка'
        ,'Демонтирани','Остатък за демонтаж по договор'
      ];
  
      header1 = [
        'Кг','Брой','Общо тегло','Брой','Брой','Брой','Брой','Общо тегло','Брой','Общо тегло'
      ];  
      
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
    worksheet.mergeCells('A1', 'L1');
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
    let row = worksheet.addRow([]);
    row.height = 40;

    let s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,header[0]);
    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,header[1]);
    s = worksheet.getCell(`C${row.number}`);
    this.createCellHeader(s,header[2]);
    s = worksheet.getCell(`D${row.number}`);
    this.createCellHeader(s,header[3]);
    s = worksheet.getCell(`E${row.number}`);
    this.createCellHeader(s,header[4]);

    worksheet.mergeCells(`F${row.number}`, `G${row.number}`);
    s = worksheet.getCell(`F${row.number}`);
    this.createCellHeader(s,header[5]);

    s = worksheet.getCell(`H${row.number}`);
    this.createCellHeader(s,header[6])
    
    if (tip == 2) {
      s = worksheet.getCell(`I${row.number}`);
      this.createCellHeader(s,header[7])
  
      s = worksheet.getCell(`J${row.number}`);
      this.createCellHeader(s,header[8])

      worksheet.mergeCells(`K${row.number}`, `L${row.number}`);
      s = worksheet.getCell(`K${row.number}`);
      this.createCellHeader(s,header[9])

      worksheet.mergeCells(`M${row.number}`, `N${row.number}`);
      s = worksheet.getCell(`M${row.number}`);
      this.createCellHeader(s,header[10])

    } else {
      s = worksheet.getCell(`I${row.number}`);
      this.createCellHeader(s,header[7])
  
      s = worksheet.getCell(`J${row.number}`);
      this.createCellHeader(s,header[8])

      worksheet.mergeCells(`K${row.number}`, `L${row.number}`);
      s = worksheet.getCell(`K${row.number}`);
      this.createCellHeader(s,header[9])

      worksheet.mergeCells(`M${row.number}`, `N${row.number}`);
      s = worksheet.getCell(`M${row.number}`);
      this.createCellHeader(s,header[10])
    } 

    //Adding Header Row
    row = worksheet.addRow([]);
    row.height = 45;

    if (tip == 2) {
      s = worksheet.getCell(`A${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`B${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`C${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`D${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`E${row.number}`);
      this.createCellHeader(s,'');

      s = worksheet.getCell(`F${row.number}`);
      this.createCellHeader(s,header1[0])

      s = worksheet.getCell(`G${row.number}`);
      this.createCellHeader(s,header1[1])

      s = worksheet.getCell(`H${row.number}`);
      this.createCellHeader(s,header1[2])

      s = worksheet.getCell(`I${row.number}`);
      this.createCellHeader(s,header1[3])

      s = worksheet.getCell(`J${row.number}`);
      this.createCellHeader(s,header1[4])

      s = worksheet.getCell(`K${row.number}`);
      this.createCellHeader(s,header1[5])

      s = worksheet.getCell(`L${row.number}`);
      this.createCellHeader(s,header1[6])

      s = worksheet.getCell(`M${row.number}`);
      this.createCellHeader(s,header1[7])

      s = worksheet.getCell(`N${row.number}`);
      this.createCellHeader(s,header1[8])

    } else {
      s = worksheet.getCell(`A${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`B${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`C${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`D${row.number}`);
      this.createCellHeader(s,'');
      s = worksheet.getCell(`E${row.number}`);
      this.createCellHeader(s,'');

      s = worksheet.getCell(`F${row.number}`);
      this.createCellHeader(s,header1[0])

      s = worksheet.getCell(`G${row.number}`);
      this.createCellHeader(s,header1[1])

      s = worksheet.getCell(`H${row.number}`);
      this.createCellHeader(s,header1[2])

      s = worksheet.getCell(`I${row.number}`);
      this.createCellHeader(s,header1[3])

      s = worksheet.getCell(`J${row.number}`);
      this.createCellHeader(s,header1[4])

      s = worksheet.getCell(`K${row.number}`);
      this.createCellHeader(s,header1[5])

      s = worksheet.getCell(`L${row.number}`);
      this.createCellHeader(s,header1[6])

      s = worksheet.getCell(`M${row.number}`);
      this.createCellHeader(s,header1[7])

      s = worksheet.getCell(`N${row.number}`);
      this.createCellHeader(s,header1[8])
    }

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

  exportSpravka7(excelData) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    let header = [
      'Код на уред','Уред','Средна цена','Включени в Техн. спец.','Поръ-чани'
      ,'Остатък за поръчка','Монтирани','Остатък за монтаж по договор'
    ];

    let header1 = [
      'Брой','Обща стойност','Брой','Брой','Брой','Обща стойност','Брой','Обща стойност'
    ];

    const colsizes = [0,7,40,7,7,10,7,7,10,7,10]

    const title = excelData.title;
    const sheet = excelData.sheet;
    const data = excelData.data;
    const filename = excelData.filename;

    //Create a workbook with a worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col =1; col <  colsizes.length; col++) {
      worksheet.getColumn(col).width = colsizes[col];
    }
    
    //Add Row and formatting
    worksheet.mergeCells('A1', 'J1');
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
    let row = worksheet.addRow([]);
    row.height = 40;
    let s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,header[0]);
    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,header[1]);
    s = worksheet.getCell(`C${row.number}`);
    this.createCellHeader(s,header[2]);

    worksheet.mergeCells(`D${row.number}`, `E${row.number}`);
    s = worksheet.getCell(`D${row.number}`);
    this.createCellHeader(s,header[3]);

    s = worksheet.getCell(`F${row.number}`);
    this.createCellHeader(s,header[4])
    
    s = worksheet.getCell(`G${row.number}`);
    this.createCellHeader(s,header[5])

    worksheet.mergeCells(`H${row.number}`, `I${row.number}`);
    s = worksheet.getCell(`H${row.number}`);
    this.createCellHeader(s,header[6])

    worksheet.mergeCells(`J${row.number}`, `K${row.number}`);
    s = worksheet.getCell(`J${row.number}`);
    this.createCellHeader(s,header[7])

    //Adding Header Row
    row = worksheet.addRow([]);
    row.height = 40;

    s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,'');

    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,'');

    s = worksheet.getCell(`C${row.number}`);
    this.createCellHeader(s,'');

    s = worksheet.getCell(`D${row.number}`);
    this.createCellHeader(s,header1[0])
    
    s = worksheet.getCell(`E${row.number}`);
    this.createCellHeader(s,header1[1])
    
    s = worksheet.getCell(`F${row.number}`);
    this.createCellHeader(s,header1[2])

    s = worksheet.getCell(`G${row.number}`);
    this.createCellHeader(s,header1[3])

    s = worksheet.getCell(`H${row.number}`);
    this.createCellHeader(s,header1[4])

    s = worksheet.getCell(`I${row.number}`);
    this.createCellHeader(s,header1[5])

    s = worksheet.getCell(`J${row.number}`);
    this.createCellHeader(s,header1[6])

    s = worksheet.getCell(`K${row.number}`);
    this.createCellHeader(s,header1[7])

    // Adding Data with Conditional Formatting
    data.forEach(d => {
      let row = worksheet.addRow(d);
      row.height = 25;

      for (let col = 1; col <= colsizes.length; col++) {    
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
