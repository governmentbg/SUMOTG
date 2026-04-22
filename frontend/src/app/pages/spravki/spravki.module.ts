import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgxPrintModule} from 'ngx-print';
import { NgxNumbersOnlyDirectiveModule } from 'ngx-numbers-only-directive';
import { ApplicationModule } from '../application/application.module';

import { SpravkiRoutingModule } from './spravki-routing.module';
import { SpravkiComponent } from './spravki.component';
import { CardComponent } from './card/card.component';

import { NbButtonModule
      , NbCardModule
      , NbDialogModule
      , NbIconModule
      , NbInputModule
      , NbSelectModule
      , NbTabsetModule, NbTreeGridModule 
} from '@nebular/theme';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { Spravka1Component } from './spravka1/spravka1/spravka1.component';
import { Filter1Component } from './spravka1/filter1/filter1.component';
import { Spravka2Component } from './spravka2/spravka2.component';
import { Spravka3Component } from './spravka3/spravka3.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { Spravka4Component } from './spravka4/spravka4.component';
import { Spravka5Component } from './spravka5/spravka5.component';
import { Spravka6Component } from './spravka6/spravka6.component';
import { Spravka7Component } from './spravka7/spravka7.component';
import { Spravka8Component } from './spravka8/spravka8.component';
import { Spravka20Component } from './spravka20/spravka20.component';
import { Spravka9Component } from './spravka9/spravka9.component';
import { Spravka10Component } from './spravka10/spravka10.component';
import { Spravka11Component } from './spravka11/spravka11.component';
import { Spravka12Component } from './spravka12/spravka12.component';
import { Spravka13Component } from './spravka13/spravka13.component';
import { Spravka21Component } from './spravka21/spravka21.component';
import { Spravka14Component } from './spravka14/spravka14.component';
import { Spravka15Component } from './spravka15/spravka15.component';
import { Spravka22Component } from './spravka22/spravka22.component';
import { Spravka50Component } from './spravka50/spravka50.component';
import { Spravka51Component } from './spravka51/spravka51.component';
import { Spravka52Component } from './spravka52/spravka52.component';
import { Spravka23Component } from './spravka23/spravka23.component';
import { Spravka61Component } from './spravka61/spravka61.component';
import { Spravka60Component } from './spravka60/spravka60.component';
import { Spravka78Component } from './spravka78/spravka78.component';
import { Spravka79Component } from './spravka79/spravka79.component';
import { Spravka70Component } from './spravka70/spravka70.component';
import { Spravka71Component } from './spravka71/spravka71.component';
import { Spravka72Component } from './spravka72/spravka72.component';
import { Spravka24Component } from './spravka24/spravka24.component';
import { Spravka62Component } from './spravka62/spravka62.component';
import { Spravka73Component } from './spravka73/spravka73.component';
import { Spravka25Component } from './spravka25/spravka25.component';


@NgModule({
  declarations: [
    SpravkiComponent,
    CardComponent,
    Filter1Component,
    Spravka1Component,
    Spravka2Component,
    Spravka3Component,
    Spravka4Component,
    Spravka5Component,
    Spravka6Component,
    Spravka7Component,
    Spravka8Component,
    Spravka9Component,
    Spravka10Component,
    Spravka11Component,
    Spravka12Component,
    Spravka13Component,
    Spravka14Component,
    Spravka15Component,
    Spravka20Component,
    Spravka21Component,
    Spravka22Component,
    Spravka23Component,
    Spravka24Component,
    Spravka25Component,
    Spravka50Component,
    Spravka51Component,
    Spravka52Component,
    Spravka60Component,
    Spravka61Component,
    Spravka62Component,
    Spravka70Component,
    Spravka71Component,
    Spravka72Component,
    Spravka73Component,
    Spravka78Component,
    Spravka79Component,
  ],
  imports: [
    NgbModule,
    CommonModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NbCardModule ,
    NbButtonModule,
    NbIconModule,
    NbTreeGridModule,
    NbDialogModule.forRoot(),
    NbSelectModule,
    NbInputModule,
    NgSelectModule,
    NgxNumbersOnlyDirectiveModule,
    SpravkiRoutingModule,
    NgxPrintModule,
    ApplicationModule,
    NgxSpinnerModule,
    NbTabsetModule,
  ],
})
export class SpravkiModule { }
