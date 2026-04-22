import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbSearchService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { RoleProvider } from '../../../../@auth/role.provider';
import { ROLES } from '../../../../@auth/roles';
import { FakturiListItem, ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { Screens } from '../../../../@core/tools/screens';

@Component({
  selector: 'ngx-monfakturi-list',
  templateUrl: './monfakturi-list.component.html',
  styleUrls: ['./monfakturi-list.component.scss']
})
export class MonfakturiListComponent implements OnInit {

  items: FakturiListItem [] = [];
  realItems: FakturiListItem [] = [];
  page = 1;
  pageSize = 15;
  isDisabled = true;
  searchText: string = '';

  constructor(
    private router: Router,
    private orderService: ObrabotkaData,
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
      this.orderService
      .getMonListFakturi(1)
      .subscribe(result => {
          this.items = result;
          this.realItems = result;
    });    
  }

  editItem($data: FakturiListItem) {
    const url = '/pages/obrabotki/monfakturiedit/' + 
                $data.idfirma + '/' + 
                ($data.ime.length>0?$data.ime:'[няма]')+'/'+
                $data.idfaktura+'/'+
                this.isDisabled;
    this.router.navigateByUrl(url);
  }

  addItem() {
    const url = '/pages/obrabotki/monfakturiedit/0/Новa/0/' + this.isDisabled;
    this.router.navigateByUrl(url);
  }

  removeItem($id: FakturiListItem) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Искате ли да изтриете избраната фактура!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтриване!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        this.orderService.delFactura($id.idfaktura).subscribe((result) => {
          this.loadContracts();
          Swal.fire(
            '',
            'Фактурата е изтрита успешно.',
            'success',
          );
        });
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
