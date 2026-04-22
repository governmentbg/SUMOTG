import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';
import { HeaderComponent } from '../../../../@theme/components/header/header.component';

@Injectable()
export class NomenclaturesApi {
  private readonly apiController: string = 'nomenclatures';

  constructor(private api: HttpService) {}

  getNomenclatures(): Observable<any> {
    const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`);

    return this.api.get(`${this.apiController}/getnomenclatures`, { params });
  }

 //#region n_obshti
 getAllNomenObshti(kod: string): Observable<any[]> {
    const params = new HttpParams()
        .set('pKod', `${kod}`)
        .set('pFaza', `${HeaderComponent.faza}`)
        .set('includeDeleted', `true`);
    return this.api.get(`${this.apiController}/getnomobshti`, { params });
  }

  getNomenObshti(kod: string): Observable<any[]> {
    const params = new HttpParams()
        .set('pKod', `${kod}`)
        .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomobshti`, { params });
  }

  getRowNomenObshti(id: number): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);
    return this.api.get(`${this.apiController}/getrownomobshti`, { params });
  }

  setRowNomenObshti(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomobshti`, item);
  }

  addRowNomenObshti(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomobshti`,item);
  }

  delRowNomenObshti(id: number): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);

    return this.api.get(`${this.apiController}/delrownomobshti`, { params });
  }  
//#endregion

//#region n_nomjk
  getNomenJk(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomjk`, { params });
  }
  getRowNomenJk(id: string): Observable<any> {
    const params = new HttpParams()
        .set('pKod', `${id}`);
        return this.api.get(`${this.apiController}/getrownomjk`, { params });
  }
  getAllNomenJk(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`)
      .set('includeDeleted', `true`);
      return this.api.get(`${this.apiController}/getnomjk`, { params });
  }
  setRowNomenJk(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomjk`, item);
  }
  addRowNomenJk(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomjk`, item);
  }
  delRowNomenJk(id: string): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomjk`, { params });
  }
  getMaxKodJk (): Observable<string> {
    return this.api.get(`${this.apiController}/getmaxkodjk`);
  }

//#endregion

//#region n_kmetstva
  getNomenKmetstva(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);    
    return this.api.get(`${this.apiController}/getnomkmetstva`, {params});
  }
  getRowNomenKmetstva(id: string): Observable<any> {
    const params = new HttpParams()
        .set('pKod', `${id}`);
    return this.api.get(`${this.apiController}/getrownomkmetstva`, { params });
  }
  getAllNomenKmetstva(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`)
      .set('includeDeleted', `true`);
      return this.api.get(`${this.apiController}/getnomkmetstva`, { params });
  }
  setRowNomenKmetstva(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomkmetstva`, item);
  }
  addRowNomenKmetstva(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomkmetstva`, item);
  }
  delRowNomenKmetstva(id: string): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomkmetstva`, { params });
}

//#endregion


//#region n_ulici
  getNomenUlici(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomulici`, {params});
  }
  getRowNomenUlici(id: string): Observable<any> {
    const params = new HttpParams()
      .set('pKod', `${id}`);
    return this.api.get(`${this.apiController}/getrownomulici`, { params });
  }
  getAllNomenUlici(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`)
      .set('includeDeleted', `true`);
      return this.api.get(`${this.apiController}/getnomulici`, { params });
  }
  setRowNomenUlici(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomulici`, item);
  }
  addRowNomenUlici(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomulici`, item);
  }
  delRowNomenUlici(id: string): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomulici`, { params });
  }
  getUliciPerNsMqsto(nkod: string):Observable<any[]>{
    const params = new HttpParams()
      .set('nkod', `${nkod}`);
    return this.api.get(`${this.apiController}/getulicipernsmqsto`, { params });
  }
  getMaxKodUlici (): Observable<any> {
    return this.api.get(`${this.apiController}/getmaxkodulici`);
  }
  //#endregion n_ulici

//#region n_nsmesta
  getNomenNsMesta(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomnsmesta`, {params});
  }
  getRowNomenNsMesta(id: string): Observable<any> {
    const params = new HttpParams()
      .set('pKod', `${id}`);
    return this.api.get(`${this.apiController}/getrownomnsmesta`, { params });
  }
  getAllNomenNsMesta(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`)
      .set('includeDeleted', `true`);
    return this.api.get(`${this.apiController}/getnomnsmesta`, { params });
  }
  setRowNomenNsMesta(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomnsmesta`, item);
  }
  addRowNomenNsMesta(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomnsmesta`, item);
  }
  delRowNomenNsMesta(id: string): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomnsmesta`, { params });
  }

  getNomenNsMestaByRaion(idraion: string): Observable<any[]> {
    const params = new HttpParams()
        .set('pRaion', `${idraion}`);
    return this.api.get(`${this.apiController}/getnomnsmestabyraion`, {params});
  }  
//#endregion

 //#region n_raoini
  getNomenRaioni(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomraioni`, {params});
  }
  getRowNomenRaioni(id: string): Observable<any> {
    const params = new HttpParams()
      .set('pKod', `${id}`);
    return this.api.get(`${this.apiController}/getrownomraioni`, { params });
  }
  getAllNomenRaioni(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`)
      .set('includeDeleted', `true`);
    return this.api.get(`${this.apiController}/getnomraioni`, { params });
  }
  setRowNomenRaioni(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomraioni`, item);
  }
  addRowNomenRaioni(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomraioni`, item);
  }
  delRowNomenRaioni(id: string): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomraioni`, { params });
  }    
  //#endregion

  //#region n_uredi
   getNomenUredi(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomuredi`, {params});
  }
  getRowNomenUredi(id: number): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/getrownomuredi`, { params });
  }
  getAllNomenUredi(includeDeleted: boolean): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', '0')
      .set('includeDeleted', `${includeDeleted}`);
    return this.api.get(`${this.apiController}/getnomuredi`, { params });
  }
  setRowNomenUredi(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setrownomuredi`, item);
  }
  addRowNomenUredi(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/addrownomuredi`, item);
  }
  delRowNomenUredi(id: number): Observable<any> {
    const params = new HttpParams()
      .set('id', `${id}`);
    return this.api.get(`${this.apiController}/delrownomuredi`, { params });
  }

  getNomenKolektivUredi(): Observable<any[]> {
    const params = new HttpParams()
      .set('pFaza', `${HeaderComponent.faza}`);
    return this.api.get(`${this.apiController}/getnomkolektivuredi`, {params});
  }  
  //#endregion

//#region statusi
  getNomenStatusi(type: string): Observable<any[]>{
    const params = new HttpParams()
      .set('type', `${type}`);
    return this.api.get(`${this.apiController}/getnomstatusi`, { params });

  }
//#endregion  

//#region nkid
  getNomenKID(): Observable<any[]> {
    return this.api.get(`${this.apiController}/getnomkid`);
  }
//#endregion

//#region extra adresi
getAllExtraAddresses():  Observable<any[]> {
  return this.api.get(`${this.apiController}/getallextraaddresses`);
}

delExtraAddress(id: number): Observable<number>{
  const params = new HttpParams()
      .set('id', `${id}`);

  return this.api.get(`${this.apiController}/delextraaddress`, { params });
}

getRowExtraAddress(id: number): Observable<any>{
  const params = new HttpParams()
      .set('id', `${id}`);

  return this.api.get(`${this.apiController}/getrowextraaddress`, { params });
}

addRowExtraAddress(item: any): Observable<number> {
  return this.api.post(`${this.apiController}/addrowextraaddress`, item);
}
setRowExtraAddress(item: any): Observable<number>{
  return this.api.post(`${this.apiController}/setrowextraaddress`, item);
}
//#region extra adresi

//#region n_uredi_budget
getAllNomenUrediBudget(includeDeleted: boolean): Observable<any[]>{
  const params = new HttpParams()
        .set('pFaza', `${HeaderComponent.faza}`)
        .set('includeDeleted', `true`);
    return this.api.get(`${this.apiController}/getallnomenuredibudget`, { params });}

getRowNomenBudgetUredi(id: number): Observable<any>{
  const params = new HttpParams()
      .set('id', `${id}`);

    return this.api.get(`${this.apiController}/getrownomenbudgeturedi`, { params });
}

setRowNomenBudgetUredi(item: any): Observable<number>{
  return this.api.post(`${this.apiController}/setrownomenbudgeturedi`, item);
}
//#endregion

}
