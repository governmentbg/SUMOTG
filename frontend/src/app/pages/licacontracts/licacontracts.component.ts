import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbRoleProvider } from '@nebular/security';
import { NbSearchService, NbToastrService } from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import Swal from 'sweetalert2';
import { ROLES } from '../../@auth/roles';
import { LiceData, PersonItem } from '../../@core/interfaces/common/lica';
import { Screens } from '../../@core/tools/screens';
import { Filter } from '../application/components/filter/filter.settings';

@Component({
  selector: 'ngx-licacontracts',
  templateUrl: './licacontracts.component.html',
  styleUrls: ['./licacontracts.component.scss'],
})
export class LicacontractsComponent implements OnInit {
  isDisabled:boolean = false;
  items: PersonItem [] = [];
  realItems: PersonItem [] = [];
  page = 1;
  pageSize = 15;
  searchText: string = '';
  filter: Filter;
  filterStorage: string = 'doglistfilter'
  countItems: number = 0;

  protected readonly unsubscribe$ = new Subject<void>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private licaService: LiceData,
    private searchService: NbSearchService,
    private toasterService: NbToastrService,
    private roleProvider : NbRoleProvider,
    private spinner: NgxSpinnerService,
  ) { 
    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.searchService.onSearchSubmit()
                      .subscribe((data: any) => {
                          this.searchText = data.term;
                          this.items = this.realItems.filter(s =>
                              (s.ime ? s.ime.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false)||
                              (s.unom ? s.unom.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false) ||
                              (s.statusDL ? s.statusDL.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false) ||
                              (s.telefon ? s.telefon.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 : false)||
                              (s.dognomer ? s.dognomer.indexOf(this.searchText) > -1 : false) ||
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
   
   this.loadPersons();   
  }

  loadPersons() {
    this.spinner.show();       
    this.licaService
      .getDogovorPersons(this.filter)
      .subscribe(result => {
        this.items = result;
        this.realItems = result;
        this.countItems = this.items.length;

        this.spinner.hide();       
    });
  }

  editLice($data: PersonItem) {
    const url = '/pages/register/lice/' 
              + $data.idlice + '/' 
              + $data.ime + '/'
              + $data.idformulqr + '/'
              + this.isDisabled;

    this.router.navigateByUrl(url);
  }  

  editItem($data: PersonItem) {
    localStorage.setItem(this.filterStorage,JSON.stringify(this.filter));

    const url = '/pages/licacontracts/dogovor/' 
              + $data.idl + '/' 
              + ($data.ime.length > 0 ? $data.ime:'Няма име')  + ' ['+$data.unom+']'+'/'
              + $data.idformulqr + '/'
              + this.isDisabled;
      this.router.navigateByUrl(url);
  }

  printItem(item: PersonItem) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#4d0099;">Печат на договор?</h5> ',
      text: 'Искате ли да се генерира договор за избраното лице!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        let filename = 'Договор_'+item.ime+ '.docx';

        this.licaService
          .genDogovorFile(item.idl)
          .subscribe((response: any) =>{
              let dataType = response.type;
              let binaryData = [];
              binaryData.push(response);
              let downloadLink = document.createElement('a');
              downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
              if (filename)
                  downloadLink.setAttribute('download', filename);
              document.body.appendChild(downloadLink);
              downloadLink.click();
          },
          error => {
            this.handleWrongResponse();
          });
      }
    });
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при генерирането на договора!`);
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

  downloadDogAddPages(){
    let filename = 'ДОГОВОР-Лице-СТР 3-6.docx';

    this.licaService
      .getDogovorAddPages()
      .subscribe((response: any) =>{
          let dataType = response.type;
          let binaryData = [];
          binaryData.push(response);
          let downloadLink = document.createElement('a');
          downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
          if (filename)
              downloadLink.setAttribute('download', filename);
          document.body.appendChild(downloadLink);
          downloadLink.click();
      },
      error => {
        this.handleWrongResponse();
      });
  }

  back() {
      this.router.navigate(['/pages/register/regfilter/4'])
  }

}
