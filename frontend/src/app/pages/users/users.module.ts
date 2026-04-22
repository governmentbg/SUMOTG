import { NgModule, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from './user/user.component';
import { ComponentsModule } from '../../@components/components.module';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { AddUserComponent } from './add/add.component';

import {
  NbButtonModule,
  NbCardModule,
  NbInputModule,
  NbUserModule,
  NbSelectModule,
  NbIconModule,
  NbSpinnerModule,
  NbDatepickerModule,
  NbSearchModule,
  NbToggleModule,
} from '@nebular/theme';

const  NB_MODULES = [
  NbButtonModule,
  NbCardModule,
  NbInputModule,
  NbUserModule,
  NbSelectModule,
  NbIconModule,
  NbSpinnerModule,
  NbDatepickerModule,
  NbInputModule,
  NbSearchModule,
  NbToggleModule,
];


@NgModule({
  declarations: [
    UsersComponent,
    UserComponent,
    AddUserComponent,
    RegisterComponent,
    ResetPasswordComponent,
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    NgbModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    ComponentsModule,
    NB_MODULES,
  ],
})
export class UsersModule {}
