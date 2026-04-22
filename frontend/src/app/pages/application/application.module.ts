import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PersonsComponent } from './lice-register/persons.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxNumbersOnlyDirectiveModule } from 'ngx-numbers-only-directive';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { NgxSpinnerModule } from 'ngx-spinner';

import {
  NbCardModule,
  NbAlertModule,
  NbChatModule,
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
  NbFormFieldModule,
  NbTabsetModule,
  NbCheckboxModule,
  NbLayoutModule,
  NbDialogModule,
} from '@nebular/theme';


import { ApplicationRoutingModule } from './application-routing.module';
import { ApplicationComponent } from './application.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CtlTextBoxComponent } from './components/ctltextbox/ctltextbox.component';
import { CtlYesNoComponent } from './components/ctlyesno/ctlyesno.component';
import { CtlNumberComponent } from './components/ctlnumber/ctlnumber.component';
import { CtlListComponent } from './components/ctllist/ctllist.component';
import { CtlListNumberComponent } from './components/ctllistnumber/ctllistnumber.component';
import { CtlDatePickerComponent } from './components/ctldatepicker/ctldatepicker.component';
import { FileUploadDialogComponent } from './components/fileupload-dialog/fileupload-dialog.component';


import { ZaqvlenieComponent } from './formpers/zaqvlenie.component';
import { Page0Component } from './formpers/page0/page0.component';
import { Page1Component } from './formpers/page1/page1.component';
import { Page2Component } from './formpers/page2/page2.component';
import { Page3Component } from './formpers/page3/page3.component';
import { Page4Component } from './formpers/page4/page4.component';
import { Page9Component } from './formpers/page9/page9.component';

import { ZaqvlenieFirmaComponent } from './formfirma/zaqvlenie.firma.component';
import { FirmaPage0Component } from './formfirma/page0/firma.page0.component';
import { FirmaPage1Component } from './formfirma/page1/firma.page1.component';
import { FirmaPage2Component } from './formfirma/page2/firma.page2.component';
import { FirmaPage4Component } from './formfirma/page4/firma.page4.component';
import { FirmaPage5Component } from './formfirma/page5/firma.page5.component';
import { FirmaPage9Component } from './formfirma/page9/firma.page9.component';

import { ZaqvlenieKolektivComponent } from './formkolektiv/zaqvlenie.kolektiv.component';
import { KolektivPage1Component } from './formkolektiv/page1/kolektiv.page1.component';
import { KolektivPage2Component } from './formkolektiv/page2/kolektiv.page2.component';
import { KolektivPage3Component } from './formkolektiv/page3/kolektiv.page3.component';
import { KolektivPage5Component } from './formkolektiv/page5/kolektiv.page5.component';
import { KolektivPage9Component } from './formkolektiv/page9/kolektiv.page9.component';
import { KolektivPage0Component } from './formkolektiv/page0/kolektiv.page0.component';
import { KolektivPage4Component } from './formkolektiv/page4/kolektiv.page4.component';

import { LiceComponent } from './lice-register/lice/lice.component';
import { FirmiComponent } from './firms-register/firmi.component';
import { FirmaComponent } from './firms-register/firma/firma.component';
import { HistoryComponent } from './formpers/history/history.component';
import { FilterComponent } from './components/filter/filter.component';
import { CtlTextAreaComponent } from './components/ctltextarea/ctltextarea.component';
import { CtlCurrencyComponent } from './components/ctlcurrency/ctlcurrency.component';
import { FilterAComponent } from './components/filter-a/filter-a.component';
import { ReplacementDialogComponent } from './replacement-dialog/replacement-dialog.component';
import { ImportAksterComponent } from './import-akster/import-akster.component';
import { RadiatorPrekodoraneComponent } from './rad-prekodirane/rad-prekodirane.component';
import { AddressEditDialogComponent } from './address-dialog/address-dialog.component';
import { Filter1Component } from '../spravki/spravka1/filter1/filter1.component';

export const NB_MODULES = [
    NbFormFieldModule,
    NbCardModule,
    NbAlertModule,
    NbChatModule.forChild({
      messageGoogleMapKey: 'AIzaSyA_wNuCzia92MAmdLRzmqitRGvCF7wCZPY',
    }),
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
    NbTabsetModule,
    NbLayoutModule,
    NbCheckboxModule,
    NbDialogModule.forRoot(),
];

@NgModule({
  declarations: [
    ApplicationComponent,
    CtlTextBoxComponent,
    CtlYesNoComponent,
    CtlNumberComponent,
    CtlListComponent,
    CtlListNumberComponent,
    CtlDatePickerComponent,
    CtlTextAreaComponent,
    CtlCurrencyComponent,
    FileUploadDialogComponent,
    FilterComponent,
    FilterAComponent,
    
    RegisterComponent,
    PersonsComponent,
    LiceComponent,
    FirmiComponent,
    FirmaComponent,

    ZaqvlenieComponent,
    Page0Component,
    Page1Component,
    Page2Component,
    Page3Component,
    Page4Component,
    Page9Component,
    HistoryComponent,

    ZaqvlenieFirmaComponent,
    FirmaPage0Component,
    FirmaPage1Component,
    FirmaPage2Component,
    FirmaPage4Component,
    FirmaPage5Component,
    FirmaPage9Component,

    ZaqvlenieKolektivComponent,
    KolektivPage0Component,
    KolektivPage1Component,
    KolektivPage2Component,
    KolektivPage3Component,
    KolektivPage4Component,
    KolektivPage5Component,
    KolektivPage9Component,

    ReplacementDialogComponent,
    ImportAksterComponent,
    RadiatorPrekodoraneComponent,
    AddressEditDialogComponent,
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    FlexLayoutModule,
    NgxNumbersOnlyDirectiveModule,
    NgSelectModule,
    NB_MODULES,
    MatDatepickerModule,
    MatNativeDateModule,
    NgxSpinnerModule,
  ],
  exports: [
    CtlListComponent,
    CtlTextBoxComponent,
    CtlYesNoComponent,
    CtlNumberComponent,
    CtlListNumberComponent,
    CtlDatePickerComponent,
    CtlTextAreaComponent,
    CtlCurrencyComponent,
    MatMomentDateModule,
    FilterComponent,
    FileUploadDialogComponent
  ],
  providers: [
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    { provide: MAT_DATE_LOCALE, useValue: 'bg-BG'},
  ],
})
export class ApplicationModule { }
