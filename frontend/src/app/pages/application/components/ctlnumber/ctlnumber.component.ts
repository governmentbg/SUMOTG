import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-ctlnumber',
  templateUrl: './ctlnumber.component.html',
  styleUrls: ['./ctlnumber.component.scss'],
})
export class CtlNumberComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() placeHolder: string;
  @Input() maxlength: number = 10;
  @Input() disable: boolean = false;
  @Input() allowDecimals: boolean = false;
  @Input() nvalue: number = 0;
  
  @Output() selectionChanged: EventEmitter<string> = new EventEmitter<string>();
 
  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    
    if (this.control.disabled == false && this.disable)
      this.control.disable();

    if (!this.control.value) this.control.setValue(0);

/*    const action = this.disable ? 'disable' : 'enable';
    this.control[action]();
*/
    if (!this.placeHolder)
      this.placeHolder = 'Въведете стойност';
  }

  onSelectionChange(value: string) {
    this.selectionChanged.emit(value);
  }
}
