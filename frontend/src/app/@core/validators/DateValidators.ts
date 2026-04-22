import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class DateValidators {
    static greaterThan(startControl: AbstractControl): ValidatorFn {
      return (endControl: AbstractControl): ValidationErrors | null => {
        const startDate: Date = startControl.value;
        const endDate: Date = endControl.value;
        if (!startDate || !endDate) {
          return null;
        }
        if (startDate >= endDate) {
          return { greaterThan: true };
        }
        return null;
      };
    }

    static greaterThanCurrent(): ValidatorFn {
        return (endControl: AbstractControl): ValidationErrors | null => {
          const startDate: Date = new Date();
          const endDate: Date = endControl.value;
          if (!startDate || !endDate) {
            return null;
          }
          if (startDate > endDate) {
            return { greaterThanCurrent: true };
          }
          return null;
        };
      }
  
      static smallerThanCurrent(): ValidatorFn {
        return (endControl: AbstractControl): ValidationErrors | null => {
          const startDate: Date = new Date();
          const endDate: Date = endControl.value;
          if (!startDate || !endDate) {
            return null;
          }
          if (startDate <= endDate) {
            return { smallerThanCurrent: true };
          }
          return null;
        };
      }
  
}