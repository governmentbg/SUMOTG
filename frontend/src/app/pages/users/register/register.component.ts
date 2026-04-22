import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbSearchService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { User, UserData } from '../../../@core/interfaces/common/users';
import { Screens } from '../../../@core/tools/screens';
import { ExportExcelService } from '../../../@theme/services/export-excel.service';

@Component({
  selector: 'ngx-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  items: User [] = [];
  realItems: User [] = [];

  page = 1;
  pageSize = 15;
  dataSource: any[];
  raioni: ViewNom[];
  searchText: string = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private usersService: UserData,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
    private searchService: NbSearchService,
    private ete: ExportExcelService,    
  ) { 

    this.searchService.onSearchSubmit()
                      .subscribe((data: any) => {
                          this.searchText = data.term;
                          this.items = this.realItems.filter(s =>
                              (s.email ? s.email.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false)||
                              (s.login ? s.login.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false) ||
                              (s.telefon ? s.telefon.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false) ||
                              (this.findRaionName(Number(s.raionid)).toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1)
                          );
    });

    this.searchService.onSearchDeactivate()
                      .subscribe((data: any) => {
                          this.searchText = '';
                          this.items = this.realItems;
    });        

  }
  ngOnInit(): void {
    this.loadUsers();
    this.pageSize = Screens.setPageSize(window.innerHeight);
  }

  loadUsers() {
    this.nomenclatureService.getNomenRaioni().subscribe((result) => {
      this.raioni = result.map((item) => new ViewNom().convertNomRaion(item));
    });  
    
    let a = this;
    this.usersService
      .getUsers()
      .subscribe(result => {
        this.items = result.sort((n1,n2) => {
          const nameA = n1.raionid.toUpperCase(); 
          const nameB = n2.raionid.toUpperCase(); 
          // const nameA = a.findRaionName(Number(n1.raionid)).toUpperCase(); 
          // const nameB = a.findRaionName(Number(n2.raionid)).toUpperCase(); 

          if (nameA < nameB) {
            return -1;
          }
          if (nameA > nameB) {
            return 1;
          }

          return 0;  
        });

        this.realItems =  this.items;
      });
  }

  addItem() {
    const url = 'add';
    this.router.navigate([url], {relativeTo: this.route});
  }

  editItem($data: User) {
    const url = 'edit/' + $data.id;
    this.router.navigate([url], {relativeTo: this.route});
  }

  removeItem($data: User) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Изтриване на потребител!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтрий!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        this.usersService.delete( $data.id).subscribe(r=> {
            if (r) {
              this.handleSuccessResponse();
              this.loadUsers();
            } else {
              this.handleWrongResponse();
            }
        }) 
      }
    });
  }

  findRaionName(raionid: number): string {
    if (raionid == 0)
      return 'Всички райони';
    else  {
      return this.raioni.find(x=>x.id == raionid).name
    }
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Потребителя беше изтрит успешно.`);
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при изтриване!`);
  }

  exportexcel() {
    let ncnt: number = 0;
    let obj: any;
    let dataForExcel = [];
    let fileName= 'Users';

    this.realItems.forEach((item: User) => {                  
      obj = {
        nomer: ++ncnt,
        login: item.login,
        email: item.email,
        telefon: item.telefon,
        raionid: this.findRaionName(Number(item.raionid)),  
        status:  (item.status==1 ? "Активен" : "Неактивен") ,
      }      

      dataForExcel.push(Object.values(obj))
    })

    let reportData = {
      title: 'Потребители',
      sheet: 'Потребители',
      colsizes: [0,5,30,40,20,30,20],
      header: ['No','Потребител','Имейл адрес','Телефон','Район', 'Статус'],
      headersize:40,        
      data: dataForExcel,
      filename: fileName,
      filter: ''
    };

    this.ete.exportExcel(reportData);  
  }
}
