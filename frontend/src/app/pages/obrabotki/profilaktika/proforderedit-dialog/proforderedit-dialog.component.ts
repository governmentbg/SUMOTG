import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NbDialogRef} from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import moment from 'moment';
import { takeUntil } from 'rxjs/operators';
import { ObrabotkaData, ProfOrderItem } from '../../../../@core/interfaces/common/obrabotki';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { CustomToastrService } from '../../../../@core/backend/common/custom-toastr.service';

@Component({
  selector: 'ngx-proforderedit-dialog',
  templateUrl: './proforderedit-dialog.component.html',
  styleUrls: ['./proforderedit-dialog.component.scss']
})
export class ProfordereditDialogComponent implements OnInit {
  item: ProfOrderItem;
  form: FormGroup;
  vliststatus:  ViewNom[];

  constructor(
    protected ref: NbDialogRef<ProfordereditDialogComponent>,
    private orderService: ObrabotkaData,
    private nomenclatureService: NomenclatureData,
    private toasterService: CustomToastrService,
  ) {
  }

  ngOnInit(): void {
    this.form = new FormGroup ({
      id: new FormControl({value:0}),
      broi: new FormControl({value:0}),
      otchdata: new FormControl({value:this.item.otchdata}),
      statusPF: new FormControl({value:this.item.status_pf}),
      note: new  FormControl({value:this.item.note}),
      idprofilaktika: new FormControl({value:0}),
    });

    this.nomenclatureService
        .getNomenStatusi('Status_PF')
        .subscribe(result => {
          this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });        

    this.form.patchValue({
          id: this.item.id,
          broi: this.item.broi,
          otchdata: this.item.otchdata  ? this.item.otchdata : null,
          statusPF: this.item.status_pf ? String(this.item.status_pf) : '0',
          note: this.item.note ? this.item.note : '',
          idprofilaktika: this.item.idprofilaktika,
    });   

    this.onChanges();
  }

  onChanges(): void {

  } 


  dismiss() {
    this.ref.close();
  }

  save() {
    const DATE_FORMAT = 'DD.MM.YYYY';
    const unsubscribe$ = new Subject<void>();
    let observable = new Observable<number>();

    this.item.broi = this.form.controls['broi'].value;
    this.item.note = this.form.controls['note'].value;
    this.item.status_pf = this.form.controls['statusPF'].value;
    this.item.otchdata = this.form.controls['otchdata'].value;

    let id = this.item.id;
    let otchdata = moment(this.item.otchdata).format(DATE_FORMAT);
    let note = this.item.note
    let status_pf = this.item.status_pf;
    let idprofilaktika = this.item.idprofilaktika;

    observable = this.orderService.setMonProfilaktika(
        id
        , (otchdata.indexOf('Invalid') > -1 ? '' : otchdata)
        , note
        , status_pf
        ,idprofilaktika
    );
    
    observable
      .pipe(takeUntil(unsubscribe$))
      .subscribe(() => {
          this.ref.close(this.item); 
      },
      (err) => {
        this.toasterService.danger("", `Грешка при запис!`);
      }
    );
  }

}
