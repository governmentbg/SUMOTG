import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common'
import { FormGroup, Validators  } from '@angular/forms';
import { ActivatedRoute,  Router} from '@angular/router';
import { Address, Lice, LiceData } from '../../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { LiceForm } from '../../formclasses/lice.form';
import { RoutingState } from '../../../../@core/backend/common/services/RoutingState.service';
import { Observable, Subject } from 'rxjs';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { pairwise, startWith, takeUntil } from 'rxjs/operators';
import { findInvalidControlsRecursive, getErrorMessage } from '../../../../@core/tools/functions';
import { CustomValidators } from '../../../../@core/validators/custom-validators';
import { PagesComponent } from '../../../pages.component';
import { AddressEditDialogComponent } from '../../address-dialog/address-dialog.component';

@Component({
  selector: 'ngx-lice',
  templateUrl: './lice.component.html',
  styleUrls: ['./lice.component.scss'],
})
export class LiceComponent implements OnInit {
  mainForm: FormGroup;
  _VID: number = 1;
  click: boolean = false;
  
  id: number = 0;
  name: string = '';
  idformulqr: number = 0;
  disable: boolean = false;
  previousUrl: string = '';

  lice: Lice;
  vidLice: ViewNom[];
  vidIdent: ViewNom[];
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  vliststatus:ViewNom[];
  vlistv8: ViewNom[];

  protected readonly unsubscribe$ = new Subject<void>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private licaService: LiceData,
    private nomenclatureService: NomenclatureData,
    private routingState: RoutingState,
    private toasterService: NbToastrService,
    private location: Location,
    private dialogService: NbDialogService,       
  ) {
    this.previousUrl = this.routingState.getPreviousUrl()

    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      this.idformulqr = Number(params.get('idformulqr'));
      this.disable = String(params.get('disable'))==='true';        
    });
  }

  ngOnInit(): void {
    this.mainForm = new LiceForm().create(0,this.disable);

    this.loadLists();
    if (this.id > 0) {
      this.loadLice();
    }
    this.onChanges();
}

  editFormuliar () {
    let url = '/pages/register/zaqvlenie/' + this.idformulqr + '/' + this.lice.ime+'/'+this.disable ;
    if (this.lice.vidLice === 3) {
      url = '/pages/register/zaqvleniefirma/' + this.idformulqr + '/' + this.lice.ime+'/'+this.disable ;
    } else if (this.lice.vidLice === 2) {
      url = '/pages/register/zaqvleniekolektiv/' + this.idformulqr + '/' + this.lice.ime+'/'+this.disable ;
    }

    this.router.navigateByUrl(url);
  }

  loadLists() {
    this.nomenclatureService
        .getNomenObshti('01')
        .subscribe(result => {
          this.vidLice = result.map(item => new ViewNom().convertNomObshti(item));  
        });

    this.nomenclatureService
        .getNomenObshti('02')
        .subscribe(result => {
        this.vidIdent = result.map(item => new ViewNom().convertNomObshti(item));
        const value = this.vidIdent.find(e=> e.id == this.mainForm.get('vidIdent').value)
        this.onIdentifierSelectionChange(value)
     });

    this.nomenclatureService
        .getNomenNsMesta()
        .subscribe(result => {
          this.nasmesta = result.map(item => new ViewNom().convertNomNsMqsto(item));
    });

    this.nomenclatureService
        .getNomenJk()
        .subscribe(result => {
          this.kvartali = result.map(item => new ViewNom().convertNomKvartal(item));
    });

    this.nomenclatureService
      .getNomenRaioni()
      .subscribe(result => {
            if (PagesComponent.raion.length > 0) {
              this.mainForm.get('admRaion').patchValue(PagesComponent.raion, {emitEvent: true});
              this.raioni = result.filter(e => e.nkod == PagesComponent.raion)
                                  .map(item => new ViewNom().convertNomRaion(item));
            } else    
              this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_L')
        .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });


    this.nomenclatureService.getNomenObshti("03").subscribe((result) => {
      this.vlistv8 = result.map((item) => new ViewNom().convertNomObshti(item));
    });    
  }

  loadLice() {
    this.licaService
        .getLice(this.id)
        .subscribe(result => {
          this.lice = result;
          this._VID = this.lice.vidLice;
          this.name = this.name + ' ['+result.unom+']'

          this.mainForm.patchValue(
            {
              idl: result.idl,
              vidLice: result.vidLice ? String(result.vidLice) : null,
              vidIdent: result.vidIdent ? String(result.vidIdent) : null,
              idlice: result.idlice,
              ident: result.ident ? result.ident : '',
              ime: result.ime ? result.ime : '',
              nomLk: result.nomLk ? result.nomLk : '',
              dataIzdavane: result.dataIzdavane,
              admRaion: result.admRaion ? result.admRaion : null,
              nasMqsto: result.nasMqsto ? result.nasMqsto : null,
              kvartal: result.kvartal ? result.kvartal : null,
              jk: result.jk ? result.jk : null,
              ulica: result.ulica ? result.ulica : null,
              nomer: result.nomer ? result.nomer : '',
              blok: result.blok ? result.blok : '',
              vhod: result.vhod ? result.vhod : '',
              etaj: result.etaj ? result.etaj : '',
              apart: result.apart ? result.apart : '',
              email: result.email ? result.email : '',
              telefon: result.telefon ? result.telefon : '',
              postKode: result.postKode ? result.postKode : '',
              tochki1: result.tochki1 ? result.tochki1 :0 ,
              tochki2: result.tochki2 ? result.tochki2 :0 ,
              tochki3: result.tochki3 ? result.tochki3 :0 ,
              tochki4: result.tochki4 ? result.tochki4 :0 ,
              tochki5: result.tochki5 ? result.tochki5 :0 ,
              tochki6: result.tochki6 ? result.tochki6 :0 ,
              tochki7: result.tochki7 ? result.tochki7 :0 ,
              total:  result.total,
              v7: result.v7 ? result.v7  : '',
              nv8: result.nv8  ?  String(result.nv8)  : null,
              statusL: result.statusL ? String(result.statusL) : null,
              typeLice: result.typeLice ? String(result.typeLice) : null,
            }
          );
        });
  }

  save() {
    if (!this.mainForm.valid) {
      let errors = findInvalidControlsRecursive(this.mainForm);

      errors.forEach (e=>{
        let message = getErrorMessage(e, 'lice:');
        if (message) 
            this.toasterService.danger(message,"Грешка!");  
      })
      return;
    }    
    
    this.click  = !this.click;
    const item: Lice = this.convertToLice(this.mainForm.value);

    let adres: Address = {
      id: item.idl,
      raionid:  item.admRaion,
      nm: item.nasMqsto,
      kv: item.kvartal,
      jk: item.jk,
      ul: item.ulica,
      nomer: item.nomer,
      blok: item.blok,
      vh: item.vhod,
      etaj: item.etaj,
      ap: item.apart,
      opos: ''
   }
   
   this.licaService
   .checkFormulqrAdres(adres)
   .subscribe((result) => {      
       if (result > 0) {
        this.dialogService
            .open(AddressEditDialogComponent
                  , { hasBackdrop: true,
                      closeOnBackdropClick: true,
                      hasScroll: false,
                      context: {
                        id: result,
                      },
                  })
            .onClose.subscribe(x => {
                this.click  = !this.click;
        });                      

      } else if (result < 0) {
         this.toasterService.danger("Дублиране на адрес с aдрес, участващ в друг проект!");  
       } else {
          let observable = new Observable<number>();

          if (this.mainForm.get('typeLice').value > 3)
            observable = this.licaService.setChlen(item)
          else
            observable = this.licaService.setLice(item)
          
          observable
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(() => {
                this.handleSuccessResponse();
              },
              err => {
                this.handleWrongResponse();
              });
        }
    });   
  }      

  convertToLice(value: any): Lice {
    const l: Lice = value;
    l.vidLice = this._VID;
    l.tochki4 = this.lice.tochki4
    l.tochki5 = this.lice.tochki5
    l.tochki6 = this.lice.tochki6
    l.tochki7 = this.lice.tochki7
    return l;
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

  back() {
    this.location.back()

    // if (this.router.url === this.previousUrl)
    //   this.router.navigateByUrl('pages/register/persons');
    // else
    //   this.router.navigateByUrl(this.previousUrl);
  }

  onIdentifierSelectionChange(value: ViewNom): void {
    const validators = [Validators.required];

    if (value?.name === "ЕГН") {
      validators.push(CustomValidators.Egn);
    } else if (value?.name === "ЛНЧ") {
      validators.push(CustomValidators.Lnch);
    }

    this.mainForm.get("ident").setValidators(validators);
    this.mainForm.get("ident").updateValueAndValidity();
  }

  onChanges(): void {
    this.mainForm.get('nasMqsto').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
            if (prev && prev != next)
              this.mainForm.get('ulica').patchValue(null, {emitEvent: true});
          });
    });
  }


}
