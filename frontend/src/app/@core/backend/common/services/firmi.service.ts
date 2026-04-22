import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dogovor, FirmaData, FirmaDogovor, FirmaIzpalnitel, Izpylnitel, Uredi } from '../../../interfaces/common/firmi';
import { FirmiApi } from '../api/firmi.api';

@Injectable()
export class FirmiService extends FirmaData {
  constructor(private api: FirmiApi) {
    super();
  }

  getFirmi(rolq: number): Observable<Izpylnitel[]>{
    return this.api.getFirmi(rolq);
  }

  getFirma(eik: string): Observable<Izpylnitel>{
    return this.api.getFirma(eik);
  }

  //#region montaz
  getFirmiMontaz(): Observable<FirmaIzpalnitel[]> {
      return this.api.getFirmiMontaz();
  }
  getMonDogovor(iddog: number): Observable<FirmaDogovor> {
    return this.api.getMonDogovor(iddog);
  }
  setMonDogovor(item: FirmaDogovor): Observable<number> {
    return this.api.setMonDogovor(item);
  }
  loadMonDogovorFirma(idfirma: number): Observable<Dogovor[]>{
    return this.api.loadMonDogovorFirma(idfirma);
  }

  loadMonDogovorUredi(iddog: number): Observable<Uredi[]> {
    return this.api.loadMonDogovorUredi(iddog);
  }

  loadMonDogovorPorychki(iddog: number): Observable<Dogovor[]>{
    return this.api.loadMonDogovorPorychki(iddog);
  }

  //#endregion

  //#region demontaz
  getFirmiDeMontaz(): Observable<FirmaIzpalnitel[]> {
      return this.api.getFirmiDeMontaz();
  }
  getDeMonDogovor(iddog: number): Observable<FirmaDogovor> {
    return this.api.getDeMonDogovor(iddog);
  }
  setDeMonDogovor(item: FirmaDogovor): Observable<number> {
    return this.api.setDeMonDogovor(item);
  }
  loadDeMonDogovorFirma(idfirma: number): Observable<Dogovor[]>{
    return this.api.loadDeMonDogovorFirma(idfirma);
  }  
  loadDeMonDogovorUredi(iddog: number): Observable<Uredi[]> {
    return this.api.loadDeMonDogovorUredi(iddog);
  }
  //#endregion
}