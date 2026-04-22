import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka50, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import _ from 'lodash';

@Component({
  selector: 'ngx-spravka51',
  templateUrl: './spravka51.component.html',
  styleUrls: ['./spravka51.component.scss']
})
export class Spravka51Component implements OnInit {
  filter: Filter;
  items: Spravka50 [] = [];
  realItems: Spravka50 [] = [];
  groups: Spravka50 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Фактически и предстоящ за изразходване бюджет';


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
    this.pageSize =  this.pageSize + 3-(this.pageSize % 3);
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka51(this.filter)
      .subscribe(result => {
          this.realItems = result;
          this.countItems = this.realItems.length;

          this.items = result;
          this.spinner.hide();   
      });  
  }


  exportexcel(): void {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka50) => {   
      obj = {
        code: ++ncnt,
        ured: item.ured,
        tip: this.getRowText(item),
        price: item.price ,
        broi: item.broi,
        budget: item.budget,
        calcbudget: item.calcbudget,
        procbudget: item.procbudget,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Фактически и предстоящ за изразходване бюджет',
      colsizes: [0,5,50,20,20,20,20,20,20],
      header: [
        '№'  
        ,'Уреди'  
        ,'Тип'  
        ,'Средна ед.цена в евро'
        ,'Брой уреди'
        ,'Планиран Бюджет в евро'   
        ,'Изчислен Бюджет в евро'
        ,'% на изчислен бюджет'
      ],
      data: dataForExcel,
      filename: this.fileName,
      headersize: 20,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/51/'+this.filter.descript])
  }

  getRowText(item: Spravka50) {
    var txt = 'общо'; 
    if (item.tip === 1)
        txt = 'дг/зв';
    else if (item.tip === 2)
        txt = 'в обр.';
    return txt;
  }
}




