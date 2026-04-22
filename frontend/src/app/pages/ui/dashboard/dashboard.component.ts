import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { DashboardTbl, UserData } from '../../../@core/interfaces/common/users';
import { HeaderComponent } from '../../../@theme/components';
@Component({
  selector: 'ngx-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {

  dbname = environment.dbname;
  selectedPhase: string = String(HeaderComponent.faza);
  items: DashboardTbl[]
  items1: DashboardTbl[]
  items2: DashboardTbl[]

  constructor(private userService: UserData) {
  }

  ngOnInit(): void {
    this.loadData();
  }
  
  loadData() {
    this.userService
    .getDashboard(Number(this.selectedPhase))
    .subscribe(result => {
      this.items = result;
      this.items1 = this.items.filter(x => x.nkod < '13');
      this.items2 = this.items.filter(x => x.nkod > '12');

      let cnt1 = 0;
      let cnt2 = 0;
      let cnt3 = 0;
      this.items.forEach(x => {
        cnt1 = cnt1 + x.formulqri;
        cnt2 = cnt2 + x.dogovori;
        cnt3 = cnt3 + x.uredi;
      })

      let obj: DashboardTbl = {
        nkod: '',
        raion: 'ОБЩО за СО',
        formulqri: cnt1,
        dogovori: cnt2,
        uredi: cnt3,
      };

      this.items2.push(obj);
    });  
  }

  changePhaseSelection($event: any) {
    if (Number(this.selectedPhase) > 0 )
        HeaderComponent.faza = Number(this.selectedPhase);

    this.loadData();
  }
}
