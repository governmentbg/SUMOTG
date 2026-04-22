import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka14,  Spravka15,  SpravkiData } from '../../../@core/interfaces/common/spravki';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import { Screens } from '../../../@core/tools/screens';


@Component({
  selector: 'ngx-spravka15',
  templateUrl: './spravka15.component.html',
  styleUrls: ['./spravka15.component.scss']
})
export class Spravka15Component implements OnInit {
  filter: Filter;
  items: Spravka15 [] = [];
  realItems: Spravka15 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka15';

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
      .getSpravka15(this.filter)
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

    this.realItems.forEach((item: Spravka15) => {                  
      obj = {
        nomer: ++ncnt,
        unom: item.unom,
        raion: item.raion,
        dogovor: (item.dogovor ? item.dogovor :  ''),
        statusDl : item.statusDl,
        dopspor: item.dopspor,
        viddopspor: item.viddopspor,
        komentar: item.komentar,
        koga: item.koga
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,20,20,30,12,20,40,40,15],
      header: ['No','ОПОС','Район','Договор №/Дата', 'Статус договор'
              ,'Доп.споразумение/заявление №/Дата','Вид','Коментар'
              ,'Дата на регистрация в системата'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter,
      headersize: 40,
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/22/'+this.filter.descript])
  }
}




