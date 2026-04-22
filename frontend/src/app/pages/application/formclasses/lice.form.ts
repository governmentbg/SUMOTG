import { FormControl, FormGroup, Validators } from "@angular/forms";
import { EMAIL_PATTERN } from "../../../@auth/components";
import { CustomValidators } from "../../../@core/validators/custom-validators";
import { HeaderComponent } from "../../../@theme/components";

export class LiceForm {
  form: FormGroup;
  isEmailRequired: boolean = false;

  constructor() {}

  create(Vid: number, isDisabled: boolean) {
    const identValidators = [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(10),
    ];

    const chlenValidators = [];
    if (Vid !== 4) chlenValidators.push(Validators.required);

    const nomLkValidators = [];
    if (Vid !== 4) {
        nomLkValidators.push(Validators.required);
        nomLkValidators.push(Validators.minLength(9));
        nomLkValidators.push(Validators.maxLength(9));
    }
              
    this.form = new FormGroup({
      idl: new FormControl({ value: 0, disabled: isDisabled }),
      faza: new FormControl({
        value: HeaderComponent.faza,
        disabled: isDisabled,
      }),
      vidLice: new FormControl({ value: String(Vid), disabled: true }),
      idlice: new FormControl({ value: 0, disabled: isDisabled }),
      vidIdent: new FormControl({ value: '4', disabled: isDisabled }),
      ident: new FormControl({ value: "", disabled: isDisabled }, [
        ...identValidators,
        CustomValidators.Egn,
      ]),      
      ime: new FormControl({ value: "", disabled: isDisabled }, [
        Validators.required,
      ]),
      nomLk: new FormControl({ value: "", disabled: isDisabled }, 
        [...nomLkValidators]
      ),
      dataIzdavane: new FormControl({ value: "", disabled: isDisabled }),
      admRaion: new FormControl({ value: null, disabled: isDisabled }, 
        [...chlenValidators]
      ),
      nasMqsto: new FormControl({ value: null, disabled: isDisabled }, 
        [...chlenValidators]
      ),
      kvartal: new FormControl({ value: null, disabled: isDisabled }),
      jk: new FormControl({ value: null, disabled: isDisabled }),
      ulica: new FormControl({ value: null, disabled: isDisabled }),
      nomer: new FormControl({ value: "", disabled: isDisabled }),
      blok: new FormControl({ value: "", disabled: isDisabled }),
      vhod: new FormControl({ value: "", disabled: isDisabled }),
      etaj: new FormControl({ value: "", disabled: isDisabled }),
      apart: new FormControl({ value: "", disabled: isDisabled }),
      email: new FormControl({ value: "", disabled: isDisabled }),
      telefon: new FormControl({ value: "", disabled: isDisabled },
        [Validators.required]
      ),
      postKode: new FormControl({ value: "", disabled: isDisabled }),
      tochki1: new FormControl({ value: 0, disabled: isDisabled }),
      tochki2: new FormControl({ value: 0, disabled: isDisabled }),
      tochki3: new FormControl({ value: 0, disabled: isDisabled }),
      tochki4: new FormControl({ value: 0, disabled: true }),
      tochki5: new FormControl({ value: 0, disabled: true }),
      tochki6: new FormControl({ value: 0, disabled: true }),
      tochki7: new FormControl({ value: 0, disabled: true }),
      total: new FormControl({ value: 0, disabled: true }),
      zona: new FormControl({ value: "", disabled: isDisabled }),
      status: new FormControl({ value: 1, disabled: isDisabled }),
      statusL: new FormControl({ value: null, disabled: isDisabled }),
      v7: new FormControl({ value: null, disabled: isDisabled }),
      nv8: new FormControl({ value: null, disabled: isDisabled }),
      typeLice: new FormControl({ value: 1, disabled: isDisabled }),
    });

    return this.form;
  }
}
