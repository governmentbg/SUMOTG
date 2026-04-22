import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbSearchService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { RoleProvider } from '../../../@auth/role.provider';
import { ROLES } from '../../../@auth/roles';
import { FirmaData, FirmaIzpalnitel } from '../../../@core/interfaces/common/firmi';
import { Screens } from '../../../@core/tools/screens';

@Component({
  selector: 'ngx-demontazj',
  templateUrl: './demontazj.component.html',
  styleUrls: ['./demontazj.component.scss'],
})
export class DemontazjComponent implements OnInit {
  items: FirmaIzpalnitel [] = [];
  realItems: FirmaIzpalnitel [] = [];
  page = 1;
  pageSize = 15;
  isDisabled = true;
  searchText: string = '';

  constructor(
    private router: Router,
    private firmservice: FirmaData,
    private roleProvider: RoleProvider,
    private searchService: NbSearchService,
  ) { }

  ngOnInit(): void {
    this.canEdit();
    this.loadContracts();
    this.pageSize = Screens.setPageSize(window.innerHeight);

    this.searchService.onSearchSubmit()
    .subscribe((data: any) => {
        this.searchText = data.term;
        this.items = this.realItems.filter(s =>
            s.ime.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            (s.regnomer && s.regnomer.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1) ||
            s.statusdm.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            s.statusur.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            s.eik.indexOf(this.searchText) > -1,
        );
    });

    this.searchService.onSearchDeactivate()
      .subscribe((data: any) => {
          this.searchText = '';
          this.items = this.realItems;
      });                
  }

  loadContracts() {
      this.firmservice
      .getFirmiDeMontaz()
      .subscribe(result => {
          this.items = result;
          this.realItems  = result;
    });
  }

  editItem($data: FirmaIzpalnitel) {
    const url = '/pages/firmcontracts/demoncontract/' + 
                $data.idfirma + '/' + 
                ($data.ime.length>0?$data.ime:'[няма]')+'/'+
                $data.iddog+'/'+
                this.isDisabled;
                
    this.router.navigateByUrl(url);
  }

  addItem() {
    const url = '/pages/firmcontracts/demoncontract/0/Нов/0/' + this.isDisabled;
    this.router.navigateByUrl(url);
  }

  removeItem($id: number) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Искате да изтриете избраният запис!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтриване!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success',
        );
      }
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
}

