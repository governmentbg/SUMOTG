import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka20, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';


@Component({
  selector: 'ngx-spravka20',
  templateUrl: './spravka20.component.html',
  styleUrls: ['./spravka20.component.scss']
})
export class Spravka20Component implements OnInit {
  filter: Filter;
  items: Spravka20 [] = [];
  realItems: Spravka20 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka20';

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
      .getSpravka20(this.filter)
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

    this.realItems.forEach((item: Spravka20) => {                  
      obj = {
        raion: item.raion,
        unom: item.unom,
        ime: item.ime,
        status: item.status,
        ime2: item.ime2,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,15,10,40,15,40],
      header: ['Район','ОПОС','Заменени','Основание','Титуляр'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/18/'+this.filter.descript])
  }
}




