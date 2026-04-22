import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbRoleProvider } from '@nebular/security';
import { NbSearchService } from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { ROLES } from '../../../@auth/roles';
import { LiceData, PersonItem } from '../../../@core/interfaces/common/lica';
import { Screens } from '../../../@core/tools/screens';
import { HeaderComponent } from '../../../@theme/components/header/header.component';
import { Filter } from '../components/filter/filter.settings';

@Component({
  selector: 'ngx-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss'],
})
export class PersonsComponent implements OnInit {
  disable: boolean = false;
  items: PersonItem [] = [];
  realItems: PersonItem [] = [];
  page = 1;
  pageSize = 15;
  searchText: string = '';

  filter: Filter;
  filterStorage: string = 'perslistfilter';
  countItems: number = 0;

  constructor(
      private router: Router,
      private licaService: LiceData,
      private searchService: NbSearchService,
      private roleProvider : NbRoleProvider,
      private spinner: NgxSpinnerService,
      private route: ActivatedRoute,
  ) {
    this.pageSize = Screens.setPageSize(window.innerHeight);

    this.searchService.onSearchSubmit()
        .subscribe((data: any) => {
            this.searchText = data.term;

            this.items = this.realItems.filter(s =>
                s.typelice.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                s.ime.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                s.unom.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                s.statusDL.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                s.statusF.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                s.ident.indexOf(this.searchText) > -1,
            );
            this.countItems = this.items.length;
    });

    this.searchService.onSearchDeactivate()
        .subscribe((data: any) => {
            this.searchText = '';
            this.items = this.realItems;
        });
        this.countItems = this.items.length;
   }

  ngOnInit(): void {
    this.canEdit();

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
    
    HeaderComponent.faza = this.filter.faza;        
    this.loadPersons();
  }

  loadPersons() {
    this.spinner.show();       

    this.licaService
        .getPersons(this.filter)
        .subscribe(result => {
          this.items = result;
          this.realItems = result;
          this.countItems = this.items.length;

          this.spinner.hide();       
    });
  }

  addItem() {
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    const url = '/pages/register/lice';
    this.router.navigateByUrl(url);
  }

  editItem($data: PersonItem) {
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    const url = '/pages/register/lice/' 
              + $data.idlice + '/' 
              + $data.ime +'/'
              + $data.idformulqr + '/'
              + this.disable;
      this.router.navigateByUrl(url);
  }

  canEdit()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);

      if (role.toLowerCase() === ROLES.GUEST)
        this.disable = true;
      else
        this.disable = false;
    });
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/5'])
  }
}
