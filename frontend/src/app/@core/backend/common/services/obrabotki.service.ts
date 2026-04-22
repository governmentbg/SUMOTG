import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DogovorRaioni, DogovorUredi, Dokument, Faktura, FakturiListItem, FileToUpload, MonOrder, ObrabotkaData, Obrabotki, PersUrediItem, ProfOrderItem } from "../../../interfaces/common/obrabotki";
import { ObrabotkiApi } from "../api/obrabotki.api";
import { HttpResponse } from "@angular/common/http";
import { FilterA } from "../../../../pages/application/components/filter-a/filter-a.settings";

@Injectable()
export class ObrabotkiService extends ObrabotkaData {
  constructor(private api: ObrabotkiApi) {
    super();
  }

  //#region montaz
  getMonListOrders(): Observable<Obrabotki[]>{
    return this.api.getMonListOrders();
  }

  getMonOrder(id: number): Observable<MonOrder>{
      return this.api.getMonOrder(id);
  }

  getDogovorFirmaUredi(iddogovorfirma: number): Observable<DogovorUredi[]>{
    return this.api.getDogovorFirmaUredi(iddogovorfirma);
  }
  
  getDogovorFirmaRaioni(iddogovorfirma: number): Observable<DogovorRaioni[]> {
    return this.api.getDogovorFirmaRaioni(iddogovorfirma);    
  }

  getPersonsWihtDogUredi(iddogovorfirma: number, raion:string, faza: number): Observable<PersUrediItem[]> {
    return this.api.getPersonsWihtDogUredi(iddogovorfirma, raion, faza);
  }

  getPersonUredi(iddogovorfirma: number, idlice:number): Observable<PersUrediItem[]> {
    return this.api.getPersonUredi(iddogovorfirma, idlice);
  }

  setMonOrder(item: MonOrder): Observable<number> {
     return this.api.setMonOrder(item);
  }

  setMonUrediDogovor (items: DogovorUredi[]): Observable<number>{
    return this.api.setMonUrediDogovor(items);
  }

  delMonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>{
    return this.api.delMonUrediDogovor(idporychka, idlicedogovor);
  }

  delMonOrder (idporychka: number): Observable<number>{
    return this.api.delMonOrder(idporychka);
  }
  getMonOrdersWithoutDemPorychka(): Observable<Obrabotki[]> {
    return this.api.getMonOrdersWithoutDemPorychka();
  }

  canDeleteMonOrder(id: number): Observable<number> {
    return this.api.canDeleteMonOrder(id);
  }
//#endregion

//#region demontazj
  getDemonListOrders(): Observable<Obrabotki[]>{
    return this.api.getDemonListOrders();
  }

  getDemonOrder(id: number): Observable<MonOrder>{
      return this.api.getDemonOrder(id);
  }

  getDemonDogovorFirmaUredi(iddogovorfirma: number): Observable<DogovorUredi[]>{
    return this.api.getDemonDogovorFirmaUredi(iddogovorfirma);
  }

  getDemonDogovorFirmaRaioni(iddogovorfirma: number): Observable<DogovorRaioni[]> {
    return this.api.getDemonDogovorFirmaRaioni(iddogovorfirma);    
  }

  getDemonPersonsWihtDogUredi(iddogovorfirma: number, raion:string, faza: number): Observable<PersUrediItem[]> {
    return this.api.getDemonPersonsWihtDogUredi(iddogovorfirma, raion, faza);
  }

  getDemonPersonUredi(iddogovorfirma: number, idlice:number): Observable<PersUrediItem[]> {
    return this.api.getDemonPersonUredi(iddogovorfirma, idlice);
  }

  setDemonOrder(item: MonOrder): Observable<number> {
    return this.api.setDemonOrder(item);
  }

  setDemonUrediDogovor (items: DogovorUredi[]): Observable<number>{
    return this.api.setDemonUrediDogovor(items);
  }

  delDemonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>{
    return this.api.delDemonUrediDogovor(idporychka, idlicedogovor);
  }

  delDemonOrder (idporychka: number): Observable<number>{
    return this.api.delDemonOrder(idporychka);
  }

  getDemonUrediFromMonPorychka(iddogovorfirma: number, idmonporychka: number): Observable<PersUrediItem[]>{
    return this.api.getDemonUrediFromMonPorychka(iddogovorfirma, idmonporychka);
  }

  setDemonOtchetUredi (opos: string, dogovor: string, data: string): Observable<number> {
    return this.api.setDemonOtchetUredi(opos, dogovor, data);
  }

//#endregion

//#region fakturi
  getMonListFakturi(vid: number): Observable<FakturiListItem[]> {
    return this.api.getMonListFakturi(vid);
  }

  getFaktura(idfaktura: number): Observable<Faktura> {
    return this.api.getFaktura(idfaktura);
  }

  setFaktura(item: Faktura): Observable<number> {
    return this.api.setFaktura(item);
  }

  delFactura(idfaktura: number): Observable<number> {
    return this.api.delFaktura(idfaktura);
  }

  getDocuments(id: number, typedoc: number): Observable<Dokument[]>{
    return this.api.getDocuments(id, typedoc);
  }

  uploadFile(file: FileToUpload): Observable<any[]> {
    return this.api.uploadFile(file);
  }

  removeFile(id: number): Observable<number> {
    return this.api.removeFile(id);
  }

  downloadFile(id: number): Observable<HttpResponse<Blob>> {
    return this.api.downloadFile(id);
  }

//#endregion

//#region profilaktika
  getProfOrder(filter: FilterA): Observable<ProfOrderItem[]>{
    return this.api.getProfOrder(filter);
  }

  setMonProfilaktika(id: number, otchdata: string, note: string, status_pf: number, idprofilaktika: number): Observable<number>{
    return this.api.setMonProfilaktika(id,otchdata, note, status_pf,idprofilaktika);
  }

  getProfOrderById(idprofilaktika: number): Observable<ProfOrderItem[]>{
    return this.api.getProfOrderById(idprofilaktika);
  }

  getProfilaktikaNextId(): Observable<number>{
    return this.api.getProfilaktikaNextId();
  }

//#endregion
} 