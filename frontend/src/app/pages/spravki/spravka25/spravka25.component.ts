import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka25, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportSpravki25Service } from '../../../@theme/services/export-spravki25.service';


@Component({
  selector: 'ngx-spravka25',
  templateUrl: './spravka25.component.html',
  styleUrls: ['./spravka25.component.scss']
})
export class Spravka25Component implements OnInit {
  filter: Filter;
  items: Spravka25 [] = [];
  realItems: Spravka25 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka24';

  constructor(
    private ete: ExportSpravki25Service,
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
      .getSpravka25(this.filter)
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
    let sumdata = [0,0,0,0];

    this.realItems.forEach((item: Spravka25) => {    
      sumdata[0] = sumdata[0]+ item.dbroi;
      sumdata[1] = sumdata[1]+ item.vbroi;
      sumdata[2] = sumdata[2]+ item.sbroi;
      sumdata[3] = sumdata[3]+ item.mbroi;

      obj = {
        rowid: ++ncnt,
        raion: item.raion,
        ime: item.ime,
        dbroi: item.dbroi,
        vbroi: item.vbroi,
        sbroi: item.sbroi,
        broi:item.dbroi+item.vbroi+item.sbroi,
        montazj: item.montazj,
        mbroi: item.mbroi,
        adres: item.adres,
        tel: item.tel,
        email: item.email,
        descript: item.descript
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      data: dataForExcel,
      sums: sumdata,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/25/'+this.filter.descript])
  }
}




