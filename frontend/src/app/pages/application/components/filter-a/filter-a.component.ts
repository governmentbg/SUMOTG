import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import moment from 'moment';
import { FirmaData } from '../../../../@core/interfaces/common/firmi';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';
import { PagesComponent } from '../../../pages.component';
import { EmptyFilterA, FilterA, FilterASettings, Spravka11Filter, Spravka12Filter, Spravka13Filter, Spravka14Filter, Spravka60Filter, Spravka61Filter, Spravka62Filter, Spravka70Filter, Spravka71Filter, Spravka72Filter, Spravka73Filter, Spravka78Filter, Spravka79Filter, Spravka80Filter } from './filter-a.settings';
import { DateValidators } from '../../../../@core/validators/DateValidators';

const DATE_FORMAT = 'DD.MM.YYYY'; 

@Component({
  selector: 'ngx-filter-a',
  templateUrl: './filter-a.component.html',
  styleUrls: ['./filter-a.component.scss']
})
export class FilterAComponent implements OnInit {
  raioni: ViewNom[];
  vliststatusL: ViewNom[];
  vliststatusG: ViewNom[];
  vliststatusM: ViewNom[];
  vliststatusGD: ViewNom[];
  vliststatusMD: ViewNom[];
  vliststatusPF: ViewNom[];
  vlistv43: ViewNom[];
  vlistvtipuredi: Array <ViewNom>;

  vmonfirmi: ViewNom[];
  vmonfirmidogovor: ViewNom[];
  vmonporychki: ViewNom[];

  vdemfirmi: ViewNom[];
  vdemfirmidogovor: ViewNom[];
  
  userForm: FormGroup;
  vidfltr: number;
  descript: string;
  disable: boolean = true;
  settings: FilterASettings = EmptyFilterA;
  currday = new Date(new Date().setDate(new Date().getDate())) ;
  nextday = new Date(new Date().setDate(new Date().getDate()+1));

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
    this.route.paramMap.subscribe( params => {
      this.vidfltr = Number(params.get('vidfltr'));
      this.descript = String(params.get('descript'));

      this.getSettings();
      this.loadLists();

      if (this.vidfltr == 7 || this.vidfltr == 8 ) {
        this.exec();        
      } else {
        this.loadFilter();
      }
    });

  }

  initUserForm() {
    this.userForm = this.fb.group({
      vid: this.fb.control(1),
      raionid: this.fb.control(null),
      statusG: this.fb.control(null),
      statusM: this.fb.control(null),
      unomer: this.fb.control(0),
      porychkanom: this.fb.control(''),
      demporychkanom: this.fb.control(''),
      firma: this.fb.control(null),
      dogovor: this.fb.control(null),
      demfirma: this.fb.control(null),
      demdogovor: this.fb.control(null),
      grafikdataot: this.fb.control(null),
      grafikdatado: this.fb.control(null),
      otchetdataot: this.fb.control(null),
      otchetdatado: this.fb.control(null),
      tipuredi: this.fb.control('ALL'),
      uredi: this.fb.control(null),
      descript: this.fb.control(''),
      txtfilter: this.fb.control(''),
      disable: this.fb.control(true),
      kymdata: this.fb.control(null,[DateValidators.greaterThanCurrent()]),
      sleddata: this.fb.control(null,[DateValidators.smallerThanCurrent()]),
      otdata: this.fb.control(null),
      dodata: this.fb.control(null),
      statusPF: this.fb.control('0'),
      curdate: this.fb.control(this.currday),
    });

  }

  get f() { return this.userForm.controls; }

  getSettings() {
    if (this.vidfltr == 1) {
      this.settings = Spravka11Filter;    
    } else if (this.vidfltr == 2) {
      this.settings = Spravka12Filter;    
    } else if (this.vidfltr == 3) {
      this.settings = Spravka13Filter;    
    } else if (this.vidfltr == 4) {
      this.settings = Spravka14Filter;    
    } else if (this.vidfltr == 5) {
      this.settings = Spravka60Filter;    
    } else if (this.vidfltr == 6) {
      this.settings = Spravka61Filter;    
    } else if (this.vidfltr == 7) {
      this.settings = Spravka78Filter;    
    } else if (this.vidfltr == 8) {
      this.settings = Spravka79Filter;    
    } else if (this.vidfltr == 9) {
      this.settings = Spravka70Filter;    
    } else if (this.vidfltr == 10) {
      this.settings = Spravka71Filter;    
    } else if (this.vidfltr == 11) {
      this.settings = Spravka72Filter;    
    } else if (this.vidfltr == 12) {
      this.settings = Spravka80Filter;    
    } else if (this.vidfltr == 13) {
      this.settings = Spravka62Filter;    
    } else if (this.vidfltr == 14) {
      this.settings = Spravka73Filter;    
    }   
}

  loadFilter() {
    let filter = <FilterA> JSON.parse(localStorage.getItem(this.settings.storageKey));

    if (filter) {
      this.userForm.patchValue({
          vid: 1,
          raionid: filter.raionid ? filter.raionid : null,
          statusG: filter.statusG ? filter.statusG : null,
          statusM: filter.statusM ? filter.statusM : null,
          unomer: filter.unomer ? filter.unomer : 0,
          porychkanom: filter.porychkanom ? filter.porychkanom : '',
          demporychkanom: filter.demporychkanom ? filter.demporychkanom : '',
          firma: filter.firma ? filter.firma : null,
          dogovor: filter.dogovor ? filter.dogovor : null,
          demfirma: filter.demfirma ? filter.demfirma : null,
          demdogovor: filter.demdogovor ? filter.demdogovor : null,
          grafikdataot: filter.grafikdataot ? filter.grafikdataot : null,
          grafikdatado: filter.grafikdatado ? filter.grafikdatado : null,
          otchetdataot: filter.otchetdataot ? filter.otchetdataot : null,
          otchetdatado: filter.otchetdatado ? filter.otchetdatado : null,
          tipuredi:filter.tipuredi ? filter.tipuredi : 'ALL',
          uredi: filter.uredi ? filter.uredi : null,
          kymdata: filter.kymdata ? filter.kymdata : null,
          sleddata: filter.sleddata ? filter.sleddata : null,
          otdata: filter.otdata ? filter.otdata : null,
          dodata: filter.dodata ? filter.dodata : null,
          statusPF: filter.statusPF ? filter.statusPF : null,
      }
      ,{emitEvent: true, onlySelf: false});  
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
        .getNomenStatusi('StatusG')
        .subscribe(result => {
        this.vliststatusG = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('StatusM')
        .subscribe(result => {
        this.vliststatusM = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('StatusGD')
        .subscribe(result => {
        this.vliststatusGD = result.map(item => new ViewNom().convertNomStatusi(item));
    });

    this.nomenclatureService
        .getNomenStatusi('StatusMD')
        .subscribe(result => {
        this.vliststatusMD = result.map(item => new ViewNom().convertNomStatusi(item));
    });    

    this.nomenclatureService
        .getNomenStatusi('Status_PF')
        .subscribe(result => {
        this.vliststatusPF = result.map(item => new ViewNom().convertNomStatusi(item));
    });    

    this.firmiService
        .getFirmi(1)
        .subscribe((result) => {
          this.vmonfirmi = result.map(item => new ViewNom().convertFirmi(item));

          if (this.userForm.get('firma').value) {
            this.firmiService
                .loadMonDogovorFirma(this.userForm.get('firma').value)
                .subscribe((result) => {
                  this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));

                  if (this.userForm.get('dogovor').value) {
                    this.firmiService
                        .loadMonDogovorPorychki(this.userForm.get('dogovor').value)
                        .subscribe((result) => {
                          this.vmonporychki =result.map(item => new ViewNom().convertMonDogovorPorychki(item));                          
                    });                
                  }
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

    this.vlistvtipuredi = [];
    this.vlistvtipuredi.push (new ViewNom ().addItem(0, 'ALL','Всички'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(1, 'PEL','Уреди на пелети'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(2, 'GAZ','Уреди на природен газ'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(3, 'KLM','Климатици'));
    this.vlistvtipuredi.push (new ViewNom ().addItem(4, 'RAD','Радиатори'));

    this.nomenclatureService
        .getNomenUredi()
        .subscribe(result => {
            this.vlistv43 = result.map(item => new ViewNom().convertNomUred(item,1));        
    });
    
  }

  onFirmItemSelected(firma: ViewNom) {
    this.firmiService.loadMonDogovorFirma(firma.id).subscribe((result) => {
      this.vmonfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));    
    });  
  }

  onFirmDogovorItemSelected(dogovor: ViewNom) {
    this.firmiService.loadMonDogovorPorychki(dogovor.id).subscribe((result) => {
      this.vmonporychki =result.map(item => new ViewNom().convertMonDogovorPorychki(item));      
    });  
  }

  onDemFirmItemSelected(firma: ViewNom) {
    this.firmiService.loadDeMonDogovorFirma(firma.id).subscribe((result) => {
      this.vdemfirmidogovor =result.map(item => new ViewNom().convertDogovorFirmi(item));
    });  
  }

  exec() {
    const filter: FilterA = this.userForm.value;
    filter.descript = this.descript;
    filter.disable = this.disable;
    filter.txtfilter = this.filterToString(filter);

    if (this.vidfltr == 7 || this.vidfltr == 8) {
      if (filter.kymdata)
          filter.kymdata = (filter.kymdata > new Date() ? new Date() : filter.kymdata) ;
      else  
        filter.kymdata = new Date();
    }
    
    this.openPage(JSON.stringify(filter));
  }

  openPage (filter: string){    
    localStorage.setItem(this.settings.storageKey,filter);

    if (this.vidfltr == 1) {
      this.router.navigate(['/pages/spravki/spravka11',{filter: filter}])
    } else if (this.vidfltr == 2) {
      this.router.navigate(['/pages/spravki/spravka12',{filter: filter}])
    } else if (this.vidfltr == 3) {
      this.router.navigate(['/pages/spravki/spravka13',{filter: filter}])
    } else if (this.vidfltr == 4) {
      this.router.navigate(['/pages/spravki/spravka14',{filter: filter}])
    } else if (this.vidfltr == 5) {
      this.router.navigate(['/pages/spravki/spravka60',{filter: filter}])
    } else if (this.vidfltr == 6) {
      this.router.navigate(['/pages/spravki/spravka61',{filter: filter}])
    } else if (this.vidfltr == 9) {
      this.router.navigate(['/pages/spravki/spravka70',{filter: filter}])
    } else if (this.vidfltr == 10) {
      this.router.navigate(['/pages/spravki/spravka71',{filter: filter}])
    } else if (this.vidfltr == 11) {
      this.router.navigate(['/pages/spravki/spravka72',{filter: filter}])
    } else if (this.vidfltr == 7) {
      this.router.navigate(['/pages/spravki/spravka78',{filter: filter}])
    } else if (this.vidfltr == 8) {
      this.router.navigate(['/pages/spravki/spravka79',{filter: filter}])
    } else if (this.vidfltr == 12) {
      this.router.navigate(['/pages/obrabotki/proforderedit',{filter: filter}])
    } else if (this.vidfltr == 13) {
      this.router.navigate(['/pages/spravki/spravka62',{filter: filter}])
    } else if (this.vidfltr == 14) {
      this.router.navigate(['/pages/spravki/spravka73',{filter: filter}])
    }    
  }

  back() {
    this.router.navigate(['/pages/spravki']);  
  }

  clearFilter() {
    localStorage.removeItem(this.settings.storageKey);
    this.vmonporychki = [];
    this.vmonfirmidogovor =[];

    this.userForm.patchValue({
      raionid: (PagesComponent.raion.length > 0 ? PagesComponent.raion: null),
      statusG: null,
      statusM: null,
      unomer: null,
      porychkanom: null,
      demporychkanom: null,
      firma: null,
      dogovor : null,
      demfirma: null,
      demdogovor : null,
      grafikdataot: null,
      grafikdatado: null,
      otchetdataot: null,
      otchetdatado: null,
      tipuredi: 'ALL',
      uredi: null,
      kymdata: null,
      sleddata: null,
      otdata: null,
      dodata: null,
      statusPF: '0'
    });  
  }

  canClearRaion() {
    return PagesComponent.raion.length === 0 ? true: false
  }
  
  filterToString(filter: FilterA): string {
    let txt =  '';
    
    if (filter.raionid) {
      txt =  'Район: ';
      if (filter.raionid.length > 0)
        txt = txt + this.raioni.find(e => e.nkod === filter.raionid).name + '; ';
      else  
        txt = txt +'Всички;'
    }

    if (filter.tipuredi) {
      txt = txt + (filter.tipuredi.length >0 && filter.tipuredi != 'ALL'? 
                'тип уред: ' + this.vlistvtipuredi.find(x=>x.nkod == filter.tipuredi).name +'; ':'');
    }

    if (filter.uredi) {
      txt = txt + (filter.uredi.length >0 ? 
                'за монтаж: ' + this.vlistv43.find(x=>x.nkod == filter.uredi).name +'; ':'');
    }

    if (filter.statusG) {
      txt = txt + (filter.statusG >0 ? 
                'Статус график: ' + this.vliststatusG.find(x=>x.id == filter.statusG).name +'; ':'');
    } 

    if (filter.statusM) {
      txt = txt + (filter.statusM > -1 ? 
                'Статус монтаж: ' + this.vliststatusM.find(x=>x.id == filter.statusM).name +'; ':'');
    } 
    
    if (filter.statusPF) {
      txt = txt + (filter.statusPF > -1 ? 
                'Статус профилактика: ' + this.vliststatusPF.find(x=>x.id == filter.statusPF).name +'; ':'');
    } 

    if (filter.grafikdataot) {
      txt = txt + 'По график: от ' 
          + moment(filter.grafikdataot).format(DATE_FORMAT)+' - '
          + moment(filter.grafikdatado).format(DATE_FORMAT);
    }

    if (filter.otchetdataot) {
      txt = txt + 'По график: от ' 
          + moment(filter.otchetdataot).format(DATE_FORMAT)+' - '
          + moment(filter.otchetdatado).format(DATE_FORMAT);
    }

    if (filter.unomer) {
      txt = txt + (filter.unomer >0 ? 
                '№ ОПОС: ' + String(filter.unomer) +'; ':'');
    }            

    if (filter.porychkanom) {
      txt = txt + (filter.porychkanom >0 ? 
                '№ поръчка за монтаж: ' + String(filter.porychkanom) +'; ':'');
    }            

    if (filter.demporychkanom) {
      txt = txt + (filter.demporychkanom >0 ? 
                '№ поръчка за демонтаж: ' + String(filter.demporychkanom) +'; ':'');
    }          
    
    if (filter.kymdata) {
      txt = txt + 'Към дата: ' 
          + moment(filter.kymdata).format(DATE_FORMAT)+ '; ';
    }

    if (filter.sleddata) {
      txt = txt + 'След дата: ' 
          + moment(filter.sleddata).format(DATE_FORMAT)+ '; ';
    }

    if (filter.otdata) {
      txt = txt + 'От дата: ' 
          + moment(filter.otdata).format(DATE_FORMAT)+ '; ';
    }

    if (filter.dodata) {
      txt = txt + 'До дата: ' 
          + moment(filter.dodata).format(DATE_FORMAT)+ '; ';
    }

    return txt;
  }
}
