import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HeaderComponent } from "../../../../@theme/components";
import { HttpService } from "./http.service";
import { FileToUpload } from "../../../interfaces/common/obrabotki";

@Injectable()
export class ObrabotkiApi {
  private readonly apiController: string = 'obrabotki';

  constructor(private api: HttpService) {}

  //#region montaz
  getMonListOrders(): Observable<any[]>{
    const params = new HttpParams()
        .set('faza', `${HeaderComponent.faza}`)

    return this.api.get(`${this.apiController}/getmonlistorders`, { params });
  };

  getMonOrder(id: number): Observable<any>{
    const params = new HttpParams()
        .set('id', `${id}`)

    return this.api.get(`${this.apiController}/getmonorder`, { params });
  };

  getDogovorFirmaUredi(iddogovorfirma: number): Observable<any[]>{
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)

    return this.api.get(`${this.apiController}/getdogovorfirmauredi`, { params });
  };  

  getDogovorFirmaRaioni(iddogovorfirma: number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)

    return this.api.get(`${this.apiController}/getdogovorfirmaraioni`, { params });
  }

  getPersonsWihtDogUredi(iddogovorfirma: number, raion: string, faza: number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)
        .set('raion', `${raion}`)
        .set('faza', `${faza}`)

    return this.api.get(`${this.apiController}/getpersonswithdoguredi`, { params });
  };

  
  getPersonUredi(iddogovorfirma: number, idlice:number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)
        .set('idlice', `${idlice}`)

        return this.api.get(`${this.apiController}/getpersonuredi`, { params });
  };

  setMonOrder(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setmonorder`, item);
  };

  setMonUrediDogovor (items: any[]): Observable<number>{
    return this.api.post(`${this.apiController}/setmonuredidogovor`, items);
  };

  delMonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>{
    const params = new HttpParams()
        .set('idporychkamain', `${idporychka}`)
        .set('idlicedogovor', `${idlicedogovor}`)

        return this.api.get(`${this.apiController}/delmonuredidogovor`, { params });
  }

  delMonOrder (idporychka: number): Observable<number>{
    const params = new HttpParams()
        .set('idporychkamain', `${idporychka}`)

    return this.api.get(`${this.apiController}/delmonorder`, { params });
  }

  getMonOrdersWithoutDemPorychka(): Observable<any[]> {
    return this.api.get(`${this.apiController}/getmonorderswithoutdemporychka`);
  }

  canDeleteMonOrder(id: number): Observable<number> {
    const params = new HttpParams()
        .set('idporychkamain', `${id}`)

    return this.api.get(`${this.apiController}/candeletemonorder`, { params });
  }

  //#endregion

 //#region demontaz
  getDemonListOrders(): Observable<any[]>{
    const params = new HttpParams()
        .set('faza', `${HeaderComponent.faza}`)

    return this.api.get(`${this.apiController}/getdemonlistorders`, { params });
  };

  getDemonOrder(id: number): Observable<any>{
    const params = new HttpParams()
        .set('id', `${id}`)

    return this.api.get(`${this.apiController}/getdemonorder`, { params });
  };

  getDemonDogovorFirmaUredi(iddogovorfirma: number): Observable<any[]>{
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)

    return this.api.get(`${this.apiController}/getdemondogovorfirmauredi`, { params });
  };  

  getDemonDogovorFirmaRaioni(iddogovorfirma: number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)

    return this.api.get(`${this.apiController}/getdemondogovorfirmaraioni`, { params });
  }

  getDemonPersonsWihtDogUredi(iddogovorfirma: number, raion: string, faza: number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)
        .set('raion', `${raion}`)
        .set('faza', `${faza}`)

    return this.api.get(`${this.apiController}/getdemonpersonswithdoguredi`, { params });
  };


  getDemonPersonUredi(iddogovorfirma: number, idlice:number): Observable<any[]> {
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)
        .set('idlice', `${idlice}`)

        return this.api.get(`${this.apiController}/getdemonpersonuredi`, { params });
  };

  setDemonOrder(item: any): Observable<any> {
    return this.api.post(`${this.apiController}/setdemonorder`, item);
  };

  setDemonUrediDogovor (items: any[]): Observable<number>{
    return this.api.post(`${this.apiController}/setdemonuredidogovor`, items);
  };

  delDemonUrediDogovor(idporychka: number, idlicedogovor: number): Observable<number>{
    const params = new HttpParams()
        .set('idporychkamain', `${idporychka}`)
        .set('idlicedogovor', `${idlicedogovor}`)

        return this.api.get(`${this.apiController}/deldemonuredidogovor`, { params });
  }

  delDemonOrder (idporychka: number): Observable<number>{
    const params = new HttpParams()
        .set('idporychkamain', `${idporychka}`)

    return this.api.get(`${this.apiController}/deldemonorder`, { params });
  }

  getDemonUrediFromMonPorychka(iddogovorfirma: number, idmonporychka: number): Observable<any[]>{
    const params = new HttpParams()
        .set('iddogovorfirma', `${iddogovorfirma}`)
        .set('idmonporychka', `${idmonporychka}`)

        return this.api.get(`${this.apiController}/getdemonuredifrommonporychka`, { params });
  }

  setDemonOtchetUredi (opos: string, dogovor: string, data: string): Observable<number> { 
      const params = new HttpParams()
        .set('opos', `${opos}`)    
        .set('dogovor', `${dogovor}`)    
        .set('data', `${data}`);    
  
    return this.api.get(`${this.apiController}/setdemonotcheturedi`, { params }); 
  }
 //#endregion

  //#region fakturi
  getMonListFakturi(vid: number): Observable<any[]> {
    const params = new HttpParams()
        .set('vid', `${vid}`)

    return this.api.get(`${this.apiController}/getmonlistfakturi`, { params });
  };

  getFaktura(idfaktura: number): Observable<any> {
    const params = new HttpParams()
        .set('idfaktura', `${idfaktura}`)

    return this.api.get(`${this.apiController}/getfaktura`, { params });
  }

  setFaktura(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setfaktura`, item);  
  }

  delFaktura(idfaktura: number): Observable<any> {
    const params = new HttpParams()
        .set('idfaktura', `${idfaktura}`)

    return this.api.get(`${this.apiController}/delfaktura`, { params });
  }

  getDocuments(id: number, typedoc: number): Observable<any[]>{
    const params = new HttpParams()
        .set('id', `${id}`)
        .set('typedoc', `${typedoc}`);

    return this.api.get(`${this.apiController}/getdocuments`, {params});
  }

  uploadFile(file: FileToUpload): Observable<any[]> {
    return this.api.post(`${this.apiController}/addfile`, file);
  }

  removeFile(id: number): Observable<number> {
    const params = new HttpParams()
        .set('id', `${id}`);

    return this.api.get(`${this.apiController}/delfile`, {params});
  }

  downloadFile(id: number): Observable<any> {
    const params = new HttpParams()
        .set('id', `${id}`);

    return this.api.get(`${this.apiController}/getfile`
                  , { params: params, responseType: 'blob' as 'json'});
  }  
  //#endregion
  
//#region profilaktika
  getProfOrder(filter: any): Observable<any[]>{
    return this.api.post(`${this.apiController}/getproforder`, filter);
  }

  setMonProfilaktika(id: number, otchdata: string, note: string, status_pf: number, idprofilaktika: number): Observable<number>{
    const params = new HttpParams()
        .set('id', `${id}`)
        .set('otchdata', `${otchdata}`)
        .set('note', `${note}`)
        .set('status_pf', `${status_pf}`)
        .set('idprofilaktika', `${idprofilaktika}`);

    return this.api.get(`${this.apiController}/setmonprofilaktika`, {params});
  }

getProfOrderById(idprofilaktika: number): Observable<any[]>{
  const params = new HttpParams()
      .set('idprofilaktika', `${idprofilaktika}`);

  return this.api.get(`${this.apiController}/getproforderbyid`, {params});
}

getProfilaktikaNextId(): Observable<number>{
  return this.api.get(`${this.apiController}/getprofilaktikanextid`);
}

//#endregion

}