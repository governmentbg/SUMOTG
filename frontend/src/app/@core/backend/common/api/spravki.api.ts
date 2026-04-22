import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HeaderComponent } from '../../../../@theme/components';
import { HttpService } from './http.service';

@Injectable()
export class SpravkiApi {
  private readonly apiController: string = 'spravki';

  constructor(private api: HttpService) {}

  getSpravki(): Observable<any> {
    const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`);

    return this.api.get(`${this.apiController}/getspravki`, { params });
  }

  getSpravka1(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka1`, filter);
  }

  getSpravka2(filter: any): Observable<any[]> {
      const params = new HttpParams()
          .set('type', '1');

        return this.api.post(`${this.apiController}/getspravka2`, filter, { params });
  }

  getSpravka3(filter: any): Observable<any[]> {
     const params = new HttpParams()
        .set('type', '2');
     return this.api.post(`${this.apiController}/getspravka2`, filter, { params });
  }

  getSpravka4(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka4`, filter);
  }

  getSpravka5(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka5`, filter);
  }

  getSpravka6(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka6`, filter);
  }

  getSpravka7(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka7`, filter);
  }

  getSpravka8(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka8`, filter);
  }

  getSpravka9(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka9`, filter);
  }

  getSpravka10(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka10`, filter);
  }

  getSpravka11(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka11`, filter);
  }

  getSpravka12(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka12`, filter);
  }

  getSpravka13(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka13`, filter);
  }
  
  getSpravka14(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka14`, filter);
  }

  getSpravka15(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka15`, filter);
  }
  
  getSpravka20(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka20`, filter);
  }

  getSpravka21(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka21`, filter);
  }

  getSpravka23(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka23`, filter);
  }
  getSpravka24(): Observable<any[]>{
    return this.api.get(`${this.apiController}/getspravka24`);
  }

  getSpravka25(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getspravka25`, filter);
  }

  getOposPortret(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getoposportret`, filter);
  }

  getSpravka50(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka50`, filter);
  }
  getSpravka51(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka51`, filter);
  }
  getSpravka52(): Observable<any[]> {
    return this.api.get(`${this.apiController}/getspravka52`);
  }
  getSpravka53(): Observable<any[]>{
    return this.api.get(`${this.apiController}/getspravka53`);
  }
  getSpravka54(): Observable<any[]>{
    return this.api.get(`${this.apiController}/getspravka54`);
  }
  getSpravka55(tip: number): Observable<any[]>{
    const params = new HttpParams()
        .set('type', tip);

    return this.api.get(`${this.apiController}/getspravka55`, {params} );
  }
  getSpravka56(): Observable<any[]>{
    return this.api.get(`${this.apiController}/getspravka56`);
  }

  getSpravka60(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka60`, filter);

  }
  getSpravka61(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka61`, filter);
  }

  getSpravka70(tip: number, filter: any): Observable<any[]>{
    const params = new HttpParams()
      .set('tip', tip);

    return this.api.post(`${this.apiController}/getspravka70`, filter, {params} );
  }

  getSpravka72(tip: number, filter: any): Observable<any[]>{
    const params = new HttpParams()
      .set('tip', tip);

    return this.api.post(`${this.apiController}/getspravka72`, filter, {params} );
  }

  getSpravka78(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka78`, filter);
  }

  getSpravka79(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getspravka79`, filter);
  }  

  setPorychkaStatus(idporychka: number, status: number): Observable<number>{
    const params = new HttpParams()
      .set('idporychka', idporychka)
      .set('status', status);

      return this.api.get(`${this.apiController}/setporychkastatus`, {params} );
  }

  setPorychkaUnSign(idporychka: number): Observable<number>{
    const params = new HttpParams()
      .set('idporychka', idporychka)

      return this.api.get(`${this.apiController}/setporychkaunsign`, {params} );
  }    
}
