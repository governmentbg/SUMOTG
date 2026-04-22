import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-ctlcurrency',
  templateUrl: './ctlcurrency.component.html',
  styleUrls: ['./ctlcurrency.component.scss'],
})
export class CtlCurrencyComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() placeHolder: string;
  @Input() maxlength: number = 10;
  @Input() disable: boolean = false;
  
  @Output() selectionChanged: EventEmitter<string> = new EventEmitter<string>();
 
  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    
    if (this.control.disabled == false && this.disable)
      this.control.disable();

    if (!this.control.value) 
      this.control.setValue(Number(0).toFixed(2))
    else
      this.control.setValue(Number(this.control.value).toFixed(2));

    if (!this.placeHolder)
      this.placeHolder = 'Въведете стойност';
  }

  onSelectionChange(value: string) {
    this.selectionChanged.emit(value);
  }
}
