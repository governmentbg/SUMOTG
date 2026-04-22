import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka14,  SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka14',
  templateUrl: './spravka14.component.html',
  styleUrls: ['./spravka14.component.scss']
})
export class Spravka14Component implements OnInit {
  filter: Filter;
  items: Spravka14 [] = [];
  realItems: Spravka14 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka14';

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
  ) { 
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
  }

  ngOnInit(): void {
    this.loadSpravka();
    this.pageSize = Screens.setPageSize(window.innerHeight);
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka14(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }


  editLice($data: Spravka14) {
    const url = '/pages/register/lice/' 
              + $data.idl + '/' 
              + $data.ime + '/'
              + $data.idformulqr + '/'
              + this.filter.disable;
      this.router.navigateByUrl(url);
  }  

  exportexcel(): void {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka14) => {                  
      obj = {
        nomer: ++ncnt,
        dognomer: (item.dognomer ? item.dognomer+'/'+item.dogdate :  ''),
        unom: item.unom,
        ime: item.ime,
        raion: item.raion,
        adres: item.adres,
        uredi: item.txturedi ? item.txturedi.replace('\r\n',';') : '',
        statusM: item.statusM,
        dataM: item.dataM,
        porychkaM: item.porychkaM,
        izpalnitel: item.izpalnitel,
        izpdogovor: item.izpdogovor,
        olduredi: item.txtolduredi ? item.txtolduredi.replace('\r\n',';') : '',
        txtkamina: item.txtkamina,
        statusD: item.statusD,
        dataD: item.dataD,
        porychkaD: item.porychkaD,
        statusDl : item.statusDl
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,20,12,20,20,40,40,10,15,10,20,20,40,20,12,12,12,12],
      header: ['No','№ Договор','ОПОС','Имена','Район', 'Адрес'
              ,'Нов опоплителен уред, в т.ч. и радиатори (ако е приложимо)'
              ,'Статус монтаж','Монтаж дата','Включен в Поръчка за монтаж №'
              ,'От изпълнител по проекта','Съгласно сключен договор със Столична община'
              ,'Стар отоплителен уред ','Зидана камина','Статус демонтаж'
              ,'Демонтаж дата','Включен в Поръчка за демонтаж №','Статус дoговор'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter,
      headersize: 40,
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/sprfiltera/4/'+this.filter.descript])
  }
}




