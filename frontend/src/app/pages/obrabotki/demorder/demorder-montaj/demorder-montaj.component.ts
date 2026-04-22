import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-demorder-montaj',
  templateUrl: './demorder-montaj.component.html',
  styleUrls: ['./demorder-montaj.component.scss']
})
export class DemorderMontajComponent implements OnInit {
  @Input() vliststatusm: ViewNom[];

  public form: FormGroup;
  public porychkaitems: FormArray

  constructor(
    private controlContainer: ControlContainer,
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.porychkaitems = this.form.get("porychkaitems") as FormArray;
  }

  getStatusMontazjName(id: number) {
    if (this.vliststatusm) {
      let ind = this.vliststatusm.find(x => x.id == id)
      if (ind)
        return ind.name;
      else  
        return '';    
    } else  
      return '';    
  }

}
