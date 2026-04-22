import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LOCALE_ID, NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS} from '@angular/material-moment-adapter';
import { CoreModule } from './@core/core.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ThemeModule } from './@theme/theme.module';
import { AuthModule } from './@auth/auth.module';

import {
  NbChatModule,
  NbDialogModule,
  NbMenuModule,
  NbSidebarModule,
  NbToastrModule,
  NbWindowModule,
} from '@nebular/theme';

import { NbRoleProvider, NbSecurityModule } from '@nebular/security';
import { authSettings } from './@auth/access.settings';
import { RoleProvider } from './@auth/role.provider';
import { NbTokenLocalStorage } from '@nebular/auth';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { CurrencyPipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule.forRoot(),
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbDialogModule.forRoot(),
    NbWindowModule.forRoot(),
    NbToastrModule.forRoot(),
    NbChatModule.forRoot({
      messageGoogleMapKey: 'AIzaSyA_wNuCzia92MAmdLRzmqitRGvCF7wCZPY',
    }),
    CoreModule.forRoot(),
    ThemeModule.forRoot(),
    MatMomentDateModule,
  ],
  exports: [
    MatMomentDateModule
  ],
  bootstrap: [AppComponent],
  providers: [
    CurrencyPipe,
    NbSecurityModule.forRoot({
      accessControl: authSettings,
    }).providers,
    { 
      provide: LOCALE_ID, useValue: "bg-BG"
    },
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    { provide: MAT_DATE_LOCALE, useValue: 'bg-BG'},
    { provide: NbRoleProvider, useClass: RoleProvider},
    { provide: NbTokenLocalStorage, useClass: NbTokenLocalStorage},
  ],
})
export class AppModule {
}
