import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  NbCardModule,
  NbAlertModule,
  NbSpinnerModule,
  NbButtonModule,
  NbStepperModule,
  NbIconModule,
  NbSelectModule,
  NbInputModule,
  NbRadioModule,
  NbTooltipModule,
  NbSearchModule,
  NbAccordionModule,
  NbLayoutModule,
  NbTabsetModule,
} from '@nebular/theme';

import { FirmcontractsRoutingModule } from './firmcontracts-routing.module';
import { MontazjComponent } from './montazj/montazj.component';
import { DemontazjComponent } from './demontazj/demontazj.component';
import { MonContractComponent } from './montazj/moncontract/moncontract.component';
import { ApplicationModule } from '../application/application.module';
import { DeMonContractComponent } from './demontazj/demoncontract/demoncontract.component';

export const NB_MODULES = [
  NbCardModule,
  NbAlertModule,
  NbSpinnerModule,
  NbButtonModule,
  NbStepperModule,
  NbIconModule,
  NbSelectModule,
  NbInputModule,
  NbRadioModule,
  NbTooltipModule,
  NbSearchModule,
  NbAccordionModule ,
  NbLayoutModule,
  NbTabsetModule,
];

@NgModule({
  declarations: [
    MontazjComponent, 
    DemontazjComponent, 
    MonContractComponent,
    DeMonContractComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    FlexLayoutModule,
    FirmcontractsRoutingModule,
    ApplicationModule,
    NB_MODULES,
  ]
})
export class FirmcontractsModule { }
