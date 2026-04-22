import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from '../../@auth/admin.guard';
import { AddUserComponent } from './add/add.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UserComponent } from './user/user.component';
import { UsersComponent } from './users.component';

const routes: Routes = [
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'add',
    canActivate: [AdminGuard],
    component: AddUserComponent,
  },
  {
    path: 'edit/:id',
    canActivate: [AdminGuard],
    component: UserComponent,
  },
  {
    path: 'current',
    component: UserComponent,
  },
  {
    path: 'changepassword/:id',
//    canActivate: [AdminGuard],
    component: ResetPasswordComponent,
  },
  {
    path: '',
    component: UsersComponent,
  },
  {
    path: '**',
    component: UsersComponent,
  },
];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UsersRoutingModule { }
