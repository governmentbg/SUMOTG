import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Spravka78, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import moment from 'moment';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';


@Component({
  selector: 'ngx-spravka73',
  templateUrl: './spravka73.component.html',
  styleUrls: ['./spravka73.component.scss']
})
export class Spravka73Component implements OnInit {
  filter: FilterA;
  items: Spravka78 [] = [];
  realItems: Spravka78 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= '73 Справка за договори с лица, предстоящи за изтичане';
  click: boolean = false;

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
      .getSpravka72(1,this.filter)
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

    this.realItems.forEach((item: Spravka78) => {   
      obj = {
        raion: item.raion,
        unom: item.unom,
        ime: item.ime,
        adres: item.adres,
        dogovor: item.dogovor,
        srok: item.srok,
        data:  moment(item.data).format(DATE_FORMAT),
      }      

      dataForExcel.push(Object.values(obj))
    })
    
    let kymdata = (this.filter.kymdata ? moment(this.filter.kymdata).format(DATE_FORMAT) : '31.12.2100')

    let reportData = {
      title: 'Договори с лица предстоящи за изтичане към дата: '+kymdata,
      sheet: 'Справка за договори с лица, предстоящи за изтичане',
      colsizes: [0,20,15,30,40,20,5,15],
      header: [
        'Район'  
        ,'ОПОС'  
        ,'Лице'
        ,'Адрес'   
        ,'Договор'
        ,'Срок (мес.)'
        ,'На дата '
      ],
      data: dataForExcel,
      filename: this.fileName,
      headersize: 20,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/sprfiltera/11/'+this.filter.descript])
  }

}




