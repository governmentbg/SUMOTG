import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { NomenclatureData, NomUred, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss'],
})
export class EditUrediDialogComponent implements OnInit {
  id: number = 0;
  EditForm!: FormGroup;
  forbiddenCodes = ['00'];
  isnewItem: boolean  = false;
  submitted = false;
  vlistfaza: ViewNom[];
  
  constructor(
    protected ref: NbDialogRef<EditUrediDialogComponent>,
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
      id: new FormControl(0,
                      [ Validators.required]),
      nkod: new FormControl('',
                      [Validators.required]),
      nime: new FormControl('',
                      [Validators.required]),
      maxbr: new FormControl(0,
                      [Validators.required]),
      doprad: new FormControl(0,
                      [Validators.required]),
      kolectform :new FormControl(1) ,
      nkod2: new FormControl(''),
      nime2: new FormControl(''),
      vid: new FormControl(''),
      status :new FormControl(1) ,
      faza: new FormControl('0')  ,
    });    
  }

  loadRow() {
    this.nomenclatureService
        .getRowNomenUredi(this.id)
        .subscribe(result => {
          
          this.EditForm.patchValue({
            id: this.id,
            nkod: result.nkod ? result.nkod  : '',
            nime: result.nime ? result.nime : '',
            maxbr: result.maxbr ? result.maxbr : 0,
            doprad: result.doprad ? String(result.doprad) : '0',
            kolectform: result.kolectform ? result.kolectform : false,
            nkod2: result.nkod2 ? result.nkod2  : '',
            nime2: result.nime2 ? result.nime2 : '',
            vid:  result.vid ? result.vid  : '',
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

    if (this.isnewItem) {
      this.nomenclatureService.addRowNomenUredi(obj).subscribe(r=> {
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
      this.nomenclatureService.setRowNomenUredi(obj).subscribe(r=> {
        if (r) {
          this.ref.close(this.EditForm.value);  
        } else {
          this.handleWrongResponse(-9);
        }
      }) 
    }
    this.ref.close(this.EditForm);  
  }

  convertToFormulqr(value: any): NomUred { 
    const obj: NomUred = value;
    obj.kolectform = (obj.kolectform ? 1 : 0);
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
