import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbSearchService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { NomenclatureData, NomUred, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { Screens } from '../../../@core/tools/screens';
import { EditUrediDialogComponent } from './edit-dialog/edit-dialog.component';

@Component({
  selector: 'ngx-ulici',
  templateUrl: './uredi.component.html',
  styleUrls: ['./uredi.component.scss']
})
export class UrediComponent implements OnInit {
  nomcode: string = '';
  name: string = '';
  disable: boolean = false;

  items: NomUred [] = [];
  realItems: NomUred [] = [];
  vlistfaza: ViewNom[];

  page = 1;
  pageSize = 15;
  searchText: string = '';

  constructor(
    private dialogService: NbDialogService,
    private router: Router,
    private route: ActivatedRoute,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
    private searchService: NbSearchService,    
  ) {
    this.vlistfaza = [];
    this.vlistfaza.push (new ViewNom ().addItem(0, '0','Всички фази'));
    this.vlistfaza.push (new ViewNom ().addItem(1, '1','Фаза 1'));
    this.vlistfaza.push (new ViewNom ().addItem(2, '2','Фаза 2'));

    this.route.paramMap.subscribe( params => {
      this.nomcode = String(params.get('nomcode'));
      this.name = String(params.get('name'));
      this.disable = String(params.get('disable')) === 'true';
    });
  }

  ngOnInit(): void {
    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.loadNomen();

    this.searchService.onSearchSubmit()
    .subscribe((data: any) => {
        this.searchText = data.term;
        this.items = this.realItems.filter(s =>
            s.nkod.indexOf(this.searchText) > 0 ||
            s.nime.toUpperCase().indexOf(this.searchText.toUpperCase()) > 0,
        );
    });

    this.searchService.onSearchDeactivate()
          .subscribe((data: any) => {
              this.searchText = '';
              this.items = this.realItems;
    });
  }

  loadNomen() {

    this.nomenclatureService
      .getAllNomenUredi(true)
      .subscribe(result => {
          this.realItems = result;      

          if (this.searchText.length>0)
              this.items = this.realItems.filter(s =>
                  s.nkod.indexOf(this.searchText) > 0 ||
                  s.nime.toUpperCase().indexOf(this.searchText.toUpperCase()) > 0,
              );
          else 
               this.items =  result;
      });
  }

  addItem() {
    this.dialogService.open(EditUrediDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: 0},
                      })
        .onClose.subscribe(x => {
          if (x) this.loadNomen()
    });                      
  }

  editItem($data: NomUred) {
      this.dialogService.open(EditUrediDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: $data.id},
                      })
          .onClose.subscribe(x => {
              if (x) this.loadNomen()
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
        this.nomenclatureService.delRowNomenUredi( $data.id).subscribe(r=> {
            if (r) {
              this.handleSuccessResponse();
              this.loadNomen();
            } else {
              this.handleWrongResponse();
            }
          }) 
      }   
    });
  }

  getFaza(faza: number) {
    let item = this.vlistfaza.find(x=>x.id == faza);
    return (item ? item.name : '');
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
}
