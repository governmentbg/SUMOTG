import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NbDialogRef, NbToastrService} from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { pairwise, startWith, takeUntil } from 'rxjs/operators';
import { Lice, LiceData } from '../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { findInvalidControlsRecursive, getErrorMessage } from '../../../@core/tools/functions';
import { CustomValidators } from '../../../@core/validators/custom-validators';
import { LiceForm } from '../formclasses/lice.form';

@Component({
  selector: 'ngx-replacement-dialog',
  templateUrl: './replacement-dialog.component.html',
  styleUrls: ['./replacement-dialog.component.scss']
})
export class ReplacementDialogComponent implements OnInit {
  id: number = 0;
  statusL: number = 0;
  disable: boolean = false;

  EditForm: FormGroup;
  lice: Lice;
  vidLice: ViewNom[];
  vidIdent: ViewNom[];
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  click: boolean = true;
  
  protected readonly unsubscribe$ = new Subject<void>();

  constructor (
    protected ref: NbDialogRef<ReplacementDialogComponent>,
    private route: ActivatedRoute,
    private nomenclatureService: NomenclatureData,
    private licaService: LiceData,
    private toasterService: NbToastrService,
  ) {
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.statusL = Number(params.get('statusL'));
    });

  }

  ngOnInit(): void {
    this.EditForm = new LiceForm().create(0,this.disable);

    this.loadLists();
    this.loadTitulqr();
    this.onChanges();
  }

  loadLists() {
    this.nomenclatureService
        .getNomenObshti('01')
        .subscribe(result => {
          this.vidLice = result.map(item => new ViewNom().convertNomObshti(item));  
        });

    this.nomenclatureService
        .getNomenObshti('02')
        .subscribe(result => {
        this.vidIdent = result.map(item => new ViewNom().convertNomObshti(item));
        const value = this.vidIdent.find(e=> e.id == this.EditForm.get('vidIdent').value)
        this.onIdentifierSelectionChange(value)
     });

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

  loadTitulqr() {
    this.licaService
    .getLice(this.id)
    .subscribe(result => {
      this.lice = result;

      this.EditForm.patchValue(
        {
          idl: result.idl,
          vidIdent: null,
          idlice: 0,
          ident: "",
          ime: "",
          nomLk: "",
          dataIzdavane: null,
          statusL: '2',
          vidLice: result.vidLice ? String(result.vidLice) : null,
          admRaion: result.admRaion ? result.admRaion : null,
          nasMqsto: result.nasMqsto ? result.nasMqsto : null,
          kvartal: result.kvartal ? result.kvartal : null,
          jk: result.jk ? result.jk : null,
          ulica: result.ulica ? result.ulica : null,
          nomer: result.nomer ? result.nomer : '',
          blok: result.blok ? result.blok : '',
          vhod: result.vhod ? result.vhod : '',
          etaj: result.etaj ? result.etaj : '',
          apart: result.apart ? result.apart : '',
          email: result.email ? result.email : '',
          telefon: result.telefon ? result.telefon : '',
          postKode: result.postKode ? result.postKode : '',
          v7: result.v7 ? result.v7  : '',
          nv8: result.nv8  ?  String(result.nv8)  : null,
          typeLice: result.typeLice ? String(result.typeLice) : null,
        }
      );
    });
  }


  onIdentifierSelectionChange(value: ViewNom): void {
    const validators = [Validators.required];

    if (value?.name === "ЕГН") {
      validators.push(CustomValidators.Egn);
    } else if (value?.name === "ЛНЧ") {
      validators.push(CustomValidators.Lnch);
    }

    this.EditForm.get("ident").setValidators(validators);
    this.EditForm.get("ident").updateValueAndValidity();
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

  dismiss() {
    this.ref.close();
  }

  save() {
    if (!this.EditForm.valid) {
      let errors = findInvalidControlsRecursive(this.EditForm);

      errors.forEach (e=>{
        let message = getErrorMessage(e, 'lice:');
        if (message) 
            this.toasterService.danger(message,"Грешка!");  
      })
      return;
    }    
    
    this.click  = !this.click;  
    const item: Lice = this.EditForm.value;
    let observable = new Observable<number>();
    observable = this.licaService.addTitular (this.id, this.statusL,item);;
    observable
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((data) => {    
        this.EditForm.get('idlice').setValue(data)  
        this.ref.close(this.EditForm.value);            
      },
      err => {
        this.handleWrongResponse();
    });

    this.click  = !this.click;  
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

}
