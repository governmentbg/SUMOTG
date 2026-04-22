import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka60, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import moment from 'moment';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';


@Component({
  selector: 'ngx-spravka61',
  templateUrl: './spravka61.component.html',
  styleUrls: ['./spravka61.component.scss']
})
export class Spravka61Component implements OnInit {
  filter: FilterA;
  items: Spravka60 [] = [];
  realItems: Spravka60 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Списък на неотчетени профилактики';
  limit: number = 0;

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
  ) { 
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
    this.filter.statusPF = 1;
  }

  ngOnInit(): void {
    this.loadSpravka();
    this.pageSize = Screens.setPageSize(window.innerHeight);
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka61(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;

          this.spinner.hide();   
      });  
  }


  exportexcel(): void {
    const DATE_FORMAT = 'DD.MM.YYYY';
    
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka60) => {   
      obj = {
        unom: item.unom,
        idporychka: item.idporychka,
        ured: item.ured,
        ime: item.ime,
        adres: item.adres,
        period: item.period,
        pnomer: item.pnomer,
        data:  moment(item.data).format(DATE_FORMAT),
        otchdata:  (item.otchdata ? moment(item.otchdata).format(DATE_FORMAT) : ''),
        dogfirma: item.dogfirma,
        namefirma: item.namefirma,
        status: item.status,
      }      

      dataForExcel.push(Object.values(obj))
    })
    
    let reportData = {
      title: this.filter.descript,
      sheet: 'Списък на Профилактиките',
      colsizes: [0,15,10,30,30,40,10,5,15,15,15,30,15],
      header: [
        ,'ОПОС'  
        ,'№ Поръчка'  
        ,'Уред'
        ,'Лице'
        ,'Адрес'   
        ,'Период (мес.)'
        ,'№'
        ,'Планирана дата '
        ,'Отчетена дата'
        ,'Договор'
        ,'Име на фирма'
        ,'Статус'
      ],
      data: dataForExcel,
      filename: this.fileName,
      headersize: 20,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/sprfiltera/6/'+this.filter.descript])
  }

}




