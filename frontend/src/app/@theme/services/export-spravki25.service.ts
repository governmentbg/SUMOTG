import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';

const DATE_TIME_FORMAT = 'DD-MM-YYYY HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class ExportSpravki25Service {

  constructor() { }

  exportExcel(excelData) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    let header = [
      '№','Район','Имена','Отоплителни уреди за смяна','За монтаж','Брой уреди за монтаж'
      ,'Адрес','Телефон','Имейл за връзка','Дублирани адреси с ОПОС(и)'
    ];

    let header1 = [
      'На дърва - брой','На въглища - брой', 'На дърва и въглища - брой', 'Общ брой уреди за замяна'
    ];

    const colsizes = [0,5,20,30,10,10,10,10,20,10,30,15,20,30]

    const title = excelData.title;
    const sheet = excelData.sheet;
    const data = excelData.data;
    const filename = excelData.filename;
    const sums = excelData.sums;

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
    row.height = 20;
    let s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,header[0]);
    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,header[1]);
    s = worksheet.getCell(`C${row.number}`);
    this.createCellHeader(s,header[2]);

    worksheet.mergeCells(`D${row.number}`, `G${row.number}`);
    s = worksheet.getCell(`D${row.number}`);
    this.createCellHeader(s,header[3]);

    s = worksheet.getCell(`H${row.number}`);
    this.createCellHeader(s,header[4])
    
    s = worksheet.getCell(`I${row.number}`);
    this.createCellHeader(s,header[5])

    s = worksheet.getCell(`J${row.number}`);
    this.createCellHeader(s,header[6])

    s = worksheet.getCell(`K${row.number}`);
    this.createCellHeader(s,header[7])

    s = worksheet.getCell(`L${row.number}`);
    this.createCellHeader(s,header[8])

    s = worksheet.getCell(`M${row.number}`);
    this.createCellHeader(s,header[9])


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
    this.createCellHeader(s,'')

    s = worksheet.getCell(`I${row.number}`);
    this.createCellHeader(s,'')

    s = worksheet.getCell(`J${row.number}`);
    this.createCellHeader(s,'')

    s = worksheet.getCell(`K${row.number}`);
    this.createCellHeader(s,'')

    s = worksheet.getCell(`L${row.number}`);
    this.createCellHeader(s,'')

    s = worksheet.getCell(`M${row.number}`);
    this.createCellHeader(s,'')

    worksheet.mergeCells(`A${row.number-1}:A${row.number}`);
    worksheet.mergeCells(`B${row.number-1}:B${row.number}`);
    worksheet.mergeCells(`C${row.number-1}:C${row.number}`);
    worksheet.mergeCells(`H${row.number-1}:H${row.number}`);
    worksheet.mergeCells(`I${row.number-1}:I${row.number}`);
    worksheet.mergeCells(`J${row.number-1}:J${row.number}`);
    worksheet.mergeCells(`K${row.number-1}:K${row.number}`);
    worksheet.mergeCells(`L${row.number-1}:L${row.number}`);
    worksheet.mergeCells(`M${row.number-1}:M${row.number}`);

    // Adding Data with Conditional Formatting
    data.forEach(d => {
      let row = worksheet.addRow(d);
      row.height = 40;
      this.createCells(row,colsizes.length) 
    });
    
    //sums
    row = worksheet.addRow([]);

    s = worksheet.getCell(`A${row.number}`);
    this.createCell(s,'');

    s = worksheet.getCell(`B${row.number}`);
    this.createCell(s,'');

    s = worksheet.getCell(`C${row.number}`);
    this.createCell(s,'Общо:');

    s = worksheet.getCell(`D${row.number}`);
    this.createCell(s,sums[0])
    
    s = worksheet.getCell(`E${row.number}`);
    this.createCell(s,sums[1])
    
    s = worksheet.getCell(`F${row.number}`);
    this.createCell(s,sums[2])

    s = worksheet.getCell(`G${row.number}`);
    this.createCell(s,sums[0]+sums[1]+sums[2])

    s = worksheet.getCell(`H${row.number}`);
    this.createCell(s,'')

    s = worksheet.getCell(`I${row.number}`);
    this.createCell(s,sums[3])

    s = worksheet.getCell(`J${row.number}`);
    this.createCell(s,'')

    s = worksheet.getCell(`K${row.number}`);
    this.createCell(s,'')

    s = worksheet.getCell(`L${row.number}`);
    this.createCell(s,'')

    s = worksheet.getCell(`M${row.number}`);
    this.createCell(s,'')

    worksheet.addRow([]);

    //Footer Row
    let footerRow = worksheet.addRow(['Файлът е генериран от Столична община на ' +  moment(new Date()).format(DATE_TIME_FORMAT)]);
    footerRow.getCell(1).fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: { argb: 'FFB050' }
    };

    //Merge Cells
    worksheet.mergeCells(`A${footerRow.number}:${alphabet.charAt(header.length+1).toUpperCase()}${footerRow.number}`);

    //Generate & Save Excel File
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, filename + '.xlsx');
    })
    
  }

  createCell(s: any, celltxt: string) {
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
      bold: false,
      size: 10
    }

    s.alignment = {
      vertical: 'top',  
      wrapText: true
    }
  }

  createCells (row: any, colsizes: number)  {
    for (let col = 1; col < colsizes; col++) {  
      let s = row.getCell(col);
      this.createCell(s,'');
    };
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
