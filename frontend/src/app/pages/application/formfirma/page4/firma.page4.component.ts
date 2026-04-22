import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ZaqvlenieForm } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-firma-page4',
  templateUrl: './firma.page4.component.html',
  styleUrls: ['./firma.page4.component.scss'],
})
export class FirmaPage4Component implements OnInit {
  @Input() disabled: boolean = false;

  public form: FormGroup;
  public uredi: FormArray;
  vlistv43:  ViewNom[];

  constructor(
    private controlContainer: ControlContainer,
    private nomenclatureService: NomenclatureData,
  ) { }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
    this.uredi = <FormArray>this.form.get('uredi');
  }

  loadLists() {
    this.nomenclatureService
      .getNomenUredi()
      .subscribe(result => {
        this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item));
    });
  }

  addItem() {
    let canadd: boolean = true;
    const uredi = (this.form.get('uredi') as FormArray);

    uredi.controls.forEach (t=> {
        if (!t.get('id').value) {
            canadd = false;
        }
    })

    if (canadd && this.disabled == false)
        this.uredi.push(this.createItem());
  }

  removeItem(index: number) {
    if (this.disabled == false)
      this.uredi.removeAt(index);
  }

  createItem(): FormGroup {
    return new ZaqvlenieForm().createUredItem();
  }


}