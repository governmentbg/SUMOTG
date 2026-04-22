import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { ExtraAddresses, NomenclatureData, NomUred, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { pairwise, startWith } from 'rxjs/operators';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditAddressDialogComponent implements OnInit {
  id: number = 0;
  EditForm!: FormGroup;
  isnewItem: boolean  = false;
  isDisabled: boolean = false;
  submitted = false;
  
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];

  constructor(
    protected ref: NbDialogRef<EditAddressDialogComponent>,
    private nomenclatureService: NomenclatureData ,
    private toasterService: NbToastrService
  ) {
  }

  ngOnInit(): void {

    this.EditForm = new FormGroup({
        id: new FormControl(0,
                        [ Validators.required]),
        tip: new FormControl(1),
        admRaion: new FormControl({ value: null, disabled: this.isDisabled }),
        nasMqsto: new FormControl({ value: null, disabled: this.isDisabled }),
        kvartal: new FormControl({ value: null, disabled: this.isDisabled }),
        jk: new FormControl({ value: null, disabled: this.isDisabled }),
        ulica: new FormControl({ value: null, disabled: this.isDisabled }),
        nomer: new FormControl({ value: "", disabled: this.isDisabled }),
        blok: new FormControl({ value: "", disabled: this.isDisabled }),
        vhod: new FormControl({ value: "", disabled: this.isDisabled }),
        etaj: new FormControl({ value: "", disabled: this.isDisabled }),
        apart: new FormControl({ value: "", disabled: this.isDisabled }),
        postKode: new FormControl({ value: "", disabled: this.isDisabled }),
        status: new FormControl({ value: 0, disabled: this.isDisabled }),
    });    

    this.loadLists();
    if (this.id > 0) {
      this.loadRow();
    } else {
      this.isnewItem = true;
    }
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
    this.nomenclatureService
        .getRowExtraAddress(this.id)
        .subscribe(result => {
           
          this.EditForm.patchValue({
            id: this.id,
            tip: result.tip ? result.tip  : 1,
            admRaion: result.admRaion ? result.admRaion  : '',
            nasMqsto: result.nasMqsto ? result.nasMqsto  : '',
            kvartal: result.kvartal ? result.kvartal  : '',
            jk: result.jk ? result.jk  : '',
            ulica: result.ulica ? result.ulica  : '',
            nomer: result.nomer ? result.nomer  : '',
            blok: result.blok ? result.blok  : '',
            vhod: result.vhod ? result.vhod  : '',
            etaj: result.etaj ? result.etaj  : '',
            apart: result.apart ? result.apart  : '',
            postKode: result.postKode ? result.postKode  : '',
            status: result.status,
          });
    });
  }

  dismiss() {
    this.ref.close();
  }

  save() {
    const obj = this.convertToFormulqr(this.EditForm.value);

    if (this.isnewItem) {
      this.nomenclatureService.addRowExtraAddress(obj).subscribe(r=> {
        if (r) {
          if (r < 0) {
             this.handleWrongResponse(r);
          } else {
            this.ref.close(this.EditForm.value);  
          }
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    } else {
      this.nomenclatureService.setRowExtraAddress(obj).subscribe(r=> {
        if (r==0) {
          this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
    this.ref.close(this.EditForm);  
  }

  convertToFormulqr(value: any): ExtraAddresses { 
    const obj: ExtraAddresses = value;
    obj.status = (obj.status? 1 : 0)
    return obj;
  }

  handleWrongResponse(r: number) {
    if (r === -1)
      this.toasterService.danger('', `Съществува запис с този код!`);
    else
      this.toasterService.danger('', `Системна грешка!`);
  }  

  onChanges(): void {
    this.EditForm.get('nasMqsto').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
            if (prev && prev != next)
              this.EditForm.get('ulica').patchValue(null, {emitEvent: true});
          });
    });
  }
}
