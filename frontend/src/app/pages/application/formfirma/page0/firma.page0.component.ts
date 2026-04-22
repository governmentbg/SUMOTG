import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { SpravkaKandidatService } from '../../../../@theme/services/spravka-kandidat.service';
import { SpravkaKandidat } from '../../formclasses/zaqvlenie.form';

@Component({
  selector: 'ngx-firma-page0',
  templateUrl: './firma.page0.component.html',
  styleUrls: ['./firma.page0.component.scss'],
})
export class FirmaPage0Component implements OnInit  {
  @Input() raioni: ViewNom[];
  @Input() vliststatus: ViewNom[];
 
  @Output() public statusChanged = new EventEmitter<Number>();

  form: FormGroup;
  vlistv18:  ViewNom[];
  vlistv43:  ViewNom[];
  vlistdocs:  ViewNom[];

  constructor(
      private controlContainer: ControlContainer,
      private nomenclatureService: NomenclatureData,
      private ete: SpravkaKandidatService
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;

    this.nomenclatureService
      .getNomenObshti('06')
      .subscribe(result => {
        this.vlistv18 = result.map(item => new ViewNom().convertNomObshti(item));
    });
    
    this.nomenclatureService
        .getNomenUredi()
        .subscribe(result => {
          this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item));
    });  
    
    this.nomenclatureService
      .getNomenObshti('09')
      .subscribe(result => {
        this.vlistdocs = result.map(item => new ViewNom().convertNomObshti(item));
    });    
  }

  onStatusChanged(item: ViewNom) {
    this.statusChanged.emit(item.id);
  }

  printSpravkaKandidat () {
    let obj: SpravkaKandidat;
    let dataForExcel = [];

    obj = {
      col1: "Номер на кандидата",
      col2: this.form.get('unom').value,
      col3: "left",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "Трите имена",
      col2: this.form.get('lice').get('ime').value,
      col3: "left",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "Район",
      col2: this.raioni.find(e => e.nkod == this.form.get('lice').get('admRaion').value).name,
      col3: "left",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "",
      col2: "",
      col3: "left",
      col4: false
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "Кандидатствам за следното отоплително оборудване",
      col2: "Брой",
      col3: "center",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    let uredi =  (this.form.get("uredi") as FormArray) 
    uredi.controls.forEach((form: FormGroup) => {    
      let u = this.vlistv43.find(e => e.nkod ==  form.get('id').value);
      if (u) {
          obj = {
              col1: u.name,
              col2: String(form.get('broi').value),
              col3: "center",
              col4: false
            };     
          dataForExcel.push(Object.values(obj));
      }    
    });

    obj = {
      col1: "",
      col2: "",
      col3: "left",
      col4: false
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "Предавам за последващо рециклиране следното старо отоплително устройство:",
      col2: "",
      col3: "left",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    let olduredi =  (this.form.get("olduredi") as FormArray) 
    olduredi.controls.forEach((form: FormGroup) => {  
      let u = this.vlistv18.find(e => e.nkod ==  form.get('id').value);
      if (u) {
        obj = {
            col1: u.name,
            col2: String(form.get('broi').value),
            col3: "center",
            col4: false
        };      
        dataForExcel.push(Object.values(obj));
      }
    });

    obj = {
      col1: "",
      col2: "",
      col3: "left",
      col4: false
    };
    dataForExcel.push(Object.values(obj));

    obj = {
      col1: "Прилагам следните документи във Формуляра за кандидатстване:",
      col2: "",
      col3: "left",
      col4: true
    };
    dataForExcel.push(Object.values(obj));

    let documenti =  (this.form.get("dokumenti") as FormArray) 
    documenti.controls.forEach((form: FormGroup) => {    
      let d = this.vlistdocs.find(e => e.nkod ==  form.get('id').value);
      if (d) {
        obj = {
            col1: d.name,
            col2: "x",
            col3: "center",
            col4: false
        }      
        dataForExcel.push(Object.values(obj));
      }  
    });


    let reportData = {
      data: dataForExcel,
      filename: this.form.get('unom').value + '_'+
                this.form.get('lice').get('ime').value
    };

    this.ete.exportExcel(reportData);  
  }    
}
