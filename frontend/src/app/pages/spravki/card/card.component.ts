import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'ngx-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent  {
  @Input () name: string = '';
  @Input () descript: string = '';
  @Input () nomcode: number = 0;
  @Input () nomtype: number = 0;
  @Input () disable: boolean = true;
  @Input () nkod: number = 0;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  doReport() {
    let url = '';

    switch (this.nomcode) {
       case 1: {          
          url = 'filter1/'+this.nomcode+'/'+String(this.nkod)+'. '+this.descript+'/'+this.disable;        
          break;
       }
       case 2: {
          url = '/pages/register/regfilter/11/'+String(this.nkod)+'. '+this.descript;        
          break;
       }
       case 3: {
          url = '/pages/register/regfilter/12/'+String(this.nkod)+'. '+this.descript;        
          break;
       }
       case 4: {
           url = '/pages/register/regfilter/13/'+String(this.nkod)+'. '+this.descript;        
           break;
       }
       case 5: {
            url = '/pages/register/regfilter/14/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 6: {
              url = '/pages/register/regfilter/15/'+String(this.nkod)+'. '+this.descript;        
              break;
        }
        case 7: {
              url = '/pages/register/regfilter/16/'+String(this.nkod)+'. '+this.descript;        
              break;
        }
        case 8: {
              url = '/pages/register/regfilter/17/'+String(this.nkod)+'. '+this.descript;        
              break;
        }
        case 9: {
            url = '/pages/register/regfilter/19/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 10: {
            url = '/pages/register/regfilter/20/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 11: {
            url = '/pages/register/sprfiltera/1/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 12: {
            url = '/pages/register/sprfiltera/2/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 13: {
            url = '/pages/register/sprfiltera/3/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 14: {
            url = '/pages/register/sprfiltera/4/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 15: {
          url = '/pages/register/regfilter/22/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 20: {
            url = '/pages/register/regfilter/18/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 21: {
            url = '/pages/register/regfilter/21/'+String(this.nkod)+'. '+this.descript;        
            break;
        }
        case 22: {
          url = '/pages/register/regfilter/23/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 23: {
          url = '/pages/register/regfilter/24/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 24: {
          url = '/pages/spravki/spravka24';        
          break;
        }
        case 25: {
          url = '/pages/register/regfilter/25/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 50: {
          url = '/pages/register/regfilter/50/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 51: {
          url = '/pages/register/regfilter/51/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 52: {
          url = '/pages/spravki/spravka52';        
          break;
        }
        case 60: {
          url = '/pages/register/sprfiltera/5/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 61: {
          url = '/pages/register/sprfiltera/6/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 62: {
          url = '/pages/register/sprfiltera/13/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 70: {
          url = '/pages/register/sprfiltera/9/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 71: {
          url = '/pages/register/sprfiltera/10/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 72: {
          url = '/pages/register/sprfiltera/11/'+String(this.nkod)+'. '+this.descript;        
          break;
        }
        case 73: {
          url = '/pages/register/sprfiltera/14/'+String(this.nkod)+'. '+this.descript;        
          break;
        }

    }

    this.router.navigate([url], {relativeTo: this.route})
  }

}
