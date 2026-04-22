import { Observable } from "rxjs/internal/Observable";

export interface FirmaIzpalnitel {
    idfirma: number;
    eik: string;
    ime: string;
    iddog: number;
    regnomer: string;
    dataregnom: Date;
    statusdm: string;
    statusur: string;
}

export interface Izpylnitel{
    idfirma: number;
    vidFirma: number;
    rolq: number;
    eik: string;
    ime: string;
    manager: string;
    mname: string;
    adres: string;
    email: string;
    telefon: string;
    postKode: string;
    status: number;
    statusDM: number;
}

export interface FirmaDogovor{
    iddog:number;
    faza: number;
    regnom: string;
    regnomdata: Date;
    nomdgsudso: string;
    nachalnadata: Date;
    srokgrafic: number;
    cenabezdds: number;
    cenadds: number;
    status_DM: number;
    status: number;
    firma: Izpylnitel;
    uredi: Uredi[],
    raioni: Raioni[],
    payments: Payment[],
}
export interface Payment {
    id:string,
    sumabezdds: number;
    sumasdds: number;
}

export interface Raioni {
    nkod: string;
    nime: string;
}

export interface Uredi {
    idured: string;
    model: string;
    name: string;
    broi: number;
    edcena:number;
    total:number;
    status:number;
    statusU:number;
}
export interface Dogovor{
    iddog:number;
    regnom: string;
    regnomdata: Date;
    nomdgsudso: string;
    nachalnadata: Date;
}

export abstract class FirmaData {
    abstract getFirmi(rolq: number): Observable<Izpylnitel[]>;
    abstract getFirma(eik: string): Observable<Izpylnitel>;

    abstract getFirmiMontaz(): Observable<FirmaIzpalnitel[]>;
    abstract getMonDogovor(iddog: number): Observable<FirmaDogovor>;
    abstract setMonDogovor(item:FirmaDogovor): Observable<number>;
    abstract loadMonDogovorFirma(idfirma: number): Observable<Dogovor[]>;
    abstract loadMonDogovorUredi(iddog: number): Observable<Uredi[]>
    abstract loadMonDogovorPorychki(iddog: number): Observable<Dogovor[]>

    abstract getFirmiDeMontaz(): Observable<FirmaIzpalnitel[]>;
    abstract getDeMonDogovor(idfirma: number): Observable<FirmaDogovor>;
    abstract setDeMonDogovor(item:FirmaDogovor): Observable<number>;
    abstract loadDeMonDogovorFirma(idfirma: number): Observable<Dogovor[]>;
    abstract loadDeMonDogovorUredi(iddog: number): Observable<Uredi[]>
} 

