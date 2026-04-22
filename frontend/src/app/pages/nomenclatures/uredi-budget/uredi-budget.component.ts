import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbSearchService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { NomenclatureData, NomUred, NomUredBudget, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { Screens } from '../../../@core/tools/screens';
import { EditUrediBudgetDialogComponent } from './edit-dialog/edit-dialog.component';

@Component({
  selector: 'ngx-ulici-budget',
  templateUrl: './uredi-budget.component.html',
  styleUrls: ['./uredi-budget.component.scss']
})
export class UrediBudgetComponent implements OnInit {
  nomcode: string = '';
  name: string = '';
  disable: boolean = false;

  items: NomUredBudget [] = [];
  realItems: NomUredBudget [] = [];
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
      .getAllNomenUrediBudget(true)
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

  editItem($data: NomUred) {
      this.dialogService.open(EditUrediBudgetDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: $data.id},
                      })
          .onClose.subscribe(x => {
              if (x) this.loadNomen()
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
