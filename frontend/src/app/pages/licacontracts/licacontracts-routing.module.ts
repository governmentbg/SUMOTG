import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LicacontractsComponent } from './licacontracts.component';
import { DogovorComponent } from './dogovor/dogovor.component';

const routes: Routes = [
  {
    path: 'dogovor/:id/:name/:idformulqr/:disable', component: DogovorComponent,
  },
  { 
    path: '', component: LicacontractsComponent, 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicacontractsRoutingModule { }
