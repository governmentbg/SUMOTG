import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomObshti } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditDialogComponent implements OnInit {
  id: number = 0;
  nomcode: string = '';

  EditForm!: FormGroup;
  isnewItem: boolean  = false;
 
  constructor(
    protected ref: NbDialogRef<EditDialogComponent>,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService
  ) {
  }

  ngOnInit(): void {
    if (this.id > 0) {
      this.loadRow();
    } else {
      this.isnewItem = true;
    }

    this.EditForm = new FormGroup({
          'idkn': new FormControl(0,
                          [ Validators.required]),
          'kodnmn': new FormControl(this.nomcode,
                          [Validators.required]),
          'kodpos': new FormControl('',
                          [Validators.required]),
          'text': new FormControl('',
                          [Validators.required]),
          'status':new FormControl(1)                
    });

  }

  loadRow() {
    this.nomenclatureService
    .getRowNomenObshti(this.id)
    .subscribe(result => {
      this.EditForm.setValue({
        idkn: this.id,
        kodnmn: result.kodnmn ? result.kodnmn  : '',
        kodpos: result.kodpos ? result.kodpos  : '',
        text: result.text ? result.text : '',
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
      this.nomenclatureService.addRowNomenObshti(obj).subscribe(r=> {
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
      this.nomenclatureService.setRowNomenObshti(obj).subscribe(r=> {
        if (r) {
            this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
  }

  convertToFormulqr(value: any): NomObshti {
    const obj: NomObshti = value;
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
