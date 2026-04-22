import { Component, OnInit} from '@angular/core';
import { Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka2, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka3',
  templateUrl: './spravka3.component.html',
  styleUrls: ['./spravka3.component.scss']
})
export class Spravka3Component implements OnInit {
  filter: Filter;
  items: Spravka2 [] = [];
  realItems: Spravka2 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka3';

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
      .getSpravka3(this.filter)
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
        dognomer: (item.dognomer ? item.dognomer+'/'+item.dogdate :  ''),
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
        komentar: item.komentar,
        dopspnom: item.dopspnom, 
        dopspvid: item.dopspvid         
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,12,12,12,30,40,40,10,15,40,20,20,20,50,30,30],
      header: ['No','Рег.№','№ Договор','Район','Имена','За монтаж','За демонтаж','Статус на лице'
              ,'Статус на Договор', 'Адрес','Вид имот','Телефон','Еmail','Коментар'
              ,'Доп. споразумение №/дата','Доп. споразумение вид'],
      headersize:40,        
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/12/'+this.filter.descript])
  }
}




