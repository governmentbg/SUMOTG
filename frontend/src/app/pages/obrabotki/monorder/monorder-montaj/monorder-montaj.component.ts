import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-monorder-montaj',
  templateUrl: './monorder-montaj.component.html',
  styleUrls: ['./monorder-montaj.component.scss']
})
export class MonorderMontajComponent implements OnInit {
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
