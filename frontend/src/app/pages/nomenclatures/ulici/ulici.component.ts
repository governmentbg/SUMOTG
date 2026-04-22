import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbSearchService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { NomenclatureData, NomUlica } from '../../../@core/interfaces/common/nomenclatures';
import { Screens } from '../../../@core/tools/screens';
import { EditUliciDialogComponent } from './edit-dialog/edit-dialog.component';

@Component({
  selector: 'ngx-ulici',
  templateUrl: './ulici.component.html',
  styleUrls: ['./ulici.component.scss']
})
export class UliciComponent implements OnInit {
  nomcode: string = '';
  name: string = '';
  disable: boolean = false;

  items: NomUlica [] = [];
  realItems: NomUlica [] = [];

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
    this.route.paramMap.subscribe( params => {
      this.nomcode = String(params.get('nomcode'));
      this.name = String(params.get('name'));
      this.disable = String(params.get('disable')) === 'true';

      if (this.nomcode !== '') {
        this.loadNomen();
      }
    });
  }

  ngOnInit(): void {
    this.loadNomen();

    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.searchService.onSearchSubmit()
                      .subscribe((data: any) => {
                          this.searchText = data.term;
                          this.items = this.realItems.filter(s =>
                              s.nkod.indexOf(this.searchText) > -1 ||
                              s.nime.toUpperCase().indexOf(this.searchText.toUpperCase()) > -1 ||
                              s.wnasm.toUpperCase().indexOf(this.searchText.toUpperCase()) > -1,
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
    .getAllNomenUlici()
    .subscribe(result => {
        this.items = result;
        this.realItems = result;
    });
  }

  addItem() {
    this.nomenclatureService
    .getMaxKodUlici()
    .subscribe(result => {
      this.dialogService.open(EditUliciDialogComponent
                  , { hasBackdrop: true,
                    closeOnBackdropClick: true,
                    hasScroll: false,
                    context: {
                        id: result,
                        isnewItem: true
                    },
                  })
          .onClose.subscribe(x => {
              if (x) this.loadNomen()
          });                      
    });
  }

  editItem($data: NomUlica) {
      this.dialogService.open(EditUliciDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {
                          id: $data.nkod,
                          isnewItem: false
                        },
                      })
          .onClose.subscribe(x => {
              if (x) this.loadNomen()
          });                      
  }

  removeItem($data: NomUlica) {
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
        this.nomenclatureService.delRowNomenUlici( $data.nkod).subscribe(r=> {
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
