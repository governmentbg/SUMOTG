import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { Filter1 } from '../../../../@core/interfaces/common/spravki';
import { HeaderComponent } from '../../../../@theme/components';

@Component({
  selector: 'ngx-filter1',
  templateUrl: './filter1.component.html',
  styleUrls: ['./filter1.component.scss']
})
export class Filter1Component implements OnInit {
  raioni: ViewNom[];
  userForm: FormGroup;
  nomcode: string;
  descript: string;
  disable: boolean = true;

  constructor(
    private nomenclatureService: NomenclatureData,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.initUserForm();
    this.loadLists();

    this.route.paramMap.subscribe( params => {
      this.nomcode = String(params.get('nomcode'));
      this.descript = String(params.get('name'));
      this.disable = Boolean(params.get('disable'));
    });
  }

  initUserForm() {
    this.userForm = this.fb.group({
      raionid: this.fb.control(''),
      ident: this.fb.control(''),
      name: this.fb.control(''),
      unom: this.fb.control(''),
      tochki: this.fb.control(0),
      faza: this.fb.control(HeaderComponent.faza),
      descript: this.fb.control(''),
      txtfilter: this.fb.control(''),
      disable: this.fb.control(true),
    });

    let filter = JSON.parse(localStorage.getItem('filter1'));
    if (filter) {
      this.userForm.patchValue({
          raionid: filter.raionid ? filter.raionid : '',
          ident: filter.ident ? filter.ident : '',
          name: filter.name ? filter.name : '',
          unom: filter.unom ? filter.unom : '',
          tochki: filter.tochki ? filter.tochki : 0,
          faza: filter.faza,
      });  
    }        
  }

  loadLists() {
    this.nomenclatureService
      .getNomenRaioni()
      .subscribe(result => {
          this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });
  }

  exec() {
    const filter: Filter1 = this.userForm.value;
    filter.descript = this.descript;
    filter.disable = this.disable;
    filter.txtfilter = this.filterToString(filter);

    localStorage.setItem('filter1',JSON.stringify(filter));
    this.router.navigate(['/pages/spravki/spravka1',{filter: JSON.stringify(filter)}]);  
  }

  clearFilter() {
    localStorage.removeItem('filter1');
    this.userForm.patchValue({
      raionid: null,
      ident: '',
      name: '',
      unom: '',
      tochki: 0,
      faza: 0,
  });  
  }

  back() {
    this.router.navigate(['/pages/spravki']);
  }

  filterToString(filter: Filter1): string {
    let txt =  'Район: ';
    if (filter.raionid && filter.raionid.length > 0)
      txt = txt + this.raioni.find(e => e.nkod === filter.raionid).name + '; ';
    else  
      txt = txt +'Всички;'

      txt = txt + (filter.ident.length >0 ? 'ЕГН/ЛНЧ: ' + filter.ident +'; ':'');
    txt = txt + (filter.name.length > 0 ? 'Име: ' + filter.name + '; ':'');
    txt = txt + (filter.unom.length > 0 ? 'Рег.№: ' + filter.unom + '; ':'');
    txt = txt + (filter.tochki>0 ? 'Точки > от: ' + filter.tochki + '; ':'');
    return txt;
  }
}
