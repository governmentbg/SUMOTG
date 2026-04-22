import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Filter } from '../../../pages/application/components/filter/filter.settings';

export interface Address {
    id: number;
    raionid: string;
    nm: string;
    kv: string;
    jk: string;
    ul: string;
    nomer: string;
    blok: string;
    vh: string;
    etaj: string;
    ap: string;
    opos: string;
}

export interface LiceDogovor {
    iddog:number;
    idl:number;
    faza: number;
    regnom: string;
    regnomdata: Date;
    uredi: Uredi[];
    olduredi: Uredi[];
    arhuredi: Uredi[];
    dopsp: DopSp[];
    status_DL: number;
    status: number;
    comentar: string;
    brdopsp: string;
    vid: number;
    srokDogovor: number;
    srokSobstvenost: number;
}

export interface ListFormulqrs{
    idFormulqr: number;
    unom: string,
    raion: string;
    idl: number;
    ident: string,
    name: string,
    telefon: string,
    idfirma: number;
    firma: string,
    bulstat: string,
    bal: 0,
    status_L: 0,
    status_f: 0,
    iddog: number,
    status_dl: 0,
    stattxt_dl: string,
    stattxt_f: string,
    stattxt_l: string,
    unomer: number
}

export interface Formulqr {
    idformulqr: number;
    faza: number;
    unom: string;
    lice: Lice;
    firma: Firma;
    nv9: string;
    nv10: string;
    v11: number;
    v12: number;
    v13: number;
    v14: number;
    v15: number;
    v16: number;
    v17: number;
    nv19: string;
    v20: number;
    v211: number;
    v212: number;
    v213: number;
    v22: number;
    v23: number;
    v24: number;
    v25: number;
    v26: number;
    v27: number;
    v28: number;
    nv29: string;
    v30: number;
    v31: number;
    v32: number;
    v33: number;
    v34: number;
    v35: number;
    v36: number;
    v37: number;
    v38: number;
    v391: number;
    v392: number;
    v401: number;
    v402: number;
    v41: number;
    v421: number;
    v422: number;
    v423: number;
    uredi: Uredi[];
    olduredi: Uredi[];
    dokumenti: Dokumenti[];
    systav: Lice[];
    status:number;
    statusF: number;
    statusDL: number;
    unomer: number;
    comentar: string;
}

export interface Dokumenti {
    idL: number;
    id:string;
    status: string;
}

export interface Uredi {
    id: string;
    broi: number;
    status:number;
    statusU:string;
}

export interface DopSp {
    id: string;
    regnomer: string;
    komentar:string;
}

export interface Lice {
    idl: number;
    faza: number;
    vidLice: number;
    idlice: number;
    vidIdent: string;
    ident: string;
    ime: string;
    nomLk: string;
    dataIzdavane: string;
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
    email: string;
    telefon: string;
    postKode: string;
    statusL: number;
    status: number;
    tochki1: number;
    tochki2: number;
    tochki3: number;
    tochki4: number;
    tochki5: number;
    tochki6: number;
    tochki7: number;
    total: number;
    zona: string;
    v7: string;
    nv8: string;
    typeLice: number;
    unom: string;
}

export interface Firma {
    idfirma: number;
    idl:number;
    faza: number;
    vidFirma: string;
    tipFirma: string;
    kodKID: string;
    ident: string;
    ime: string;
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
    email: string;
    telefon: string;
    postKode: string;
    statusL: number;
    statusF: number;
    status: number;
}

export interface PersonItem {
    idl: number;
    raion: string;
    unom: string;
    ident: string;
    ime: string;
    bal: number;
    status: string;
    statusL: string;
    idformulqr: number;
    statusF: string;
    iddogovor: number;
    statusDL: string;
    typelice: string;
    dognomer: string;
    dogdate: string;
    telefon: string;
    adres: string;
    idlice: number
}

export interface FirmaItem {
    idfirma: number;
    raion: string;
    unom: string;
    ident: string;
    ime: string;
    bal: number;
    status: string;
    statusL: string;
    idformulqr: number;
    statusF: string;
    iddogovor: number;
    statusDL: string;
    vidlice: number;
}

export interface RadPrekodItem {
    iddogovorlice: number;
    IdL: number;
    ident: string;
    ime: string;
    vidimot: string;
    A_raion: string;
    adres: string;
    email: string;
    telefon: string;
    uredname: string;
    unom: string;
    unomer: number;
    vidured: string;
    raion: string;
    txtStatusDL: string;
    isSelected: boolean
}

export abstract class LiceData {
    abstract getLice(id: number): Observable<Lice>;
    abstract setLice(item: Lice): Observable<number>;
    abstract setChlen(item: Lice): Observable<number>;
    abstract getLiceDogovor(id: number): Observable<LiceDogovor>;
    abstract setLiceDogovor(item: LiceDogovor): Observable<number>;
    abstract setLiceDogovorStatus (iddog:number, status: number): Observable<number>;
    abstract changeLiceTitulqr (idlice: number, statuslice: number): Observable<number>;
    abstract addTitular (idlice: number, statuslice: number, item: Lice): Observable<number>;    
    abstract setLiceDogovorExpired (iddog:number): Observable<number>;
    
    abstract getListFormulqrs(vid: number,filter: Filter): Observable<ListFormulqrs[]>;
    abstract getFormulqr(id: number): Observable<Formulqr>;
    abstract addFormulqr(item: Formulqr): Observable<any>;
    abstract setFormulqr(item: Formulqr): Observable<any> ;
    abstract getPersons(filter: Filter): Observable<PersonItem[]>;
    abstract getDogovorPersons(filter: Filter): Observable<PersonItem[]>;
    abstract getFirma(id: number): Observable<Firma>;
    abstract getFirms(filter: Filter): Observable<FirmaItem[]>;
    abstract setFirma(item: Firma): Observable<number>;
    abstract getHistoryFormulqr(id: number): Observable<PersonItem[]>;
    abstract setFormulqrStatus(idformulqr: number, status: number): Observable<number>;
    abstract checkFormulqrUnomer(unomer: string): Observable<number>;
    abstract checkFormulqrAdres(adres: Address): Observable<number>;
          
    abstract genDogovorFile(id: number): Observable<HttpResponse<Blob>>;
    abstract getDogovorAddPages(): Observable<HttpResponse<Blob>>;
    abstract getLiceDogovorStatus(id: number):  Observable<number>;
    abstract updOposDogovorNomer(nomer: string, data: string, otnosno: string):  Observable<number>;
    abstract getRadiatoriZaPrekodirane(filter: Filter): Observable<RadPrekodItem[]>;
    abstract doPrekodiraneRadiatori(iddogovorlice: number): Observable<number>;

    abstract getAddress(id: number): Observable<Address>;
    abstract setAddress(item: Address): Observable<number>;

}
