import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-demorder-grafic',
  templateUrl: './demorder-grafic.component.html',
  styleUrls: ['./demorder-grafic.component.scss']
})
export class DemorderGraficComponent implements OnInit {
  @Input() vliststatusg: ViewNom[];

  public form: FormGroup;
  public porychkaitems: FormArray

  constructor(
    private controlContainer: ControlContainer,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.porychkaitems = this.form.get("porychkaitems") as FormArray;
  }

  getStatusGrafikName(id: number) {
    if (this.vliststatusg) {
      let ind = this.vliststatusg.find(x => x.id == id)
      if (ind)
        return ind.name;
      else  
        return '';
    } else    
      return '';
  }
}
