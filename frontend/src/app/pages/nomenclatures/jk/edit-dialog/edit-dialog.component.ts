import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomJk } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditJkDialogComponent implements OnInit {
  id: string = '';
  EditForm!: FormGroup;
  forbiddenCodes = ['00'];
  isnewItem: boolean  = false;
  submitted = false;

  constructor(
    protected ref: NbDialogRef<EditJkDialogComponent>,
    private nomenclatureService: NomenclatureData, 
    private toasterService: NbToastrService    
  ) {
  }

  ngOnInit(): void {
    this.EditForm = new FormGroup({
      'nkod': new FormControl({value: this.id, disabled: true }, [ Validators.required]),
      'nime': new FormControl('',[Validators.required]),
      'status':new FormControl(1)                
    });

    if (!this.isnewItem) {
      this.loadRow();
    }
  }

  loadRow() {
    this.nomenclatureService
    .getRowNomenJk(this.id)
    .subscribe(result => {
      this.EditForm.setValue({
        nkod: result.nkod ? result.nkod  : '',
        nime: result.nime ? result.nime : '',
        status: result.status,
      });
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
      this.nomenclatureService.addRowNomenJk(obj).subscribe(r=> {
        if (r) {
          if (r <= 0) {
             this.handleWrongResponse(r);
          }else {
            this.ref.close(this.EditForm.value);  
          }
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    } else {
      this.nomenclatureService.setRowNomenJk(obj).subscribe(r=> {
        if (r) {
            this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
  }

  convertToFormulqr(value: any): NomJk {
    const obj: NomJk = value;
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
