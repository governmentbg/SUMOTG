
import { ChangeDetectionStrategy, ChangeDetectorRef, Component,  OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { startWith, pairwise, takeUntil } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable, Subject } from 'rxjs';
import { CustomToastrService } from '../../../@core/backend/common/custom-toastr.service';
import { CollectInfo, PublicData } from '../../../@core/interfaces/common/public';
import {Location} from '@angular/common';

import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'


@Component({
  selector: 'ngx-collectinfo-form',
  styleUrls: ['./collectinfo-form.component.scss'],
  templateUrl: './collectinfo-form.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NgxCollectInfoComponent implements OnInit {
  isDisabled: boolean = false;
  click: boolean = false;

  form: FormGroup;
  raioni: ViewNom[];
  ulici: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  vlistv7: ViewNom[];
  vlistv8: ViewNom[];

  protected readonly unsubscribe$ = new Subject<void>();
  
  constructor(
    protected cd: ChangeDetectorRef
    ,protected fb: FormBuilder
    ,private spinner: NgxSpinnerService
    ,private toasterService: CustomToastrService
    ,private publicService: PublicData
    ,private nomenclatureService: NomenclatureData
    ,private location: Location
  ) { }

  async ngOnInit(): Promise<void> {    
    this.createForm();
    this.loadLists();
    this.onChanges();
  }

  createForm() {
  
    this.form = new FormGroup({
      ime: new FormControl({ value: "", disabled: this.isDisabled }, [
        Validators.required,
      ]),
      prezime: new FormControl({ value: "", disabled: this.isDisabled }),
      familiq: new FormControl({ value: "", disabled: this.isDisabled }, [
        Validators.required,
      ]),
      raionid: new FormControl({ value: null, disabled: this.isDisabled }, 
        [Validators.required]
      ),
      nm: new FormControl({ value: null, disabled: this.isDisabled }, 
        [Validators.required]
      ),
      pk: new FormControl({ value: "", disabled: this.isDisabled }),      
      jk: new FormControl({ value: null, disabled: this.isDisabled }),
      ul: new FormControl({ value: null, disabled: this.isDisabled }),
      nomer: new FormControl({ value: "", disabled: this.isDisabled }),
      blok: new FormControl({ value: "", disabled: this.isDisabled }),
      vh: new FormControl({ value: "", disabled: this.isDisabled }),
      etaj: new FormControl({ value: "", disabled: this.isDisabled }),
      ap: new FormControl({ value: "", disabled: this.isDisabled }),
      email: new FormControl({ value: "", disabled: this.isDisabled },
 //       [Validators.required]
      ),
      tel: new FormControl({ value: "", disabled: this.isDisabled },
        [Validators.required]
      ),
      v1: new FormControl({ value: null, disabled: this.isDisabled }, 
        [Validators.required]
      ),
      v101: new FormControl({ value: null, disabled: this.isDisabled },
        [  Validators.required
          ,Validators.min(1)
          ,Validators.max(9)
          ,Validators.pattern("[0-9]{1,2}?$")
        ]
      ),
      v2: new FormControl({ value: null, disabled: this.isDisabled },
        [Validators.required]
      ),
      v201: new FormControl({ value: null, disabled: this.isDisabled },
        [  Validators.required
          ,Validators.min(1)
          ,Validators.max(9)
          ,Validators.pattern("[0-9]{1,2}?$")
        ]
      ),
      editmode: new FormControl({ value: 0, disabled: this.isDisabled }),
    });
  }

  loadLists() {
    this.nomenclatureService.getNomenRaioni().subscribe(result => {
      this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService.getNomenJk().subscribe((result) => {
      this.kvartali = result.map((item) => new ViewNom().convertNomKvartal(item));
    });

    this.nomenclatureService.getNomenObshti('15').subscribe(result => {
      this.vlistv7 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService.getNomenObshti('16').subscribe(result => {
      this.vlistv8 = result.map(item => new ViewNom().convertNomObshti(item));
    });

  }

  onChanges(): void {
    debugger;
    this.form.get('raionid').valueChanges
          .pipe(startWith(null as string), pairwise())
          .subscribe(([prev, next]: [any, any]) => {
            debugger
              this.nomenclatureService.getNomenNsMestaByRaion(next).subscribe((result) => {
                this.nasmesta = result.map((item) => new ViewNom().convertNomNsMqsto(item));
                if (prev && prev != next)
                  this.form.get('nm').patchValue(null, {emitEvent: true});
                  this.form.get('ul').patchValue(null, {emitEvent: true});
              });
    });

    this.form.get('nm').valueChanges
          .pipe(startWith(null as string), pairwise())
          .subscribe(([prev, next]: [any, any]) => {
              this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
                this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
                if (prev && prev != next)
                  this.form.get('ul').patchValue(null, {emitEvent: true});
              });
    });
  }

  checkData() {
    const data: CollectInfo = this.form.value;

    const emailRegex: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (data.email && !emailRegex.test(data.email) ) {
      this.toasterService.danger("", `Грешен формат на email!.`);
      return false;
    } else if (data.v2 == 90 && data.v201 > 3) {
      this.toasterService.danger("", `8.1 Брой уреди за монтаж трябва да бъде 1, 2 или 3!.`);
      return false;
    } else if (data.v2 > 90 && data.v201 > 1){
      this.toasterService.danger("", `8.1 Брой уреди за монтаж трябва да бъде 1!.`);
      return false;
    }

    return true;
  }

  save() {
    this.click = true;
    if (this.checkData()) {
        this.spinner.show();  
  
        const data: CollectInfo = this.form.value;

        let observable = new Observable<number>();
        observable = this.publicService.setCollectInfo(data);
      
        observable
          .pipe(takeUntil(this.unsubscribe$))
          .subscribe(async result => {
            this.spinner.hide();  

            if (result > 0) {
              await this.handleSuccessResponse();
            } else {
              if (result == -1)
                this.handleWrongEmail();
              else if (result == -2)
                this.handleWrongAdres();
            }
          },
          (err) => {
            this.spinner.hide();  
            this.handleWrongResponse();
          }
        );        
    }
  
    this.click = false;
  }

  handleSuccessResponse() {
    Swal.fire({
      title: 'Вашата предварителна заявка е приета успешно!',
      text: 'След стартиране на дейностите по проекта, с Вас ще се свържат технически лица за допълнителни уточнения и проверка на подадената информация.',
      icon: 'success',
      color: "#716add",
      showCloseButton: true,
      confirmButtonText: 'Благодарим за участието!',
    }).then((result) => {
      this.back();
    })      
  }

  handleWrongResponse() {
    this.toasterService.danger("", `Грешка при запис!`);
  }

  handleWrongEmail() {
    this.toasterService.danger("", `Формуляр с този имейл вече е подаден!`);
  }

  handleWrongAdres() {
    this.toasterService.danger("", `Формуляр с този адрес вече е въведен!`);
  }

  back() {
    this.location.back();
  }
}
