import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka4, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka4',
  templateUrl: './spravka4.component.html',
  styleUrls: ['./spravka4.component.scss']
})
export class Spravka4Component implements OnInit {
  filter: Filter;
  items: Spravka4 [] = [];
  realItems: Spravka4 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka4';

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
      .getSpravka4(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }


  editLice($data: Spravka4) {
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

    this.realItems.forEach((item: Spravka4) => {                  
      obj = {
        nomer: ++ncnt,
        raion: item.raion,
        unom: item.unom,
        ime: item.ime,
        statusF: item.statusF,
        statusL: item.statusL,
        statusDL: item.statusDL,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,20,15,40,15,15,15],
      header: ['No','Район','№ ОПОС','Имена','Статус формуляр','Статус на лице','Статус на Договор'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/13/'+this.filter.descript])
  }
}




