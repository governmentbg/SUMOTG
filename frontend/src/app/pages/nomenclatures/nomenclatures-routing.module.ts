import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonComponent } from './common/common.component';
import { JkComponent } from './jk/jk.component';
import { KmetstvaComponent } from './kmetstva/kmetstva.component';
import { NomenclaturesComponent } from './nomenclatures.component';
import { NsmestaComponent } from './nsmesta/nsmesta.component';
import { RaioniComponent } from './raioni/raioni.component';
import { UliciComponent } from './ulici/ulici.component';
import { UrediComponent } from './uredi/uredi.component';
import { ExtraAddressesComponent } from './extaddresses/extra-addresses.component';
import { UrediBudgetComponent } from './uredi-budget/uredi-budget.component';

const routes: Routes = [
  {
    path: 'common/:nomcode/:name/:disable', component: CommonComponent,
  },
  {
    path: 'jk/:name/:disable', component: JkComponent,
  },
  {
    path: 'kmetstva/:name/:disable', component: KmetstvaComponent,
  },
  {
    path: 'ulici/:name/:disable', component: UliciComponent,
  },
  {
    path: 'nsmesta/:name/:disable', component: NsmestaComponent,
  },
  {
    path: 'raioni/:name/:disable', component: RaioniComponent,
  },
  {
    path: 'uredi/:name/:disable', component: UrediComponent,
  },
  {
    path: 'uredibudget/:name/:disable', component: UrediBudgetComponent,
  },
  {
    path: 'extadreses', component: ExtraAddressesComponent,
  },
  {
      path: '', component: NomenclaturesComponent,
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NomenclaturesRoutingModule { }
