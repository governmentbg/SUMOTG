import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NomenclatureData, NomObshti, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { LiceForm } from '../../formclasses/lice.form';

@Component({
  selector: 'ngx-kolektiv-page5',
  templateUrl: './kolektiv.page5.component.html',
  styleUrls: ['./kolektiv.page5.component.scss'],
})
export class KolektivPage5Component implements OnInit {
  @Input() disabled: boolean = false;

  public form: FormGroup;
  public systav: FormArray;
  vidIdent: ViewNom[];
  vidLice: NomObshti[];

  constructor(
    private controlContainer: ControlContainer,
    private nomenclatureService: NomenclatureData,
  ) { }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
    this.systav = <FormArray>this.form.get('systav');
  }

  loadLists() {
    this.nomenclatureService
        .getNomenObshti('01')
        .subscribe(result => {
          this.vidLice = result;
     });

     this.nomenclatureService
        .getNomenObshti('02')
        .subscribe(result => {
          this.vidIdent = result.map(item => new ViewNom().convertNomObshti(item));
     });
  }

  addItem() {
    if (!this.disabled)
        this.systav.push(this.createItem());
  }

  removeItem(index: number) {
    if (!this.disabled)
        this.systav.removeAt(index);
  }

  createItem(): FormGroup {
    let item = this.vidLice.find(x=>x.kodpos=='4');
    let form = new LiceForm().create(4,false);
    form.get('typeLice').setValue(item.idkn)
    return form;
  }
}