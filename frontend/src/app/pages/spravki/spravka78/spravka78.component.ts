import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka60, Spravka78, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import moment from 'moment';
import { LiceData } from '../../../@core/interfaces/common/lica';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';


@Component({
  selector: 'ngx-spravka78',
  templateUrl: './spravka78.component.html',
  styleUrls: ['./spravka78.component.scss']
})
export class Spravka78Component implements OnInit {
  filter: FilterA;
  items: Spravka78 [] = [];
  realItems: Spravka78 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Прекратяване на договори';
  click: boolean = false;

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
    private liceService: LiceData,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toasterService: CustomToastrService
  ) { 
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
  }

  ngOnInit(): void {
    this.loadSpravka();
    this.pageSize = 10;
  }

  loadSpravka() {
    this.spinner.show();       
    this.service
      .getSpravka78(this.filter)
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
    
    let reportData = {
      title: this.filter.descript,
      sheet: 'Прекратяване на договори',
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
    this.router.navigate(['/pages/register/sprfiltera/7/'+this.filter.descript])
  }

  save() {
    this.spinner.show();       

    this.realItems.forEach((item: Spravka78) => {   
      this.liceService
          .setLiceDogovorExpired(item.iddogovor)
          .subscribe(result => {  
            if (this.realItems[this.realItems.length - 1] === item ) { 
                this.spinner.hide();   
            }
      });        
    })

    this.toasterService.success("", `Успешен запис.`);
  }
}




