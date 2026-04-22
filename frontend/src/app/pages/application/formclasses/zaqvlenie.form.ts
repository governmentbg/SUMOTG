import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { HeaderComponent } from "../../../@theme/components";
import { FirmaForm } from "./firma.form";
import { LiceForm } from "./lice.form";

export interface SpravkaKandidat {
  col1: string
  col2: string
  col3: string
  col4: boolean
}

export class ZaqvlenieForm {
  form: FormGroup;
 
  constructor() {}

  create(Vid: number, isDisabled: boolean): FormGroup {

    const v32Validators = [];
    if (Vid !=3) v32Validators.push(Validators.min(1));

    const v33Validators = [];
    if (Vid !=3) v33Validators.push(Validators.min(1));
    
    this.form = new FormGroup({
      idformulqr: new FormControl({ value: 0, disabled: isDisabled }),
      unom: new FormControl({ value: "", disabled: isDisabled }),
      faza: new FormControl({
        value: HeaderComponent.faza,
        disabled: isDisabled,
      }),
      lice: new LiceForm().create(Vid, isDisabled),
      firma: new FirmaForm().create(Vid, isDisabled),
      nv9: new FormControl({ value: null, disabled: isDisabled }, [Validators.required]),
      nv10: new FormControl({ value: null, disabled: isDisabled }),
      v11: new FormControl({ value: 0, disabled: isDisabled }),
      v12: new FormControl({ value: 0, disabled: isDisabled },[Validators.min(1)]),
      v13: new FormControl({ value: 0, disabled: isDisabled },[Validators.min(1)]),
      v14: new FormControl({ value: 0, disabled: isDisabled },[Validators.min(1)]),
      v15: new FormControl({ value: 0, disabled: isDisabled }),
      v16: new FormControl({ value: 0, disabled: isDisabled }),
      v17: new FormControl({ value: 0, disabled: isDisabled }),
      nv19: new FormControl({ value: null, disabled: isDisabled }),
      v20: new FormControl({ value: 0, disabled: isDisabled }),
      v211: new FormControl({ value: 0, disabled: isDisabled }),
      v212: new FormControl({ value: 0, disabled: isDisabled }),
      v213: new FormControl({ value: 0, disabled: isDisabled }),
      v22: new FormControl({ value: 0, disabled: isDisabled }),
      v23: new FormControl({ value: 0, disabled: isDisabled }),
      v24: new FormControl({ value: 0, disabled: isDisabled }),
      v25: new FormControl({ value: 0, disabled: isDisabled }),
      v26: new FormControl({ value: 0, disabled: isDisabled }),
      v27: new FormControl({ value: 0, disabled: isDisabled }),
      v28: new FormControl({ value: 0, disabled: isDisabled }),
      nv29: new FormControl({ value: null, disabled: isDisabled }),
      v30: new FormControl({ value: 0, disabled: isDisabled }),
      v31: new FormControl({ value: 0, disabled: isDisabled }),
      v32: new FormControl({ value: 0, disabled: isDisabled },[...v32Validators]),
      v33: new FormControl({ value: 0, disabled: isDisabled },[...v33Validators]),
      v34: new FormControl({ value: 0, disabled: isDisabled }),
      v35: new FormControl({ value: 0, disabled: isDisabled }),
      v36: new FormControl({ value: 0, disabled: isDisabled }),
      v37: new FormControl({ value: 0, disabled: isDisabled }),
      v38: new FormControl({ value: 0, disabled: isDisabled }),
      v391: new FormControl({ value: 0, disabled: isDisabled }),
      v392: new FormControl({ value: 0, disabled: isDisabled }),
      v401: new FormControl({ value: 0, disabled: isDisabled }),
      v402: new FormControl({ value: 0, disabled: isDisabled }),
      v41: new FormControl({ value: 0, disabled: isDisabled }),
      v421: new FormControl({ value: 0, disabled: isDisabled }),
      v422: new FormControl({ value: 0, disabled: isDisabled }),
      v423: new FormControl({ value: 0, disabled: isDisabled }),
      uredi: new FormArray([this.createUredItem()], [Validators.required]),
      olduredi: new FormArray([this.createOldUredItem()], [Validators.required]),
      dokumenti: new FormArray([this.createDocumentItem()]),
      systav: new FormArray([]),
      status: new FormControl({ value: 1, disabled: isDisabled }),
      statusF: new FormControl({ value: 1, disabled: isDisabled }),
      statusDL: new FormControl({ value: 0, disabled: isDisabled }),
      unomer: new FormControl({ value: 0, disabled: isDisabled }),
      comentar: new FormControl({value:'', disabled: isDisabled}),
    });

    return this.form;
  }

  createOldUredItem(): FormGroup {
    return new FormGroup({
      id: new FormControl(null, [Validators.required]),
      broi: new FormControl(0, [Validators.min(1)]),
      status: new FormControl(1),
      statusU: new FormControl(1),
    });
  }

  createUredItem(): FormGroup {
    return new FormGroup({
      id: new FormControl(null, [Validators.required]),
      broi: new FormControl(0, [Validators.min(1)]),
      status: new FormControl(1),
      statusU: new FormControl(1),
    });
  }

  createDocumentItem(): FormGroup {
    return new FormGroup({
      idl: new FormControl(null),
      iddoc: new FormControl(null),
      id: new FormControl(null),
      nime: new FormControl(""),
      description: new FormControl(""),
      status: new FormControl(1),
      filename: new FormControl(""),
    });
  }
}
