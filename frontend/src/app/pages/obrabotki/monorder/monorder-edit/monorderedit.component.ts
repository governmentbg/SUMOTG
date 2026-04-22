import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbStepperComponent } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FirmaData } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { DogovorRaioni, DogovorUredi, MonOrder, MonOrderItem, ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { HeaderComponent } from '../../../../@theme/components';
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';
import { ObrabotkiForms } from '../../forms/monorder.edit.form';
import { Workbook } from 'exceljs';
import { DomSanitizer } from '@angular/platform-browser';
import * as moment from 'moment';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';
import { ExportMontazjExcelService } from '../../../../@theme/services/export-montazj-excel.service';
import { NgxSpinnerService } from 'ngx-spinner';

interface ExportOrderItem {
  chksum: string,
  nomer: string,
  raion: string,
  unom: string,
  ime: string,
  uredname: string,
  broi: number,
  vidimot: string,
  adres: string,
  email: string,
  telefon: string,
  dodata: Date,
  otchas: string,
  dochas: string,
  note: string,
  status_g: number,
  status_m: number,
  mondata: Date,
  model: string,
  fabrnomer: string,
  garkarta: string,
  gardata: Date,
  protdata: Date,
  note2: string,
  note3: string;
  recno: number,
}

interface ImportGrafik {
  chksum: string,
  dodata: string,
  otchas: string,
  dochas: string,
  note: string,
  status_g: string,
}

interface importMontazj {
  chksum: string,
  status_m: string,
  mondata: string,
  model: string,
  fabrnomer: string,
  garkarta: string,
  gardata: string,
  protnomer: string,
  protdata: string,
  snimka: string,
  safeurl: string;  
  note: string,
}

@Component({
  selector: 'ngx-monorderedit',
  templateUrl: './monorderedit.component.html',
  styleUrls: ['./monorderedit.component.scss']
})
export class MonordereditComponent implements OnInit {
  @ViewChild("stepper") stepper!: NbStepperComponent;

  _VID: number = 1;
  isDisabled = false;
  mainForm: FormGroup;
  click: boolean = false;
  
  vlistv43:  ViewNom[];
  raioni: ViewNom[];
  vliststatus: ViewNom[];

  vmonfirmi: ViewNom[];
  vmonfirmidogovor: ViewNom[];
  vdoguredi: DogovorUredi[];
  vdograioni: DogovorRaioni[];
  vliststatusg: ViewNom[];
  vliststatusm: ViewNom[];

  id: number = 0;
  name: string = '';
  disable: boolean = false;
  imageurl: any;
  idporychka: number =0;

  minDate: Date;
  maxDate: Date;
  dataImportGrafik: ImportGrafik[] = new Array();
  dataImportMontazj: importMontazj[] = new Array();
  
  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
    private ete: ExportMontazjExcelService,
    private excelService: ExportExcelService,
    private router: Router,
    private route: ActivatedRoute,
    private orderService: ObrabotkaData,
    private firmiService: FirmaData,
    private nomenclatureService: NomenclatureData,
    private toasterService: CustomToastrService,
    private sanitizer: DomSanitizer,
    private spinner: NgxSpinnerService,
  ) {
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      this.idporychka = Number(params.get('iddog'));
      this.disable = String(params.get('disable'))==='true';       
    });

    this.minDate = new Date(2020,1,1);
    this.maxDate = new Date(2030,12,31);;    
   }

  ngOnInit(): void {
    this.mainForm = new ObrabotkiForms().createMonorderEdit(this.disable);
    this.loadLists();
    this.loadOrder();
    this.onStatusChanged();
  }

  loadLists() {
    this.nomenclatureService
        .getNomenRaioni()
        .subscribe(result => {
        this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_DPM')
        .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.firmiService
        .getFirmi(1)
        .subscribe((result) => {
          this.vmonfirmi = result.map(item => new ViewNom().convertFirmi(item));
    });  

    this.nomenclatureService
        .getNomenStatusi('StatusG')
        .subscribe(result => {
        this.vliststatusg = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('StatusM')
        .subscribe(result => {
        this.vliststatusm = result.map(item => new ViewNom().convertNomStatusi(item));
    });

  }

  loadOrder () {
    this.orderService.getMonOrder(this.idporychka).subscribe((result) => {
      if (result.porychkaitems && result.porychkaitems.length > 0) {
        (this.mainForm.get("porychkaitems") as FormArray).removeAt(0);

        result.porychkaitems.forEach((t) => {
          var ured: FormGroup = new ObrabotkiForms().createMonorderItem(this.isDisabled); 
          (this.mainForm.get("porychkaitems") as FormArray).push(ured);
        });
      }

      this.loadMonDogovorFirma (result.idfirma);
      this.loadDogovorFirmaUredi (result.iddogovorfirma);
      this.loadDogovorFirmaRaioni (result.iddogovorfirma);

      this.idporychka = result.idporychkamain ? result.idporychkamain : 0;

      this.mainForm.patchValue({
        idporychkamain: result.idporychkamain ? result.idporychkamain : 0,
        nomer: result.nomer ? result.nomer : 0,
        data: result.data ? result.data : null,
        idfirma: result.idfirma ? String(result.idfirma) : null,
        iddogovorfirma: result.iddogovorfirma ? String(result.iddogovorfirma) : null,
        raion: result.raion ? result.raion : null,
        startdata: result.startdata ? result.startdata : null,
        enddata: result.enddata ? result.enddata : null,
        faza: result.faza ? result.faza : HeaderComponent.faza,
        porychkaitems: result.porychkaitems,
        status: result.status ? result.status : 1,
        status_pm: result.status_pm ? String(result.status_pm) : '1',
        note: result.note ? result.note : "",
      });

      let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

      porychkaitems.controls.forEach((form: FormGroup) => {
        let snimka = form.get('safeurl').value;
        form.get('safeurl').setValue(snimka.trim().length>0 ? this.getSafeUrl(snimka) : '');   
      });  
   
      if (this.mainForm.get('status_pm').value > 1) {
        this.vliststatus = this.vliststatus.filter(e => e.id > 1);
      }      

      this.calcPorychkaUredi(); 
    });
  }

  loadMonDogovorFirma (idfirma: number) {
    this.firmiService.loadMonDogovorFirma(idfirma).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
    });  
  }

  loadDogovorFirmaUredi (iddogovorfirma: number) {
    this.orderService.getDogovorFirmaUredi(iddogovorfirma).subscribe((result) => {
      this.vdoguredi = result;
      this.calcPorychkaUredi();
    });  
  }

  calcPorychkaUredi() {
    if (this.mainForm.get("porychkaitems") &&  this.vdoguredi) {
      let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;
      this.vdoguredi.forEach ((item: DogovorUredi) => {   

        let sum = 0;   
        porychkaitems.controls.forEach((form: FormGroup, index) => {  
          let obj =  form.get('idured') ? form.get('idured').value : 0
          if (obj === item.id) {
            sum = sum + (form.get('broi') ? form.get('broi').value : 0) ;
          }
        })
        item.currentbroi = sum; 
      });
    }
  }

  loadDogovorFirmaRaioni (iddogovorfirma: number) {
    this.orderService.getDogovorFirmaRaioni(iddogovorfirma).subscribe((result) => {
      this.vdograioni = result;

      if (this.vdograioni.length > 0) {
        this.mainForm
            .get('raion')
            .patchValue(this.vdograioni[0].nkod, {emitEvent: true});
      }
    });  
  }

  save() {
    if (this.checkOrder()) {
      this.spinner.show();  

      //zashtoto ako e zabraneno ne se serializira
      this.mainForm.get('idporychkamain').enable();

      const order: MonOrder = this.mainForm.value;
      order.status_pm = (order.status_pm== 0 ? 1 : order.status_pm);
      order.uredi = this.vdoguredi;

      this.click  = !this.click;
      let observable = new Observable<number>();
      observable = this.orderService.setMonOrder(order);
    
      observable
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(() => {
          this.spinner.hide();  
          this.handleSuccessResponse();
        },
        (err) => {
          this.spinner.hide();  
          this.handleWrongResponse();
        }
      );
    }

  }

  async statusChange($event) {
    this.click  = $event;
  }

  checkOrder() {
    //TODO check statuses and fields
    let canSave = true;
    this.vdoguredi.forEach ((item: DogovorUredi) => {  
        if (item.broiporychani > item.broi) {
          this.toasterService.showToast("danger",item.name + " - превишен е максималният разрешен брой");  
          canSave = false;
        }
    });

    let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

    if (porychkaitems) {
      porychkaitems.controls.forEach((form: FormGroup) => {
        if (form.get('safeurl')) {
          form.get('safeurl').setValue('');   
        }
      });
    }    

    return canSave;
  }

  getDogovorNomer() {
    if (this.vmonfirmidogovor) {
      let dogovor = this.vmonfirmidogovor.find(e => e.nkod === this.mainForm.get('iddogovorfirma').value);
      return dogovor ? dogovor.name : ''
    } else  
      return ''
  }

  exportexcel(): void {
    let md5 = require("md5")
    let firma = this.vmonfirmi.find(e => e.nkod === this.mainForm.get('idfirma').value);
 //   let eik = firma ? firma.name.substring(0, firma.name.indexOf(" ")) : ''
    let fname = firma ? firma.name.substring(firma.name.indexOf(" ")) : ''

 //   let raion = this.raioni.find(e => e.nkod === this.mainForm.get('raion').value);
    let obj: ExportOrderItem;
    let dataForExcel = [];
    let items =  (this.mainForm.get("porychkaitems") as FormArray) 

    items.controls.forEach((form: FormGroup) => {    
      let chksum =  md5(String(form.get('idl').value)+ '|'+
                        String(form.get('idured').value)+'|'+
                        String(this.mainForm.get('idporychkamain').value)); 

      obj = {
          chksum:  chksum,
          nomer: '',
          raion: form.get('raion') ? form.get('raion').value : '',
          unom: form.get('unom') ? form.get('unom').value : '',
          ime: form.get('ime').value,
          uredname: form.get('uredname').value,
          broi: form.get('broi').value,
          vidimot: form.get('vidimot').value,
          adres: form.get('adres').value,
          email: form.get('email').value,
          telefon: form.get('telefon').value,
          dodata: null,
          otchas: '',
          dochas: '',
          note: '',
          status_g: null,
          status_m: null,
          mondata: null,
          model: '',
          fabrnomer: '',
          garkarta: '',
          gardata: null,
          protdata: null,
          note2: '',
          note3: form.get('note3').value,     
          recno: 0,
      }      

      dataForExcel.push(Object.values(obj))
    })

    dataForExcel = dataForExcel.sort(function(a, b) {
      var raionA = a[2].toUpperCase(); // ignore upper and lowercase
      var raionB = b[2].toUpperCase(); // ignore upper and lowercase

      var uredA = a[2].toUpperCase();
      var uredB = b[2].toUpperCase();

      if (raionA === raionB) {
        return (uredA < uredB ? -1 : 1);
      } else {
        return (raionA < raionB ? -1 : 1);
      }    
    });

     let oldunom = ''; 
     let cntopos = 0;     
     let reccount = 0;
   
     dataForExcel.forEach (x => {
       x[25] = ++reccount;
       if (oldunom != x[3]) {
        oldunom = x[3];
        x[1] = String(++cntopos);
      } else {
        x[1] = ''
      }
    })

    let dogovor = this.vmonfirmidogovor.find(e => e.nkod === this.mainForm.get('iddogovorfirma').value);
    let dognomer = dogovor ? dogovor.name.substring(0, dogovor.name.indexOf("/")) : ''
    let dogdate = dogovor ? dogovor.name.substring(dogovor.name.indexOf(" ")) : ''

    let reportData = {
      data: dataForExcel,
      firma: fname,
      porychka: this.mainForm.get('idporychkamain').value,
      porychkadate: this.mainForm.get('data').value,
      dogovor: dogovor ? dogovor.name : '',
      dogovordate:dogdate,
      raion: this.raioni.find(e => e.nkod === this.mainForm.get('raion').value).name,      
      filename: this.mainForm.get('idporychkamain').value+'_'+
                fname.trim().replace(' ','_') + '_'+dognomer.trim()
    }

    this.ete.exportPorychka(reportData);  
//    this.mainForm.get('status_pm').setValue('2');
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
    if (await this.checkImportGrafik(filename) == 0) {
        let idporychkamain = String(this.mainForm.get('idporychkamain').value);
        let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

        this.dataImportGrafik.forEach(x=> {    
          let indx = porychkaitems.controls
                                  .findIndex (t=> md5(String(t.get('idl').value)+'|'+
                                                      String(t.get('idured').value)+'|'+
                                                      idporychkamain) == x.chksum); 

          if (indx > -1) {
            let item = porychkaitems.controls[indx];
            item.get('dodata').setValue(moment.utc(x.dodata,DATE_FORMAT).toDate());
            item.get('otchas').setValue(x.otchas);
            item.get('dochas').setValue(x.dochas);
            item.get('note').setValue(x.note);
            item.get('status_g').setValue(x.status_g);
            item.get('status').setValue(9);
                  
            porychkaitems.controls[indx] = item;
          }  
        }); 

        //this.mainForm.get('status_pm').setValue('3');
    }  else {
      this.toasterService.danger('', `Грешни данни! Проверете протокола.`);
    }
  };
  
  //otchet
  async importexcel2(event) {
    const md5 = require("md5")
    const DATE_FORMAT = 'DD.MM.YYYY'; 
    const target: DataTransfer = <DataTransfer>(event.target);

    if (target.files.length === 0) {
      return;
    }

    if (target.files.length !== 1) {
      throw new Error('Cannot use multiple files');
    }

    const filename = target.files[0];
    if (await this.checkImportMontazj(filename) == 0) {
        let idporychkamain = String(this.mainForm.get('idporychkamain').value);
        let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

      this.dataImportMontazj.forEach(x=> {    
        let indx = porychkaitems.controls
                                .findIndex (t=> md5(String(t.get('idl').value)+'|'+
                                                    String(t.get('idured').value)+'|'+
                                                    idporychkamain) == x.chksum); 

        if (indx > -1) {
            let item = porychkaitems.controls[indx];
            
            item.get('status_m').setValue(x.status_m.substring(0,1))
            item.get('mondata').setValue(moment.utc(x.mondata,DATE_FORMAT));
            item.get('model').setValue(x.model);
            item.get('fabrnomer').setValue(x.fabrnomer);
            item.get('garkarta').setValue(x.garkarta);
            item.get('gardata').setValue(moment.utc(x.gardata,DATE_FORMAT))
            item.get('protdata').setValue(moment.utc(x.protdata,DATE_FORMAT) )
            item.get('note2').setValue(x.note);
            item.get('snimka').setValue(x.snimka);
            item.get('safeurl').setValue(x.safeurl);
            item.get('status').setValue(9);
            
            porychkaitems.controls[indx] = item;
        }    
      });  
      //this.mainForm.get('status_pm').setValue('4');

    }  else {
      this.toasterService.danger('', `Грешни данни! Проверете протокола.`);
    }  
  };

  get64BaseString(image: any) {    
    let TYPED_ARRAY = new Uint8Array(image.buffer);
    const STRING_CHAR = TYPED_ARRAY.reduce((data, byte)=> {
            return data + String.fromCharCode(byte);
    }, '');
   
    return btoa(STRING_CHAR);
  }

  getSafeUrl(str: string) {
    return this.sanitizer.bypassSecurityTrustUrl('data:image/jpg;base64, ' + str);
  }

  onFirmItemSelected(firma: ViewNom) {
    this.firmiService.loadMonDogovorFirma(firma.id).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
      if (this.vmonfirmidogovor.length > 0) {
        this.mainForm
            .get('iddogovorfirma')
            .patchValue(String(this.vmonfirmidogovor[0].id), {emitEvent: true});
  
        this.loadDogovorFirmaUredi(this.vmonfirmidogovor[0].id);
        this.loadDogovorFirmaRaioni(this.vmonfirmidogovor[0].id);
      }      
    });  
  }

  onDogovorItemSelected(dogovorfirma: ViewNom) {
    this.loadDogovorFirmaUredi (dogovorfirma.id)
  }

  onStatusChanged() {
    // this.mainForm.get('status_pm')
    //     .valueChanges
    //     .pipe(pairwise())
    //     .subscribe(([prev, next]: [any, any]) =>  {
    //         if (prev == 1 && next == 2) {
    //           this.exportexcel();
    //         }
    //     });
  }

  async checkImportGrafik(filename: any) {
    const md5 = require("md5")
    const DATE_FORMAT = 'DD.MM.YYYY';
    const TIME_FORMAT = 'HH:mm';

    let dataImportGrafik = new Array();

    const workbook = new Workbook();
    const blob = new Blob([filename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);

    const worksheet = workbook.getWorksheet(1);

    let idporychkamain = String(this.mainForm.get('idporychkamain').value);
    let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

    let dataForExcel = [];  
    let counters = [
        0,    //all records
        0,    //correct
        0,    //wrong
        0,    //doubled
        0,    //bez greafik
        0,    //obraboten w otchet
        0,    //obraboten w grafik
    ];

    worksheet.eachRow(function (row, rowNumber) {
      if (rowNumber > 15) {

        let obj = {
          raion: row.getCell('B').value,
          unom: row.getCell('D').value ,
          ime: row.getCell('E').value,
          status: '',
        }      

        let chksum  =  (row.getCell('A').value ? String(row.getCell('A').value) : '');

        if (chksum.length>0 && chksum.indexOf('Файлът') == -1) {                     
          counters [0]++;
          let indx = porychkaitems.controls
                .findIndex (t=> md5(String(t.get('idl').value)+'|'+
                                    String(t.get('idured').value)+'|'+
                                    idporychkamain) == chksum); 

          if (indx > -1) {
              let lstatus = row.getCell('P').value ? row.getCell('P').value.toString(): '0';
              let item = porychkaitems.controls[indx];

              if (item.get('status_m').value > 0) {
                counters [5]++;
                obj.status = 'Обработен в отчет';    
              } else if (item.get('status_g').value < 2) {
                  let ldodata = moment(row.getCell('L').value as Date).format(DATE_FORMAT);

                  if ((lstatus.length ==0 || lstatus === '0') && ldodata.indexOf('Invalid') > -1) {
                      obj.status = '';    
                      counters [4]++;
                  } else if (lstatus.substring(0,1) === '0') {
                      obj.status = 'Невалиден статус';    
                      counters [2]++;
                  } else if (lstatus.substring(0,1) === '1' && ldodata.indexOf('Invalid') > -1) {
                      obj.status = 'Невалидна дата';  
                      counters [2]++;
                  } else if (lstatus.substring(0,1) === item.get('status_g').value) {
                      counters [3]++;
                      obj.status = 'Дублиран запис';    
                  } else {
                    counters [1]++;
                    obj.status = 'За регистрация';

                    let lotchas = row.getCell('M').value ? row.getCell('M').value : '';
                    let ldochas = row.getCell('N').value ? row.getCell('N').value : '';
                    let lnote   = row.getCell('O').value ? row.getCell('O').value.toString() : '';

                    let h1 = moment.utc(lotchas as Date).format(TIME_FORMAT);
                    let h2 = moment.utc(ldochas as Date).format(TIME_FORMAT);

                    let d: ImportGrafik = {
                      chksum: chksum,
                      dodata: (ldodata.indexOf('Invalid') > -1 ? '' : ldodata),
                      otchas: (h1.indexOf('Invalid') > -1 ? '' : h1),
                      dochas: (h2.indexOf('Invalid') > -1 ? '' : h2),
                      note: lnote,
                      status_g: lstatus.substring(0,1),
                    }      

                    dataImportGrafik.push(d);
                  }
              } else if (lstatus.substring(0,1) == item.get('status_g').value) {
                counters [3]++;
                obj.status = 'Дублиран запис';    
              } else {
                counters [6]++;
                obj.status = 'Обработен в график';    
              }
          } else {
            counters [2]++;
            obj.status = 'Невалиден идентификатор'    
          }
          
          if (obj.status.length > 0) {
            dataForExcel.push(Object.values(obj))      
          }  
        }    
      }  
    });

    //add summary counters
    let obj = {
      raion: '',
      unom: '' ,
      ime: 'За регистрация',
      status: counters [1],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Грешни записи',
      status: counters [2],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Дублирани записи',
      status: counters [3],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Без график',
      status: counters [4],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Обработени в отчет',
      status: counters [5],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Обработени в график',
      status: counters [6],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Всичко',
      status: counters [0],
    }      
    dataForExcel.push(Object.values(obj))      

    let firma = this.vmonfirmi.find(e => e.nkod === this.mainForm.get('idfirma').value);
    let fname = firma ? firma.name.substring(firma.name.indexOf(" ")) : ''
    let dogovor = this.vmonfirmidogovor.find(e => e.nkod === this.mainForm.get('iddogovorfirma').value);
    let dognomer = dogovor ? dogovor.name.substring(0, dogovor.name.indexOf("/")) : ''

    let reportData = {
      title: 'Резултат от обработката на график - монтаж',
      sheet: 'Справка',
      colsizes: [0,5,15,35,50],
      header: ['№','№ ОПОС','Имена','Резултат'],
      data: dataForExcel,
      fname: fname,
      dogovor: dognomer.trim(),
      filename: this.mainForm.get('idporychkamain').value+'_'+
                'РезултатГМ_'+dognomer.trim()
    };
    
    this.excelService.exportExcel(reportData);  
    this.dataImportGrafik = dataImportGrafik;
      
    return counters [2];      
  }


  async checkImportMontazj (filename: any) {
    const md5 = require("md5")
    const DATE_FORMAT = 'DD.MM.YYYY'; 

    let dataImportMontazj = new Array();

    const workbook = new Workbook();
    const blob = new Blob([filename], 
      { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
    const buffer = await blob.arrayBuffer()
    await workbook.xlsx.load(buffer);

    const worksheet = workbook.getWorksheet(1);

    let idporychkamain = String(this.mainForm.get('idporychkamain').value);
    let porychkaitems = this.mainForm.get("porychkaitems") as FormArray;

    let dataForExcel = [];  
    let counters = [
        0,    //all records
        0,    //correct
        0,    //wrong
        0,    //doubled
        0,    // без монтаж
        0,    // obraboten w otchet
        0,    // obraboten w график
    ];
  
    let images: any[] = [];
    
    for (const image of worksheet.getImages()) {
        const img = workbook.model.media[image.imageId];
        let imgitem = {
          'row': image.range.br.nativeRow,
          'col': image.range.br.nativeCol,
          'name': img.name,
          'extension': img.extension,
          'str64base': this.get64BaseString(img),  
          'safeUrl': this.getSafeUrl(this.get64BaseString(img))  
        }
        images.push (imgitem);
    }

    worksheet.eachRow(function (row, rowNumber) {
      if (rowNumber > 15) {
        let obj = {
          raion: row.getCell('B').value,
          unom: row.getCell('D').value ,
          ime: row.getCell('E').value,
          status: '',
        }      

        let chksum  =  (row.getCell('A').value ? String(row.getCell('A').value) : '');

        if (chksum.length>0 && chksum.indexOf('Файлът') == -1) {    
          counters [0]++;                 

          let indx = porychkaitems.controls
              .findIndex (t=> md5(String(t.get('idl').value)+'|'+
                                  String(t.get('idured').value)+'|'+
                                  idporychkamain) == chksum); 
          if (indx > -1) {
            let item = porychkaitems.controls[indx];
            let status = (row.getCell('Q').value ? row.getCell('Q').value.toString() : '0');
            
            if (item.get('status_m').value < 2) {
                let mondata = moment(row.getCell('R').value as Date).format(DATE_FORMAT);

                if (item.get('status_g').value > 1 && status.substring(0,1) !== '0') {
                  counters [6]++;
                  obj.status = 'Обработен в график';  

                } else if ((status.length ==0 || status === '0') && mondata.indexOf('Invalid') > -1) {
                    obj.status = '';    
                    counters [4]++;

                } else if (status.substring(0,1) === '0') {
                    obj.status = 'Невалиден статус';    
                    counters [2]++;

                } else if (status.substring(0,1) === '1' && mondata.indexOf('Invalid') > -1) {
                    obj.status = 'Невалидна дата';  
                    counters [2]++;

                } else if (status.substring(0,1) != '1' && item.get('status_m').value == 1) {
                    obj.status = 'Обработен в отчет';    
                    counters [5]++;
                    
                } else {
                    counters [1]++;
                    obj.status = 'За регистрация';

                    let model = row.getCell('S').value;
                    let fabrnomer = row.getCell('T').value;
                    let garkarta = row.getCell('U').value;
                    let gardata = moment(row.getCell('V').value as Date).format(DATE_FORMAT);
                    let protdata = moment(row.getCell('W').value as Date).format(DATE_FORMAT);
                    let note = row.getCell('X').value;
    
                    let img = images.find(({row}) => row === rowNumber-1);
                    if (img) {
                      item.get('snimka').setValue(img.str64base);
                      item.get('safeurl').setValue(img.safeUrl);
                    }                    

                    let d: importMontazj = {
                      chksum: chksum,
                      status_m: status.substring(0,1),
                      mondata: mondata,
                      model: (model ? model.toString() : ''),
                      fabrnomer: (fabrnomer ? fabrnomer.toString() : ''),
                      garkarta: (garkarta ? garkarta.toString() : ''),
                      gardata: (gardata.indexOf('Invalid') > -1 ? '' : gardata),
                      protnomer: '',
                      protdata: (protdata.indexOf('Invalid') > -1 ? '' : protdata),
                      note: (note ? note.toString() : ''),
                      snimka: (img ? img.str64base : ''),
                      safeurl: (img ? img.safeUrl : '')  
                    }      

                    dataImportMontazj.push(d);
                } 
            } else if (status.substring(0,1) == item.get('status_m').value) {
                counters [3]++;
                obj.status = 'Дублиран запис';    
            } else {
              counters [5]++;
              obj.status = 'Обработен в отчет';    
            }
          } else {
            counters [2]++;
            obj.status = 'Невалиден идентификатор'    
          }

          if (obj.status.length > 0) {
            dataForExcel.push(Object.values(obj))      
          }  
        }
      }    
    });

    //add summary counters
    let obj = {
      raion: '',
      unom: '' ,
      ime: 'За регистрация',
      status: counters [1],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Грешни записи',
      status: counters [2],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Дублирани записи',
      status: counters [3],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Обработени в отчет',
      status: counters [5],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Обработени в график',
      status: counters [6],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Без данни',
      status: counters [4],
    }      
    dataForExcel.push(Object.values(obj))      

    obj = {
      raion: '',
      unom: '' ,
      ime: 'Всичко',
      status: counters [0],
    }      
    dataForExcel.push(Object.values(obj))   

    let firma = this.vmonfirmi.find(e => e.nkod === this.mainForm.get('idfirma').value);
    let fname = firma ? firma.name.substring(firma.name.indexOf(" ")) : ''
    let dogovor = this.vmonfirmidogovor.find(e => e.nkod === this.mainForm.get('iddogovorfirma').value);
    let dognomer = dogovor ? dogovor.name.substring(0, dogovor.name.indexOf("/")) : ''

    let reportData = {
      title: 'Резултат от обработката на отчет - монтаж',
      sheet: 'Справка',
      colsizes: [0,5,15,35,50],
      header: ['№','№ ОПОС','Имена','Резултат'],
      data: dataForExcel,
      fname: fname,
      dogovor: dognomer.trim(),
      filename: this.mainForm.get('idporychkamain').value+'_'+
                'РезултатОМ_'+dognomer.trim()
    };

    this.excelService.exportExcel(reportData);  
    this.dataImportMontazj = dataImportMontazj;
      
    return counters [2];          
  };

  back() {
    this.router.navigateByUrl('pages/obrabotki/monorder');
  }

  handleSuccessResponse() {
    this.toasterService.success("", `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger("", `Грешка при запис!`);
  }
  
}
