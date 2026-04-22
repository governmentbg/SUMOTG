import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeMonContractComponent } from './demontazj/demoncontract/demoncontract.component';
import { DemontazjComponent } from './demontazj/demontazj.component';
import { MonContractComponent } from './montazj/moncontract/moncontract.component';
import { MontazjComponent } from './montazj/montazj.component';

const routes: Routes = [
  {
    path: 'montazj', component: MontazjComponent,
  },
  {
    path: 'moncontract/:idfirma/:name/:iddog/:disable', component: MonContractComponent,
  },
  {
    path: 'demontazj', component: DemontazjComponent,
  },
  {
    path: 'demoncontract/:idfirma/:name/:iddog/:disable', component: DeMonContractComponent,
  },
  {
    path: '',
    redirectTo: 'montazj',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FirmcontractsRoutingModule { }
