import { HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { FilterA } from "../../../pages/application/components/filter-a/filter-a.settings";

//#region  fakturi
export interface FakturiListItem{
    idfaktura: number;
    faknomer:number;
    fakdata: Date;
    idfirma: number;
    eik: string;
    ime: string;
    total: number;
}

export interface Faktura{
    idfactura: number;
    vidfirma: number;
    idfirma: number;
    facnomer:string;
    facdata: Date;
    iddogovorfirma: number;
    suma: number;
    dds: number;
    total: number;
    fakturaitems: FakturaRow[],
    status: number;
    vidpayment: string;
    forperiod: string;

}


export interface FakturaRow{
    idfactura: number;
    id: string;
    edcena: number;
    broi: number;
    total: number;
    status: number,
}
//#endregion

//#region montazj porychki

export interface Obrabotki{
    idporychka: number;
    nomer:number;
    faza: number;
    data: Date;
    idfirma: number;
    eik: string;
    ime: string;
    email: string;
    telefon: string;
    dogovor: string;
    statusPM: string;
    status: number;
    note: string;
    spm:number;
}

export interface MonOrder{
    idporychkamain: number,
    nomer: number,
    data: Date,
    idfirma: number,
    iddogovorfirma: number,
    raion: string,
    startdata: Date,
    enddata: Date,
    faza: number,
    porychkaitems: MonOrderItem[],
    status: number,
    status_pm: number,
    uredi: DogovorUredi[],
    note: string;
    idmonporychka: number
}

export interface MonOrderItem {
    faza: number,
    idporychkabody: number,
    idl: number,
    idured: number,
    iddogovorlice: number,
    raion: string,
    unom: string,
    eik: string
    ime: string,
    uredname: string,
    broi: number,
    vidimot: string,
    adres: string,
    email: string,
    telefon: string,
    dodata: Date,
    otchas: string,
    dochas: string,
    note: string,
    status_g: number,
    status_m: number,
    mondata: Date,
    model: string,
    fabrnomer: string,
    garkarta: string,
    gardata: Date,
    protnomer: string,
    protdata: Date,
    note2: string,
    snimka: string,
    status: number,
    ident: string,
    safeurl: string;
    vidured: string;
}

export interface DogovorUredi {
    idspdost: number
    id: number,
    name: string,
    edcena: number,
    broi: number,
    maxbroi: number,
    broiporychani: number,
    currentbroi:number,
    vidured: string;
}

export interface DogovorRaioni {
    nkod: string,
}

export interface PersUrediItem {
    iddogovorlice: number,
    idured: number,
    broi: number,
    idL: number;
    ident: string,
    ime: string,
    vidimot: string,
    adres: string,
    email: string,
    telefon: string,
    ischeck: number,
    unom: string,
    vidured: string;
    raion: string;
    uredname: string;
    note3: string;
}


export class FileToUpload {
    idDog: number = 0;
    idFactura: number = 0;
    docType: number = 0;
    fileName: string = "";
    fileSize: number = 0;
    fileType: string = "";
    description: string = ''; 
    fileAsBase64: string = "";
    rawFile: BlobPart;
    type: string;
    status: number = 1;
}

export interface Dokument {
    id: number;
    iddog: number;
    description: string;
    filename: string
    status: string;
}

export interface Profilaktika {
    id: number;
    iddog: number;
    description: string;
    filename: string
    status: string;
}

export interface ProfOrderItem{
    id: number,
    idporychkamain: number,
    idporychka: number,
    unom: string,
    idured: number,
    nkod: string,
    nomer: number,
    ured: string,
    broi: number,
    ime: string,
    adres: string,
    plandata: Date,
    otchdata: Date,
    status: number,
    status_pf: number,
    model: string,
    note: string;
    status_pfstr: string,
    changed: number,
    idprofilaktika: number   
    dogfirma: string,
    namefirma: string,
}


export abstract class ObrabotkaData {
//#region montazj
    abstract getMonListOrders(): Observable<Obrabotki[]>;
    abstract getMonOrder(id: number): Observable<MonOrder>;
    abstract getDogovorFirmaUredi(iddogovorfirma: number): Observable<DogovorUredi[]>;
    abstract getDogovorFirmaRaioni(iddogovorfirma: number): Observable<DogovorRaioni[]>;
    abstract getPersonsWihtDogUredi(iddogovorfirma: number, raion: string, faza: number): Observable<PersUrediItem[]>;
    abstract getPersonUredi(iddogovorfirma: number, idlice: number): Observable<PersUrediItem[]>;
    abstract setMonOrder(item: MonOrder): Observable<number>;
    abstract setMonUrediDogovor (items: DogovorUredi[]): Observable<number>;
    abstract delMonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>;
    abstract delMonOrder (idporychka: number): Observable<number>;
    abstract getMonOrdersWithoutDemPorychka(): Observable<Obrabotki[]>;
    abstract canDeleteMonOrder(id: number): Observable<number>;
//#endregion

//#region demontazj
    abstract getDemonListOrders(): Observable<Obrabotki[]>;
    abstract getDemonOrder(id: number): Observable<MonOrder>;
    abstract getDemonDogovorFirmaUredi(iddogovorfirma: number): Observable<DogovorUredi[]>;
    abstract getDemonDogovorFirmaRaioni(iddogovorfirma: number): Observable<DogovorRaioni[]>;
    abstract getDemonPersonsWihtDogUredi(iddogovorfirma: number, raion: string, faza: number): Observable<PersUrediItem[]>;
    abstract getDemonPersonUredi(iddogovorfirma: number, idlice: number): Observable<PersUrediItem[]>;
    abstract setDemonOrder(item: MonOrder): Observable<number>;
    abstract setDemonUrediDogovor (items: DogovorUredi[]): Observable<number>;
    abstract delDemonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>;
    abstract delDemonOrder (idporychka: number): Observable<number>;
    abstract getDemonUrediFromMonPorychka(iddogovorfirma: number, idmonporychka: number): Observable<PersUrediItem[]>;
    abstract setDemonOtchetUredi (opos: string, dogovor: string, data: string): Observable<number>;
//#endregion

    //#region fakturi
    abstract getMonListFakturi(vid: number): Observable<FakturiListItem[]>;
    abstract getFaktura(idfaktura: number): Observable<Faktura>;
    abstract setFaktura(item: Faktura): Observable<number>;
    abstract delFactura(idfaktura: number): Observable<number>;
    abstract getDocuments(id: number, typedoc: number): Observable<Dokument[]>;
    abstract uploadFile(file: FileToUpload): Observable<any[]>;
    abstract removeFile(id: number): Observable<number>;
    abstract downloadFile(id: number): Observable<HttpResponse<Blob>>;
    //#endregion

    //#region profilaktika
    abstract getProfOrder(filter: FilterA): Observable<ProfOrderItem[]>;
    abstract setMonProfilaktika(id: number, otchdata: string, note: string, status_pf: number, idprofilaktika: number): Observable<number>;
    abstract getProfOrderById(idprofilaktika: number): Observable<ProfOrderItem[]>;
    abstract getProfilaktikaNextId(): Observable<number>;
    //#endregion
} 
