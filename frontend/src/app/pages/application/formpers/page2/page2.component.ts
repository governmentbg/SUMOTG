import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ZaqvlenieForm } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.scss'],
})
export class Page2Component implements OnInit{
  @Input() disabled: boolean = false;

  public form: FormGroup;
  public olduredi: FormArray;

  vlistv9:  ViewNom[];
  vlistv10: ViewNom[];
  vlistv18: ViewNom[];
  vlistv19: ViewNom[];
  vlistv29: ViewNom[];

  constructor(
    private controlContainer: ControlContainer,
      private nomenclatureService: NomenclatureData,
  ) { }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
    this.olduredi = <FormArray>this.form.get('olduredi');

  }

  loadLists() {
    this.nomenclatureService
      .getNomenObshti('04')
      .subscribe(result => {
        this.vlistv9 = result.map(item => new ViewNom().convertNomObshti(item));
      });


    this.nomenclatureService
      .getNomenObshti('05')
      .subscribe(result => {
        this.vlistv10 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenObshti('06')
      .subscribe(result => {
        this.vlistv18 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenObshti('07')
      .subscribe(result => {
        this.vlistv19 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenObshti('08')
      .subscribe(result => {
        this.vlistv29 = result.map(item => new ViewNom().convertNomObshti(item));
    });
  }

  addItem18() {
    let canadd: boolean = true;
    const uredi = (this.form.get('olduredi') as FormArray);

    uredi.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd && !this.disabled)    
      this.olduredi.push(this.createItem());
  }

  removeItem18(index: number) {
    if (!this.disabled)
      this.olduredi.removeAt(index);
  }

  createItem(): FormGroup {
    return new ZaqvlenieForm().createOldUredItem();
  }  
}
