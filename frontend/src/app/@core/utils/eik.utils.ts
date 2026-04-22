import { Injectable } from "@angular/core";

/**
 * Проверка на БУЛСТАТ
 */
@Injectable({
  providedIn: "root",
})
export class EIKUtils {
  private CONTROLS1 = [1, 2, 3, 4, 5, 6, 7, 8];
  private CONTROLS2 = [3, 4, 5, 6, 7, 8, 9, 10];

  private ADDCONTROLS1 = [2, 7, 3, 5];
  private ADDCONTROLS2 = [4, 9, 5, 7];

  private _value: string;

  constructor(value) {
    if (typeof value !== "string") {
      throw new Error(`${value} is not of type string!`);
    }

    if (!(value.length === 9 || value.length === 13)) {
      throw new Error(`${value} is in wrong size!`);
    }

    this._value = value;
  }

  private value() {
    return this._value;
  }


  public isValid(): boolean {
    let sum = 0;

    for (let i = 0; i < this.CONTROLS1.length; i++) {
      sum += ~~this._value.charAt(i) * this.CONTROLS1[i];
    }

    let mod = sum % 11;
    if (mod == 10) {
        for (let i = 0; i < this.CONTROLS1.length; i++) {
            sum += ~~this._value.charAt(i) * this.CONTROLS2[i];
        }      
        let mod = sum % 11;
    }
    
    if (this._value.length==13) {
        for (let i = 0; i < this.ADDCONTROLS1.length; i++) {
            sum += ~~this._value.charAt(i+8) * this.ADDCONTROLS1[i];
        }      

        let mod = sum % 11;
        if (mod == 10) {
            for (let i = 0; i < this.ADDCONTROLS2.length; i++) {
                sum += ~~this._value.charAt(i+8) * this.ADDCONTROLS2[i];
            }      
            let mod = sum % 11;
        }    
    }

    return mod === ~~this._value.substr(~~this._value.length-1);
  }

  public static isValid(value): boolean {
    var utils = new EIKUtils(value);
    var result = utils.isValid();
    return result;
  }
}
