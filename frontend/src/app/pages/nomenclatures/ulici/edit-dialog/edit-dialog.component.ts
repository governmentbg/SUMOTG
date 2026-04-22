import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomUlica, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditUliciDialogComponent implements OnInit {
  id: string = '';
  EditForm!: FormGroup;
  forbiddenCodes = ['00000'];
  isnewItem: boolean  = false;
  submitted = false;
  nasmesta: ViewNom[];

  constructor(
    protected ref: NbDialogRef<EditUliciDialogComponent>,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService
  ) {
  }

  ngOnInit(): void {
    this.loadLists();

    this.EditForm = new FormGroup({
      'nkod': new FormControl({value: this.id, disabled: true }, [ Validators.required]),
      'nime': new FormControl('',[Validators.required]),
      'wnasm_nkod': new FormControl('',[Validators.required]),
      'wnuli_nkod': new FormControl(''),
      'status':new FormControl(1)                
    });

    if (this.id.length > 0) {
      this.loadRow();
      this.EditForm.get('nkod').setValue(this.id);
    }
  }

  loadRow() {
    this.nomenclatureService
    .getRowNomenUlici(this.id)
    .subscribe(result => {
      this.EditForm.setValue({
        nkod: this.id,
        nime: result.nime ? result.nime : '',
        wnasm_nkod: result.wnasm_nkod ? result.wnasm_nkod : '',
        wnuli_nkod: result.wnuli_nkod ? result.wnuli_nkod : '',
        status: result.status,
      });
    });    
  }

  loadLists() {
    this.nomenclatureService.getNomenNsMesta().subscribe((result) => {
      this.nasmesta = result.map((item) =>
        new ViewNom().convertNomNsMqsto(item)
      );
    });    
  }

  dismiss() {
    this.ref.close();
  }

  save() {
    this.EditForm.get('nkod').enable();
    const obj = this.convertToFormulqr(this.EditForm.value);
    this.EditForm.get('nkod').disable();

    if (this.isnewItem) {
      this.nomenclatureService.addRowNomenUlici(obj).subscribe(r=> {
        if (r) {
          if (r <= 0) {
             this.handleWrongResponse(r);
          } else {
            this.ref.close(this.EditForm.value);  
          }
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    } else {
      this.nomenclatureService.setRowNomenUlici(obj).subscribe(r=> {
        if (r) {
          this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
  }

  convertToFormulqr(value: any): NomUlica {
    const obj: NomUlica = value;
    obj.status = (obj.status? 1 : 0)
    return obj;
  }

  handleWrongResponse(r: number) {
    if (r === -1)
      this.toasterService.danger('', `Съществува запис с този код!`);
    else
      this.toasterService.danger('', `Системна грешка!`);
  }  
}
