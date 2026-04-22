import { Component, OnInit} from '@angular/core';
import { Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Filter1, Spravka1, SpravkiData } from '../../../../@core/interfaces/common/spravki';
import { Screens } from '../../../../@core/tools/screens';
import { NgxSpinnerService } from "ngx-spinner";
import { ExportExcelService } from '../../../../@theme/services/export-excel.service';

@Component({
  selector: 'ngx-spravka1',
  templateUrl: './spravka1.component.html',
  styleUrls: ['./spravka1.component.scss']
})
export class Spravka1Component implements OnInit {
  filter: Filter1;
  items: Spravka1 [] = [];
  realItems: Spravka1 [] = [];

  page: number      = 1;
  pageSize: number  = 10;
  countItems:number = 0;
  fileName:string   = 'Spravka1';

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private _location: Location,
    private spinner: NgxSpinnerService
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
      .getSpravka1(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();
      });  
  }


  editLice($data: Spravka1) {
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

    this.realItems.forEach((item: Spravka1) => {                  
      obj = {
        nomer: ++ncnt,
        unom: item.unom,
        ime: item.ime,
        tochki1: item.tochki1,
        tochki2: item.tochki2,
        tochki3: item.tochki3,
        tochki4: item.tochki4,
        tochki5: item.tochki5,
        tochki6: item.tochki6,
        tochki7: item.tochki7,
        total: item.total,
        status: item.status,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,13,30,8,8,8,8,8,8,8,8,10],
      header: ['No','Рег.№','Имена','Пок.1','Пок.2','Пок.3','Пок.4','Пок.5','Пок.6','Пок.7','Общо','Статус'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this._location.back();
  }

}

