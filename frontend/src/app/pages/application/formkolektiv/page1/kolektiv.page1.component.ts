import {
  Component,
  Input,
  OnInit,
} from "@angular/core";
import { ControlContainer, FormGroup, Validators } from "@angular/forms";
import { NbDialogService } from "@nebular/theme";
import { Subject } from "rxjs";
import { pairwise, startWith} from "rxjs/operators";
import { Lice, } from "../../../../@core/interfaces/common/lica";
import {
  NomenclatureData,
  ViewNom,
} from "../../../../@core/interfaces/common/nomenclatures";
import { CustomValidators } from "../../../../@core/validators/custom-validators";
import { PagesComponent } from "../../../pages.component";
import { ReplacementDialogComponent } from "../../replacement-dialog/replacement-dialog.component";

@Component({
  selector: "ngx-kolektiv-page1",
  templateUrl: "./kolektiv.page1.component.html",
  styleUrls: ["./kolektiv.page1.component.scss"],
})
export class KolektivPage1Component implements OnInit {
  @Input() statusF:number = 0;
  @Input() raioni: ViewNom[];

  public form: FormGroup;

  vidLice: ViewNom[];
  vidIdent: ViewNom[];
  ulici: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  vlistv8: ViewNom[];
  vliststatus:  ViewNom[];

  protected readonly unsubscribe$ = new Subject<void>();

  constructor(
    private controlContainer: ControlContainer,
    private nomenclatureService: NomenclatureData,
    private dialogService: NbDialogService,
  ) {}

  onIdentifierSelectionChange(value: ViewNom): void {
    const validators = [Validators.required];

    if (value?.name === "ЕГН") {
      validators.push(CustomValidators.Egn);
    } else if (value?.name === "ЛНЧ") {
      validators.push(CustomValidators.Lnch);
    }

    this.form.get("ident").setValidators(validators);
    this.form.get("ident").updateValueAndValidity();
  }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.loadLists();
    this.onChanges();
  }

  loadLists() {
    this.nomenclatureService.getNomenObshti("01").subscribe((result) => {
      this.vidLice = result.map((item) => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService.getNomenObshti("02").subscribe((result) => {
      this.vidIdent = result.map((item) => new ViewNom().convertNomObshti(item));
      const value = this.vidIdent.find(e=> e.id == this.form.get('vidIdent').value)
      this.onIdentifierSelectionChange(value)
    });

    this.nomenclatureService.getNomenNsMesta().subscribe((result) => {
      this.nasmesta = result.map((item) => new ViewNom().convertNomNsMqsto(item));
    });

    this.nomenclatureService.getNomenJk().subscribe((result) => {
      this.kvartali = result.map((item) =>new ViewNom().convertNomKvartal(item));
    });

    if (PagesComponent.raion.length > 0 && this.form.get('raionid')) {
        this.form.get('raionid').patchValue(PagesComponent.raion, {emitEvent: true});
    }

    this.nomenclatureService.getNomenObshti("03").subscribe((result) => {
      this.vlistv8 = result.map((item) => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenStatusi('Status_L')
      .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });        
  }

  
  onChanges(): void {
    this.form.get('nasMqsto').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
            if (prev && prev != next)
              this.form.get('ulica').patchValue(null, {emitEvent: true});
          });
    });
  }

  addTitulqr() {
    this.dialogService
    .open(ReplacementDialogComponent
                      , { hasBackdrop: true,
                          closeOnBackdropClick: true,
                          hasScroll: false,
                          context: {
                            id: this.form.get('idlice').value, 
                            statusL: this.form.get('statusL').value, 
                          },
                        })
    .onClose.subscribe(x => {
      if (x) {
        let lice: Lice = x;
        this.form.get('vidIdent').setValue(lice.vidIdent);
        this.form.get('idlice').setValue(lice.idlice);
        this.form.get('ident').setValue(lice.ident);
        this.form.get('ime').setValue(lice.ime);
        this.form.get('nomLk').setValue(lice.nomLk);
        this.form.get('dataIzdavane').setValue(lice.dataIzdavane);
        this.form.get('admRaion').setValue(lice.admRaion);
        this.form.get('nasMqsto').setValue(lice.nasMqsto);
        this.form.get('kvartal').setValue(lice.kvartal);
        this.form.get('jk').setValue(lice.jk);
        this.form.get('ulica').setValue(lice.ulica);
        this.form.get('nomer').setValue(lice.nomer);
        this.form.get('blok').setValue(lice.blok);
        this.form.get('vhod').setValue(lice.vhod);
        this.form.get('etaj').setValue(lice.etaj);
        this.form.get('apart').setValue(lice.apart);
        this.form.get('email').setValue(lice.email);
        this.form.get('telefon').setValue(lice.telefon);
        this.form.get('postKode').setValue(lice.postKode);    
        this.form.get('statusL').setValue(lice.statusL);    
      }
    });           
  }
}
