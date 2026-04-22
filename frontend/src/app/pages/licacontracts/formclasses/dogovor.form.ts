import { FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { HeaderComponent } from '../../../@theme/components';

export class LiceDogovorForm  {
    form: FormGroup;

    constructor() {}

    create(isDisabled: boolean) {
        const identValidators = [
            Validators.required,
            Validators.minLength(10),
            Validators.maxLength(10),
        ];

        this.form = new FormGroup({
            iddog:new FormControl({value:0, disabled: isDisabled}),
            idl:new FormControl({value:0, disabled: isDisabled}),
            faza: new FormControl({value:HeaderComponent.faza, disabled: isDisabled}),
            regnom: new FormControl({value:'', disabled: isDisabled}),
            regnomdata: new FormControl({value:null, disabled: isDisabled}),
            uredi: new FormArray([this.createUredItem()]),
            olduredi: new FormArray([this.createOldUredItem()]),
            arhuredi: new FormArray([this.createArhUredItem()]),
            dopsp: new FormArray([this.createDopSpItem()]),
            status_DL: new FormControl({value:1, disabled: isDisabled}),
            status: new FormControl({value:1, disabled: isDisabled}),
            comentar: new FormControl({value:'', disabled: isDisabled}),
            brdopsp: new FormControl({value:'', disabled: isDisabled}),
            vid: new FormControl({value:0, disabled: isDisabled}),
            srokDogovor: new FormControl({value:0, disabled: isDisabled}),
            srokSobstvenost: new FormControl({value:0, disabled: isDisabled})
        });

        return this.form;
    }

    createArhUredItem(): FormGroup {
        return new FormGroup({
            id: new FormControl({value:null, disabled: false}, [Validators.required]),
            broi: new FormControl({value:0, disabled: false}, [Validators.min(1)]),
            status: new FormControl({value:1, disabled: false}),
            statusU: new FormControl({value:'1', disabled: false}),
        });
    }

    createOldUredItem(): FormGroup {
        return new FormGroup({
            id: new FormControl({value:null, disabled: false}, [Validators.required]),
            broi: new FormControl({value:0, disabled: false}, [Validators.min(1)]),
            status: new FormControl({value:1, disabled: false}),
            statusU: new FormControl({value:'1', disabled: false}),
        });
    }

    createUredItem(): FormGroup {
        return new FormGroup({
            id: new FormControl({value:null, disabled: false}, [Validators.required]),
            broi: new FormControl({value:0, disabled: false}, [Validators.min(1)]),
            status: new FormControl({value:1, disabled: false}),
            statusU: new FormControl({value:'1', disabled: false}),
        });
    }

    createDopSpItem(): FormGroup {
        return new FormGroup({
            id: new FormControl({value:null, disabled: false}),
            regnomer: new FormControl({value:'', disabled: false}),
            komentar: new FormControl({value:'', disabled: false}),
        });
    }

}
