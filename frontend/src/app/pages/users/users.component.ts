import { Component } from '@angular/core';

@Component({
  selector: 'ngx-users',
  template: `
    <ngx-register></ngx-register>
    <router-outlet></router-outlet>
  `,
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent {}
