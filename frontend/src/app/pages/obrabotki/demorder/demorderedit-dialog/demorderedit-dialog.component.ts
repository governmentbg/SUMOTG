import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { NbDialogRef, NbSearchService } from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs/internal/Observable';
import { pairwise, startWith } from 'rxjs/operators';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ObrabotkaData, PersUrediItem } from '../../../../@core/interfaces/common/obrabotki';
import { Screens } from '../../../../@core/tools/screens';
import { HeaderComponent } from '../../../../@theme/components';
import { FormArrayFilterPipe } from '../../forms/form-array-filter.pipe';

@Component({
  selector: 'ngx-demorderedit-dialog',
  templateUrl: './demorderedit-dialog.component.html',
  styleUrls: ['./demorderedit-dialog.component.scss']
})
export class DemordereditDialogComponent implements OnInit {
  idporychka: number = 0;
  idmonporychka: number = 0;
  iddogovorfirma: number = 0;
  raion: string = '';

  isDisabled: boolean = false;
  selectedItems: number [] = [];
  raioni: ViewNom[];
  vlistfaza: ViewNom[];

  EditForm: FormGroup;
  isnewItem: boolean  = false;
  currentsum: number = 0;
  items: FormArray;
  searchText: string = '';

  page: number      = 1;
  pageSize: number  = 100;
  itemslength: number = 0;

  observable: Observable <PersUrediItem[]>;
  isLoaded: boolean = false;

  constructor(
    protected ref: NbDialogRef<DemordereditDialogComponent>,
    private obrabotkiService: ObrabotkaData,
    private nomenclatureService: NomenclatureData,
    private searchService: NbSearchService,
    private spinner: NgxSpinnerService,

  ) {
    this.vlistfaza = [];
    this.vlistfaza.push (new ViewNom ().addItem(1, '1','Фаза 1'));
    this.vlistfaza.push (new ViewNom ().addItem(2, '2','Фаза 2'));

    this.nomenclatureService
        .getNomenRaioni()
        .subscribe(result => {
            this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });    
  }

  ngOnInit(): void {
    this.EditForm = new FormGroup ({
      iddog: new FormControl({value:0, disabled: this.isDisabled}),
      id: new FormControl({value:0, disabled: this.isDisabled}),
      broi: new FormControl({value:0, disabled: this.isDisabled}),
      items: new FormArray([]),
      faza: new FormControl({value: String(HeaderComponent.faza), disabled: this.isDisabled}),
      raion: new FormControl({value: '01', disabled: this.isDisabled}),
      unom: new FormArray([]),
    });

    this.items =  <FormArray>this.EditForm.get('items');

    this.searchService.onSearchSubmit()
        .subscribe((data: any) => {
            this.searchText = data.term;
            this.itemslength = new FormArrayFilterPipe().transform(this.items.controls,this.searchText).length ; 
    });

    this.searchService.onSearchDeactivate()
        .subscribe((data: any) => {
            this.searchText = '';
            this.itemslength = this.items.length; 

    });

    this.loadPorychka();
//    this.onChanges();
  }

  loadPorychka() {
    this.spinner.show();   

    let faza = Number(this.EditForm.get('faza').value);

    this.observable = new Observable <PersUrediItem[]>();
    this.observable =  (this.idporychka ==0 && this.idmonporychka>0)
      ? this.obrabotkiService.getDemonUrediFromMonPorychka(this.iddogovorfirma, this.idmonporychka)
      : this.obrabotkiService.getDemonPersonsWihtDogUredi(this.iddogovorfirma, this.raion, faza)

      this.observable
        .subscribe(result => {

          this.items.clear();          
          result.forEach((t) => {
            var docs =  this.createFormItem();
            this.items.push(docs);
          });        

          this.EditForm.patchValue({items:result});     

          this.items.controls.forEach((form: FormGroup) => { 
              if (this.selectedItems.indexOf(form.get('idL').value) > -1
                || (this.idporychka ==0 && this.idmonporychka>0)) {
                      form.patchValue({ischeck:true});
              }
          })        
          
          this.itemslength = this.items.length ; 
          this.isLoaded = true;     
          this.spinner.hide();   
        });
  }


  createFormItem(): FormGroup {
    return new FormGroup({
      iddogovorlice: new FormControl(0),
      idured: new FormControl(0),
      broi: new FormControl(0),
      idL: new FormControl(0),
      ident: new FormControl(''),
      ime: new FormControl(''),
      vidimot: new FormControl(''),
      adres: new FormControl(''),
      email: new FormControl(''),
      telefon: new FormControl(''),
      ischeck: new FormControl(0),
      unom: new FormControl(''),
      uredname: new FormControl(''),
      note2: new FormControl(''),
    });
  }

  onItemClick(data: FormGroup) {
    const ischeck = data.get('ischeck').value;
    if (ischeck)
      this.currentsum = this.currentsum + data.get('broi').value;
    else
      this.currentsum = this.currentsum - data.get('broi').value; ; 
  }
  
  // onChanges(): void {
  //   this.EditForm.get('raion').valueChanges
  //     .pipe(startWith(null as string), pairwise())
  //     .subscribe(([prev, next]: [any, any]) => {
  //         this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
  //             this.raion = next;
  //             this.loadPorychka();
  //         });
  //   });

  //   this.EditForm.get('faza').valueChanges
  //     .pipe(startWith(null as string), pairwise())
  //     .subscribe(([prev, next]: [any, any]) => {
  //         this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
  //           this.loadPorychka();
  //         });
  //   });

  // } 


  dismiss() {
    this.ref.close();
  }

  save() {
    this.ref.close(this.items.value);    
  }
}
