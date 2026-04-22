import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NomenclaturesRoutingModule } from './nomenclatures-routing.module';
import { NomenclaturesComponent } from './nomenclatures.component';
import { CardComponent } from './card/card.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonComponent } from './common/common.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EditDialogComponent } from './common/edit-dialog/edit-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NsmestaComponent } from './nsmesta/nsmesta.component';
import { JkComponent } from './jk/jk.component';
import { UliciComponent } from './ulici/ulici.component';
import { RaioniComponent } from './raioni/raioni.component';
import { KmetstvaComponent } from './kmetstva/kmetstva.component';
import { EditJkDialogComponent } from './jk/edit-dialog/edit-dialog.component';
import { EditKmetstvaDialogComponent } from './kmetstva/edit-dialog/edit-dialog.component';
import { EditNsMestaDialogComponent } from './nsmesta/edit-dialog/edit-dialog.component';
import { EditRaioniDialogComponent } from './raioni/edit-dialog/edit-dialog.component';
import { EditUliciDialogComponent } from './ulici/edit-dialog/edit-dialog.component';
import { EditUrediDialogComponent } from './uredi/edit-dialog/edit-dialog.component';
import { UrediComponent } from './uredi/uredi.component';

import { 
  NbButtonModule
  , NbCardModule
  , NbDialogModule
  , NbIconModule
  , NbSearchModule
  , NbToggleModule
  , NbTreeGridModule 
  , NbRadioModule
  , NbCheckboxModule
  , NbSelectModule,

} from '@nebular/theme';
import { NgxNumbersOnlyDirectiveModule } from 'ngx-numbers-only-directive';
import { ApplicationModule } from '../application/application.module';
import { ExtraAddressesComponent } from './extaddresses/extra-addresses.component';
import { EditAddressDialogComponent } from './extaddresses/edit-dialog/edit-dialog.component';
import { EditUrediBudgetDialogComponent } from './uredi-budget/edit-dialog/edit-dialog.component';
import { UrediBudgetComponent } from './uredi-budget/uredi-budget.component';

@NgModule({
  declarations: [
    NomenclaturesComponent,
    CardComponent,
    CommonComponent,
    EditDialogComponent,
    NsmestaComponent,
    EditNsMestaDialogComponent,
    JkComponent,
    EditJkDialogComponent,
    UliciComponent,
    EditUliciDialogComponent,
    RaioniComponent,
    EditRaioniDialogComponent,
    KmetstvaComponent,
    EditKmetstvaDialogComponent,
    UrediComponent,
    EditUrediDialogComponent,
    ExtraAddressesComponent,
    EditAddressDialogComponent,
    UrediBudgetComponent,
    EditUrediBudgetDialogComponent,
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
    NbToggleModule,
    NbSearchModule,
    NbRadioModule,
    NbCheckboxModule,
    NbSelectModule,
    NomenclaturesRoutingModule,
    NgxNumbersOnlyDirectiveModule,
    ApplicationModule,
  ],
})
export class NomenclaturesModule { }
