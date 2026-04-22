import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonOrderComponent } from './monorder/monorder.component';
import { ObrabotkiComponent } from './obrabotki.component';
import { DemOrderComponent } from './demorder/demorder.component';
import { MonordereditComponent } from './monorder/monorder-edit/monorderedit.component';
import { DemordereditComponent } from './demorder/demorder-edit/demorderedit.component';
import { MonfakturiListComponent } from './monfakturi/monfakturi-list/monfakturi-list.component';
import { MonfakturiEditComponent } from './monfakturi/monfakturi-edit/monfakturi-edit.component';
import { DemfakturiEditComponent } from './demfakturi/demfakturi-edit/demfakturi-edit.component';
import { DemfakturiListComponent } from './demfakturi/demfakturi-list/demfakturi-list.component';
import { DemorderImportSofEkoComponent } from './demorder/demorder-import-sofeko/demorder-import-sofeko.component';
import { ProfOrderEditComponent } from './profilaktika/proforderedit.component';
import { ImportProfiComponent } from './profilaktika/importprof/importprof.component';

const routes: Routes = [
  {
    path: 'monorder', component: MonOrderComponent,
  },
  {
    path: 'monorderedit/:id/:name/:iddog/:disable', component: MonordereditComponent,
  },
  {
    path: 'demorder', component: DemOrderComponent,
  },
  {
    path: 'demorderedit/:id/:name/:iddog/:disable', component: DemordereditComponent,
  },
  {
    path: 'demsofekostroi', component: DemorderImportSofEkoComponent,
  },
  {
    path: 'monfakturi', component: MonfakturiListComponent,
  },
  {
    path: 'monfakturiedit/:id/:name/:idfaktura/:disable', component: MonfakturiEditComponent,
  },
  {
    path: 'demfakturi', component: DemfakturiListComponent,
  },
  {
    path: 'demfakturiedit/:id/:name/:idfaktura/:disable', component: DemfakturiEditComponent,
  },
  {
    path: 'proforderedit', component: ProfOrderEditComponent
  },
  {
    path: 'importprof', component: ImportProfiComponent,
  },
  {
    path: '', component: ObrabotkiComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ObrabotkiRoutingModule { }
