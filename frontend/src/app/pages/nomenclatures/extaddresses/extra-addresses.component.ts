import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbSearchService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { AllExtraAddresses, ExtraAddresses, NomenclatureData, NomUred } from '../../../@core/interfaces/common/nomenclatures';
import { Screens } from '../../../@core/tools/screens';
import { ROLES } from '../../../@auth/roles';
import { RoleProvider } from '../../../@auth/role.provider';
import { EditAddressDialogComponent } from './edit-dialog/edit-dialog.component';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';

@Component({
  selector: 'ngx-extra-addresses',
  templateUrl: './extra-addresses.component.html',
  styleUrls: ['./extra-addresses.component.scss']
})
export class ExtraAddressesComponent implements OnInit {
  disable: boolean = false;

  items: AllExtraAddresses [] = [];
  realItems: AllExtraAddresses [] = [];

  page = 1;
  pageSize = 15;
  searchText: string = '';
  role: string;

  constructor(
    private dialogService: NbDialogService,
    private router: Router,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
    private searchService: NbSearchService,    
    private roleProvider: RoleProvider,
    private ete: ExportExcelService,    
  ) {
  }

  ngOnInit(): void {
    this.pageSize = Screens.setPageSize(window.innerHeight);
    this. getUserRole();
    this.loadExtraAddresses();

    this.searchService.onSearchSubmit()
    .subscribe((data: any) => {
        this.searchText = data.term;
        this.items = this.realItems.filter(s =>
            s.opisanie.toUpperCase().indexOf(this.searchText.toUpperCase()) > 0,
        );
    });

    this.searchService.onSearchDeactivate()
          .subscribe((data: any) => {
              this.searchText = '';
              this.items = this.realItems;
    });
  }

  loadExtraAddresses() {

    this.nomenclatureService
      .getAllExtraAddresses()
      .subscribe(result => {
          this.realItems = result;      

          if (this.searchText.length>0)
              this.items = this.realItems.filter(s =>
                  s.opisanie.toUpperCase().indexOf(this.searchText.toUpperCase()) > 0,
              );
          else 
               this.items =  result;
      });
  }

  addItem() {
    this.dialogService.open(EditAddressDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: 0},
                      })
        .onClose.subscribe(x => {
          if (x) this.loadExtraAddresses()
    });                      
  }

  editItem($data: NomUred) {
      this.dialogService.open(EditAddressDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: $data.id},
                      })
          .onClose.subscribe(x => {
              if (x) this.loadExtraAddresses()
    });                      
  }

  removeItem($data: NomUred) {
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
        this.nomenclatureService.delExtraAddress( $data.id).subscribe(r=> {
            if (r) {
              this.handleSuccessResponse();
              this.loadExtraAddresses();
            } else {
              this.handleWrongResponse();
            }
          }) 
      }   
    });
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешно беше изтрит записа.`);
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при изтриване!`);
  }

  back() {
    this.router.navigate(['pages/nomenclatures']);
  }

  getUserRole()  {
    this.roleProvider.getRole().subscribe(s =>{
      this.role = String(s);
      this.disable = (this.role!== ROLES.ADMIN);
    });
  }

  exportexcel() {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];
    let fileName= 'Адреси от друг проект';

    this.realItems.forEach((item: AllExtraAddresses) => {                  
      obj = {
        nomer: ++ncnt,
        tip: item.tip,
        opisanie: item.opisanie,
        status:  (item.status==1 ? "Активен" : "Неактивен") ,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: 'Адреси',
      sheet: 'Адреси',
      colsizes: [0,5,5,80,20],
      header: ['No','Тип','Описание','Статус'],
      headersize:40,        
      data: dataForExcel,
      filename: fileName,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }  
}
