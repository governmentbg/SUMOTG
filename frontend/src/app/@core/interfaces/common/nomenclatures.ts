import moment from 'moment';
import { Observable } from 'rxjs';
import { Dogovor, Izpylnitel, Uredi } from './firmi';
import { Obrabotki } from './obrabotki';

export interface AllExtraAddresses {
  id: number;
  tip: number;
  opisanie: string;
  status: number;
}

export interface ExtraAddresses {
  id: number;
  tip: number;
  admRaion: string;
  nasMqsto: string;
  kvartal: string;
  jk: string;
  ulica: string;
  nomer: string;
  blok: string;
  vhod: string;
  etaj: string;
  apart: string;
  postKode: string;
  opisanie: string;
  status: number;
}

export interface Nomenclature {
  kodnmn: string;
  role: string;
  tabablicaVBazata: string;
  ime: string;
  status: number;
}

export interface NomObshti {
  idkn: number;
  kodnmn: string;
  kodpos: string;
  status: number;
  text: string;
}

export interface NomJk {
  nkod: string;
  nime: string;
  status: number;
}

export interface NomKmetstvo {
  nkod: string;
  nime: string;
  status: number;
}

export interface NomRaion {
  nkod: string;
  nime: string;
  status: number;
}

export interface NomNsMqsto {
  nkod: string;
  nime: string;
  kmetstvo: string;
  status: number;
}

export interface NomUlica {
  nkod: string;
  nime: string;
  wnasm_nkod: string;
  wnuli_nkod: string;
  status: number;
  wnasm: string;
}

export interface NomKvartal {
  nkod: string;
  nime: string;
  status: number;
}

export interface NomUred {
  id: number;
  faza: number;
  nkod: string;
  nime: string;
  maxbr: number;
  doprad: number;
  status: number;
  kolectform: number;
  vid: string;
  nkod2: string;
  nime2: string;
}

export interface NomUredBudget {
  id: number;
  faza: number;
  nkod: string;
  nime: string;
  quantity: number;
  price: number;
  status: number;
}

export interface NomStatus {
  code: number;
  text: string
}

export interface NomKid {
  nkod: string;
  nime: string;
  status: number;
}

export class ViewNom {
  id: number;
  nkod: string;
  name: string;

  addAll() {
    this.id = 0;
    this.nkod = '0';
    this.name = 'Всички';
    return this;
  }

  addItem(id: number, nkod: string, name: string) {
    this.id = id;
    this.nkod = nkod;
    this.name = name;
    return this;
  }

  convertNomObshti(item: NomObshti) {
    this.id = item.idkn;
    this.nkod = String(item.idkn);
    this.name = item.text;
    return this;
  }

  convertNomUlici(item: NomUlica) {
    this.id = Number(item.nkod);
    this.nkod = item.nkod;
    this.name = item.nime;
    return this;
  }

  convertNomKvartal(item: NomKvartal) {
    this.id = Number(item.nkod);
    this.nkod = item.nkod;
    this.name = item.nime;
    return this;
  }

  convertNomNsMqsto(item: NomNsMqsto) {
    this.id = Number(item.nkod);
    this.nkod = item.nkod;
    this.name = item.nime;
    return this;
  }

  convertNomRaion(item: NomRaion) {
    this.id = Number(item.nkod);
    this.nkod = item.nkod;
    this.name = item.nime;
    return this;
  }

  convertNomUred(item: NomUred, tip:number = 0) {
    if (tip == 1) {
      this.id = Number(item.nkod);
      this.nkod = item.nkod;
      this.name = item.nkod+' '+item.nime;
    } else {
      this.id = item.id;
      this.nkod = String(item.id);
      this.name = item.nkod+' '+item.nime;
    }
    return this;
  }

  convertNomStatusi(item: NomStatus) {
    this.id = item.code;
    this.nkod = String(item.code);
    this.name = item.text;
    return this;
  }

  convertNomKID(item: NomKid) {
    this.id = Number(item.nkod);;
    this.nkod = String(item.nkod);
    this.name = item.nime;
    return this;
  }

  convertFirmi(item: Izpylnitel) {
    this.id = Number(item.idfirma);;
    this.nkod = String(item.idfirma);
    this.name = item.eik+' '+item.ime;
    return this;
  }

  convertDogovorFirmi(item: Dogovor) {
    const regdate = new Date (item.regnomdata)

    this.id = Number(item.iddog);;
    this.nkod = String(item.iddog);
    this.name = item.regnom+' / ' + regdate.toLocaleDateString('bg-BG');
    return this;
  }


  convertMonDogovorPorychki (item: Dogovor) {
    this.id = Number(item.iddog);;
    this.nkod = String(item.iddog);
    this.name = 'Поръчка № '+String(item.iddog);
    return this;
  }

  convertDogUred(item: Uredi) {
    this.id = Number(item.idured);
    this.nkod = item.idured;
    this.name = item.name;
    return this;
  }

  convertMonOrder(item: Obrabotki) {
    this.id = item.idporychka;
    this.nkod = String(item.idporychka);
    this.name = 'поръчка за монтаж '+ String(item.idporychka)+' ('+item.ime+')';
    return this;
  }
}



export abstract class NomenclatureData {
  abstract getNomenclatures(): Observable<Nomenclature[]>;

//#region n_obshti
  abstract getAllNomenObshti(kod: string): Observable<NomObshti[]>;
  abstract getNomenObshti(kod: string): Observable<NomObshti[]>;
  abstract getRowNomenObshti(id: number): Observable<NomObshti>;
  abstract setRowNomenObshti(item: NomObshti): Observable<boolean>;
  abstract addRowNomenObshti(item: NomObshti): Observable<number>;
  abstract delRowNomenObshti(id: number): Observable<boolean>;
//#endregion

//#region n_jk
  abstract getAllNomenJk(): Observable<NomJk[]>;
  abstract getNomenJk(): Observable<NomJk[]>;
  abstract getRowNomenJk(id: string): Observable<NomJk>;
  abstract setRowNomenJk(item: NomJk): Observable<boolean>;
  abstract addRowNomenJk(item: NomJk): Observable<number>;
  abstract delRowNomenJk(id: string): Observable<boolean>;  
  abstract getMaxKodJk (): Observable<string>;
//#endregion

//#region n_kmetstva
  abstract getAllNomenKmetstva(): Observable<NomKmetstvo[]>;
  abstract getNomenKmetstva(): Observable<NomKmetstvo[]>;
  abstract getRowNomenKmetstva(id: string): Observable<NomKmetstvo>;
  abstract setRowNomenKmetstva(item: NomKmetstvo): Observable<boolean>;
  abstract addRowNomenKmetstva(item: NomKmetstvo): Observable<number>;
  abstract delRowNomenKmetstva(id: string): Observable<boolean>;
//#endregion

//#region n_ulici
  abstract getAllNomenUlici(): Observable<NomUlica[]>;
  abstract getNomenUlici(): Observable<NomUlica[]>;
  abstract getRowNomenUlici(id: string): Observable<NomUlica>;
  abstract setRowNomenUlici(item: NomUlica): Observable<boolean>;
  abstract addRowNomenUlici(item: NomUlica): Observable<number>;
  abstract delRowNomenUlici(id: string): Observable<boolean>;
  abstract getUliciPerNsMqsto(nkod: string):Observable<NomUlica[]>;
  abstract getMaxKodUlici (): Observable<string>;
//#endregion

//#region n_nasmesta
  abstract getAllNomenNsMesta(): Observable<NomNsMqsto[]>;
  abstract getNomenNsMesta(): Observable<NomNsMqsto[]>;
  abstract getRowNomenNsMesta(id: string): Observable<NomNsMqsto>;
  abstract setRowNomenNsMesta(item: NomNsMqsto): Observable<boolean>;
  abstract addRowNomenNsMesta(item: NomNsMqsto): Observable<number>;
  abstract delRowNomenNsMesta(id: string): Observable<boolean>;
  abstract getNomenNsMestaByRaion(idraion: string): Observable<NomNsMqsto[]>;
//#endregion

//#region n_raioni
  abstract getAllNomenRaioni(): Observable<NomRaion[]>;
  abstract getNomenRaioni(): Observable<NomRaion[]>;
  abstract getRowNomenRaioni(id: string): Observable<NomRaion>;
  abstract setRowNomenRaioni(item: NomRaion): Observable<boolean>;
  abstract addRowNomenRaioni(item: NomRaion): Observable<number>;
  abstract delRowNomenRaioni(id: string): Observable<boolean>;
//#endregion

//#region n_uredi
  abstract getAllNomenUredi(includeDeleted: boolean): Observable<NomUred[]>;
  abstract getNomenUredi(): Observable<NomUred[]>;
  abstract getRowNomenUredi(id: number): Observable<NomUred>;
  abstract setRowNomenUredi(item: NomUred): Observable<number>;
  abstract addRowNomenUredi(item: NomUred): Observable<number>;
  abstract delRowNomenUredi(id: number): Observable<boolean>;
  abstract getNomenKolektivUredi(): Observable<NomUred[]>;
//#endregion

//#region statusi
  abstract getNomenStatusi(type: string): Observable<NomStatus[]>;
//#endregion

//#region nkid
  abstract getNomenKID(): Observable<NomKid[]>
//#endregion

//#region extra adresi
abstract getAllExtraAddresses():  Observable<AllExtraAddresses[]>
abstract delExtraAddress(id: number): Observable<number>;
abstract getRowExtraAddress(id: number): Observable<ExtraAddresses>;
abstract addRowExtraAddress(item: ExtraAddresses): Observable<number>;
abstract setRowExtraAddress(item: ExtraAddresses): Observable<number>;
//#region extra adresi


//#region n_uredi_budget
abstract getAllNomenUrediBudget(includeDeleted: boolean): Observable<NomUredBudget[]>;
abstract getRowNomenBudgetUredi(id: number): Observable<NomUredBudget>;
abstract setRowNomenBudgetUredi(item: NomUredBudget): Observable<number>;
//#endregion

}
