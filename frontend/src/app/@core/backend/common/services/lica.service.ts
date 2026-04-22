import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Filter } from '../../../../pages/application/components/filter/filter.settings';
import { Address, Firma, FirmaItem, Formulqr, Lice, LiceData, LiceDogovor, ListFormulqrs, PersonItem, RadPrekodItem } from '../../../interfaces/common/lica';
import { LicaApi } from '../api/lica.api';

@Injectable()
export class LicaService extends LiceData {

  constructor(private api: LicaApi) {
    super();
  }

//#region lica
  getLice(id: number): Observable<Lice> {
    return this.api.getLice(id);
  }

  getDogovorPersons(filter: Filter): Observable<PersonItem[]> {
    return this.api.getDogovorPersons(filter);
  }

  getPersons(filter: Filter): Observable<PersonItem[]> {
    return this.api.getPersons(filter);
  }

  setLice(item: Lice): Observable<number> {
    return this.api.setLice(item);
  }  

  setChlen(item: Lice): Observable<number> {
    return this.api.setChlen(item);
  }  

  getLiceDogovor(id: number): Observable<LiceDogovor> {
    return this.api.getLiceDogovor(id);
  }

  setLiceDogovor(item: LiceDogovor): Observable<number> {
    return this.api.setLiceDogovor(item);
  }

  setLiceDogovorStatus (iddog:number, status: number): Observable<number> {
    return this.api.setLiceDogovorStatus(iddog,status);
  }

  changeLiceTitulqr (idlice: number, statuslice: number): Observable<number> {
    return this.api.changeLiceTitulqr(idlice,statuslice)
  }

  addTitular (idlice: number, statuslice: number, item: Lice): Observable<number> {
    return this.api.addTitular(idlice,statuslice,item)
  }

  getLiceDogovorStatus(id: number):  Observable<number>{
    return this.api.getLiceDogovorStatus(id)
  }  

  setLiceDogovorExpired (iddog:number): Observable<number>{
    return this.api.setLiceDogovorExpired(iddog)
  }

  //#endregion

//#region formulqr
  getListFormulqrs(vid: number,filter: Filter): Observable<ListFormulqrs[]> {
    return this.api.getListFormulqrs(vid,filter);
  }

  getFormulqr(id: number): Observable<Formulqr> {
    return this.api.getFormulqr(id);
  }

  addFormulqr(item: any): Observable<any> {
    return this.api.addFormulqr(item);
  }

  setFormulqr(item: Formulqr): Observable<Formulqr> {
    return this.api.setFormulqr(item);
  }
  
  getHistoryFormulqr(id: number): Observable<PersonItem[]> {
    return this.api.getHistoryFormulqr(id);
  }

  setFormulqrStatus(idformulqr: number, status: number): Observable<number> {
    return this.api.setFormulqrStatus(idformulqr, status);
  }

  checkFormulqrUnomer(unomer: string): Observable<number> {
    return this.api.checkFormulqrUnomer(unomer);
  }

  checkFormulqrAdres(adres: Address): Observable<number> {
    return this.api.checkFormulqrAdres(adres);
  }
  
//#endregion

//#region firma
  getFirma(id: number): Observable<Firma> {
    return this.api.getFirma(id);
  }

  getFirms(filter: Filter): Observable<FirmaItem[]> {
    return this.api.getFirms(filter);
  }

  setFirma(item: Firma): Observable<number> {
    return this.api.setFirma(item);
  }

//#endregion

  genDogovorFile(id: number): Observable<HttpResponse<Blob>> {
    return this.api.genDogovorFile(id);
  }

  getDogovorAddPages(): Observable<HttpResponse<Blob>> {
    return this.api.getDogovorAddPages();
  }

  updOposDogovorNomer(nomer: string, data: string, otnosno: string):  Observable<number>{
    return this.api.updOposDogovorNomer(nomer, data, otnosno);
  }

  getRadiatoriZaPrekodirane(filter: Filter): Observable<RadPrekodItem[]> {
    return this.api.getRadiatoriZaPrekodirane(filter);
  }

  doPrekodiraneRadiatori(iddogovorlice: number): Observable<number>{
    return this.api.doPrekodiraneRadiatori(iddogovorlice);
  }

  getAddress(id: number): Observable<Address>{
    return this.api.getAddress(id);
  }
  setAddress(item: Address): Observable<number>{
    return this.api.setAddress(item);
  }
}
