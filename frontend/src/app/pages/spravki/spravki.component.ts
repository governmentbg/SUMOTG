import { Component, OnInit } from '@angular/core';
import { RoleProvider } from '../../@auth/role.provider';
import { ROLES } from '../../@auth/roles';
import { Spravka, SpravkiData } from '../../@core/interfaces/common/spravki';

@Component({
  selector: 'ngx-spravki',
  templateUrl: './spravki.component.html',
  styleUrls: ['./spravki.component.scss']
})
export class SpravkiComponent implements OnInit {
  items: Spravka [] = [];
  isDisabled: boolean = true;

  constructor(
    private spravkiService: SpravkiData,
    private roleProvider: RoleProvider,
  ) { }

  ngOnInit(): void {
    this.loadSpravki();
  }

  loadSpravki() {
    this.spravkiService
      .getSpravki()
      .subscribe(result => {
        this.items = result;
      });
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

  filterSpravki(items: Spravka[], tip: number): any[] {
    return items.filter(p => p.tip === tip);
  }
}