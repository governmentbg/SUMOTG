import { Component, OnInit } from '@angular/core';
import { RoleProvider } from '../../@auth/role.provider';
import { ROLES } from '../../@auth/roles';

@Component({
  selector: 'ngx-application',
  template: '<ngx-register isDisable="isDisable"></ngx-register><router-outlet></router-outlet>',
  styles: [],
})
export class ApplicationComponent implements OnInit {
  isDisabled: boolean = false;
  
  constructor(
    private roleProvider: RoleProvider,
  ) { }

  ngOnInit(): void {
     this.canEdit();
  }

  canEdit()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);
      if (role.toLowerCase() === ROLES.GUEST)
          this.isDisabled = true;
      else
          this.isDisabled = false;
    });

 
  }
}
