import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Filter } from '../../application/components/filter/filter.settings';
import { Spravka13, Spravka8, SpravkiData } from '../../../@core/interfaces/common/spravki';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';


@Component({
  selector: 'ngx-spravka13',
  templateUrl: './spravka13.component.html',
  styleUrls: ['./spravka13.component.scss']
})
export class Spravka13Component implements OnInit {
  filter: Filter;
  items: Spravka13 [] = [];
  realItems: Spravka13 [] = [];

  page = 1;
  pageSize = 10;
  countItems:number = 0;
  fileName= 'Spravka13';

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
      .getSpravka13(this.filter)
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

    this.realItems.forEach((item: Spravka13) => {                  
      obj = {
        kodured: item.kodured,
        imeured: item.imeured,
        l_dogbroi: item.l_dogbroi,
        l_ordbroi: item.l_ordbroi,
        l_inordbroi: item.l_inordbroi,
        p_ingrafik: item.p_ingrafik,
        p_inotchet: item.p_inotchet,
        p_montirani: item.p_montirani,
        l_otkazani: item.l_otkazani,
        p_otkazani: item.p_otkazani,
        p_izklucheni: item.p_izklucheni,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: this.filter.descript,
      sheet: 'Справка',
      colsizes: [0,10,40,15,15,15,15,15,15,15,15,15],
      headersize: 50,
      header: ['Код','Уред',
              'Заявени за сключване на дог. с кандидати',
              'За поръчки (със сключени дог. с кандидати)',
              'Включени в поръчки',
              'Включени в график',
              'Включени в отчет',
              'Монтирани',
              'Отказани ОБЩО ',
              'в т.ч. Отказани чрез График/Отчет ',
              'Изключени чрез График/Отчет (Отложени+ Ненамерени+ За замяна)'
      ],
      header1: ['1','2','3','4','5','6','7','8','9','10','11'],
      data: dataForExcel,
      filename: this.fileName,
      filter: this.filter.txtfilter
    };

    this.ete.exportExcel(reportData);  
  }

  back() {
    this.router.navigate(['/pages/register/sprfiltera/3/'+this.filter.descript])
  }
}




