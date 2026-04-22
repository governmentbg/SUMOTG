import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomRaion } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditRaioniDialogComponent implements OnInit {
  id: string = '';
  EditForm!: FormGroup;
  forbiddenCodes = ['00'];
  isnewItem: boolean  = false;
  submitted = false;

  constructor(
    protected ref: NbDialogRef<EditRaioniDialogComponent>,
    private nomenclatureService: NomenclatureData, 
    private toasterService: NbToastrService
    ) {
  }

  ngOnInit(): void {
    if (this.id.length > 0) {
      this.loadRow();
    } else {
      this.isnewItem = true;
    }

    this.EditForm = new FormGroup({
      'nkod': new FormControl(this.id,
                      [ Validators.required]),
      'nime': new FormControl('',
                      [Validators.required]),
      'status':new FormControl(1)                
    });
  }

  loadRow() {
    this.nomenclatureService
    .getRowNomenRaioni(this.id)
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
    const obj = this.convertToFormulqr(this.EditForm.value);

    if (this.isnewItem) {
      this.nomenclatureService.addRowNomenRaioni(obj).subscribe(r=> {
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
      this.nomenclatureService.setRowNomenRaioni(obj).subscribe(r=> {
        if (r) {
          this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
  }

  convertToFormulqr(value: any): NomRaion {
    const obj: NomRaion = value;
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
