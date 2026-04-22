import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { pairwise, startWith } from 'rxjs/operators';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { PagesComponent } from '../../../pages.component';

@Component({
  selector: 'ngx-firma-page5',
  templateUrl: './firma.page5.component.html',
  styleUrls: ['./firma.page5.component.scss'],
})
export class FirmaPage5Component implements OnInit  {
  @Input() disabled: boolean = false;
  @Input() raioni: ViewNom[];

  public form: FormGroup;
  
  vlistVidfirma: ViewNom[];
  vlistTipfirma: ViewNom[];
  ulici: ViewNom[];
  nasmesta: ViewNom[];
  kvartali: ViewNom[];
  kid: ViewNom[];
  
  constructor(
      private controlContainer: ControlContainer,
      private nomenclatureService: NomenclatureData,
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.loadLists();
    this.onChanges();
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
      .getNomenKID()
      .subscribe(result => {
        this.kid = result.map(item => new ViewNom().convertNomKID(item));
    });    
  }

 
  onChanges(): void {
    this.form.get('nasMqsto').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          this.nomenclatureService.getUliciPerNsMqsto(next).subscribe((result) => {
            this.ulici = result.map((item) => new ViewNom().convertNomUlici(item));
            if (prev && prev != next)
              this.form.get('ulica').patchValue(null, {emitEvent: true});
          });
    });
  }
}
