import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';
import * as logo from './logo.js';

const DATE_TIME_FORMAT = 'YYYY-MM-DD HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class SpravkaKandidatService {

  constructor() { }

  exportExcel(excelData) {

    const colsizes = [5,15,20,15,20,15];

    const title_row1 = `Проект № BG16M1OP002-5.003-0001`;
    const title_row2 = `„Подобряване качеството на атмосферния въздух`;
    const title_row3 = `в Столична община чрез подмяна на отоплителни устройства`;
    const title_row4 = `на твърдо гориво с екологични алтернативи“`;
    const sheet = 'Кандидат';
    const data = excelData.data;
    const filename = excelData.filename;

    //Create a workbook with a worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col = 0; col <  colsizes.length; col++) {
      worksheet.getColumn(col+1).width = colsizes[col];
    }

    //Add Image
    let myLogoImage = workbook.addImage({
      base64: logo.logo1,
      extension: 'png',
    });
    worksheet.mergeCells('B7:B11');
    worksheet.addImage(myLogoImage, 'B7:B11');
    
    myLogoImage = workbook.addImage({
      base64: logo.logo2,
      extension: 'png',
    });
    worksheet.mergeCells('D7:D11');
    worksheet.addImage(myLogoImage, 'D7:D11');

    myLogoImage = workbook.addImage({
      base64: logo.logo3,
      extension: 'png',
    });
    worksheet.mergeCells('F7:F11');
    worksheet.addImage(myLogoImage, 'F7:F11');

    //Blank Row 
    worksheet.addRow([]);

    //Add Row and formatting
    worksheet.mergeCells('A13', 'F13');
    let titleRow = worksheet.getCell('A13');
    titleRow.value = title_row1
    titleRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }

    worksheet.mergeCells('A14', 'F14');
    titleRow = worksheet.getCell('A14');
    titleRow.value = title_row2
    titleRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }

    worksheet.mergeCells('A15', 'F15');
    titleRow = worksheet.getCell('A15');
    titleRow.value = title_row3
    titleRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }

    worksheet.mergeCells('A16', 'F16');
    titleRow = worksheet.getCell('A16');
    titleRow.value = title_row4
    titleRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'center' }

    //Blank Row 
    worksheet.addRow([]);

     // Adding Data with Conditional Formatting
    data.forEach(d => {
        let row = worksheet.addRow([]);
        row.height = 25;

        worksheet.mergeCells(`A${row.number}:D${row.number}`);
        let s1 =  worksheet.getCell(`A${row.number}`);
        s1.value = d[0];
        s1.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s1.font   = { name: 'Calibri', bold: d[3],size: 11}
        s1.alignment = {vertical: 'middle',  wrapText: true}

        worksheet.mergeCells(`E${row.number}:F${row.number}`);
        let s2 =  worksheet.getCell(`E${row.number}`);
        s2.value = d[1];
        s2.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s2.font   = { name: 'Calibri', bold: false,size: 11}
        s2.alignment = {vertical: 'middle',  wrapText: true, horizontal: d[2]}
    });

    worksheet.addRow([]);

    //Footer Rows
    let footerRow = worksheet.addRow([]);

    footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`A${footerRow.number}:C${footerRow.number}`);
    let c = footerRow.getCell(1)
    c.value = 'Дата: ' +  moment(new Date()).format(DATE_FORMAT);

    worksheet.mergeCells(`E${footerRow.number}:F${footerRow.number}`);
    c = worksheet.getCell(`E${footerRow.number}`);
    c.value = 'Кандидат ……………………………';
    c.alignment = { vertical: 'middle', horizontal: 'center' }

    footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`E${footerRow.number}:F${footerRow.number}`);
    c = worksheet.getCell(`E${footerRow.number}`)
    c.value = '(подпис)';
    c.alignment = { vertical: 'middle', horizontal: 'center' }

    //Generate & Save Excel File
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, filename + '.xlsx');
    })

  }
}
