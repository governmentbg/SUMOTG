import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { ObrabotkaData } from '../../../@core/interfaces/common/obrabotki';
import { pairwise, startWith } from 'rxjs/operators';
import { Address, LiceData } from '../../../@core/interfaces/common/lica';

@Component({
  selector: 'ngx-address-dialog',
  templateUrl: './address-dialog.component.html',
  styleUrls: ['./address-dialog.component.scss'],
})
export class AddressEditDialogComponent implements OnInit {
  id: number = 0; 
  EditForm: FormGroup;
  isDisabled: boolean = false;
  opos: string = '';
  
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];

  constructor(
    protected ref: NbDialogRef<AddressEditDialogComponent>,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
    private liceService: LiceData
  ) {

    this.EditForm = new FormGroup({
        id: new FormControl(0,
                        [ Validators.required]),
        tip: new FormControl(1),
        raionid: new FormControl({ value: null, disabled: this.isDisabled }),
        nm: new FormControl({ value: null, disabled: this.isDisabled }),
        kv: new FormControl({ value: null, disabled: this.isDisabled }),
        jk: new FormControl({ value: null, disabled: this.isDisabled }),
        ul: new FormControl({ value: null, disabled: this.isDisabled }),
        nomer: new FormControl({ value: "", disabled: this.isDisabled }),
        blok: new FormControl({ value: "", disabled: this.isDisabled }),
        vh: new FormControl({ value: "", disabled: this.isDisabled }),
        etaj: new FormControl({ value: "", disabled: this.isDisabled }),
        ap: new FormControl({ value: "", disabled: this.isDisabled }),
        pk: new FormControl({ value: "", disabled: this.isDisabled }),
        status: new FormControl({ value: 0, disabled: this.isDisabled }),
    });
  }

  ngOnInit(): void {
    this.loadLists();
    this.loadRow();
    this.onChanges();
  }

  loadLists() {
    this.nomenclatureService
        .getNomenNsMesta()
        .subscribe(result => {
          this.nasmesta = result.map(item => new ViewNom().convertNomNsMqsto(item));
    });

    this.nomenclatureService
        .getNomenJk()
        .subscribe(result => {
          this.kvartali = result.map(item => new ViewNom().convertNomKvartal(item));
    });

    this.nomenclatureService
      .getNomenRaioni()
      .subscribe(result => {
              this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });
  }

  loadRow() {
    this.liceService
        .getAddress(this.id)
        .subscribe(result => {
          
          this.opos = result.opos ? result.opos  : '';

          this.EditForm.patchValue({
            id: result.id,
            raionid: result.raionid ? result.raionid  : '',
            nm: result.nm ? result.nm  : '',
            kv: result.kv ? result.kv : '',
            jk: result.jk ? result.jk  : '',
            ul: result.ul ? result.ul  : '',
            nomer: result.nomer ? result.nomer  : '',
            blok: result.blok ? result.blok  : '',
            vh: result.vh ? result.vh  : '',
            etaj: result.etaj ? result.etaj  : '',
            ap: result.ap ? result.ap  : '',
          });
    });
  }

  dismiss() {
    this.ref.close();
  }

  save() {
    const obj = this.convertToFormulqr(this.EditForm.value);

    this.liceService.setAddress(obj).subscribe(r=> {
      if (r==0) {
        this.ref.close(this.EditForm.value);  
      } else {
        this.handleWrongResponse(-9);
      }
    }) 

    this.ref.close(this.EditForm);  
  }

  convertToFormulqr(value: any): Address { 
    const obj: Address = value;
    return obj;
  }

  handleWrongResponse(r: number) {
    if (r === -1)
      this.toasterService.danger('', `Съществува запис с този код!`);
    else
      this.toasterService.danger('', `Системна грешка!`);
  }  

  onChanges(): void {
    this.EditForm.get('nm').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
            if (prev && prev != next)
              this.EditForm.get('ul').patchValue(null, {emitEvent: true});
          });
    });
  }

} 
