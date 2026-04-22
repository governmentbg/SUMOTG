import { Component, OnInit} from '@angular/core';
import { Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Spravka2, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { NgxSpinnerService } from 'ngx-spinner';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Filter } from '../../application/components/filter/filter.settings';

@Component({
  selector: 'ngx-spravka2',
  templateUrl: './spravka2.component.html',
  styleUrls: ['./spravka2.component.scss']
})
export class Spravka2Component implements OnInit {
  filter: Filter;
  items: Spravka2 [] = [];
  realItems: Spravka2 [] = [];

  page: number      = 1;
  pageSize: number  = 10;
  countItems:number = 0;
  fileName:string   = 'Spravka2';

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
    private _location: Location
  ) { 
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
  }

  ngOnInit(): void {
    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.loadSpravka();
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka2(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }


  editLice($data: Spravka2) {
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

    this.realItems.forEach((item: Spravka2) => {                  
      obj = {
        nomer: ++ncnt,
        unom: item.unom,
        raion: item.raion,
        ime: item.ime,
        uredi: item.txturedi ? item.txturedi.replace('\r\n',';') : '',
        olduredi: item.txtolduredi ? item.txtolduredi.replace('\r\n',';') : '',
        status: item.status,
        statusF: item.statusF,
        adres: item.adres,
        vidimot: item.vidimot,
        telefon: item.telefon,
        e_mail: item.e_mail,
        komentar: item.komentar            
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,12,12,30,40,40,10,15,40,40,40,40,40],
      header: ['No','Рег.№','Район','Имена','За монтаж','За демонтаж','Статус на лице'
              ,'Статус на формуляр', 'Адрес','Вид имот','Телефон','Еmail','Коментар'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/11/'+this.filter.descript])
  }
}

