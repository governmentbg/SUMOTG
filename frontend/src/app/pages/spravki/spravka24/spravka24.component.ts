import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka24, Spravka5, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka24',
  templateUrl: './spravka24.component.html',
  styleUrls: ['./spravka24.component.scss']
})
export class Spravka24Component implements OnInit {
  items: Spravka24 [] = [];
  realItems: Spravka24 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName = 'Дублирани адреси';
  disable: boolean = false;

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
  ) { 
  }

  ngOnInit(): void {
    this.loadSpravka();
    this.pageSize = Screens.setPageSize(window.innerHeight);
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka24()
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
              + this.disable;
      this.router.navigateByUrl(url);
  }  

  exportexcel(): void {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka24) => {                  
      obj = {
        nomer: ++ncnt,
        idl: item.idl,
        opos: item.opos,
        ime: item.ime,
        adres: item.adres,
        statusDL: item.status_dl,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: "Справка 23 – Дублирани адреси",
      sheet: 'Справка',
      colsizes: [0,5,5,15,30,40,15],
      header: ['No','Ид лице ','№ ОПОС','Имена','Адрес','Статус на договор'],
      data: dataForExcel,
      filename: this.fileName,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/spravki'])
  }
}




