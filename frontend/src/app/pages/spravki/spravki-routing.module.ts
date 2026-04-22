import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilterComponent } from '../application/components/filter/filter.component';
import { Filter1Component } from './spravka1/filter1/filter1.component';
import { Spravka1Component } from './spravka1/spravka1/spravka1.component';
import { Spravka10Component } from './spravka10/spravka10.component';
import { Spravka11Component } from './spravka11/spravka11.component';
import { Spravka12Component } from './spravka12/spravka12.component';
import { Spravka13Component } from './spravka13/spravka13.component';
import { Spravka14Component } from './spravka14/spravka14.component';
import { Spravka15Component } from './spravka15/spravka15.component';
import { Spravka2Component } from './spravka2/spravka2.component';
import { Spravka20Component } from './spravka20/spravka20.component';
import { Spravka21Component } from './spravka21/spravka21.component';
import { Spravka22Component } from './spravka22/spravka22.component';
import { Spravka3Component } from './spravka3/spravka3.component';
import { Spravka4Component } from './spravka4/spravka4.component';
import { Spravka5Component } from './spravka5/spravka5.component';
import { Spravka50Component } from './spravka50/spravka50.component';
import { Spravka51Component } from './spravka51/spravka51.component';
import { Spravka6Component } from './spravka6/spravka6.component';
import { Spravka7Component } from './spravka7/spravka7.component';
import { Spravka8Component } from './spravka8/spravka8.component';
import { Spravka9Component } from './spravka9/spravka9.component';
import { SpravkiComponent } from './spravki.component';
import { Spravka52Component } from './spravka52/spravka52.component';
import { Spravka23Component } from './spravka23/spravka23.component';
import { Spravka60Component } from './spravka60/spravka60.component';
import { Spravka61Component } from './spravka61/spravka61.component';
import { Spravka78Component } from './spravka78/spravka78.component';
import { Spravka79Component } from './spravka79/spravka79.component';
import { Spravka70Component } from './spravka70/spravka70.component';
import { Spravka71Component } from './spravka71/spravka71.component';
import { Spravka72Component } from './spravka72/spravka72.component';
import { Spravka24Component } from './spravka24/spravka24.component';
import { Spravka62Component } from './spravka62/spravka62.component';
import { Spravka73Component } from './spravka73/spravka73.component';
import { Spravka25Component } from './spravka25/spravka25.component';

const routes: Routes = [
  {
    path: 'regfilter/:vidfltr',component: FilterComponent,
  },  
  {
    path: 'filter1/:id/:name/:disable',
    component: Filter1Component,
  },
  {
    path: 'spravka1',
    component: Spravka1Component,
  },
  {
    path: 'spravka2',
    component: Spravka2Component,
  },  
  {
    path: 'spravka3',
    component: Spravka3Component,
  },  
  {
    path: 'spravka4',
    component: Spravka4Component,
  },  
  {
    path: 'spravka5',
    component: Spravka5Component,
  },  
  {
    path: 'spravka6',
    component: Spravka6Component,
  },  
  {
    path: 'spravka7',
    component: Spravka7Component,
  },    
  {
    path: 'spravka8',
    component: Spravka8Component,
  },    
  {
    path: 'spravka9',
    component: Spravka9Component,
  },    
  {
    path: 'spravka10',
    component: Spravka10Component,
  },    
  {
    path: 'spravka11',
    component: Spravka11Component,
  },    
  {
    path: 'spravka12',
    component: Spravka12Component,
  },    
  {
    path: 'spravka13',
    component: Spravka13Component,
  },    
  {
    path: 'spravka14',
    component: Spravka14Component,
  },    
  {
    path: 'spravka15',
    component: Spravka15Component,
  },   
  {
    path: 'spravka20',
    component: Spravka20Component,
  },    
  {
    path: 'spravka21',
    component: Spravka21Component,
  },    
  {
    path: 'spravka22',
    component: Spravka22Component,
  },    
  {
    path: 'spravka23',
    component: Spravka23Component,
  },  
  {
    path: 'spravka24',
    component: Spravka24Component,
  },    
  {
    path: 'spravka25',
    component: Spravka25Component,
  },    
  {
    path: 'spravka50',
    component: Spravka50Component,
  },    
  {
    path: 'spravka51',
    component: Spravka51Component,
  },    
  {
    path: 'spravka52',
    component: Spravka52Component,
  },    
  {
    path: 'spravka60',
    component: Spravka60Component,
  },    
  {
    path: 'spravka61',
    component: Spravka61Component,
  },    
  {
    path: 'spravka62',
    component: Spravka62Component,
  },    
  {
    path: 'spravka70',
    component: Spravka70Component,
  },    
  {
    path: 'spravka71',
    component: Spravka71Component,
  },    
  {
    path: 'spravka72',
    component: Spravka72Component,
  },    
  {
    path: 'spravka73',
    component: Spravka73Component,
  },    
  {
    path: 'spravka78',
    component: Spravka78Component,
  },    
  {
    path: 'spravka79',
    component: Spravka79Component,
  },    
  { 
    path: '', 
    component: SpravkiComponent 
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SpravkiRoutingModule { }
