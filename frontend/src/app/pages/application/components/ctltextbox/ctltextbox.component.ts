import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-ctltextbox',
  templateUrl: './ctltextbox.component.html',
  styleUrls: ['./ctltextbox.component.scss'],
})
export class CtlTextBoxComponent implements OnInit {
  form: FormGroup;
  control: FormControl;

  @Input() controlName: string;
  @Input() placeholder: string;
  @Input() maxlength: number = 100;
  @Input() disable: boolean = false;
  @Input() isNumberOnly: boolean = false;
  @Input() оnlyCyrillic: boolean = false;

  @Input() cvalue: string = '';

  constructor(private controlContainer: ControlContainer) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    
    if (this.control.disabled == false && this.disable)
        this.control.disable();

    if (!this.control.value) this.control.setValue('');
/*
    const action = this.disable ? 'disable' : 'enable';
    this.control[action]();
*/
    if (!this.placeholder)
      this.placeholder = 'Въведете стойност';
  }

  onKeyPress(e) {
    var verified = String.fromCharCode(e.which).match(/^[абвгдеёжзийклмнопрстуфхцчшщьыъэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ]*$/);
    debugger;
    if (!verified && this.оnlyCyrillic) {
      e.preventDefault();
    }
  }
}
