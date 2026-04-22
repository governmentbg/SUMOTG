import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka21, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportSpravki21Service } from '../../../@theme/services/export-spravki21.service';


@Component({
  selector: 'ngx-spravka21',
  templateUrl: './spravka21.component.html',
  styleUrls: ['./spravka21.component.scss']
})
export class Spravka21Component implements OnInit {
  filter: Filter;
  items: Spravka21 [] = [];
  realItems: Spravka21 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka21';

  constructor(
    private ete: ExportSpravki21Service,
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
      .getSpravka21(this.filter)
      .subscribe(result => {
          this.items = result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;

          let totals = {
            nkod: '',
            raion: 'ОБЩО',
            formulqri: 0,
            dogovori: 0,
            doguredi: 0,
            monuredi: 0,
            monurpel: 0,
            monurgaz: 0,
            monurklm: 0,
            monurrad: 0,
            monuredid: 0,
            monurpeld: 0,
            monurgazd: 0,
            monurklmd: 0,
          };

          this.realItems.forEach(x=> {
            totals.formulqri = totals.formulqri + x.formulqri,
            totals.dogovori = totals.dogovori + x.dogovori,
            totals.doguredi = totals.doguredi + x.doguredi,
            totals.monuredi = totals.monuredi + x.monuredi,
            totals.monurpel = totals.monurpel + x.monurpel,
            totals.monurgaz = totals.monurgaz + x.monurgaz,
            totals.monurklm = totals.monurklm + x.monurklm,
            totals.monurrad = totals.monurrad + x.monurrad
            totals.monuredid = totals.monuredid + x.monuredid,
            totals.monurpeld = totals.monurpeld + x.monurpeld,
            totals.monurgazd = totals.monurgazd + x.monurgazd,
            totals.monurklmd = totals.monurklmd + x.monurklmd
          });

          this.realItems.push(totals); 
          this.spinner.hide();   
      });  
  }


  exportexcel(): void {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];

    this.realItems.forEach((item: Spravka21) => {                  
      obj = {
        nkod: item.nkod,
        raion: item.raion,
        formulqri: item.formulqri,
        dogovori: item.dogovori,
        doguredi: item.doguredi,
        monuredi: item.monuredi,
        monuredid: item.monuredid,
        monurpel: item.monurpel,
        monurpeld: item.monurpeld,
        monurgaz: item.monurgaz,
        monurgazd: item.monurgazd,
        monurklm: item.monurklm,
        monurklmd: item.monurklmd,
        monurrad: item.monurrad,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,5,20,15,15,15,10,15,10,15,10,15,10,15,10],
      header: ['№','Район','Кандидати','Сключени договори','Отоплителни уреди'
              ,'Монтирани отоплителни уреди - Общо','','в т.ч. Пелетни', '','в т.ч. Газови',''
              , 'в т.ч. Климатици', '','Монтирани радиатори'],
      header1: ['','','','','','Уреди', 'Домакинства','Уреди', 'Домакинства','Уреди'
              ,'Домакинства','Уреди', 'Домакинства',''],
      data: dataForExcel,
      filename: this.fileName,
      headersize: 40,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/21/'+this.filter.descript])
  }
}




