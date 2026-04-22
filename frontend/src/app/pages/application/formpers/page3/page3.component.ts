import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-page3',
  templateUrl: './page3.component.html',
  styleUrls: ['./page3.component.scss'],
})
export class Page3Component implements OnInit {
  @Input() disabled: boolean = false;

  public form: FormGroup;

  constructor(
    private controlContainer: ControlContainer,
      private nomenclatureService: NomenclatureData,
  ) {
    this.form = <FormGroup>this.controlContainer.control;
  }

  ngOnInit(): void {
    this.loadLists();
    this.form = <FormGroup>this.controlContainer.control;
  }

  loadLists() {
    const a = 1;
  }
}
