import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbSearchService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { RoleProvider } from '../../../@auth/role.provider';
import { ROLES } from '../../../@auth/roles';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { ObrabotkaData, Obrabotki } from '../../../@core/interfaces/common/obrabotki';
import { Screens } from '../../../@core/tools/screens';

@Component({
  selector: 'ngx-monorder',
  templateUrl: './monorder.component.html',
  styleUrls: ['./monorder.component.scss']
})
export class MonOrderComponent implements OnInit {
  items: Obrabotki [] = [];
  realItems: Obrabotki [] = [];
  page = 1;
  pageSize = 15;
  isDisabled = true;
  searchText: string = '';

  constructor(
    private router: Router,
    private orderService: ObrabotkaData,
    private roleProvider: RoleProvider,
    private searchService: NbSearchService,
    private toasterService: CustomToastrService,
    ) { }

  ngOnInit(): void {
    this.canEdit();
    this.loadContracts();
    this.pageSize = Screens.setPageSize(window.innerHeight);

    this.searchService.onSearchSubmit()
    .subscribe((data: any) => {
        this.searchText = data.term;
        this.items = this.realItems.filter(s =>
            s.idporychka.toString().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            s.ime.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            (s.email && s.email.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1) ||
            (s.telefon && s.telefon.indexOf(this.searchText) > -1) ||
            (s.dogovor && s.dogovor.indexOf(this.searchText) > -1) ||
            s.statusPM.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
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
      .getMonListOrders()
      .subscribe(result => {
          this.items = result;
          this.realItems = result;          
    });    
  }

  editItem($data: Obrabotki) {
    const url = '/pages/obrabotki/monorderedit/' + 
                $data.idfirma + '/' + 
                ($data.ime.length>0?$data.ime:'[няма]')+'/'+
                $data.idporychka+'/'+
                this.isDisabled;
    this.router.navigateByUrl(url);
  }

  addItem() {
    const url = '/pages/obrabotki/monorderedit/0/Новa/0/' + this.isDisabled;
    this.router.navigateByUrl(url);
  }

  removeItem($id: number) {
    this.orderService
        .canDeleteMonOrder($id)
        .subscribe((result) => {
            if (result>0) {
                this.toasterService.showToast("danger","Поръчката не може да бъде изтрита, има уреди с данни за График/Отчет.");  
            } else {
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
                this.orderService.delMonOrder($id).subscribe((result) => {
                    this.loadContracts();
                    Swal.fire(
                      '',
                      'Поръчката е изтрира успешно.',
                      'success',
                    );
                });
              }
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