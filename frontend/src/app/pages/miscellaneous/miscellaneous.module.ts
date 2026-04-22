/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { NgModule } from '@angular/core';
import { NbAccordionModule, NbAlertModule, NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbLayoutModule, NbRadioModule, NbSearchModule, NbSelectModule, NbSpinnerModule, NbStepperModule, NbTabsetModule, NbTooltipModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { MiscellaneousRoutingModule } from './miscellaneous-routing.module';
import { MiscellaneousComponent } from './miscellaneous.component';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  imports: [
    ThemeModule,
    NbCardModule,
    NbButtonModule,
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
    MiscellaneousRoutingModule,
  ],
  declarations: [
    MiscellaneousComponent,
    NotFoundComponent,
  ],
})
export class MiscellaneousModule { }
