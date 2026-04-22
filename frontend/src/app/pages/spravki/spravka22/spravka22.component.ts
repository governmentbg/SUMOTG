import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka21, SpravkaOposPortret, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';


@Component({
  selector: 'ngx-spravka22',
  templateUrl: './spravka22.component.html',
  styleUrls: ['./spravka22.component.scss']
})
export class Spravka22Component implements OnInit {
  filter: Filter;
  items: SpravkaOposPortret [] = [];
  realItems: SpravkaOposPortret [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;

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
      .getOposPortret(this.filter)
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

    this.realItems.forEach((item: SpravkaOposPortret) => {   
      obj = {
        code: ++ncnt,
        text: item.text,
        text2: item.text2,
        isbold: item.isbold
      }      

      dataForExcel.push(Object.values(obj))
    })

    let fileName= 'ПОРТРЕТ на '+ this.realItems[1].text2;

    let reportData = {
      title: this.filter.descript,
      sheet: 'ПОРТРЕТ на ОПОС',
      colsizes: [0,5,35,50],
      header: ['','',''],
      data: dataForExcel,
      filename: fileName,
      headersize: 1,
      filter: ''
    };

    this.ete.exportPortret(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/23/'+this.filter.descript])
  }
}




