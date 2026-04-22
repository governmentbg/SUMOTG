import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka5, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka23',
  templateUrl: './spravka23.component.html',
  styleUrls: ['./spravka23.component.scss']
})
export class Spravka23Component implements OnInit {
  filter: Filter;
  items: Spravka5 [] = [];
  realItems: Spravka5 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka5a';

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
      .getSpravka23(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }


  editLice($data: Spravka5) {
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

    this.realItems.forEach((item: Spravka5) => {                  
      obj = {
        nomer: ++ncnt,
        raion: item.raion,
        unom: item.unom,
        ime: item.ime,
        adres: item.adres,
        nkod: item.nkod,
        ured: item.ured,
        broi: item.broi,
        statusU: item.statusU,
        idporychka: item.idporychka,
        regdog: item.regdog,
        statusDL: item.statusDL,
        tipuredime: item.tipuredime
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,18,15,30,40,10,40,15,20,15,20,20,20],
      header: ['No','Район','№ ОПОС','Имена','Адрес','Код','Уред','Брой','Статус на уреда','№ поръчка','Договор','Статус на договор', 'Тип уред'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/24/'+this.filter.descript])
  }
}




