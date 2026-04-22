import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HeaderComponent } from '../../../../@theme/components';
import { HttpService } from './http.service';

@Injectable()
export class LicaApi {
  private readonly apiController: string = 'lica';

  constructor(private api: HttpService) {}

  //#region lica
  getLice(id: number): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);

    return this.api.get(`${this.apiController}/getlice`, { params });
  }
  
  getDogovorPersons(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getdogovorpersons`, filter);
  }

  getPersons(filter: any): Observable<any[]> {
    const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`);    

    return this.api.post(`${this.apiController}/getpersons`, filter, { params });
  }

  setLice(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setlice`, item);
  }  

  setChlen(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setchlen`, item);
  }  

  getLiceDogovor(id: number): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);
    return this.api.get(`${this.apiController}/getlicedogovor`, { params });
  }

  setLiceDogovor(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setlicedogovor`, item);
  }

  setLiceDogovorStatus (iddog:number, status: number): Observable<number> {
    const params = new HttpParams()
        .set('iddog', `${iddog}`)
        .set('status', `${status}`)
    return this.api.get(`${this.apiController}/setlicedogovorstatus`, { params });
  }

  changeLiceTitulqr (idlice: number, statuslice: number): Observable<number> {
    const params = new HttpParams()
        .set('idlice', `${idlice}`)
        .set('statuslice', `${statuslice}`)
    return this.api.get(`${this.apiController}/changelicetitulqr`, { params });  
  }

  addTitular (idlice: number, statuslice: number, item: any): Observable<number> {
    const params = new HttpParams()
        .set('oldidlice', `${idlice}`)
        .set('oldstatus', `${statuslice}`)

        return this.api.post(`${this.apiController}/addtitulqr`, item, { params });
  }

  getLiceDogovorStatus(id: number):  Observable<number>{
    const params = new HttpParams()
        .set('id', `${id}`)

    return this.api.get(`${this.apiController}/getlicedogovorstatus`, { params });
  }    

  setLiceDogovorExpired (iddog:number): Observable<number>{
    const params = new HttpParams()
        .set('iddog', `${iddog}`)

    return this.api.get(`${this.apiController}/setlicedogovorexpired`, { params });
  }

  ////#endregion

  //#region formulqr
  getListFormulqrs(vid: number,filter: any): Observable<any[]> {
    const params = new HttpParams()
        .set('pVid', `${vid}`)

    return this.api.post(`${this.apiController}/getlistformulqrs`, filter, { params } );
  }

  getFormulqr(id: number): Observable<any> {
    const params = new HttpParams().set('id', `${id}`);
    return this.api.get(`${this.apiController}/getformulqr`, { params });
  }

  addFormulqr(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addformulqr`, item);
  }

  setFormulqr(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setformulqr`, item);
  }

  getHistoryFormulqr(id: number): Observable<any[]> {
    const params = new HttpParams().set('id', `${id}`);
    return this.api.get(`${this.apiController}/gethistoryformulqr`, { params });
  }

  setFormulqrStatus(idformulqr: number, status: number): Observable<number> {
    const params = new HttpParams()
        .set('idformulqr', `${idformulqr}`)
        .set('status', `${status}`)
    return this.api.get(`${this.apiController}/setformulqrstatus`, { params });
  }

  checkFormulqrUnomer(unomer: string): Observable<number> {
    const params = new HttpParams()
        .set('unomer', `${unomer}`)
        .set('faza', `${HeaderComponent.faza}`);  
    return this.api.get(`${this.apiController}/checkformulqrunomer`, { params });
  }

  checkFormulqrAdres(adres: any): Observable<any> {
    return this.api.post(`${this.apiController}/checkformulqradres`,adres);
  }
  

  //#endregion

  //#region firma
  getFirma(id: number): Observable<any> {
    const params = new HttpParams().set('id', `${id}`);
    return this.api.get(`${this.apiController}/getfirma`, { params });
  }

  getFirms(filter: any): Observable<any[]> {
    const params = new HttpParams()
              .set('pFaza', `${HeaderComponent.faza}`);    

    return this.api.post(`${this.apiController}/getfirms`, filter, { params });
  }

  setFirma(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setfirma`, item);
  }  
  //#endregion  

  genDogovorFile(id: number): Observable<any> {
    const params = new HttpParams()
              .set('id', `${id}`);    
              
    return this.api.get(`${this.apiController}/gendogovorfile`
                      , { params: params, responseType: 'blob' as 'json'});
  }  

  getDogovorAddPages(): Observable<any> {
    return this.api.get(`${this.apiController}/getdogovoraddpages`
                      , {responseType: 'blob' as 'json'});
  }

  updOposDogovorNomer(nomer: string, data: string, otnosno: string):  Observable<any>{
    const params = new HttpParams()
      .set('nomer', `${nomer}`)
      .set('data', `${data}`)    
      .set('otnosno', `${otnosno}`);    
    
    return this.api.get(`${this.apiController}/updoposdogovornomer`, { params });
  }

  getRadiatoriZaPrekodirane(filter: any): Observable<any[]> {
    return this.api.post(`${this.apiController}/getradiatorizaprekodirane`, filter);
  }

  doPrekodiraneRadiatori(iddogovorlice: number): Observable<any>{
    const params = new HttpParams()
      .set('iddog', `${iddogovorlice}`);
    
    return this.api.get(`${this.apiController}/doprekodiraneradiatori`, { params });
  }

  getAddress(id: number): Observable<any>{
    const params = new HttpParams()
      .set('id', `${id}`);
    
    return this.api.get(`${this.apiController}/getaddress`, { params });
  }
  
  setAddress(item: any): Observable<number>{
    return this.api.post(`${this.apiController}/setaddress`, item);
  }


}
