import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  ExtraAddresses,
  Nomenclature,
  NomenclatureData,
  NomJk,
  NomKid,
  NomKmetstvo,
  NomKvartal,
  NomNsMqsto,
  NomObshti,
  NomRaion,
  NomStatus,
  NomUlica,
  NomUred,
  NomUredBudget,
} from '../../../interfaces/common/nomenclatures';
import { NomenclaturesApi } from '../api/nomenlatures.api';

@Injectable()
export class NomenclaturesService extends NomenclatureData {

  constructor(private api: NomenclaturesApi) {
    super();
  }


  getNomenclatures(): Observable<Nomenclature[]> {
    return this.api.getNomenclatures();
  }

//#region n_obshti
  getAllNomenObshti(kod: string): Observable<NomObshti[]> {
    return this.api.getAllNomenObshti(kod);
  }

  getNomenObshti(kod: string): Observable<NomObshti[]> {
    return this.api.getNomenObshti(kod);
  }
  getRowNomenObshti(id: number): Observable<NomObshti> {
    return this.api.getRowNomenObshti(id);
  }
  setRowNomenObshti(item: NomObshti): Observable<boolean> {
    return this.api.setRowNomenObshti(item);
  }
  addRowNomenObshti(item: NomObshti): Observable<number> {
    return this.api.addRowNomenObshti(item);
  }
  delRowNomenObshti(id: number): Observable<boolean> {
    return this.api.delRowNomenObshti(id);
  }
//#endregion

//#region n_nomjk
  getNomenJk(): Observable<NomJk[]> {
    return this.api.getNomenJk();
  }
  getRowNomenJk(id: string): Observable<NomJk> {
    return this.api.getRowNomenJk(id);
  }
  getAllNomenJk(): Observable<NomJk[]> {
    return this.api.getAllNomenJk();
  }
  setRowNomenJk(item: NomJk): Observable<boolean> {
    return this.api.setRowNomenJk(item);
  }
  addRowNomenJk(item: NomJk): Observable<number> {
    return this.api.addRowNomenJk(item);
  }
  delRowNomenJk(id: string): Observable<boolean> {
    return this.api.delRowNomenJk(id);
  }
  getMaxKodJk (): Observable<string> {
    return this.api.getMaxKodJk();
  }

//#endregion

//#region n_kmetstva
  getNomenKmetstva(): Observable<NomKmetstvo[]> {
    return this.api.getNomenKmetstva();
  }
  getRowNomenKmetstva(id: string): Observable<NomKmetstvo> {
    return this.api.getRowNomenKmetstva(id);
  }
  getAllNomenKmetstva(): Observable<NomKmetstvo[]> {
    return this.api.getAllNomenKmetstva();
  }
  setRowNomenKmetstva(item: NomKmetstvo): Observable<boolean> {
    return this.api.setRowNomenKmetstva(item);
  }
  addRowNomenKmetstva(item: NomKmetstvo): Observable<number> {
    return this.api.addRowNomenKmetstva(item);
  }
  delRowNomenKmetstva(id: string): Observable<boolean> {
    return this.api.delRowNomenKmetstva(id);
  }


//#endregion

//#region n_ulici
  getNomenUlici(): Observable<NomUlica[]> {
    return this.api.getNomenUlici();
  }
  getRowNomenUlici(id: string): Observable<NomUlica> {
    return this.api.getRowNomenUlici(id);
  }
  getAllNomenUlici(): Observable<NomUlica[]> {
    return this.api.getAllNomenUlici();
  }
  setRowNomenUlici(item: NomUlica): Observable<boolean> {
    return this.api.setRowNomenUlici(item);
  }
  addRowNomenUlici(item: NomUlica): Observable<number> {
    return this.api.addRowNomenUlici(item);
  }
  delRowNomenUlici(id: string): Observable<boolean> {
    return this.api.delRowNomenUlici(id);
  }

  getUliciPerNsMqsto(nkod: string):Observable<NomUlica[]>{
    return this.api.getUliciPerNsMqsto(nkod);
  }
 
  getMaxKodUlici (): Observable<string> {
    return this.api.getMaxKodUlici();
  }

//#endregion

//#region n_nomnsmesta
  getNomenNsMesta(): Observable<NomNsMqsto[]> {
    return this.api.getNomenNsMesta();
  }
  getRowNomenNsMesta(id: string): Observable<NomNsMqsto> {
    return this.api.getRowNomenNsMesta(id);
  }
  getAllNomenNsMesta(): Observable<NomNsMqsto[]> {
    return this.api.getAllNomenNsMesta();
  }
  setRowNomenNsMesta(item: NomNsMqsto): Observable<boolean> {
    return this.api.setRowNomenNsMesta(item);
  }
  addRowNomenNsMesta(item: NomNsMqsto): Observable<number> {
    return this.api.addRowNomenNsMesta(item);
  }
  delRowNomenNsMesta(id: string): Observable<boolean> {
    return this.api.delRowNomenNsMesta(id);
  }
  getNomenNsMestaByRaion(idraion: string): Observable<NomNsMqsto[]> {
    return this.api.getNomenNsMestaByRaion(idraion);
  }

//#endregion

//#region n_raioni
  getNomenRaioni(): Observable<NomRaion[]> {
    return this.api.getNomenRaioni();
  }
  getRowNomenRaioni(id: string): Observable<NomRaion> {
    return this.api.getRowNomenRaioni(id);
  }
  getAllNomenRaioni(): Observable<NomRaion[]> {
    return this.api.getAllNomenRaioni();
  }
  setRowNomenRaioni(item: NomRaion): Observable<boolean> {
    return this.api.setRowNomenRaioni(item);
  }
  addRowNomenRaioni(item: NomRaion): Observable<number> {
    return this.api.addRowNomenRaioni(item);
  }
  delRowNomenRaioni(id: string): Observable<boolean> {
    return this.api.delRowNomenRaioni(id);
  }  
//#endregion

//#region n_uredi
  getNomenUredi(): Observable<NomUred[]> {
    return this.api.getNomenUredi();
  }
  getRowNomenUredi(id: number): Observable<NomUred> {
    return this.api.getRowNomenUredi(id);
  }
  getAllNomenUredi(includeDeleted: boolean): Observable<NomUred[]> {
    return this.api.getAllNomenUredi(includeDeleted);
  }
  setRowNomenUredi(item: NomUred): Observable<number> {
    return this.api.setRowNomenUredi(item);
  }
  addRowNomenUredi(item: NomUred): Observable<number> {
    return this.api.addRowNomenUredi(item);
  }
  delRowNomenUredi(id: number): Observable<boolean> {
    return this.api.delRowNomenUredi(id);
  }
  getNomenKolektivUredi(): Observable<NomUred[]> {
    return this.api.getNomenKolektivUredi();
  }
  
//#endregion

//#region statusi
  getNomenStatusi(type: string): Observable<NomStatus[]>{
    return this.api.getNomenStatusi(type);
  }
//#endregion

//#region nkid
  getNomenKID(): Observable<NomKid[]> {
    return this.api.getNomenKID();
  }
//#endregion

//#region extra adresi
getAllExtraAddresses():  Observable<ExtraAddresses[]> {
  return this.api.getAllExtraAddresses();
}

delExtraAddress(id: number): Observable<number>{
  return this.api.delExtraAddress(id);
}

getRowExtraAddress(id: number): Observable<ExtraAddresses>{
  return this.api.getRowExtraAddress(id);
}

addRowExtraAddress (item: ExtraAddresses): Observable<number> {
  return this.api.addRowExtraAddress(item);
}

setRowExtraAddress(item: ExtraAddresses): Observable<number>{
  return this.api.setRowExtraAddress(item);
}
//#region extra adresi


//#region n_uredi_budget
getAllNomenUrediBudget(includeDeleted: boolean): Observable<NomUredBudget[]>{
  return this.api.getAllNomenUrediBudget(includeDeleted);
}
getRowNomenBudgetUredi(id: number): Observable<NomUredBudget>{
  return this.api.getRowNomenBudgetUredi(id);
}
setRowNomenBudgetUredi(item: NomUredBudget): Observable<number>{
  return this.api.setRowNomenBudgetUredi(item);
}
//#endregion
}
