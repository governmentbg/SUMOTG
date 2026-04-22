import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NbIconLibraries } from '@nebular/theme';
import { environment } from '../environments/environment';
import { AnalyticsService } from './@core/utils';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  
  constructor(
      private analytics: AnalyticsService,
      private titleService: Title,
      private iconsLibrary: NbIconLibraries
  ) {
    iconsLibrary.registerFontPack('fa', { packClass: 'fa', iconClassPrefix: 'fa' }); 
    iconsLibrary.registerFontPack('far', { packClass: 'far', iconClassPrefix: 'fa' }); 
    iconsLibrary.registerFontPack('fas', { packClass: 'fas', iconClassPrefix: 'fa' });
    iconsLibrary.registerFontPack('fab', { packClass: 'fab', iconClassPrefix: 'fa' });

    iconsLibrary.registerSvgPack("tbsoft", {
      "menu1": '<img src="../../../assets/img/form3.png" width="100%" height="100%"">',
    });

  }

  ngOnInit(): void {
    this.analytics.trackPageViews();
    this.titleService.setTitle('Heaters '+environment.dbname);
  }
}
