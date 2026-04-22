import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbRoleProvider } from '@nebular/security';
import { NbSearchService, NbToastrService } from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { ROLES } from '../../../@auth/roles';
import { LiceData, ListFormulqrs } from '../../../@core/interfaces/common/lica';
import { Screens } from '../../../@core/tools/screens';
import { HeaderComponent } from '../../../@theme/components';
import { PagesComponent } from '../../pages.component';
import { Filter } from '../components/filter/filter.settings';

interface RegListFilter {
  id: number,
  searchText: string, 
  page: number
}

@Component({
  selector: 'ngx-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {

  @Input() isDisabled: boolean = false;

  id: number = 0;
  formname: string = '';
  items: ListFormulqrs [] = [];
  realItems: ListFormulqrs [] = [];
  selectedPhase: string = '1';
  filter: Filter;

  page = 1;
  pageSize = 15;
  searchText: string = '';
  filterStorage: string = 'reglistfilter';
  countItems: number = 0;
  canAppend: boolean = true;
  canDelete: boolean = true;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private searchService: NbSearchService,
    private roleProvider :NbRoleProvider,
    private licaService: LiceData,
    private spinner: NgxSpinnerService,
    private toasterService: NbToastrService,
  ) { 
    this.selectedPhase = String(HeaderComponent.faza); 
  
    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.searchService.onSearchSubmit()
                      .subscribe((data: any) => {
                          
                          this.searchText = data.term;
                          this.items = this.realItems.filter(s =>
                              s.name.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.raion.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.firma.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.unom.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              (s.bulstat ? s.bulstat.indexOf(this.searchText) > -1 : false) ||
                              (s.telefon ? s.telefon.indexOf(this.searchText) > -1 : false) ||
                              s.ident.indexOf(this.searchText) > -1,
                          );
                          this.countItems = this.items.length;                          
                      });

    this.searchService.onSearchDeactivate()
                  .subscribe((data: any) => {
                      this.searchText = '';
                      this.items = this.realItems;
                      this.countItems = this.items.length;                      
                  });

  }

  ngOnInit(): void {
    this.canEdit();
    this.canDeleteFormulqr();

    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));

      this.formname = 'Списък индивидуални формуляри';
      this.filterStorage = 'register1';
      if (this.id === 2) {
        this.formname = 'Списък формуляри за колективно решение за отопление';
        this.filterStorage = 'register2';
      } else if (this.id === 3) {
        this.formname = 'Списък формуляри за юридически лица';
        this.filterStorage = 'register3';
      }
  
      //globalen filtyr
      this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));
      if (!this.filter) {
         this.filter =  JSON.parse(localStorage.getItem(this.filterStorage))
         
         if (!this.filter) {
            this.filter = {
                raionid: null,
                tipuredi: 'ALL',
                uredi: null,
                olduredi: null,
                faza: 0,
                vid: null,
                statusL: null,
                statusF: null,
                statusDL: null,
                statusU: null,
                unomer: 0,
                regnom: '',
                adres: '',  
                descript: '',
                txtfilter: '',
                disable: false,
            }        
        }
      }
      this.selectedPhase   = String(this.filter.faza);
      HeaderComponent.faza = this.filter.faza;
      this.loadFormulqrs();
    });
  }

  loadFormulqrs() {
    this.spinner.show();   
    this.canAppend = HeaderComponent.faza > 0;

    this.licaService
      .getListFormulqrs(this.id,this.filter)
      .subscribe(result => {

        this.realItems = result;
        this.items = result;
        this.countItems = this.items.length;
        
        if (this.searchText.length > 0) {
          this.searchService.submitSearch(this.searchText);
        }
        this.spinner.hide();       
      });  
  }

 
  addItem() {
    let url = '/pages/register/zaqvlenie';
    if (this.id === 3) {
      url = '/pages/register/zaqvleniefirma';
    } else if (this.id === 2) {
      url = '/pages/register/zaqvleniekolektiv';
    }

    this.router.navigateByUrl(url);
  }

  editItem($data: ListFormulqrs) {
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    let url = '/pages/register/zaqvlenie/' + $data.idFormulqr + '/' + ($data.name.length==0?'_':$data.name)+'/'+ this.isDisabled;
    if (this.id === 3) {
      url = '/pages/register/zaqvleniefirma/' + $data.idFormulqr + '/' + ($data.name.length==0?'_':$data.name)+'/'+ this.isDisabled;
    } else if (this.id === 2) {
      url = '/pages/register/zaqvleniekolektiv/' + $data.idFormulqr + '/' + ($data.name.length==0?'_':$data.name)+'/'+ this.isDisabled;
    }
    this.router.navigateByUrl(url);
  }

  editLice ($item: ListFormulqrs) { 
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    let url = '/pages/register/lice/' + 
              $item.idl+'/'+
              $item.name+ ' ['+$item.unom+']'+'/'+
              $item.idFormulqr +'/'
              this.isDisabled;
    this.router.navigateByUrl(url);
  }

  editFirma ($item: ListFormulqrs) {
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    let url = '/pages/register/firma/' + $item.idfirma+'/'+$item.name+'/'+$item.idFormulqr + '/'+ this.isDisabled;
    this.router.navigateByUrl(url);
  }

  removeItem($item: ListFormulqrs) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Искате да изтриете избраният формуляр!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтриване!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        this.licaService
            .setFormulqrStatus($item.idFormulqr,9)
            .subscribe(result => {
              this.realItems = this.realItems.filter(obj => obj !== $item);              
              this.items = this.items.filter(obj => obj !== $item);              
              this.toasterService.success("", `Успешен запис.`);
            });  
      }
    });
  }

  canDeleteFormulqr()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);
      if (role.toLowerCase() === ROLES.ADMIN  || (role==ROLES.USER && PagesComponent.raion.length==0))
          this.canDelete = true;
      else
          this.canDelete = false;
    });
  }

  canEdit()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);

      if (role.toLowerCase() === ROLES.GUEST)
//  za test    if (role.toLowerCase() !== ROLES.ADMIN)
        this.isDisabled = true;
      else
        this.isDisabled = false;
    });
  }

  selectTable() {
    return this.id;
  }

  back() {
    if (this.id == 1) {
      this.router.navigate(['/pages/register/regfilter/1'])
    } else if (this.id == 2) {
      this.router.navigate(['/pages/register/regfilter/2'])
    } else if (this.id == 3) {
      this.router.navigate(['/pages/register/regfilter/3'])
    }    
  }

  changePhaseSelection($event: any) {
    HeaderComponent.faza = Number(this.selectedPhase);
    this.filter.faza = HeaderComponent.faza

    this.loadFormulqrs();
 }
}
