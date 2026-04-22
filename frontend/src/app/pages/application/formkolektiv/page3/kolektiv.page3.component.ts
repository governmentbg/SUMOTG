import { Component, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { NomenclatureData } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-kolektiv-page3',
  templateUrl: './kolektiv.page3.component.html',
  styleUrls: ['./kolektiv.page3.component.scss'],
})
export class KolektivPage3Component implements OnInit {
  form: FormGroup;

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
