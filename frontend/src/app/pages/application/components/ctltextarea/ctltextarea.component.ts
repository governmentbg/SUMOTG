import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-ctltextarea',
  templateUrl: './ctltextarea.component.html',
  styleUrls: ['./ctltextarea.component.scss'],
})
export class CtlTextAreaComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() placeholder: string;
  @Input() disable: boolean = false;
  @Input() cvalue: string = '';
  @Input() rows: number = 5;


  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    
    if (this.control.disabled == false && this.disable)
        this.control.disable();

    if (!this.control.value) this.control.setValue('');

    if (!this.placeholder)
      this.placeholder = 'Въведете стойност';
  }
}
