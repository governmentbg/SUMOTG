import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';
import * as logo1 from './logo1.js';
import * as logo2 from './logo2.js';
import * as logo3 from './logo3.js';

const DATE_TIME_FORMAT = 'DD-MM-YYYY HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class ExportDemontazjExcelService {

  constructor() { }

  exportPorychka(excelData) {
    //Title, Header & Data
    let subtitle = [
      'Служебен','П О Р Ъ Ч К А','Г Р А Ф И К','О Т Ч Е Т',					
    ];

    let header = [
      '','№',
      'Район','Ид. № по ОПОС','ИМЕНА','Уред','Брой','Вид имот','Адрес на демонтажа',
      'Електронен адрес (email)','Телефон за контакти',	'Планиран за дата',	'От час','До час',
      'Забележка'	,'Статус График','Статус Демонтаж','Демонтиран на дата', 'Забележка',
      'Снимка','Пор. №'
    ];

    const colsizes = [
      0,0,
      5,15,12,20,25,5,15,35,20,12,
      10,7,7,20,15,
      15,10,20,
      10
    ]

    const title_row1 = `изпълнител: ${excelData.firma}`;
    const title_row2 = `съгласно договор № ${excelData.dogovor}`;
    const title_row3 = ``;
    const title_row4 = ``;
    const foother_1  = 'Документът е изготвен в изпълнение на проект № BG16M1ОP002-5.003-0001 „Подобряване качеството на атмосферния въздух ';
    const foother_2  = 'в Столична община чрез подмяна на отоплителни устройства на твърдо гориво с екологични алтернативи”,';
    const foother_3  = 'финансиран по Оперативна програма „Околна среда 2014-2020г.“, съфинансирана от Европейския съюз ';
    const foother_4  = 'чрез Кохезионния фонд и от националния бюджет на Република България ';
    const sheet = 'Демонтаж_ПГО';
    const data = excelData.data;
    const filename = excelData.filename;
    const porychka = excelData.porychka;
    const porychkadate = excelData.porychkadate;

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
    worksheet.mergeCells('H1:H6');
    worksheet.addImage(myLogoImage, 'H1:H6');

    myLogoImage = workbook.addImage({
      base64: logo3.logo3,
      extension: 'png',
    });
    worksheet.mergeCells('J1:J6');
    worksheet.addImage(myLogoImage, 'J1:J6');

    //Blank Row 
    worksheet.addRow([]);

    //Add Row and formatting
    worksheet.mergeCells('E8', 'J8');
    let titleRow = worksheet.getCell('E8');
    titleRow.value = title_row1
    titleRow.font = {
      name: 'Calibri',
      size: 11,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'left' }

    worksheet.mergeCells('E9', 'J9');
    titleRow = worksheet.getCell('E9');
    titleRow.value = title_row2
    titleRow.font = {
      name: 'Calibri',
      size: 11,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'left' }

    worksheet.mergeCells('E10', 'J10');
    titleRow = worksheet.getCell('E10');
    titleRow.value = title_row3
    titleRow.font = {
      name: 'Calibri',
      size: 11,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'left' }

    worksheet.mergeCells('E11', 'J11');
    titleRow = worksheet.getCell('E11');
    titleRow.value = title_row4
    titleRow.font = {
      name: 'Calibri',
      size: 11,
    }
    titleRow.alignment = { vertical: 'middle', horizontal: 'left' }

    //Blank Row 
    worksheet.addRow([]);

    //porychka
    porychka
    worksheet.mergeCells(`A12:J12`);
    worksheet.getCell('A12').value = `Поръчка № ${porychka} от дата ` +  
      moment(porychkadate).format(DATE_FORMAT);
    
    //Adding Subtitle Row
    //worksheet.mergeCells('A8', 'F8');
    worksheet.getCell('A13').value = subtitle[0];

    worksheet.mergeCells('B13', 'K13');
    worksheet.getCell('B13').value = subtitle[1];

    worksheet.mergeCells('L13', 'P13');
    worksheet.getCell('L13').value = subtitle[2];

    worksheet.mergeCells('Q13', 'T13');
    worksheet.getCell('Q13').value = subtitle[3];

    worksheet.mergeCells('Y13', 'Z13');

    //Adding Header Row
    worksheet.addRow(header);

    //system range
    let range = {start: {row: 13, col: 1}, end: {row: 15, col: 1}};
    for (let row = range.start.row; row <= range.end.row; row++) {
      for (let col = range.start.col; col <= range.end.col; col++) {    
          let s = worksheet.getCell(row, col)
          s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
          s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'ffc000' },bgColor: { argb: '' }}
          s.font   = {name: 'Calibri', bold: true,size: 10}
          s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
      };
    }

    //porychka range
    range = {start: {row: 13, col: 2}, end: {row: 15, col: 11}};
    for (let row = range.start.row; row <= range.end.row; row++) {
      for (let col = range.start.col; col <= range.end.col; col++) {    
        let s = worksheet.getCell(row, col)
        s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'eeeeee' },bgColor: { argb: '' }}
        s.font   = {name: 'Calibri', bold: true,size: 10}
        s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
      };
    }

    //grafik range
    range = {start: {row: 13, col: 12}, end: {row: 15, col: 16}};
    for (let row = range.start.row; row <= range.end.row; row++) {
      for (let col = range.start.col; col <= range.end.col; col++) {    
        let s = worksheet.getCell(row, col)
        s.border = {top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: 'ffff00' },bgColor: { argb: '' }}
        s.font   = {name: 'Calibri', bold: true,size: 10}
        s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
      };
    }

    //otchet range
    range = {start: {row: 13, col: 17}, end: {row: 15, col: colsizes.length}};
    for (let row = range.start.row; row <= range.end.row; row++) {
      for (let col = range.start.col; col <= range.end.col; col++) {    
        let s = worksheet.getCell(row, col)
        s.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s.fill   = {type: 'pattern',pattern: 'solid',fgColor: { argb: '92d050' },bgColor: { argb: '' }}
        s.font   = { name: 'Calibri', bold: true,size: 10}
        s.alignment = {vertical: 'top', horizontal: 'center',  wrapText: true}
      };
    }

    let cntcol = 0;
    range = {start: {row: 15, col: 1}, end: {row: 15, col: colsizes.length}};
    for (let col = range.start.col; col <= range.end.col; col++) {
      worksheet.getCell(range.start.row, col).value = cntcol;
      cntcol++;
    }

    let datarow = 16

    // Adding Data with Conditional Formatting
    data.forEach(d => {
      let row = worksheet.addRow(d);
      row.height = 25;

      for (let col = 1; col <= colsizes.length; col++) {    
        let s = row.getCell(col)
        s.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
        s.font   = { name: 'Calibri', bold: false,size: 10}
        s.alignment = {vertical: 'top',  wrapText: true}
      };
    });

    for( let i =datarow; i < data.length+datarow; i++) {
      //status p
      worksheet.getCell(`P${i}`).dataValidation = {
        type: 'list',
        allowBlank: true,
        formulae: ['"1-За демонтаж, 2-Ненамерен, 3-Отказан, 4-Отложен"'],
        showInputMessage: true,
        showErrorMessage: true,
        errorStyle: 'stop',
        errorTitle: 'Избор на статус',
        error: 'Трябва да изберете позиция от списъка'
      };

      //status m
      worksheet.getCell(`Q${i}`).dataValidation = {
        type: 'list',
        allowBlank: true,
        formulae: ['"1-Демонтиран, 2-Ненамерен, 3-Отказан, 4-Отложен"'],
        showInputMessage: true,
        showErrorMessage: true,
        errorStyle: 'stop',
        errorTitle: 'Избор на статус',
        error: 'Трябва да изберете позиция от списъка'
      };

      //planirano za
      worksheet.getCell(`L${i}`).numFmt = 'dd.mm.yyyy'; 

      //ot chas
      worksheet.getCell(`M${i}`).numFmt = 'hh:mm'; 

      //do chas
      worksheet.getCell(`N${i}`).numFmt = 'hh:mm'; 

      //деmontirano za
      worksheet.getCell(`R${i}`).numFmt = 'dd.mm.yyyy'; 
    }

    worksheet.addRow([]);

    //Footer Rows
    let footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`E${footerRow.number}:K${footerRow.number}`);
    footerRow.getCell(5).value = foother_1;

    footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`E${footerRow.number}:K${footerRow.number}`);
    footerRow.getCell(5).value = foother_2;

    footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`E${footerRow.number}:K${footerRow.number}`);
    footerRow.getCell(5).value = foother_3;

    footerRow = worksheet.addRow([]);
    worksheet.mergeCells(`E${footerRow.number}:K${footerRow.number}`);
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
    })

  }
}
