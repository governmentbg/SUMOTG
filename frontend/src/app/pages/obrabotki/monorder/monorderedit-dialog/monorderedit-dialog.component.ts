import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { NbDialogRef, NbSearchService} from '@nebular/theme';
import { NgxSpinnerService } from 'ngx-spinner';
import { pairwise, startWith } from 'rxjs/operators';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { HeaderComponent } from '../../../../@theme/components';

@Component({
  selector: 'ngx-monorderedit-dialog',
  templateUrl: './monorderedit-dialog.component.html',
  styleUrls: ['./monorderedit-dialog.component.scss']
})
export class MonordereditDialogComponent implements OnInit {
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
  realItems: FormArray;
  searchText: string = '';

  constructor(
    protected ref: NbDialogRef<MonordereditDialogComponent>,
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
      raion: new FormControl({value:this.raion, disabled: this.isDisabled}),
      unom: new FormArray([]),
    });

    this.items =  <FormArray>this.EditForm.get('items');

    this.searchService.onSearchSubmit()
    .subscribe((data: any) => {
        this.searchText = data.term;
        this.items = this.realItems;
        this.items.controls = this.items.controls.filter(s =>
            s.get('ime').value.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1 ||
            s.get('unom').value.toLocaleLowerCase().indexOf(this.searchText.toLocaleLowerCase()) > -1
        );
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

    let faza = Number(this.EditForm.get('faza').value);

    this.obrabotkiService
      .getPersonsWihtDogUredi(this.iddogovorfirma, this.raion, faza)
      .subscribe(result => {

        this.items =  <FormArray>this.EditForm.get('items');
        this.items.clear();
        
        result.forEach((t) => {
          var docs =  this.createFormItem();
          (this.EditForm.get('items') as FormArray).push(docs);
        });        

        this.EditForm.patchValue({items:result});     

        let items =  (this.EditForm.get('items') as FormArray) 
        items.controls.forEach((form: FormGroup) => { 
            if (this.selectedItems.indexOf(form.get('idL').value) > -1) {
                form.patchValue({ischeck:true});
            }
        })        
        
        this.items =  <FormArray>this.EditForm.get('items');
        this.realItems = this.items;
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
    });
  }

  onItemClick(data: FormGroup) {
    const ischeck = data.get('ischeck').value;
 //TODO this.broi
    // if (ischeck && this.currentsum === 999) {
    //    this.toasterService.danger('', `Достигнат е максималният разрешен брой уреди!`);
    //    data.patchValue({ischeck:false});
    // } else  {
      if (ischeck)
        this.currentsum = this.currentsum + data.get('broi').value;
      else
        this.currentsum = this.currentsum - data.get('broi').value; ; 
      // }
  }
  
  onChanges(): void {
    this.EditForm.get('raion').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
              this.raion = next;
              this.loadPorychka();
          });
    });

    this.EditForm.get('faza').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.loadPorychka();
          });
    });

  } 


  dismiss() {
    this.ref.close();
  }

  save() {
    this.ref.close(this.items.value);    
  }

}
