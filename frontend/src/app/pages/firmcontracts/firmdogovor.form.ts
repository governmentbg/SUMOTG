import { FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { HeaderComponent } from '../../@theme/components';

export class FirmDogovorForm  {
    form: FormGroup;

    constructor(
       
    ) {}

    create(isDisabled: boolean) {
        const cenaValidators = [
            Validators.required,
            Validators.min (1)
        ];

        this.form = new FormGroup({
            iddog:new FormControl({value:0, disabled: isDisabled}),
            faza: new FormControl({value:HeaderComponent.faza, disabled: isDisabled}),
            regnom: new FormControl({value:'', disabled: isDisabled},
                    Validators.required
            ),
            regnomdata: new FormControl({value:null, disabled: isDisabled},
                Validators.required
            ),
            nomdgsudso: new FormControl({value:'', disabled: isDisabled}),
            nachalnadata: new FormControl({value:null, disabled: isDisabled}),
            srokgrafic: new FormControl({value:0, disabled: isDisabled}),
            cenabezdds: new FormControl({value:0, disabled: isDisabled},
               [...cenaValidators]
            ),
            cenadds: new FormControl({value:0, disabled: isDisabled},
                [...cenaValidators]
            ),
            broiporychki: new FormControl({value:0, disabled: isDisabled}),
            uredi: new FormArray([this.createUredItem()]),
            raioni: new FormArray([this.createRaionItem()]),
            status_DM: new FormControl({value:1, disabled: isDisabled}),
            status: new FormControl({value:1, disabled: isDisabled}),
            firma: this.createFirmForm(isDisabled),
            payments: new FormArray([this.createPaymentItem()]),
        });

        return this.form;
    }

    createFirmForm(isDisabled): FormGroup {
        const identValidators = []
        identValidators.push(Validators.required);
        identValidators.push(Validators.minLength(9));      
        identValidators.push(Validators.maxLength(13));

        return new FormGroup({
            idfirma:new FormControl({value:0, disabled: isDisabled}),
            faza: new FormControl({value:HeaderComponent.faza, disabled: isDisabled}),
            vidFirma: new FormControl({value:0, disabled: isDisabled}),
            rolq: new FormControl({value:0, disabled: isDisabled}),
            eik: new FormControl({value:'', disabled: isDisabled},[
                ...identValidators
            ]),
            ime: new FormControl({value:'', disabled: isDisabled}
               ,Validators.required
            ),
            manager: new FormControl({value:'', disabled: isDisabled}),
            mname: new FormControl({value:'', disabled: isDisabled}),
            adres: new FormControl({value:'', disabled: isDisabled}),
            email: new FormControl({value:'', disabled: isDisabled}),
            telefon: new FormControl({value:'', disabled: isDisabled}),
            postKode: new FormControl({value:'', disabled: isDisabled}),
            status:new FormControl({value:1, disabled: isDisabled}),
            statusDM: new FormControl({value:1, disabled: isDisabled}),   
        });
    }

    createPaymentItem(): FormGroup {
        return new FormGroup({
            id: new FormControl(null),
            sumabezdds: new FormControl(0),
            sumasdds: new FormControl(0),
        });
    }

    createRaionItem(): FormGroup {
        return new FormGroup({
            nkod: new FormControl(null),
        });
    }

    createUredItem(): FormGroup {
        return new FormGroup({
            idured: new FormControl(0),
            model: new FormControl(''),
            edcena: new FormControl(0),
            broi: new FormControl(0),
            total:new FormControl({value:0, disabled: true}),
            status: new FormControl(1),
            garancia: new FormControl(24),
            profilaktika: new FormControl({value:12, disabled: true}),
        });
    }

}
