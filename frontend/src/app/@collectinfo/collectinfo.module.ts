
import { NgModule} from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, registerLocaleData } from '@angular/common';
import localeBg from '@angular/common/locales/bg';
import { CollectInfoRoutingModule } from './collectinfo-routing.module';
import { CollectionInfoComponent } from './collectioninfo.component';
import { ApplicationModule } from '../pages/application/application.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxCollectInfoComponent,} from './components';

import {
  NbAlertModule,
  NbCardModule,
  NbIconModule,
  NbLayoutModule,
  NbInputModule,
  NbButtonModule,
  NbIconLibraries,
  NbAccordionModule,
  NbRadioModule,
  NbSearchModule,
  NbSelectModule,
  NbSpinnerModule,
  NbStepperModule,
  NbTabsetModule,
  NbTooltipModule,
} from '@nebular/theme';
import { NgxSpinnerModule } from 'ngx-spinner';


const PIPES = [];
const COMPONENTS = [
  NgxCollectInfoComponent,
  CollectionInfoComponent
];

const NB_MODULES = [
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
  declarations: [...PIPES, ...COMPONENTS],
  imports: [
    CommonModule,
    CollectInfoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    FlexLayoutModule,
    ApplicationModule,
    NgxSpinnerModule,
    ...NB_MODULES,
  ],
  exports: [...PIPES],
  providers: [],
})
export class CollectInfoModule {
  constructor(iconsLibrary: NbIconLibraries) { 
    registerLocaleData(localeBg);
  } 
}
