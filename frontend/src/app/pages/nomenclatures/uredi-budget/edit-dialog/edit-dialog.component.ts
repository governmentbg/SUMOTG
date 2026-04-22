import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomUred, NomUredBudget, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditUrediBudgetDialogComponent implements OnInit {
  id: number = 0;
  EditForm!: FormGroup;
  forbiddenCodes = ['00'];
  isnewItem: boolean  = false;
  submitted = false;
  vlistfaza: ViewNom[];
  
  constructor(
    protected ref: NbDialogRef<EditUrediBudgetDialogComponent>,
    private nomenclatureService: NomenclatureData ,
    private toasterService: NbToastrService
  ) {
  }

  ngOnInit(): void {

    this.vlistfaza = [];
    this.vlistfaza.push (new ViewNom ().addItem(0, '0','Всички фази'));
    this.vlistfaza.push (new ViewNom ().addItem(1, '1','Фаза 1'));
    this.vlistfaza.push (new ViewNom ().addItem(2, '2','Фаза 2'));

    if (this.id > 0) {
      this.loadRow();
    } else {
      this.isnewItem = true;
    }

    this.EditForm = new FormGroup({
      id:   new FormControl(0),
      faza: new FormControl('0')  ,
      nkod: new FormControl(''),
      nime: new FormControl(''),
      quantity: new FormControl(0,
                      [Validators.required]),
      price: new FormControl(0,
                      [Validators.required]),
      status :new FormControl(1) ,
    });    
  }

  loadRow() {
    this.nomenclatureService
        .getRowNomenBudgetUredi(this.id)
        .subscribe(result => {
          
          this.EditForm.patchValue({
            id: this.id,
            nkod: result.nkod ? result.nkod  : '',
            nime: result.nime ? result.nime : '',
            quantity: result.quantity ? result.quantity : 0,
            price: result.price ? result.price : 0,
            status: result.status,
            faza: String(result.faza)
          });
    });
  }

  dismiss() {
    this.ref.close();
  }

  save() {
    const obj = this.convertToFormulqr(this.EditForm.value);

    this.nomenclatureService.setRowNomenBudgetUredi(obj).subscribe(r=> {
      if (r) {
        this.ref.close(this.EditForm.value);  
      } else {
        this.handleWrongResponse(-9);
      }
    }) 
    this.ref.close(this.EditForm);  
  }

  convertToFormulqr(value: any): NomUredBudget { 
    const obj: NomUredBudget = value;
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
