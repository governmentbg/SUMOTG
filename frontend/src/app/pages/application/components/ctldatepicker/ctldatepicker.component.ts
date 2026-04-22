import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

export const CUSTOM_YMD_REGEX = /^(\d{4})\/(\d{2})\/(\d{2})$/;

@Component({
  selector: 'ngx-ctldatepicker',
  templateUrl: './ctldatepicker.component.html',
  styleUrls: ['./ctldatepicker.component.scss'],
})
export class CtlDatePickerComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() placeholder: string;
  @Input() disable: boolean = false;
 
  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);

    if (!this.control.value) 
        this.control.setValue('');

    if (!this.placeholder)
      this.placeholder = 'Въведете дата';
  }

}
