import { Component, OnInit} from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka52, Spravka53, Spravka54, Spravka55, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import _ from 'lodash';
import { Router } from '@angular/router';
import { ExportSpravkaFP4Service } from '../../../@theme/services/export-spravkaFP4-excel.service';

@Component({
  selector: 'ngx-spravka52',
  templateUrl: './spravka52.component.html',
  styleUrls: ['./spravka52.component.scss']
})
export class Spravka52Component implements OnInit {
  filter: Filter;
  items52: Spravka52 [] = [];
  items53: Spravka53 [] = [];
  items54: Spravka54 [] = [];
  items550: Spravka55 [] = [];
  items551: Spravka55 [] = [];
  items552: Spravka55 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Фактически и предстоящ за изразходване бюджет';
  sumbroi550 = 0;
  sumemis550: number = 0;
  sumbroi551 = 0;
  sumemis551: number = 0;
  sumbroiuredi550 = 0;
  sumemisuredi550: number = 0;
  sumbroiuredi551 = 0;
  sumemisuredi551: number = 0;

  constructor(
    private ete: ExportSpravkaFP4Service,
    private service: SpravkiData,
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
        .getSpravka52()
        .subscribe(result => {
            this.items52 = result;
            this.spinner.hide();   
      });  

      this.service
        .getSpravka53()
        .subscribe(result => {
            this.items53 = result;
            this.spinner.hide();   
      });  

      this.service
        .getSpravka54()
        .subscribe(result => {
            this.items54 = result;
            this.spinner.hide();   
      });  

      this.service
        .getSpravka55(0)
        .subscribe(result => {
            this.items550 = result;
            this.sumbroi550 = this.items550.reduce((sum, current) => sum + current.broi, 0);            
            this.sumemis550 = this.items550.reduce((sum, current) => sum + current.calc, 0);  
            this.sumbroiuredi550 = this.items550.reduce((sum, current) => sum + current.broiuredi, 0); 
            this.sumemisuredi550 = this.items550.reduce((sum, current) => sum + current.calcuredi, 0);            
            this.spinner.hide();   
      });  

      this.service
        .getSpravka55(1)
        .subscribe(result => {
            this.items551 = result;
            this.sumbroi551 = this.items551.reduce((sum, current) => sum + current.broi, 0);            
            this.sumemis551 = this.items551.reduce((sum, current) => sum + current.calc, 0);            
            this.sumbroiuredi551 = this.items551.reduce((sum, current) => sum + current.broiuredi, 0);
            this.sumemisuredi551 = this.items551.reduce((sum, current) => sum + current.calcuredi, 0);
            this.spinner.hide();   
      });  

      this.service
        .getSpravka56()
        .subscribe(result => {
            this.items552 = result;
            this.spinner.hide();   
      });  

  }

  exportexcel(): void {
    let items550 = [...this.items550];
    items550.push({
          id: 999999,
          nime: "Всичко",
          broi: this.sumbroi550,
          calc: this.sumemis550,
          broiuredi: this.sumbroiuredi550,
          calcuredi: this.sumemisuredi550
    })

    let items551 = [...this.items551];
    items551.push({
      id: 999999,
      nime: "Всичко",
      broi: this.sumbroi551,
      calc: this.sumemis551,
      broiuredi: this.sumbroiuredi551,
      calcuredi: this.sumemisuredi551
    })

    this.ete.exportSpravka(this.items52, this.items53, this.items54, 
                           items550, items551, this.items552);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/50a/'+this.filter.descript])
  }
}




