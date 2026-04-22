import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-ctlyesno',
  templateUrl: './ctlyesno.component.html',
  styleUrls: ['./ctlyesno.component.scss'],
})
export class CtlYesNoComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() ynvalue: number = 0;

  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    
    if (!this.control.value) this.control.setValue(0);
  }

}
