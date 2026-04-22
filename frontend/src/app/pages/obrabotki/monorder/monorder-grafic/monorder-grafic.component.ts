import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-monorder-grafic',
  templateUrl: './monorder-grafic.component.html',
  styleUrls: ['./monorder-grafic.component.scss']
})
export class MonorderGraficComponent implements OnInit {
  @Input() vliststatusg: ViewNom[];

  public form: FormGroup;
  public porychkaitems: FormArray

  constructor(
    private controlContainer: ControlContainer,
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
