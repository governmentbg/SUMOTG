import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka50, SpravkaOposPortret, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';


@Component({
  selector: 'ngx-spravka50',
  templateUrl: './spravka50.component.html',
  styleUrls: ['./spravka50.component.scss']
})
export class Spravka50Component implements OnInit {
  filter: Filter;
  items: Spravka50 [] = [];
  realItems: Spravka50 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Достигнати лимити от бюджета';
  limit: number = 0;

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
  ) { 
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
    this.limit = (this.filter.limit ? this.filter.limit : 100);
  }

  ngOnInit(): void {
    this.loadSpravka();
    this.pageSize = Screens.setPageSize(window.innerHeight);
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka50(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;

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
      sheet: 'Достигнати лимити от бюджета',
      colsizes: [0,5,50,20,20,20,20,20],
      header: [
        '№'  
        ,'Уреди'  
        ,'Средна ед.цена в евро'
        ,'Брой монтирани уреди'
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
    this.router.navigate(['/pages/register/regfilter/50/'+this.filter.descript])
  }

  getColor(item: Spravka50) {
    var color = 'white'; 
    if (item.procbudget > this.limit)
        color = 'red';
    return color;
  }
}




