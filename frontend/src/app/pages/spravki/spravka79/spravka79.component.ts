import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka60, Spravka70, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';
import moment from 'moment';
import { LicaService } from '../../../@core/backend/common/services/lica.service';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';


@Component({
  selector: 'ngx-spravka79',
  templateUrl: './spravka79.component.html',
  styleUrls: ['./spravka79.component.scss']
})
export class Spravka79Component implements OnInit {
  filter: FilterA;
  items: Spravka70 [] = [];
  realItems: Spravka70 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Прекратяване на собственост';
  click: boolean = false;

  constructor(
    private ete: ExportExcelService,
    private service: SpravkiData,
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
      .getSpravka79(this.filter)
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

    this.realItems.forEach((item: Spravka70) => {   
      obj = {
        raion: item.raion,
        unom: item.unom,
        ime: item.ime,
        adres: item.adres,
        ured: item.ured,
        srok: item.srok,
        data:  moment(item.data).format(DATE_FORMAT),
      }      

      dataForExcel.push(Object.values(obj))
    })
    
    let reportData = {
      title: this.filter.descript,
      sheet: 'Прекратяване на собственост',
      colsizes: [0,20,15,30,40,20,5,15],
      header: [
        'Район'  
        ,'ОПОС'  
        ,'Лице'
        ,'Адрес'   
        ,'Уред'
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
    this.router.navigate(['/pages/register/sprfiltera/8/'+this.filter.descript])
  }

  save() {
    this.spinner.show();       

    this.realItems.forEach((item: Spravka70) => {   
      this.service
          .setPorychkaUnSign(item.idporychka)
          .subscribe(result => {  
            if (this.realItems[this.realItems.length - 1] === item ) { 
              this.spinner.hide();   
            }
      });        
    })

    this.toasterService.success("", `Успешен запис.`);
  }
}




