/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserData } from '../../interfaces/common/users';
import { UsersService } from './services/users.service';
import { UsersApi } from './api/users.api';
import { HttpService } from './api/http.service';
import { SettingsApi } from './api/settings.api';
import { NbAuthModule } from '@nebular/auth';
import { SettingsData } from '../../interfaces/common/settings';
import { SettingsService } from './services/settings.service';
import { NomenclatureData } from '../../interfaces/common/nomenclatures';
import { NomenclaturesService } from './services/nomenclatures.service';
import { NomenclaturesApi } from './api/nomenlatures.api';
import { SpravkiService } from './services/spravki.service';
import { SpravkiData } from '../../interfaces/common/spravki';
import { SpravkiApi } from './api/spravki.api';
import { LicaApi } from './api/lica.api';
import { LiceData } from '../../interfaces/common/lica';
import { LicaService } from './services/lica.service';
import { RoutingState } from './services/RoutingState.service';
import { FirmiApi } from './api/firmi.api';
import { FirmiService } from './services/firmi.service';
import { FirmaData } from '../../interfaces/common/firmi';
import { ObrabotkiApi } from './api/obrabotki.api';
import { ObrabotkiService } from './services/obrabotki.service'; 
import { ObrabotkaData } from '../../interfaces/common/obrabotki';
import { DocumentsData } from '../../interfaces/common/documents';
import { DocumentApi } from './api/document.api';
import { DocumentService } from './services/documents.service';
import { PublicApi } from './api/public.api';
import { PublicData } from '../../interfaces/common/public';
import { PublicService } from './services/public.service';

const API = [
  UsersApi,
  SettingsApi,
  HttpService,
  NomenclaturesApi,
  SpravkiApi,
  LicaApi,
  FirmiApi,
  ObrabotkiApi,
  DocumentApi,
  PublicApi,
];

const SERVICES = [
  { provide: UserData, useClass: UsersService },
  { provide: SettingsData, useClass: SettingsService },
  { provide: NomenclatureData, useClass: NomenclaturesService },
  { provide: SpravkiData, useClass: SpravkiService },
  { provide: LiceData, useClass: LicaService },
  { provide: FirmaData, useClass: FirmiService },
  { provide: ObrabotkaData, useClass: ObrabotkiService },
  { provide: RoutingState, useClase:RoutingState},
  { provide: DocumentsData, useClass: DocumentService },
  { provide: PublicData, useClass: PublicService },
];

@NgModule({
  imports: [CommonModule, NbAuthModule],
})
export class CommonBackendModule {
  static forRoot(): ModuleWithProviders<CommonBackendModule> {
    return {
      ngModule: CommonBackendModule,
      providers: [
        ...API,
        ...SERVICES,    
      ],
    };
  }
}
