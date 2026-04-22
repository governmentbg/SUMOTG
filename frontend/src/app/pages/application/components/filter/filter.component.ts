import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { pairwise, startWith } from 'rxjs/operators';
import { FirmaData } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, NomUred, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { HeaderComponent } from '../../../../@theme/components';
import { PagesComponent } from '../../../pages.component';
import { DogovorFilter, EmptyFilter, Filter, FilterSettings, ListFirms, ListPersons, RadPrekodFilter, RegFilter1, RegFilter2, RegFilter3, Spravka10Filter, Spravka15Filter, Spravka20Filter, Spravka21Filter, Spravka22Filter, Spravka24Filter, Spravka25Filter, Spravka2Filter, Spravka3Filter, Spravka4Filter, Spravka50Filter, Spravka51Filter, Spravka5Filter, Spravka6Filter, Spravka7Filter, Spravka8Filter, Spravka9Filter } from './filter.settings';

@Component({
  selector: 'ngx-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  raioni: ViewNom[];
  vlisturedi: NomUred[];
  vlistv43: ViewNom[];
  vlistv18: ViewNom[];
  vliststatusL: ViewNom[];
  vliststatusDL: ViewNom[];
  vliststatusF: ViewNom[];
  vliststatusU: ViewNom[];
  vliststatusDU: ViewNom[];
  vdopspor: ViewNom[];

  vlistvtipuredi: Array <ViewNom>;
  vlistvtipuredi1: Array <ViewNom>;
  vlistvtipuredi2: Array <ViewNom>;
  vlistvtipuredi3: Array <ViewNom>;
  vlisttipformulqr: Array <ViewNom>;
  vlisttipportret: Array <ViewNom>;

  vlistfaza: Array <ViewNom>;
  vlistvid: ViewNom[];
  vmonfirmi: ViewNom[];
  vmonfirmidogovor: ViewNom[];
  vdemfirmi: ViewNom[];
  vdemfirmidogovor: ViewNom[];
  
  userForm: FormGroup;
  vidfltr: number;
  descript: string;
  disable: boolean = true;
  settings: FilterSettings = EmptyFilter;

  constructor(
    private nomenclatureService: NomenclatureData,
    private firmiService: FirmaData,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
  ) { 
    this.initUserForm();
  }

  ngOnInit(): void {
    this.onChanges();
    
    this.route.paramMap.subscribe( params => {
      this.vidfltr = Number(params.get('vidfltr'));
      this.descript = String(params.get('descript'));

      this.getSettings();
      this.loadFilter();
      this.loadLists();
    });

  }

  initUserForm() {
    this.userForm = this.fb.group({
      raionid: this.fb.control(null),
      tipuredi: this.fb.control('ALL'),
      uredi: this.fb.control(null),
      olduredi: this.fb.control(null),
      statusL: this.fb.control(null),
      statusF: this.fb.control(null),
      statusDL: this.fb.control(null),
      statusU: this.fb.control(null),
      statusDU: this.fb.control(null),
      faza: this.fb.control(String(HeaderComponent.faza)),
      descript: this.fb.control(''),
      txtfilter: this.fb.control(''),
      disable: this.fb.control(true),
      unomer: this.fb.control(0),
      regnom: this.fb.control(''),
      adres: this.fb.control(''),
      vid: this.fb.control(''),
      firma: this.fb.control(null),
      dogovor: this.fb.control(null),
      demfirma: this.fb.control(null),
      demdogovor: this.fb.control(null),
      dpregnom: this.fb.control(null),
      viddpspor: this.fb.control(null),
      limit: this.fb.control(null),
      vidformulqr: this.fb.control('1'),
      vidportret: this.fb.control('0'),
    });

  }

  getSettings() {
    if (this.vidfltr == 1) {
      this.settings = RegFilter1;
    } else if (this.vidfltr == 2) {
      this.settings = RegFilter2;
    } else if (this.vidfltr == 3) {
      this.settings = RegFilter3;
    } else if (this.vidfltr == 4) {
      this.settings = DogovorFilter;    
    } else if (this.vidfltr == 5) {
      this.settings = ListPersons;    
    } else if (this.vidfltr == 6) {
      this.settings = ListFirms;    
    } else if (this.vidfltr == 7) {
      this.settings = RadPrekodFilter;    
    } else if (this.vidfltr == 11) {
      this.settings = Spravka2Filter;    
    } else if (this.vidfltr == 12) {
      this.settings = Spravka3Filter;    
    } else if (this.vidfltr == 13) {
      this.settings = Spravka4Filter;    
    } else if (this.vidfltr == 14) {
      this.settings = Spravka5Filter;    
    } else if (this.vidfltr == 15) {
      this.settings = Spravka6Filter;    
    } else if (this.vidfltr == 16) {
      this.settings = Spravka7Filter;    
    } else if (this.vidfltr == 17) {
      this.settings = Spravka8Filter;    
    } else if (this.vidfltr == 18) {
      this.settings = Spravka20Filter;    
    } else if (this.vidfltr == 19) {
      this.settings = Spravka9Filter;    
    } else if (this.vidfltr == 20) {
      this.settings = Spravka10Filter;    
    } else if (this.vidfltr == 21) {
      this.settings = Spravka21Filter;    
    } else if (this.vidfltr == 22) {
      this.settings = Spravka15Filter;    
    } else if (this.vidfltr == 23) {
      this.settings = Spravka22Filter;    
    } else if (this.vidfltr == 24) {
      this.settings = Spravka24Filter;    
    } else if (this.vidfltr == 25) {
      this.settings = Spravka25Filter;    
    } else if (this.vidfltr == 50) {
      this.settings = Spravka50Filter;    
    } else if (this.vidfltr == 51) {
      this.settings = Spravka51Filter;    
    } else {
      this.settings = EmptyFilter;
    }   
  }

  loadFilter() {
    let filter = JSON.parse(localStorage.getItem(this.settings.storageKey));
    
    if (filter) {
      this.userForm.patchValue({
          raionid: filter.raionid ? filter.raionid : null,
          tipuredi:filter.tipuredi ? filter.tipuredi : 'ALL',
          uredi: filter.uredi ? filter.uredi : null,
          olduredi: filter.olduredi ? filter.olduredi : null,
          faza: filter.faza ? filter.faza : (this.settings.showAllFaza ? '0' : '1'),
          vid: filter.vid ? filter.vid : null,
          statusL: filter.statusL ? filter.statusL : null,
          statusF: filter.statusF ? filter.statusF : null,
          statusDL: filter.statusDL && filter.statusDL > -1 ? filter.statusDL : null,
          statusU: filter.statusU ? filter.statusU : null,
          statusDU: filter.statusDU ? filter.statusDU : null,
          unomer: filter.unomer ? filter.unomer : 0,
          regnom: filter.regnom ? filter.regnom : '',
          adres: filter.adres ? filter.adres : '',
          firma: filter.firma ? filter.firma : null,
          dogovor: filter.dogovor ? filter.dogovor : null,
          demfirma: filter.demfirma ? filter.demfirma : null,
          demdogovor: filter.demdogovor ? filter.demdogovor : null,
          dpregnom: filter.dpregnom ? filter.dpregnom : '',
          viddpspor: filter.viddpspor ? filter.viddpspor : null,
          limit: filter.limit ? filter.limit : null,
          vidformulqr: filter.vidformulqr ? filter.vidformulqr : '1',
          vidportret: filter.vidportret ? filter.vidportret : '0',
        },
        {emitEvent: true, onlySelf: false});  
    }
  }

  loadLists() {
    this.nomenclatureService
      .getNomenRaioni()
      .subscribe(result => {
          if (PagesComponent.raion.length > 0) {
            this.userForm.get('raionid').patchValue(PagesComponent.raion, {emitEvent: true});
            this.raioni = result.filter(e => e.nkod == PagesComponent.raion)
                                .map(item => new ViewNom().convertNomRaion(item));
          } else
            this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

    this.nomenclatureService
      .getNomenObshti('06')
      .subscribe(result => {
        this.vlistv18 = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
      .getNomenObshti('12')
      .subscribe(result => {
        this.vdopspor = result.map(item => new ViewNom().convertNomObshti(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_DL')
        .subscribe(result => {
        this.vliststatusDL = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_F')
        .subscribe(result => {
        this.vliststatusF = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_L')
        .subscribe(result => {
        this.vliststatusL = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_U')
        .subscribe(result => {
        this.vliststatusU = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('Status_DU')
        .subscribe(result => {
        this.vliststatusDU = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.loadUredi();

    this.vlisttipformulqr=[]
    this.vlisttipformulqr.push (new ViewNom ().addItem(0, '1','Физическо лице'));
    this.vlisttipformulqr.push (new ViewNom ().addItem(1, '2','Колектив'));
    this.vlisttipformulqr.push (new ViewNom ().addItem(2, '3','Юридическо лице'));

    this.vlisttipportret = []
    this.vlisttipportret.push (new ViewNom ().addItem(0, '0','Пълен списък'));
    this.vlisttipportret.push (new ViewNom ().addItem(1, '1','Кратък списък'));

    this.vlistvtipuredi = [];
    this.vlistvtipuredi.push (new ViewNom ().addItem(0, 'ALL','Всички'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(1, 'PEL','Уреди на пелети'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(2, 'GAZ','Уреди на природен газ'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(3, 'KLM','Климатици'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(4, 'RAD','Радиатори'));

    this.vlistvtipuredi1 = [];
    this.vlistvtipuredi1.push (new ViewNom ().addItem(0, 'ALL','Всички'));
    this.vlistvtipuredi1.push (new ViewNom ().addItem(1, 'PEL','Уреди на пелети'));
    this.vlistvtipuredi1.push (new ViewNom ().addItem(2, 'GAZ','Уреди на природен газ'));
    this.vlistvtipuredi1.push (new ViewNom ().addItem(3, 'KLM','Климатици'));
    this.vlistvtipuredi1.push (new ViewNom ().addItem(4, 'RADPEL','Радиатори към уреди на пелети'));
    this.vlistvtipuredi1.push (new ViewNom ().addItem(5, 'RADGAZ','Радиатори към уреди на природен газ'));

    this.vlistvtipuredi2 = [];
    this.vlistvtipuredi2.push (new ViewNom ().addItem(0, 'ALL','Всички'));
    this.vlistvtipuredi2.push (new ViewNom ().addItem(1, 'PEL','Уреди на пелети'));
    this.vlistvtipuredi2.push (new ViewNom ().addItem(2, 'GAZ','Уреди на природен газ'));

    this.vlistvtipuredi3 = [];
    this.vlistvtipuredi3.push (new ViewNom ().addItem(0, 'ALL','Всички'));
    this.vlistvtipuredi3.push (new ViewNom ().addItem(1, 'PEL','Уреди на пелети'));
    this.vlistvtipuredi3.push (new ViewNom ().addItem(2, 'GAZ','Уреди на природен газ'));
    this.vlistvtipuredi3.push (new ViewNom ().addItem(3, 'KLM','Климатици'));

    this.vlistfaza = [];
    if (this.settings.showAllFaza) {
      this.vlistfaza.push (new ViewNom ().addItem(0, '0','Всички фази'));
    }
    this.vlistfaza.push (new ViewNom ().addItem(1, '1','Фаза 1'));
    this.vlistfaza.push (new ViewNom ().addItem(2, '2','Фаза 2'));

    this.vlistvid = [];
    this.vlistvid.push (new ViewNom ().addItem(1, '0','Всички'));
    this.vlistvid.push (new ViewNom ().addItem(1, '1','Индивидуален'));
    this.vlistvid.push (new ViewNom ().addItem(2, '2','Колективен'));
    this.vlistvid.push (new ViewNom ().addItem(3, '3','Юридически'));

    this.firmiService
        .getFirmi(1)
        .subscribe((result) => {
          this.vmonfirmi = result.map(item => new ViewNom().convertFirmi(item));

          if (this.userForm.get('firma').value) {
            this.firmiService
                .loadMonDogovorFirma(this.userForm.get('firma').value)
                .subscribe((result) => {
                  this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
            });                
          }
    });  

    this.firmiService
        .getFirmi(2)
        .subscribe((result) => {
          this.vdemfirmi = result.map(item => new ViewNom().convertFirmi(item));

          if (this.userForm.get('demfirma').value) {
            this.firmiService
                .loadDeMonDogovorFirma(this.userForm.get('demfirma').value)
                .subscribe((result) => {
                  this.vdemfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
            });                
          }
    });  

  }

  loadUredi() {
    this.nomenclatureService
        .getNomenUredi()
        .subscribe(result => {
          this.vlisturedi = result;

          if (this.userForm.get('tipuredi').value == 'ALL') {
            this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item,1));        
          } else {
            let tipured = this.userForm.get('tipuredi').value;
            if (tipured == 'RADPEL' || tipured == 'RADGAZ' || tipured == 'RAD')
                tipured = 'RAD';

            this.vlistv43 = this.vlisturedi
                                .filter(e => e.vid == tipured)
                                .map((item) => new ViewNom().convertNomUred(item,1))
          }

    });
  }

  onFirmItemSelected(firma: ViewNom) {
    this.firmiService.loadMonDogovorFirma(firma.id).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
    });  
  }

  onDemFirmItemSelected(firma: ViewNom) {
    this.firmiService.loadDeMonDogovorFirma(firma.id).subscribe((result) => {
      this.vdemfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
    });  
  }

  exec() {
    const filter: Filter = this.userForm.value;
    filter.statusDL = filter.statusDL ? filter.statusDL : -1;
    filter.descript = this.descript;
    filter.disable = this.disable;
    filter.txtfilter = this.filterToString(filter);

    this.openPage(JSON.stringify(filter));
  }

  openPage (filter: string){
    localStorage.setItem(this.settings.storageKey,filter);

    if (this.vidfltr == 1) {
      this.router.navigate(['/pages/register/register/1',{filter: filter}])
    } else if (this.vidfltr == 2) {
      this.router.navigate(['/pages/register/register/2',{filter: filter}])
    } else if (this.vidfltr == 3) {
      this.router.navigate(['/pages/register/register/3',{filter: filter}])
    } else if (this.vidfltr == 4) {
      this.router.navigate(['/pages/licacontracts',{filter: filter}])
    } else if (this.vidfltr == 5) {
      this.router.navigate(['/pages/register/persons',{filter: filter}])
    } else if (this.vidfltr == 6) {
      this.router.navigate(['/pages/register/firms',{filter: filter}])
    } else if (this.vidfltr == 7) {
      this.router.navigate(['/pages/register/radprekod',{filter: filter}])
    } else if (this.vidfltr == 11) {
      this.router.navigate(['/pages/spravki/spravka2',{filter: filter}])
    } else if (this.vidfltr == 12) {
      this.router.navigate(['/pages/spravki/spravka3',{filter: filter}])
    } else if (this.vidfltr == 13) {
      this.router.navigate(['/pages/spravki/spravka4',{filter: filter}])
    } else if (this.vidfltr == 14) {
      this.router.navigate(['/pages/spravki/spravka5',{filter: filter}])
    } else if (this.vidfltr == 15) {
      this.router.navigate(['/pages/spravki/spravka6',{filter: filter}])
    } else if (this.vidfltr == 16) {
      this.router.navigate(['/pages/spravki/spravka7',{filter: filter}])
    } else if (this.vidfltr == 17) {
      this.router.navigate(['/pages/spravki/spravka8',{filter: filter}])
    } else if (this.vidfltr == 18) {
      this.router.navigate(['/pages/spravki/spravka20',{filter: filter}])
    } else if (this.vidfltr == 19) {
      this.router.navigate(['/pages/spravki/spravka9',{filter: filter}])
    } else if (this.vidfltr == 20) {
      this.router.navigate(['/pages/spravki/spravka10',{filter: filter}])
    } else if (this.vidfltr == 21) {
      this.router.navigate(['/pages/spravki/spravka21',{filter: filter}])
    } else if (this.vidfltr == 22) {
      this.router.navigate(['/pages/spravki/spravka15',{filter: filter}])
    } else if (this.vidfltr == 23) {
      this.router.navigate(['/pages/spravki/spravka22',{filter: filter}])
    } else if (this.vidfltr == 24) {
      this.router.navigate(['/pages/spravki/spravka23',{filter: filter}])
    } else if (this.vidfltr == 25) {
      this.router.navigate(['/pages/spravki/spravka25',{filter: filter}])
    } else if (this.vidfltr == 50) {
      this.router.navigate(['/pages/spravki/spravka50',{filter: filter}])
    } else if (this.vidfltr == 51) {
      this.router.navigate(['/pages/spravki/spravka51',{filter: filter}])
    }    
}

  back() {
    if (this.vidfltr == 1) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 2) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 3) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 4) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 5) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 6) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr == 7) {
      this.router.navigate(['/pages/dashboard'])
    } else if (this.vidfltr > 10) {
      this.router.navigate(['/pages/spravki']);  
    }  
  }

  onChanges(): void {
    this.userForm.get('tipuredi').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          if (this.vlisturedi) {
            if (next == 'ALL') {
              this.vlistv43 = this.vlisturedi
                                  .map((item) => new ViewNom().convertNomUred(item,1))
            } else {
              let tipured = next;
              if (tipured == 'RADPEL' || tipured == 'RADGAZ'|| tipured == 'RAD')
                  tipured = 'RAD';
  
              this.vlistv43 = this.vlisturedi
                                  .filter(e => e.vid == tipured)
                                  .map((item) => new ViewNom().convertNomUred(item,1))

              if (prev && prev != next)
                this.userForm.get('uredi').patchValue(null, {emitEvent: true});
            }    
          }  
    });

    this.userForm.get('faza').valueChanges
      .pipe(startWith(null as string), pairwise())
      .subscribe(([prev, next]: [any, any]) => {
          HeaderComponent.faza = (next ? next : (this.settings.showAllFaza ? '0' : '1')),
          this.loadUredi();
      });
  }

  clearFilter() {
    localStorage.removeItem(this.settings.storageKey);
    this.userForm.patchValue({
      raionid: (PagesComponent.raion.length > 0 ? PagesComponent.raion: null),
      tipuredi: 'ALL',
      uredi: null,
      olduredi: null,
      faza:  (this.settings.showAllFaza ? '0' : '1'),
      vid: '0',
      statusL: null,
      statusF: null,
      statusDL: null,
      statusU: null,
      statusDU: null,
      unomer: null,
      regnom: '',
      adres: '', 
      firma: null,
      dogovor : null,
      demfirma: null,
      demdogovor : null,
      dpregnom: null,
      viddpspor: null,
      limit: null,    
      vidformulqr: '1' ,
      vidportret: '0'    
    });  
  }

  showUredText (id: number) {
    var elem = this.vlistv43.find(x=>x.id == id); 
    return elem.name;
  }

  canClearRaion() {
    return PagesComponent.raion.length === 0 ? true: false
  }
  
  filterToString(filter: Filter): string {
    let txt =  '';
    if (filter.raionid) {
      txt =  'Район: ';
      if (filter.raionid.length > 0)
        txt = txt + this.raioni.find(e => e.nkod === filter.raionid).name + '; ';
      else  
        txt = txt +'Всички;'
    }

    if (filter.faza) {
      txt = txt + (filter.faza >0 ? 
                  'фаза: ' + filter.faza +'; ':'');
    }              

  if (this.settings.filters.tipuredi) {
     if (filter.tipuredi) {
        txt = txt + (filter.tipuredi.length >0 && filter.tipuredi != 'ALL'? 
                  'тип уред: ' + this.vlistvtipuredi.find(x=>x.nkod == filter.tipuredi).name +'; ':'');
      }
    } 

    if (this.settings.filters.tipuredi1) {
      if (filter.tipuredi) {
        txt = txt + (filter.tipuredi.length >0 && filter.tipuredi != 'ALL'? 
                  'тип уред: ' + this.vlistvtipuredi1.find(x=>x.nkod == filter.tipuredi).name +'; ':'');
      }
    } 

    if (this.settings.filters.tipuredi2) {
      if (filter.tipuredi) {
        txt = txt + (filter.tipuredi.length >0 && filter.tipuredi != 'ALL'? 
                  'тип уред: ' + this.vlistvtipuredi2.find(x=>x.nkod == filter.tipuredi).name +'; ':'');
      }
    } 

    if (filter.uredi) {
        txt = txt + (filter.uredi.length >0 ? 
                  'за монтаж: ' + this.vlistv43.find(x=>x.nkod == filter.uredi).name +'; ':'');
    }
    

    if (filter.olduredi) {
        txt = txt + (filter.olduredi.length >0 ? 
              'за демонтаж: ' + this.vlistv18.find(x=>x.nkod == filter.olduredi).name +'; ':'');
    }

    if (filter.statusL) {
      txt = txt + (filter.statusL >0 ? 
                'Статус лице: ' + this.vliststatusL.find(x=>x.id == filter.statusL).name +'; ':'');
    } 

    if (filter.statusDL) {
      txt = txt + (filter.statusDL > -1 ? 
                'Статус договор: ' + this.vliststatusDL.find(x=>x.id == filter.statusDL).name +'; ':'');
    } 
    
    if (filter.statusF) {
      txt = txt + (filter.statusF >0 ? 
                'Статус формуляр: ' + this.vliststatusF.find(x=>x.id == filter.statusF).name +'; ':'');
    } 

    if (filter.statusU) {
      txt = txt + (filter.statusU >0 ? 
                'Статус уред: ' + this.vliststatusU.find(x=>x.id == filter.statusU).name +'; ':'');
    } 

    if (filter.statusDU) {
      txt = txt + (filter.statusDU >0 ? 
                'Статус уред: ' + this.vliststatusU.find(x=>x.id == filter.statusDU).name +'; ':'');
    } 

    if (filter.vid) {
      txt = txt + (filter.vid >0 ? 
                'Вид формуляр: ' + this.vlistvid.find(x=>x.id == filter.vid).name +'; ':'');
    }

    if (filter.unomer) {
      txt = txt + (filter.unomer >0 ? 
                '№ ОПОС: ' + String(filter.unomer) +'; ':'');
    }            

    if (filter.adres) {
      txt = txt + (filter.adres.length >0 ? 
                'Адрес: ' + filter.adres +'; ':'');
    } 

    return txt;
  }
}
