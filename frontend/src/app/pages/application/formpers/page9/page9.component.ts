import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NbDialogService } from '@nebular/theme';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ZaqvlenieForm } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-page9',
  templateUrl: './page9.component.html',
  styleUrls: ['./page9.component.scss'],
})
export class Page9Component implements OnInit {
  @Input() disabled: boolean = false;

  public form: FormGroup;
  public documenti: FormArray;
  vlistdocs:  ViewNom[];

  constructor(
    private controlContainer: ControlContainer,
    private nomenclatureService: NomenclatureData,
  ) { }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
    this.documenti = <FormArray>this.form.get('dokumenti');
  }

  loadLists() {
    this.nomenclatureService
      .getNomenObshti('09')
      .subscribe(result => {
        this.vlistdocs = result.map(item => new ViewNom().convertNomObshti(item));
    });
  }


  addItem() {
    if(!this.disabled)
        this.documenti.push(this.createItem());    
  }

  removeItem(index: number) {
    if (!this.disabled)
        this.documenti.removeAt(index);
  }

  createItem(): FormGroup {
    return new ZaqvlenieForm().createDocumentItem();
  }
  
}
