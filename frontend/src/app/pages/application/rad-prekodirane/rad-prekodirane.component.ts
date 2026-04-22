import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogRef, NbSearchService} from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import { forkJoin, Observable } from 'rxjs';
import { pairwise, startWith, takeUntil } from 'rxjs/operators';
import { LiceData, RadPrekodItem } from '../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { Screens } from '../../../@core/tools/screens';
import { HeaderComponent } from '../../../@theme/components';
import { Filter } from '../components/filter/filter.settings';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';

@Component({
  selector: 'ngx-rad-prekodirane',
  templateUrl: './rad-prekodirane.component.html',
  styleUrls: ['./rad-prekodirane.component.scss']
})
export class RadiatorPrekodoraneComponent implements OnInit {
  page = 1;
  pageSize = 15;
  filter: Filter;
  searchText: string = '';
  filterStorage: string = 'radprekodfilter';
  countItems: number = 0;

  raion: string = '';

  isDisabled: boolean = false;
  selectedItems: RadPrekodItem [] = [];

  currentsum: number = 0;
  items: RadPrekodItem[] = [];
  realItems: RadPrekodItem[] =[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private searchService: NbSearchService,
    private spinner: NgxSpinnerService,
    private licaService: LiceData,
    private toasterService: CustomToastrService,
  ) {
    this.filter = JSON.parse(this.route.snapshot.paramMap.get('filter'));

    this.pageSize = Screens.setPageSize(window.innerHeight);
    this.searchService.onSearchSubmit()
                      .subscribe((data: any) => {
                          
                          this.searchText = data.term;
                          this.items = this.realItems.filter(s =>
                              s.ime.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.raion.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.vidimot.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
                              s.unom.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
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
    this.searchService.onSearchSubmit()
      .subscribe((data: any) => {
          this.searchText = data.term;
          this.items = this.realItems;
         
    });

    this.searchService.onSearchDeactivate()
        .subscribe((data: any) => {
            this.searchText = '';
            this.items = this.realItems;
    });

    this.loadPorychka();
    this.onChanges();
  }

  loadPorychka() {
    this.spinner.show();   

    this.licaService
      .getRadiatoriZaPrekodirane(this.filter)
      .subscribe(result => {        
          this.items =  result;
          this.realItems = this.items;
          this.countItems = this.realItems.length;
          this.spinner.hide();   
      });
  }

  onItemClick(item: RadPrekodItem, checked: boolean) {
    const index = this.realItems.findIndex(i=> i.unomer === item.unomer);
    this.realItems[index].isSelected = checked
  }
  
  onChanges(): void {
  } 


  prekodirane() {
    const products$: Observable<any>[] = [];    
    const selected = this.realItems.filter(x=> x.isSelected);
    
    selected.forEach(item=> {
          products$.push(this.licaService.doPrekodiraneRadiatori(item.iddogovorlice))
    });              

    forkJoin(products$).subscribe(() => {
      this.toasterService.success("", `Успешен запис.`);
      this.loadPorychka();
    });                
  }

  back() {
    this.router.navigate(['/pages/register/regfilter/7'])
  }


}
