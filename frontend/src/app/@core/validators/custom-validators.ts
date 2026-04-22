import { AbstractControl, FormControl, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";
import { EgnUtils } from "../utils/egn.utils";
import { LnchUtils } from "../utils/lnch.utils";

export class CustomValidators {
  static Egn(control: AbstractControl): ValidationErrors | null {
    if (control.value.length < 10) {
      return { invalidEgn: control.value };
    }

    return EgnUtils.isValid(control.value) ? null : { invalidEgn: control.value };
  }

  static Lnch(control: AbstractControl): ValidationErrors | null {
    if (control.value.length < 10) {
      return { invalidLnch: control.value };
    }

    return LnchUtils.isValid(control.value) ? null : { invalidLnch: control.value };
  }
}
