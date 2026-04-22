import { Observable } from 'rxjs';
import { FilterA } from '../../../pages/application/components/filter-a/filter-a.settings';
import { Filter } from '../../../pages/application/components/filter/filter.settings';

export interface Spravka {
  id: number;
  ime: string;
  komentar: string;
  tip: number;
  nkod: number;
}

export interface Spravka25 {
  raion: string,
  ime: string,
  dbroi: number,
  vbroi: number,
  sbroi: number,
  montazj: string,
  mbroi: number,
  adres: string,
  tel: string,
  email: string,
  descript: string,
}

export interface Spravka78 {
  raion: string,
  unom: string,
  ime: string,
  adres: string,
  dogovor: string,
  srok: number,
  data: Date,
  iddogovor: number
}

export interface Spravka70 {
  raion: string,
  unom: string,
  ime: string,
  adres: string,
  ured: string,
  srok: number,
  data: Date,
  idporychka: number,
  dogfirma: string
}

export interface Spravka60 {
  raion: string,
  unom: string,
  ured: string,
  ime: string,
  adres: string,
  period: number,
  pnomer: number,
  data: Date,
  otchdata: Date,
  status: string,
  idporychka:number,
  note: string,
  dogfirma: string
  namefirma:string
}

export interface Spravka55 {
  id: number,
  nime: string,
  broi: number,
  calc: number,
  broiuredi: number,
  calcuredi: number,
}

export interface Spravka54 {
  vid: string,
  col2: number,
  col3: number,
  col4: number,
  col5: number,
  col6: number,
  col7: number,
  col8: number,
  col9: number,
  col10: number,
  col11: number,
  col12: number,
}

export interface Spravka53 {
  idured: number,
  nkod: string
  nime: string,
  broimon: number,
  broizaq: number,
  price: number,
  budget: number,
}

export interface Spravka52 {
//  id: number,
  nime: string,
  broi: number,
}

export interface Spravka50 {
  idured: number,
  ured: string,
  price: number,
  broi: number,
  budget: number,
  calcbudget: number,
  procbudget: number,
  tip: number
}

export interface Spravka15 {
  idl: number,
  idformulqr: number,
  unom: string,
  raion: string,
  dogovor: string,
  statusDl: string
  dopspor: string
  viddopspor: string,
  komentar: string,
  koga: string
}

export interface Spravka14 {
  idl: number,
  idformulqr: number,
  dognomer: string,
  dogdate: string,
  unom: string,
  ime: string,
  raion: string,
  adres: string,
  txturedi: string,
  statusM: string,
  dataM: string,
  porychkaM: string,
  izpalnitel: string,
  izpdogovor:string,
  txtolduredi: string,
  statusD: string,
  dataD: string,
  porychkaD: string,
  txtkamina: string,
  statusDl: string
}

export interface Spravka24 {
  idl: number;
  ime: string;
  idformulqr: number;
  opos: string;
  adres: string;
  status_dl: string;
}

export interface SpravkaOposPortret {
  code: string;
  text: string;
  text2: string;
  isbold: number;
}

export interface Spravka21 {
  nkod: string;
  raion: string;
  formulqri: number;
  dogovori: number;
  doguredi: number;
  monuredi: number;
  monurpel: number;
  monurgaz: number;
  monurklm: number;
  monurrad: number;
  monuredid: number;
  monurpeld: number;
  monurgazd: number;
  monurklmd: number;

}
export interface Spravka20 {
  raion: string,
  unom: string,
  ime: string,
  status: string,
  ime2: string,
}

export interface Spravka13 {
  kodured: string,
  imeured: string,
  l_dogbroi: number,
  l_ordbroi: number,
  l_inordbroi: number,
  p_ingrafik: number,
  p_inotchet: number,
  p_montirani: number,
  l_otkazani: number,
  p_otkazani: number,
  p_izklucheni: number,
}

export interface Spravka11 {
  porychka: number,
  idfirma: number,
  eik: string,
  iddog: number,
  dogovor: string,
  unomer: string,
  kodured: string,
  imeured: string,
  broi: number,
  datag: Date,
  otchas: string,
  dochas: string,
  statusg: string,
  note: string,
  datam: Date,
  statusm: string,
  note2: string,
  ime: string,
  adres: string,
  model: string,
  fabrnomer: string,
  garkarta: string,
  gardata: Date,
  protnomer: string,
  protdata: Date,
}

export interface Spravka8 {
  kodured: string,
  imeured: string,
  dogbroi: number,
  ordbroi: number,
  tspbroi: number,
  inordbroi: number,
  restbroi: number,
  newrestbroi: number,
}

export interface Spravka7 {
  kodured: string,
  imeured: string,
  edcena: number,
  tspbroi: number,
  tsptotal: number,
  ordbroi: number,
  monbroi: number,
  montotal: number,
  restbroi: number,
  resttotal: number,
}

export interface Spravka6 {
  idfirma: number
  ime: string
  iddog: number
  dogovor: string
  kodured: string,
  imeured: string,
  edcena: number,
  tspbroi: number,
  tsptotal: number,
  ordbroi: number,
  rembroi: number,  
  monbroi: number,
  montotal: number,
  restbroi: number,
  resttotal: number,
}

export interface Spravka5 {
  idl: number
  idformulqr: number
  unom: string,
  raion: string,
  ime: string,
  adres: string,
  nkod: string,
  ured: string,
  statusU: string,
  broi: number,
  idporychka: number,
  regdog: string,
  statusDL: string,
  tipuredime: string
}

export interface Spravka4 {
  idl: number
  idformulqr: number
  unom: string,
  raion: string,
  ime: string,
  statusL: string,
  statusF: string,
  statusDL: string,
}

export interface Spravka3 {
  idformulqr: number
  unom: string,
  raion: string,
  txtured: string,
  txtrad: string,
  datamon: Date,
  note: string,
  status: string,
}

export interface Spravka2 {
  idl: number,
  idformulqr: number,
  raion: string,
  unom: string,
  ime: string,
  txturedi: string,
  txtolduredi: string,
  status: string,
  statusF: string,
  vidimot: string,
  adres: string,
  telefon: string,
  e_mail: string,
  dognomer: string,
  dogdate: string,
  komentar: string,
  dopspnom: string
  dopspvid: string,
}

export interface Filter1 {
  raionid: string,
  ident: string,
  name: string,
  unom: string,
  tochki: number,
  faza: number,
  descript: string,
  txtfilter: string,
  disable: boolean,
}

export interface Spravka1 {
  idl: number,
  idformulqr: number
  unom: string,
  ime: string,
  tochki1: number,
  tochki2: number,
  tochki3: number,
  tochki4: number,
  tochki5: number,
  tochki6: number,
  tochki7: number,
  total: number,
  status: string
}

export abstract class SpravkiData {
    abstract getSpravki(): Observable<Spravka[]>;
    abstract getSpravka1(filter: Filter1): Observable<Spravka1[]>;
    abstract getSpravka2(filter: Filter): Observable<Spravka2[]>;
    abstract getSpravka3(filter: Filter): Observable<Spravka2[]>;
    abstract getSpravka4(filter: Filter): Observable<Spravka4[]>;
    abstract getSpravka5(filter: Filter): Observable<Spravka5[]>;
    abstract getSpravka6(filter: Filter): Observable<Spravka6[]>;
    abstract getSpravka7(filter: Filter): Observable<Spravka7[]>;
    abstract getSpravka8(filter: Filter): Observable<Spravka8[]>;
    abstract getSpravka9(filter: Filter): Observable<Spravka5[]>;
    abstract getSpravka10(filter: Filter): Observable<Spravka6[]>;
    abstract getSpravka11(filter: FilterA): Observable<Spravka11[]>;
    abstract getSpravka12(filter: FilterA): Observable<Spravka11[]>;
    abstract getSpravka13(filter: Filter): Observable<Spravka13[]>;
    abstract getSpravka14(filter: Filter): Observable<Spravka14[]>;
    abstract getSpravka15(filter: Filter): Observable<Spravka15[]>;
    abstract getSpravka20(filter: Filter): Observable<Spravka20[]>;
    abstract getSpravka21(filter: Filter): Observable<Spravka21[]>;
    abstract getSpravka23(filter: Filter): Observable<Spravka5[]>;
    abstract getSpravka24(): Observable<Spravka24[]>;
    abstract getSpravka25(filter: Filter): Observable<Spravka25[]>;
    abstract getOposPortret(filter: Filter): Observable<SpravkaOposPortret[]>;
    abstract getSpravka50(filter: Filter): Observable<Spravka50[]>;
    abstract getSpravka51(filter: Filter): Observable<Spravka50[]>;
    abstract getSpravka52(): Observable<Spravka52[]>;
    abstract getSpravka53(): Observable<Spravka53[]>;
    abstract getSpravka54(): Observable<Spravka54[]>;
    abstract getSpravka55(tip: number): Observable<Spravka55[]>;
    abstract getSpravka56(): Observable<Spravka55[]>;
    abstract getSpravka60(filter: FilterA): Observable<Spravka60[]>;
    abstract getSpravka61(filter: FilterA): Observable<Spravka60[]>;
    abstract getSpravka70(tip: number, filter: FilterA): Observable<Spravka70[]>;
    abstract getSpravka72(tip: number, filter: FilterA): Observable<Spravka78[]>;
    abstract getSpravka78(filter: FilterA): Observable<Spravka78[]>;
    abstract getSpravka79(filter: FilterA): Observable<Spravka70[]>;

    abstract setPorychkaStatus(idporychka: number, status: number): Observable<number>;
    abstract setPorychkaUnSign(idporychka: number): Observable<number>;
  }
