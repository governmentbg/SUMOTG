import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HeaderComponent } from '../../../../@theme/components';
import { HttpService } from './http.service';

@Injectable()
export class FirmiApi {
  private readonly apiController: string = 'firmi';

  constructor(private api: HttpService) {}

  getFirmi(rolq: number): Observable<any[]>{
    const params = new HttpParams()
        .set('faza', `${HeaderComponent.faza}`)
        .set('rolq', `${rolq}`);

    return this.api.get(`${this.apiController}/getfirmi`, { params });
  }

  getFirma(eik: string): Observable<any>{
    const params = new HttpParams()
        .set('eik', `${eik}`);

    return this.api.get(`${this.apiController}/getfirma`, { params });
}


  //#region montaz
  getFirmiMontaz(): Observable<any> {
    const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`);

    return this.api.get(`${this.apiController}/getfirmimontaz`, { params });
  }

  getMonDogovor(iddog: number): Observable<any> {
    const params = new HttpParams()
        .set('iddog', `${iddog}`);

    return this.api.get(`${this.apiController}/getmondogovor`, { params });
  }
  
  setMonDogovor(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setmondogovor`, item);
  }

  loadMonDogovorFirma(idfirma: number): Observable<any[]>{
    const params = new HttpParams()
        .set('idfirma', `${idfirma}`);

    return this.api.get(`${this.apiController}/getmondogovorifirma`, {params});
  }  

  loadMonDogovorUredi(iddog: number): Observable<any[]> {
    const params = new HttpParams()
        .set('idgogovor', `${iddog}`);

    return this.api.get(`${this.apiController}/loadmongogovoruredi`, {params});
  }

  loadMonDogovorPorychki(iddog: number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovor', `${iddog}`);

    return this.api.get(`${this.apiController}/loadmondogovorporychki`, {params});
  }

  //#endregion

  //#region demontaz
  getFirmiDeMontaz(): Observable<any> {
    const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`);

    return this.api.get(`${this.apiController}/getfirmidemontaz`, { params });
  }

  getDeMonDogovor(iddog: number): Observable<any> {
    const params = new HttpParams()
        .set('iddog', `${iddog}`);

    return this.api.get(`${this.apiController}/getdemdogovor`, { params });
  }
  
  setDeMonDogovor(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setdemdogovor`, item);
  }

  loadDeMonDogovorFirma(idfirma: number): Observable<any[]>{
    const params = new HttpParams()
        .set('idfirma', `${idfirma}`);

    return this.api.get(`${this.apiController}/getdemondogovorifirma`, {params});
  }  

  loadDeMonDogovorUredi(iddog: number): Observable<any[]> {
    const params = new HttpParams()
        .set('idgogovor', `${iddog}`);

    return this.api.get(`${this.apiController}/loaddemongogovoruredi`, {params});
  }

  //#endregion
}