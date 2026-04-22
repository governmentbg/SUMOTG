import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka8, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';


@Component({
  selector: 'ngx-spravka8',
  templateUrl: './spravka8.component.html',
  styleUrls: ['./spravka8.component.scss']
})
export class Spravka8Component implements OnInit {
  filter: Filter;
  items: Spravka8 [] = [];
  realItems: Spravka8 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka8';

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
      .getSpravka8(this.filter)
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

    this.realItems.forEach((item: Spravka8) => {                  
      obj = {
        kodured: item.kodured,
        imeured: item.imeured,
        dogbroi: item.dogbroi,
        ordbroi: item.ordbroi,
        tspbroi: item.tspbroi,
        inordbroi: item.inordbroi,
        restbroi: item.restbroi,
        newrestbroi: item.newrestbroi,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,10,40,15,15,15,15,15,15],
      headersize: 50,
      header: ['Код','Уред',
              'Заявени за сключване на договори с кандидати',
              'За поръчки (със сключени договори с кандидати)',
              'Брой в Техн. задания',
              'Поръчани',
              'Остатък по Техн. задания',
              'За ново договориране с фирма изпълнител'],
      header1: ['1','2','3','4','5','6','7=(5)-(6)','8=(3)+(4)-(7)'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/17/'+this.filter.descript])
  }
}




