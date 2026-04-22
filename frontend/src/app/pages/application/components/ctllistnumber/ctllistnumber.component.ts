import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';
import { NgSelectConfig } from '@ng-select/ng-select';
import { ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
@Component({
  selector: 'ngx-ctllistnumber',
  templateUrl: './ctllistnumber.component.html',
  styleUrls: ['./ctllistnumber.component.scss'],
})
export class CtlListNumberComponent implements OnInit {
  form: FormGroup;
  lcontrol: FormControl;
  ncontrol: FormControl;

  @Output() selectionChanged: EventEmitter<string> = new EventEmitter<string>();
  
  @Input() items: ViewNom[] = [];
  @Input() controlListName: string;
  @Input() controlNumbName: string;
  @Input() placeholder: string;
  @Input() maxlength: number = 10;
  @Input() disable: boolean = false;
  @Input() allowDecimals: boolean = false;

  @Input() selectedItem: string = '';
  @Input() nvalue = 0;

  constructor(
    private controlContainer: ControlContainer,
    private config: NgSelectConfig
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.lcontrol = <FormControl>this.form.get(this.controlListName);
    this.ncontrol = <FormControl>this.form.get(this.controlNumbName);

    this.config.notFoundText = 'Няма намерени елементи';
    this.config.appendTo = 'body';

    if (!this.ncontrol.value)
      this.ncontrol.setValue(0);
/*
    const action = this.disable ? 'disable' : 'enable';
    this.lcontrol[action]();
    this.ncontrol[action]();
*/
    if (!this.placeholder)
      this.placeholder = 'Въведете стойност';
  }

  onSelectionChange(value: string) {
    this.selectionChanged.emit(value);
  }
}
