import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxNumbersOnlyDirectiveModule } from 'ngx-numbers-only-directive';
import { ApplicationModule } from '../application/application.module';
import { NgxSpinnerModule } from 'ngx-spinner';

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
  NbCheckboxModule,
} from '@nebular/theme';

import { ObrabotkiRoutingModule } from './obrabotki-routing.module';
import { ObrabotkiComponent } from './obrabotki.component';
import { DemOrderComponent } from './demorder/demorder.component';
import { MonOrderComponent } from './monorder/monorder.component';

import { MonordereditComponent } from './monorder/monorder-edit/monorderedit.component';
import { DemordereditComponent } from './demorder/demorder-edit/demorderedit.component';
import { MonordereditDialogComponent } from './monorder/monorderedit-dialog/monorderedit-dialog.component';
import { DemordereditDialogComponent } from './demorder/demorderedit-dialog/demorderedit-dialog.component';
import { MonorderOrderComponent } from './monorder/monorder-order/monorder-order.component';
import { DemorderOrderComponent } from './demorder/demorder-order/demorder-order.component';
import { PorychkiFilterPipe } from './forms/porychki-filter.pipe';
import { DemorderGraficComponent } from './demorder/demorder-grafic/demorder-grafic.component';
import { MonorderGraficComponent } from './monorder/monorder-grafic/monorder-grafic.component';
import { MonorderMontajComponent } from './monorder/monorder-montaj/monorder-montaj.component';
import { dateFormatPipe } from '../../@theme/pipes/dateFormatPipe';
import { MonfakturiListComponent } from './monfakturi/monfakturi-list/monfakturi-list.component';
import { MonfakturiEditComponent } from './monfakturi/monfakturi-edit/monfakturi-edit.component';
import { DemorderMontajComponent } from './demorder/demorder-montaj/demorder-montaj.component';
import { DemfakturiListComponent } from './demfakturi/demfakturi-list/demfakturi-list.component';
import { DemfakturiEditComponent } from './demfakturi/demfakturi-edit/demfakturi-edit.component';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { FormArrayFilterPipe } from './forms/form-array-filter.pipe';
import { DemorderImportSofEkoComponent } from './demorder/demorder-import-sofeko/demorder-import-sofeko.component';
import { FileFackturaUploadDialogComponent } from './monfakturi/fileupload-dialog/fileupload-dialog.component';
import { ProfOrderEditComponent } from './profilaktika/proforderedit.component';
import { ProfordereditDialogComponent } from './profilaktika/proforderedit-dialog/proforderedit-dialog.component';
import { ImportProfiComponent } from './profilaktika/importprof/importprof.component';


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
  NbCheckboxModule,
];

@NgModule({
  declarations: [
    ObrabotkiComponent, 
    DemOrderComponent, 
    MonOrderComponent, 
    MonordereditComponent, 
    MonorderOrderComponent, 
    MonorderGraficComponent,
    MonorderMontajComponent,
    DemordereditComponent, 
    MonordereditDialogComponent, 
    DemordereditDialogComponent, 
    DemorderOrderComponent,
    DemorderGraficComponent,
    DemorderMontajComponent,
    PorychkiFilterPipe,
    dateFormatPipe,
    MonfakturiListComponent,
    MonfakturiEditComponent,
    DemfakturiListComponent,
    DemfakturiEditComponent,
    FormArrayFilterPipe,
    DemorderImportSofEkoComponent,
    FileFackturaUploadDialogComponent,
    ProfOrderEditComponent,
    ProfordereditDialogComponent, 
    ImportProfiComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NbCheckboxModule,
    NgxNumbersOnlyDirectiveModule,
    FlexLayoutModule,
    ObrabotkiRoutingModule,
    ApplicationModule,
    NB_MODULES,
    NgxSpinnerModule,
  ],  
  providers: [
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    { provide: MAT_DATE_LOCALE, useValue: 'bg-BG'},
  ],
})
export class ObrabotkiModule { }
