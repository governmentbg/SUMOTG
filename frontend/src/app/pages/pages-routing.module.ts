/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { SettingsComponent } from './ui/settings/settings.component';
import { DashboardComponent } from './ui/dashboard/dashboard.component';
import { AboutComponent } from './ui/about/about.component';
import { HelpComponent } from './ui/help/help.component';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
      },
      {
        path: 'settings',
        component: SettingsComponent,
      },
      {
        path: 'about',
        component: AboutComponent,
      },
      {
        path: 'help',
        component: HelpComponent,
      },
      {
        path: 'register',
        loadChildren: () => import('./application/application.module').then(m => m.ApplicationModule),
      },
      {
        path: 'licacontracts',
        loadChildren: () => import('./licacontracts/licacontracts.module').then(m => m.LicacontractsModule),
      },
      {
        path: 'nomenclatures',
        loadChildren: () => import('./nomenclatures/nomenclatures.module').then(m => m.NomenclaturesModule),
      },
      {
        path: 'firmcontracts',
        loadChildren: () => import('./firmcontracts/firmcontracts.module').then(m => m.FirmcontractsModule),
      },
      {
        path: 'obrabotki',
        loadChildren: () => import('./obrabotki/obrabotki.module').then(m => m.ObrabotkiModule),
      },
      {
        path: 'spravki',
        loadChildren: () => import('./spravki/spravki.module').then(m => m.SpravkiModule),
      },
      {
        path: 'usersreg',
//        canActivate: [AdminGuard],
        loadChildren: () => import('./users/users.module').then(m => m.UsersModule),
      },
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },      
      // {
      //   path: '**',
      //   component: NotFoundComponent,
      // },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
