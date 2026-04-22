import { Component } from '@angular/core';
import packageInfo  from '../../../package.json';

@Component({
  selector: 'ngx-collectioninfo',
  styleUrls: ['./collectioninfo.component.scss'],
  template: `
  <nb-layout center>
    <nb-layout-column center>
      <nb-card>
        <nb-card-header>
          <table style="width:100%">
            <tr>
                <td>
                  <img src="assets/img/logo11.jpg" width="64" height="64">
                </td>  
                <td style="text-align: center">
                  <img src="assets/img/logo2.png" width="64" height="64">
                </td>  
                <td>
                  <img src="assets/img/logo31.jpg" align="right" width="64" height="64">
                </td>  
            </tr>    
          </table>  
        </nb-card-header>
        <nb-card-body>
            <router-outlet></router-outlet>        
        </nb-card-body>
        <nb-card-footer>
          <div style="text-align:center">
            <small>
            Програмата се финансира от програма „Околна среда“ 2021-2027 г., чрез проект № BG16FFPR002-5.002-0003 „Подмяна на отоплителните устройства в домакинствата за по-чист въздух!“
            </small>
          </div>  
        </nb-card-footer>
      </nb-card>
    </nb-layout-column>
  </nb-layout>
  `,
})
export class CollectionInfoComponent{
  version: string = packageInfo.version;

  get currentYear(): number {
    return new Date().getFullYear();
  }
}
