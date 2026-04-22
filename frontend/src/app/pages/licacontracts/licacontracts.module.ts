import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LicacontractsRoutingModule } from './licacontracts-routing.module';
import { LicacontractsComponent } from './licacontracts.component';
import { DogovorComponent } from './dogovor/dogovor.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FlexLayoutModule } from '@angular/flex-layout';

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
  NbTabsetModule,
} from '@nebular/theme';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicationModule } from '../application/application.module';
import { NgxSpinnerModule } from 'ngx-spinner';

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
  NbTabsetModule,
];
@NgModule({
  declarations: [
    LicacontractsComponent,
    DogovorComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    FlexLayoutModule,
    NB_MODULES,
    LicacontractsRoutingModule,
    ApplicationModule,
    NgxSpinnerModule,
  ],
})
export class LicacontractsModule { }
