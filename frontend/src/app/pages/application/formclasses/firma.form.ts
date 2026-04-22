import { FormControl, FormGroup, Validators } from "@angular/forms";
import { EMAIL_PATTERN } from "../../../@auth/components";
import { HeaderComponent } from "../../../@theme/components";

export class FirmaForm {
  form: FormGroup;
  isEmailRequired: boolean = false;

  constructor() {}

  create(Vid: number, isDisabled: boolean) {
    const identValidators = []
    if (Vid === 3) {
      identValidators.push(Validators.required);
      identValidators.push(Validators.minLength(9));      
      identValidators.push(Validators.maxLength(13));
    }

    const imeValidators = []
    if (Vid === 3) {
      imeValidators.push(Validators.required);
    }

    const emailValidators = [Validators.pattern(EMAIL_PATTERN)];
    //isEmailRequired && emailValidators.push(Validators.required);

    this.form = new FormGroup({
      idfirma: new FormControl({ value: 0, disabled: isDisabled }),
      idl: new FormControl({ value: 0, disabled: isDisabled }),
      faza: new FormControl({
        value: HeaderComponent.faza,
        disabled: isDisabled,
      }),
      vidFirma: new FormControl({ value: null, disabled: isDisabled }),
      tipFirma: new FormControl({ value: null, disabled: isDisabled }),
      ident: new FormControl({ value: "", disabled: isDisabled }, [
        ...identValidators,
      ]),
      kodKID: new FormControl({ value: "00", disabled: isDisabled }),
      ime: new FormControl({ value: "", disabled: isDisabled },[
          ...imeValidators
      ]),
      admRaion: new FormControl({ value: null, disabled: isDisabled }),
      nasMqsto: new FormControl({ value: null, disabled: isDisabled }),
      kvartal: new FormControl({ value: null, disabled: isDisabled }),
      jk: new FormControl({ value: null, disabled: isDisabled }),
      ulica: new FormControl({ value: null, disabled: isDisabled }),
      nomer: new FormControl({ value: "", disabled: isDisabled }),
      blok: new FormControl({ value: "", disabled: isDisabled }),
      vhod: new FormControl({ value: "", disabled: isDisabled }),
      etaj: new FormControl({ value: "", disabled: isDisabled }),
      apart: new FormControl({ value: "", disabled: isDisabled }),
      email: new FormControl({ value: "", disabled: isDisabled }, [
        ...emailValidators,
      ]),
      telefon: new FormControl({ value: "", disabled: isDisabled }),
      postKode: new FormControl({ value: "", disabled: isDisabled }),
      zona: new FormControl({ value: "", disabled: isDisabled }),
      statusL: new FormControl({ value: 1, disabled: isDisabled }),
      statusF: new FormControl({ value: 1, disabled: isDisabled }),
      status: new FormControl({ value: 1, disabled: isDisabled }),
    });

    return this.form;
  }
}
