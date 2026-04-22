import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NbDialogService } from '@nebular/theme';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ZaqvlenieForm } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-firma-page9',
  templateUrl: './firma.page9.component.html',
  styleUrls: ['./firma.page9.component.scss'],
})
export class FirmaPage9Component implements OnInit {
  @Input() disabled: boolean = false;

  public form: FormGroup;
  public documenti: FormArray;
  vlistdocs:  ViewNom[];

  constructor(
    private controlContainer: ControlContainer,
    private nomenclatureService: NomenclatureData,
    private dialogService: NbDialogService,
  ) { }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
    this.documenti = <FormArray>this.form.get('dokumenti');
  }

  loadLists() {
    this.nomenclatureService
      .getNomenObshti('11')
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
