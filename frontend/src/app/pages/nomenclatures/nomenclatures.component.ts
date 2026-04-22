import { Component, OnInit } from '@angular/core';
import { RoleProvider } from '../../@auth/role.provider';
import { ROLES } from '../../@auth/roles';
import { Nomenclature, NomenclatureData } from '../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-nomenclatures',
  templateUrl: './nomenclatures.component.html',
  styleUrls: ['./nomenclatures.component.scss'],
})
export class NomenclaturesComponent implements OnInit {
  items: Nomenclature [] = [];
  isDisabled: boolean = false;

  constructor(
    private nomenclatureService: NomenclatureData,
    private roleProvider: RoleProvider
  ) { 
    this.canEdit();
  }

  ngOnInit(): void {
    this.loadNomenlatures();
  }

  loadNomenlatures() {
    this.nomenclatureService
      .getNomenclatures()
      .subscribe(result => {
        this.items = result;
      });
  }

  canEdit()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);
      if (role.toLowerCase() === ROLES.ADMIN)
          this.isDisabled = false;
      else
          this.isDisabled = true;
    });
  }

}
