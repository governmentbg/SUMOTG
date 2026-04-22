import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka7, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportSpravkiService } from '../../../@theme/services/export-spravki.service';


@Component({
  selector: 'ngx-spravka7',
  templateUrl: './spravka7.component.html',
  styleUrls: ['./spravka7.component.scss']
})
export class Spravka7Component implements OnInit {
  filter: Filter;
  items: Spravka7 [] = [];
  realItems: Spravka7 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka7';

  constructor(
    private ete: ExportSpravkiService,
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
      .getSpravka7(this.filter)
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

    this.realItems.forEach((item: Spravka7) => {                  
      obj = {
        kodured: item.kodured,
        imeured: item.imeured,
        edcena: item.edcena,
        tspbroi: item.tspbroi,
        tsptotal: item.tsptotal,
        ordbroi: item.ordbroi,
        restordbroi: item.tspbroi-item.ordbroi,
        monbroi: item.monbroi,
        montotal: item.montotal,
        restbroi: item.restbroi,
        resttotal: item.resttotal
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportSpravka7(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/16/'+this.filter.descript])
  }
}




