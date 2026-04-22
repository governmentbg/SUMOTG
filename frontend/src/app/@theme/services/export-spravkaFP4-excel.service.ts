import { Injectable } from '@angular/core';
import { Workbook } from 'exceljs';
import * as moment from 'moment';
import * as fs from 'file-saver';

const DATE_TIME_FORMAT = 'DD-MM-YYYY HH:mm:ss'; 
const DATE_FORMAT = 'DD.MM.YYYY'; 

@Injectable({
  providedIn: 'root'
})
export class ExportSpravkaFP4Service {

  constructor() { }

  exportSpravka(data51, data52, data53, data54, data55, data56) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    let header51= ['Кандидати','Брой'];

    let header52= [
          'Код'    
          ,'Уреди'
          ,'Брой нови монтирани уреди'
          ,'Брой нови уреди със сключени/заявени за сключване договори (без монтирани)'
          ,'Ед. цена с монтаж (евро с ДДС/бр.)'
          ,'Общо изчислен бюджет в евро с ДДС'
    ];

    let header53= [
        '',
        'Бр. домакинства',
        'Отопляващи се на въглища',
        'Отопляващи се на дърва',
        'В т.ч. на дърва и въглища',
        'Брой домакинства'
    ];

    let header53a= [
        'Вид алтернативно отопление към което се преминава',
        'заявили алтернативно отопление',
        'Брой домакинства',
        'Брой уреди',
        'Въглища (кг)',
        'Брой домакинства',
        'Брой уреди',
        'Дърва (куб.м.)',
        'Брой домакинства',
        'Брой уреди',
        'Не показали',
        'Грешни данни',
    ];    

    let header54= [
        '№',    
        'Промяна на отоплителната база',
        'Общо бр. домакинства с монтирани и заявени нови топлоуреди',
        'Спестени емисии кг/г.'
    ];

    let header55= [
        '№',    
        'Промяна на отоплителната база',
        'Общо бр. домакинства с монтирани нови топлоуреди',
        'Спестени емисии кг/г.',
        'Брой сменени стари уреди',
        'Спестени емисии кг/г. (на база уреди)'
    ];

    const filename = 'Индикатори ФПЧ';
    let title = 'Общ брой на домакинствата/крайни получатели, заявили интерес за участие';

    let colsizes = [0,80,20]
    let sheet = 'Справка 1';

    //Create a workbook with a worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col =1; col <  colsizes.length; col++) {
      worksheet.getColumn(col).width = colsizes[col];
    }
    
    //Add Row and formatting
    worksheet.mergeCells('A1', 'B1');
    let titleRow = worksheet.getCell('B1');
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
    let row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

    row1.alignment = { vertical: 'middle', horizontal: 'left' }
    worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header51.length).toUpperCase()}${row1.number}`);
        
    //Adding Header Row
    let row = worksheet.addRow([]);
    row.height = 25;

    let s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,header51[0]);
    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,header51[1]);

    // Adding Data with Conditional Formatting
    data51.forEach(d => {
      let row = worksheet.addRow([]);
      row.height = 25;

      s = row.getCell(1);
      s.value = d.nime

      s = row.getCell(2);
      s.value = d.broi

      this.createCell(row,colsizes.length); 
    });
    
    this.crateFootherRow(workbook, worksheet, header51.length, filename);
    
    //sheet2
    colsizes = [0,10,60,15,15,15,15]
    sheet = 'Справка 2';
    title = 'Брой домакинства заявили/сключили договори за алтернативно отопление';

    //Create a workbook with a worksheet
    worksheet = workbook.addWorksheet(sheet);

    //set columns size
    for (let col =1; col <  colsizes.length; col++) {
      worksheet.getColumn(col).width = colsizes[col];
    }
    
    //Add Row and formatting
    worksheet.mergeCells('A1', 'F1');
    titleRow = worksheet.getCell('F1');
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
    row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

    row1.alignment = { vertical: 'middle', horizontal: 'left' }
    worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header51.length).toUpperCase()}${row1.number}`);
        
    //Adding Header Row
    row = worksheet.addRow([]);
    row.height = 80;

    s = worksheet.getCell(`A${row.number}`);
    this.createCellHeader(s,header52[0]);
    s = worksheet.getCell(`B${row.number}`);
    this.createCellHeader(s,header52[1]);
    s = worksheet.getCell(`C${row.number}`);
    this.createCellHeader(s,header52[2]);
    s = worksheet.getCell(`D${row.number}`);
    this.createCellHeader(s,header52[3]);
    s = worksheet.getCell(`E${row.number}`);
    this.createCellHeader(s,header52[4]);
    s = worksheet.getCell(`F${row.number}`);
    this.createCellHeader(s,header52[5]);

    // Adding Data with Conditional Formatting
    data52.forEach(d => {
      let row = worksheet.addRow([]);
      row.height = 25;

      let s = row.getCell(1);
      s.value = d.nkod

      s = row.getCell(2);
      s.value = d.nime

      s = row.getCell(3);
      s.value = d.broimon

      s = row.getCell(4);
      s.value = d.broizaq

      s = row.getCell(5);
      s.value = d.price

      s = row.getCell(6);
      s.value = d.budget

      this.createCell(row,colsizes.length)  
    });

    this.crateFootherRow(workbook, worksheet, header52.length, filename);

   //sheet3
   colsizes = [0,20,15,15,10,10,15,10,10,15,10,10,10]
   sheet = 'Справка 3';
   title = 'Таблица 3 - вид алтернативно отопление към което се преминава';

   //Create a workbook with a worksheet
   worksheet = workbook.addWorksheet(sheet);

   //set columns size
   for (let col =1; col <  colsizes.length; col++) {
     worksheet.getColumn(col).width = colsizes[col];
   }
   
   //Add Row and formatting
   worksheet.mergeCells('A1', 'L1');
   titleRow = worksheet.getCell('L1');
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
   row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

   row1.alignment = { vertical: 'middle', horizontal: 'left' }
   worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header51.length).toUpperCase()}${row1.number}`);
       
   //Adding Header Row
   row = worksheet.addRow([]);
   row.height = 25;

   s = worksheet.getCell(`A${row.number}`);
   this.createCellHeader(s,header53[0]);
   s = worksheet.getCell(`B${row.number}`);
   this.createCellHeader(s,header53[1]);
   worksheet.mergeCells(`C${row.number}`, `E${row.number}`);
   s = worksheet.getCell(`C${row.number}`);
   this.createCellHeader(s,header53[2]);
   worksheet.mergeCells(`F${row.number}`, `H${row.number}`);
   s = worksheet.getCell(`F${row.number}`);
   this.createCellHeader(s,header53[3]);
   worksheet.mergeCells(`I${row.number}`, `J${row.number}`);
   s = worksheet.getCell(`I${row.number}`);
   this.createCellHeader(s,header53[4]);
   worksheet.mergeCells(`K${row.number}`, `L${row.number}`);
   s = worksheet.getCell(`K${row.number}`);
   this.createCellHeader(s,header53[5]);

   row = worksheet.addRow([]);
   row.height = 40;

   s = worksheet.getCell(`A${row.number}`);
   this.createCellHeader(s,header53a[0]);
   s = worksheet.getCell(`B${row.number}`);
   this.createCellHeader(s,header53a[1]);
   s = worksheet.getCell(`C${row.number}`);
   this.createCellHeader(s,header53a[2]);
   s = worksheet.getCell(`D${row.number}`);
   this.createCellHeader(s,header53a[3]);
   s = worksheet.getCell(`E${row.number}`);
   this.createCellHeader(s,header53a[4]);
   s = worksheet.getCell(`F${row.number}`);
   this.createCellHeader(s,header53a[5]);
   s = worksheet.getCell(`G${row.number}`);
   this.createCellHeader(s,header53a[6]);
   s = worksheet.getCell(`H${row.number}`);
   this.createCellHeader(s,header53a[7]);
   s = worksheet.getCell(`I${row.number}`);
   this.createCellHeader(s,header53a[8]);
   s = worksheet.getCell(`J${row.number}`);
   this.createCellHeader(s,header53a[9]);
   s = worksheet.getCell(`K${row.number}`);
   this.createCellHeader(s,header53a[10]);
   s = worksheet.getCell(`L${row.number}`);
   this.createCellHeader(s,header53a[11]);

   // Adding Data with Conditional Formatting
   data53.forEach(d => {
     let row = worksheet.addRow([]);
     row.height = 25;

     let s = row.getCell(1);
     s.value = d.vid

     s = row.getCell(2);
     s.value = d.col2

     s = row.getCell(3);
     s.value = d.col3

     s = row.getCell(4);
     s.value = d.col4

     s = row.getCell(5);
     s.value = d.col5

     s = row.getCell(6);
     s.value = d.col6

     s = row.getCell(7);
     s.value = d.col7

     s = row.getCell(8);
     s.value = d.col8

     s = row.getCell(9);
     s.value = d.col9

     s = row.getCell(10);
     s.value = d.col10

     s = row.getCell(11);
     s.value = d.col11

     s = row.getCell(12);
     s.value = d.col12

     this.createCell(row,colsizes.length)  
   });

   this.crateFootherRow(workbook, worksheet, header53a.length, filename);   
   
  //sheet4
  colsizes = [0,15,50,15,15]
  sheet = 'Справка 4';
  title = 'Таблица 4 - спестени емисии ФПЧ 10 (актуализирана целева стойност)';

  //Create a workbook with a worksheet
  worksheet = workbook.addWorksheet(sheet);

  //set columns size
  for (let col =1; col <  colsizes.length; col++) {
    worksheet.getColumn(col).width = colsizes[col];
  }
  
  //Add Row and formatting
  worksheet.mergeCells('A1', 'D1');
  titleRow = worksheet.getCell('D1');
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
  row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

  row1.alignment = { vertical: 'middle', horizontal: 'left' }
  worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header54.length).toUpperCase()}${row1.number}`);
      
  //Adding Header Row
  row = worksheet.addRow([]);
  row.height = 70;

  s = worksheet.getCell(`A${row.number}`);
  this.createCellHeader(s,header54[0]);
  s = worksheet.getCell(`B${row.number}`);
  this.createCellHeader(s,header54[1]);
  s = worksheet.getCell(`C${row.number}`);
  this.createCellHeader(s,header54[2]);
  s = worksheet.getCell(`D${row.number}`);
  this.createCellHeader(s,header54[3]);

  // Adding Data with Conditional Formatting
  data54.forEach(d => {

    if (d.id === 999999) {
      let row = worksheet.addRow([]);
      row.height = 25;
  
      //row 1
      let s = row.getCell(2);
      s.value = 'Общо спестени емисии ФПЧ 10 кг/г.'

      s = row.getCell(4);
      s.value = d.calc

      this.createCell(row,colsizes.length)  

      //row 2
      row = worksheet.addRow([]);
      row.height = 25;
  
      s = row.getCell(2);
      s.value = 'Общо спестени емисии ФПЧ 10 т/г.'

      s = row.getCell(4);
      s.value = d.calc/1000

      this.createCell(row,colsizes.length)  

      //row 2
      row = worksheet.addRow([]);
      row.height = 25;
  
      s = row.getCell(2);
      s.value = 'Общ брой домакинства'

      s = row.getCell(3);
      s.value = d.broi

      this.createCell(row,colsizes.length)  

    } else {
      let row = worksheet.addRow([]);
      row.height = 25;

      let s = row.getCell(1);
      s.value = d.id

      s = row.getCell(2);
      s.value = d.nime

      s = row.getCell(3);
      s.value = d.broi

      s = row.getCell(4);
      s.value = d.calc

      this.createCell(row,colsizes.length)  
    }
  });

  this.crateFootherRow(workbook, worksheet, header54.length, filename);      

  //sheet5
  colsizes = [0,15,50,15,15,15,15]
  sheet = 'Справка 5';
  title = 'Таблица 5 - спестени емисии ФПЧ 10 ';

  //Create a workbook with a worksheet
  worksheet = workbook.addWorksheet(sheet);

  //set columns size
  for (let col =1; col <  colsizes.length; col++) {
    worksheet.getColumn(col).width = colsizes[col];
  }
  
  //Add Row and formatting
  worksheet.mergeCells('A1', 'F1');
  titleRow = worksheet.getCell('F1');
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
  row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

  row1.alignment = { vertical: 'middle', horizontal: 'left' }
  worksheet.mergeCells(`A${row1.number}:${alphabet.charAt(header55.length).toUpperCase()}${row1.number}`);
      
  //Adding Header Row
  row = worksheet.addRow([]);
  row.height = 70;

  s = worksheet.getCell(`A${row.number}`);
  this.createCellHeader(s,header55[0]);
  s = worksheet.getCell(`B${row.number}`);
  this.createCellHeader(s,header55[1]);
  s = worksheet.getCell(`C${row.number}`);
  this.createCellHeader(s,header55[2]);
  s = worksheet.getCell(`D${row.number}`);
  this.createCellHeader(s,header55[3]);
  s = worksheet.getCell(`E${row.number}`);
  this.createCellHeader(s,header55[4]);
  s = worksheet.getCell(`F${row.number}`);
  this.createCellHeader(s,header55[5]);

  // Adding Data with Conditional Formatting
  data55.forEach(d => {
    if (d.id === 999999) {
      let row = worksheet.addRow([]);
      row.height = 25;
  
      //row 1
      let s = row.getCell(2);
      s.value = 'Общо спестени емисии ФПЧ 10 кг/г. (домакинства/Уреди)'

      s = row.getCell(4);
      s.value = d.calc

      s = row.getCell(6);
      s.value = d.calcuredi

      this.createCell(row,colsizes.length)  

      //row 2
      row = worksheet.addRow([]);
      row.height = 25;
  
      s = row.getCell(2);
      s.value = 'Общо спестени емисии ФПЧ 10 т/г. (домакинства/Уреди)'

      s = row.getCell(4);
      s.value = d.calc/1000

      s = row.getCell(6);
      s.value = d.calcuredi/1000

      this.createCell(row,colsizes.length)  

      //row 2
      row = worksheet.addRow([]);
      row.height = 25;
  
      s = row.getCell(2);
      s.value = 'Общ брой домакинства (домакинства/Уреди)'

      s = row.getCell(3);
      s.value = d.broi

      s = row.getCell(5);
      s.value = d.broiuredi

      this.createCell(row,colsizes.length)  

    } else {    
      let row = worksheet.addRow([]);
      row.height = 25;

      let s = row.getCell(1);
      s.value = (d.id === 999999 ?'':d.id)

      s = row.getCell(2);
      s.value = d.nime

      s = row.getCell(3);
      s.value = d.broi

      s = row.getCell(4);
      s.value = d.calc

      s = row.getCell(5);
      s.value = d.broiuredi

      s = row.getCell(6);
      s.value = d.calcuredi

      this.createCell(row,colsizes.length)  
    }
  });

  this.crateFootherRow(workbook, worksheet, header55.length, filename);        

 //sheet5
 colsizes = [0,45,15]
 sheet = 'Справка 6';
 title = 'Таблица 6';

 //Create a workbook with a worksheet
 worksheet = workbook.addWorksheet(sheet);

 //set columns size
 for (let col =1; col <  colsizes.length; col++) {
   worksheet.getColumn(col).width = colsizes[col];
 }
 
 //Add Row and formatting
 worksheet.mergeCells('A1', 'B1');
 titleRow = worksheet.getCell('B1');
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
 row1 = worksheet.addRow([moment(new Date()).format(DATE_TIME_FORMAT)]);

 // Adding Data with Conditional Formatting
 data56.forEach(d => {
   let row = worksheet.addRow([]);
   row.height = 25;

   s = row.getCell(1);
   s.value = d.nime

   s = row.getCell(2);
   s.value = Number(parseFloat(d.calc).toFixed(2));

   this.createCell(row,3)  
 });

 this.crateFootherRow(workbook, worksheet, 2, filename);     
 
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

  crateFootherRow (workbook: any, worksheet: any, length: number, filename: string) {
    const alphabet = "_abcdefghijklmnopqrstuvwxyz"

    worksheet.addRow([]);

    //Footer Row
    let footerRow = worksheet.addRow(['Файлът е генериран от Столична община на ' +  moment(new Date()).format(DATE_TIME_FORMAT)]);
    footerRow.getCell(1).fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'FFB050' }
    };

    //Merge Cells
    worksheet.mergeCells(`A${footerRow.number}:${alphabet.charAt(length).toUpperCase()}${footerRow.number}`);

  }
}
