import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka6, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportSpravkiService } from '../../../@theme/services/export-spravki.service';


@Component({
  selector: 'ngx-spravka10',
  templateUrl: './spravka10.component.html',
  styleUrls: ['./spravka10.component.scss']
})
export class Spravka10Component implements OnInit {
  filter: Filter;
  items: Spravka6 [] = [];
  realItems: Spravka6 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka6';

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
      .getSpravka10(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });  
  }


  editDogovor($data: Spravka6) {
    const url = '/pages/firmcontracts/moncontract/' + 
                $data.idfirma + '/' + 
                ($data.ime.length>0?$data.ime:'[няма]')+'/'+
                $data.iddog+'/'+
                true;
      this.router.navigateByUrl(url);
  }  

  exportexcel(): void {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka6) => {                  
      obj = {
        ime: item.ime,
        dogovor: item.dogovor,
        kodured: item.kodured,
        imeured: item.imeured,
        edcena: item.edcena,
        tspbroi: item.tspbroi,
        tsptotal: item.tsptotal,
        ordbroi: item.ordbroi,
        rembroi: item.rembroi,
        ostbroi: item.tspbroi - item.ordbroi + item.rembroi,
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
      filter: this.filter.txtfilter,
    };

    this.ete.exportSpravka6(reportData,2);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/20/'+this.filter.descript])
  }
}




