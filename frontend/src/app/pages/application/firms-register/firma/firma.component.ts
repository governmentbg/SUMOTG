import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common'
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { pairwise, startWith, takeUntil } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { RoutingState } from '../../../../@core/backend/common/services/RoutingState.service';
import { DocumentsData, Dokument } from '../../../../@core/interfaces/common/documents';
import { Address, Firma, LiceData } from '../../../../@core/interfaces/common/lica';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { findInvalidControlsRecursive, getErrorMessage } from '../../../../@core/tools/functions';
import { PagesComponent } from '../../../pages.component';
import { FileUploadDialogComponent } from '../../components/fileupload-dialog/fileupload-dialog.component';
import { FirmaForm } from '../../formclasses/firma.form';
import { AddressEditDialogComponent } from '../../address-dialog/address-dialog.component';

@Component({
  selector: 'ngx-firms',
  templateUrl: './firma.component.html',
  styleUrls: ['./firma.component.scss']
})
export class FirmaComponent implements OnInit {
  mainForm: FormGroup;
  previousUrl: string = '';
  _VID: number = 1;
  click: boolean = false;

  id: number = 0;
  name: string = '';
  idformulqr: number = 0;
  disable: boolean = false;

  firma: Firma;
  vlistVidfirma: ViewNom[];
  vlistTipfirma: ViewNom[];
  ulici: ViewNom[];
  raioni: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  vliststatus: ViewNom[];
  kid: ViewNom[];
  dokumenti: Dokument[];

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
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.name = String(params.get('name'));
      this.idformulqr = Number(params.get('idformulqr'));
      this.disable = String(params.get('disable'))==='true';

    });
  }

  ngOnInit(): void {
    this.previousUrl = this.routingState.getPreviousUrl()
    this.mainForm = new FirmaForm().create(3,this.disable);

    this.loadLists();
    if (this.id > 0) {
      this.loadFirma();
    }  
    this.onChanges();
  }

  editFormuliar () {
    const url = '/pages/register/zaqvleniefirma/' + this.idformulqr + '/' + this.firma.ime+'/'+this.disable ;
    this.router.navigateByUrl(url);
  }

  loadLists() {
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
            this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService
        .getNomenObshti('12')
        .subscribe(result => {
      this.vlistVidfirma = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
        .getNomenObshti('13')
        .subscribe(result => {
      this.vlistTipfirma = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_L')
        .subscribe(result => {
        this.vliststatus = result.map(item => new ViewNom().convertNomStatusi(item));
    });    

    this.nomenclatureService
      .getNomenKID()
      .subscribe(result => {
        this.kid = result.map(item => new ViewNom().convertNomKID(item));
    });    
  }
  
  loadFirma() {
    this.licaService
        .getFirma(this.id)
        .subscribe(result => {
          this.firma = result;

          this.mainForm.patchValue(
            {
              idfirma: result.idfirma,
              idl: result.idl,
              faza: result.faza,            
              vidFirma: result.vidFirma ? result.vidFirma : null,
              tipFirma: result.tipFirma ? result.tipFirma : null,
              kodKID: result.kodKID ? result.kodKID : '',
              ident: result.ident ? result.ident : '',
              ime: result.ime ? result.ime : '',
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
              statusL: result.statusL? result.statusL : null,
            }
          );
        });
  }

  save() {
    if (!this.mainForm.valid) {
      let errors = findInvalidControlsRecursive(this.mainForm);

      errors.forEach (e=>{
        let message = getErrorMessage(e, 'firma:');
        if (message) 
            this.toasterService.danger(message,"Грешка!");  
      })
      return;
    }    

    this.click  = !this.click;
    const item: Firma = this.convertToFirma(this.mainForm.value);

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
                if (x) false;
         });               
       } else if (result < 0) {
         this.toasterService.danger("Дублиране на адрес с aдрес, участващ в друг проект!");  
       } else {
          let observable = new Observable<number>();
          observable = this.licaService.setFirma(item)
          
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
  
  convertToFirma(value: any): Firma {
    const l: Firma = value;
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