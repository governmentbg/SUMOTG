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
export class ExportSpravki21Service {

  constructor() { }

  exportExcel(excelData) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    const title = excelData.title;
    const sheet = excelData.sheet;
    const colsizes = excelData.colsizes;
    const header = excelData.header;
    const data = excelData.data;
    const filename = excelData.filename;

    const dogovor = (excelData.dogovor ? excelData.dogovor : '')
    const fname = (excelData.fname ? excelData.fname : '')

    //Create a workbook with a worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col =1; col <  colsizes.length; col++) {
      worksheet.getColumn(col).width = colsizes[col];
    }
    
    //Add Row and formatting
    worksheet.mergeCells('A1', alphabet.charAt(header.length).toUpperCase()+'1');
    let titleRow = worksheet.getCell('A1');
    titleRow.value = title
    titleRow.font = {
      name: 'Calibri',
      size: 16,
      bold: true,
      color: { argb: '0085A3' }
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }
 
    if (dogovor) {
      //Blank Row 
      worksheet.addRow([]);
      let subrow = worksheet.addRow(['Изпълнител: '+fname]);
      subrow.alignment = { vertical: 'middle', horizontal: 'left' }
      worksheet.mergeCells(`A${subrow.number}:${alphabet.charAt(header.length).toUpperCase()}${subrow.number}`);

      subrow = worksheet.addRow(['Договор: '+dogovor]);
      subrow.alignment = { vertical: 'middle', horizontal: 'left' }
      worksheet.mergeCells(`A${subrow.number}:${alphabet.charAt(header.length).toUpperCase()}${subrow.number}`);
    }

    //Blank Row 
    worksheet.addRow([]);
    let row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)
              +' '+(excelData.filter?excelData.filter:'')]);
    row1.alignment = { vertical: 'middle', horizontal: 'left' }
    worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header.length).toUpperCase()}${row1.number}`);

    //Adding Header Row
    let row = worksheet.addRow([]);
    row.height = (excelData.headersize ? excelData.headersize : 25);
    worksheet.mergeCells(`F${row.number}:G${row.number}`);
    worksheet.mergeCells(`H${row.number}:I${row.number}`);
    worksheet.mergeCells(`J${row.number}:K${row.number}`);
    worksheet.mergeCells(`L${row.number}:M${row.number}`);

    for (let i = 0; i < header.length; i++) {    
      let s = row.getCell(i+1);
      this.createCellHeader(s,header[i])
    };

    if (excelData.header1) {
      let row = worksheet.addRow([]);
      for (let i = 0; i < excelData.header1.length; i++) {    
        let s = row.getCell(i+1);
        this.createCellHeader(s,excelData.header1[i])
      };
    }


    // Adding Data with Conditional Formatting
    data.forEach(d => {
      let row = worksheet.addRow(d);
      this.createCell (row, colsizes);
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

  createCell (row: any, colsizes: number)  {
    for (let col = 1; col < colsizes; col++) {    
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
