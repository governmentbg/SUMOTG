import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationComponent } from './application.component';
import { ZaqvlenieComponent } from './formpers/zaqvlenie.component';
import { ZaqvlenieFirmaComponent } from './formfirma/zaqvlenie.firma.component';
import { ZaqvlenieKolektivComponent } from './formkolektiv/zaqvlenie.kolektiv.component';
import { LiceComponent } from './lice-register/lice/lice.component';
import { PersonsComponent } from './lice-register/persons.component';
import { RegisterComponent } from './register/register.component';
import { FirmiComponent } from './firms-register/firmi.component';
import { FirmaComponent } from './firms-register/firma/firma.component';
import { FilterComponent } from './components/filter/filter.component';
import { FilterAComponent } from './components/filter-a/filter-a.component';
import { ImportAksterComponent } from './import-akster/import-akster.component';
import { RadiatorPrekodoraneComponent } from './rad-prekodirane/rad-prekodirane.component';
import { Filter1Component } from '../spravki/spravka1/filter1/filter1.component';

const routes: Routes = [
  {
    path: 'regfilter/:vidfltr',component: FilterComponent,
  },  
  {
    path: 'regfilter/:vidfltr/:descript',component: FilterComponent,
  },  
  {
    path: 'sprfiltera/:vidfltr/:descript',component: FilterAComponent,
  },
  {
    path: 'register/:id', component: RegisterComponent,
  },
  {
    path: 'persons', component: PersonsComponent,
  },
  {
    path: 'firms', component: FirmiComponent,
  },
  {
    path: 'zaqvlenie', component: ZaqvlenieComponent,
  },
  {
    path: 'zaqvlenie/:id/:name/:disable', component: ZaqvlenieComponent,
  },
  {
    path: 'zaqvleniefirma', component: ZaqvlenieFirmaComponent,
  },
  {
    path: 'zaqvleniefirma/:id/:name/:disable', component: ZaqvlenieFirmaComponent,
  },
  {
    path: 'zaqvleniekolektiv', component: ZaqvlenieKolektivComponent,
  },
  {
    path: 'zaqvleniekolektiv/:id/:name/:disable', component: ZaqvlenieKolektivComponent,
  },
  {
    path: 'lice', component: LiceComponent,
  },
  {
    path: 'lice/:id/:name/:idformulqr/:disable', component: LiceComponent,
  },
  {
    path: 'firma', component: FirmaComponent,
  },
  {
    path: 'firma/:id/:name/:idformulqr/:disable', component: FirmaComponent,
  },
  {
    path: 'akster', component: ImportAksterComponent,
  },
  {
    path: 'radprekod', component: RadiatorPrekodoraneComponent,
  },
  {
    path: '.', component: ApplicationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ApplicationRoutingModule { }
