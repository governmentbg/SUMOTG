import { FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { HeaderComponent } from '../../../@theme/components/header/header.component';

export class ObrabotkiForms  {
    form: FormGroup;

    constructor() {}

 
    createMonorderEdit(isDisabled: boolean) {
        this.form = new FormGroup({
            idporychkamain: new FormControl({value:0, disabled: isDisabled}),
            nomer: new FormControl(
                {value:0, disabled: isDisabled}, 
                Validators.required
            ),
            data: new FormControl({value:null, disabled: isDisabled}),
            idfirma:new FormControl(
                {value:'', disabled: isDisabled}, 
                Validators.required
            ),
            iddogovorfirma:new FormControl(
                {value:'', disabled: isDisabled}, 
                Validators.required
            ),
            raion:new FormControl(
                {value:null, disabled: isDisabled}, 
                Validators.required,
            ),
            startdata: new FormControl({value:null, disabled: isDisabled}),
            enddata: new FormControl({value:null, disabled: isDisabled}),
            faza: new FormControl({value:HeaderComponent.faza, disabled: isDisabled}),
            porychkaitems: new FormArray([]),
            status: new FormControl({value:1, disabled: isDisabled}),
            status_pm: new FormControl({value:1, disabled: isDisabled}),
            note: new FormControl({value:"", disabled: isDisabled}),
            idmonporychka: new FormControl({value:null, disabled: isDisabled}),
        });

        return this.form;
    }

    createMonorderItem(isDisabled: boolean) {
        this.form = new FormGroup({
            idporychkabody: new FormControl({value:0, disabled: isDisabled}),
            iddogovorlice:new FormControl({value:0, disabled: isDisabled}),
            idl:new FormControl({value:0, disabled: isDisabled}),
            idured:new FormControl({value:0, disabled: isDisabled}),
            broi:new FormControl({value:0, disabled: isDisabled}),
            unom: new FormControl({value:'', disabled: true}),
            dodata:new FormControl({value:null, disabled: isDisabled}),
            otchas: new FormControl({value:'', disabled: isDisabled}),
            dochas: new FormControl({value:'', disabled: isDisabled}),
            note: new FormControl({value:'', disabled: isDisabled}),
            mondata:new FormControl({value:null, disabled: isDisabled}),
            protnomer:new FormControl({value:0, disabled: isDisabled}),
            protdata:new FormControl({value:null, disabled: isDisabled}),
            model:new FormControl({value:'', disabled: isDisabled}),
            fabrnomer:new FormControl({value:'', disabled: isDisabled}),
            garkarta:new FormControl({value:'', disabled: isDisabled}),
            gardata:new FormControl({value:null, disabled: isDisabled}),
            note2: new FormControl({value:'', disabled: isDisabled}),
            status_g: new FormControl({value:1, disabled: isDisabled}),
            status_m: new FormControl({value:1, disabled: isDisabled}),
            status: new FormControl({value:1, disabled: isDisabled}),
            uredname: new FormControl({value:'', disabled: true}),
            ident: new FormControl({value:'', disabled: isDisabled}),
            ime: new FormControl({value:'', disabled: true}),
            vidimot: new FormControl({value:'', disabled: true}),
            adres: new FormControl({value:'', disabled: true}),
            email: new FormControl({value:'', disabled: true}),
            telefon: new FormControl({value:'', disabled: true}),
            snimka: new FormControl({value:'', disabled: isDisabled}),
            safeurl: new FormControl({value:'', disabled: isDisabled}),
            vidured: new FormControl({value:'', disabled: isDisabled}),
            raion: new FormControl({value:'', disabled: isDisabled}),
            note3: new FormControl({value:'', disabled: isDisabled}),
        });

        return this.form;
    }
  
    createUredItem(): FormGroup {
        return new FormGroup({
            idspdost: new FormControl(0),
            id: new FormControl(0),
            name: new FormControl(''),
            edcena: new FormControl(0),
            broi: new FormControl(0),
            maxbroi: new FormControl(0),
            broiporychani: new FormControl(0),
        });
    }


//#region fakturi
    createFakturiEdit(vid: number, isDisabled: boolean) {
        const cenaValidators = [
            Validators.required,
            Validators.min (0.01)
        ];

        this.form = new FormGroup({
            vidfirma: new FormControl({value:vid}),
            idfactura: new FormControl({value:0, disabled: isDisabled}),
            facnomer: new FormControl(
                {value:'', disabled: isDisabled}, 
                Validators.required
            ),
            facdata: new FormControl({value:null, disabled: isDisabled}),
            idfirma:new FormControl(
                {value:'0', disabled: isDisabled}, 
                Validators.required
            ),
            iddogovorfirma:new FormControl(
                {value:'0', disabled: isDisabled}, 
                Validators.required
            ),
            suma: new FormControl({value:0, disabled: isDisabled},
                [...cenaValidators]
            ),
            dds: new FormControl({value:0, disabled: isDisabled},
                 [...cenaValidators]
            ),
            total: new FormControl({value:0, disabled: isDisabled},
                [...cenaValidators]
            ),
            fakturaitems: new FormArray([this.createFakturaUredItem()]),
            status: new FormControl({value:1, disabled: isDisabled}),
            vidpayment: new FormControl(
                {value:'', disabled: isDisabled}, 
            ),
            forperiod: new FormControl(
                {value:'', disabled: isDisabled}, 
            ),
        });

        return this.form;
    }

    createFakturaUredItem(): FormGroup {
        return new FormGroup({
            idfactura: new FormControl(0),
            id: new FormControl(null),
            edcena: new FormControl(0),
            broi: new FormControl(0),
            total: new FormControl({value:0, disabled: true}),
            status: new FormControl(1),
        });
    }
//#endregion

}
