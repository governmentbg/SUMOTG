import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormControl, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { ZaqvlenieForm } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss'],
})
export class HistoryComponent implements OnInit {
  @Input() items: ViewNom[];
  @Input() disabled: boolean = false;

  public form: FormGroup;

  constructor(
    private controlContainer: ControlContainer,
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
  }
}
