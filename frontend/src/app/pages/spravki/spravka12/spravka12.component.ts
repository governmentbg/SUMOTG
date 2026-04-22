import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Spravka11, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportSpravki11Service } from '../../../@theme/services/export-spravki11.service';
import { FilterA } from '../../application/components/filter-a/filter-a.settings';


@Component({
  selector: 'ngx-spravka12',
  templateUrl: './spravka12.component.html',
  styleUrls: ['./spravka12.component.scss']
})
export class Spravka12Component implements OnInit {
  filter: FilterA;
  items: Spravka11 [] = [];
  realItems: Spravka11 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka12';

  constructor(
    private ete: ExportSpravki11Service,
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
      .getSpravka12(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }

  exportexcel(): void {
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka11) => {                  
      obj = {
        porychka: item.porychka,
        eik: item.eik,
        dogovor: item.dogovor,
        unomer: item.unomer,
        kodured: item.kodured,
        imeured: item.imeured,
        broi: item.broi,
        datag: (!item.datag ? " " : item.datag),
        statusg: item.statusg,
        note: item.note,
        datam: (!item.datam ? " " : item.datam),
        statusm: item.statusm,
        note2: item.note2,
        ime: item.ime,
        adres: item.adres
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

    this.ete.exportSpravka(reportData,2);  
  }

  back() {
    this.router.navigate(['/pages/register/sprfiltera/2/'+this.filter.descript])
  }
}




