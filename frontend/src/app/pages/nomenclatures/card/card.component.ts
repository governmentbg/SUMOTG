import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'ngx-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent implements OnInit {
  @Input () name: string = '';
  @Input () descript: string = '';
  @Input () nomcode: string = '';
  @Input () nomtype: string = '';
  @Input () disable: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const a = 1;
  }

  editCard() {
    // eslint-disable-next-line eqeqeq
    switch (this.nomtype) {
       case 'n_nmn_obsti': {
          const url = 'common/' + this.nomcode + '/' + this.descript+'/'+this.disable;
          this.router.navigate([url], {relativeTo: this.route});
          break;
       }
       case 'n_ns_mesta': {
          const url = 'nsmesta/' + this.descript+'/'+this.disable;
          this.router.navigate([url], {relativeTo: this.route});
          break;
       }
       case 'n_jk': {
        const url = 'jk/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_ulici': {
        const url = 'ulici/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_kvartali': {
        const url = 'kvartali/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_raioni': {
        const url = 'raioni/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_kmetstva': {
        const url = 'kmetstva/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_uredi': {
        const url = 'uredi/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
      case 'n_uredi_budget': {
        const url = 'uredibudget/' + this.descript+'/'+this.disable;
        this.router.navigate([url], {relativeTo: this.route});
        break;
      }
    }
  }

}
