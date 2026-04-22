
import { NgModule } from '@angular/core';
import { NgIdleKeepaliveModule } from '@ng-idle/keepalive'; 

import { registerLocaleData } from '@angular/common';
import localeBg from '@angular/common/locales/bg';

import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { ThemeModule } from '../@theme/theme.module';
import { MiscellaneousModule } from './miscellaneous/miscellaneous.module';
import { PagesMenu } from './pages-menu';

import { 
    NbCardModule
  , NbIconLibraries
  , NbMenuModule
  , NbSelectModule, NbSpinnerModule 
} from '@nebular/theme';

import { AuthModule } from '../@auth/auth.module';
import { RoleProvider } from '../@auth/role.provider';
import { AboutComponent } from './ui/about/about.component';
import { SettingsComponent } from './ui/settings/settings.component';
import { DashboardComponent } from './ui/dashboard/dashboard.component';

const PAGES_COMPONENTS = [
  AboutComponent,
  DashboardComponent,
  SettingsComponent,
  PagesComponent,
];

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    NbCardModule,
    NbSelectModule,
    NbSpinnerModule,
    MiscellaneousModule,
    AuthModule.forRoot(),
    NgIdleKeepaliveModule.forRoot(),
  ],
  declarations: [
    ...PAGES_COMPONENTS,
  ],
  providers: [
    PagesMenu,
    RoleProvider,
  ],
})
export class PagesModule { 
  constructor(iconsLibrary: NbIconLibraries) { 
    registerLocaleData(localeBg);
  } 
}
