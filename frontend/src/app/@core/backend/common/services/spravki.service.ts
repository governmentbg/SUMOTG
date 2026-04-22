import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FilterA } from '../../../../pages/application/components/filter-a/filter-a.settings';
import { Filter } from '../../../../pages/application/components/filter/filter.settings';
import { Filter1, Spravka, Spravka1, Spravka11, Spravka13, Spravka14, Spravka15, Spravka2, Spravka20, Spravka21, Spravka24, Spravka25, Spravka3, Spravka4, Spravka5, Spravka50, Spravka52, Spravka53, Spravka54, Spravka55, Spravka6, Spravka60, Spravka7, Spravka70, Spravka78, Spravka8, SpravkaOposPortret, SpravkiData } from '../../../interfaces/common/spravki';
import { SpravkiApi } from '../api/spravki.api';

@Injectable()
export class SpravkiService extends SpravkiData {

  constructor(private api: SpravkiApi) {
    super();
  }


  getSpravki(): Observable<Spravka[]> {
    return this.api.getSpravki();
  }

  getSpravka1(filter: Filter1): Observable<Spravka1[]> {
    return this.api.getSpravka1(filter);
  }
  getSpravka2(filter: Filter): Observable<Spravka2[]> {
    return this.api.getSpravka2(filter);
  }
  getSpravka3(filter: Filter): Observable<Spravka2[]> {
    return this.api.getSpravka3(filter);
  }

  getSpravka4(filter: Filter): Observable<Spravka4[]> {
    return this.api.getSpravka4(filter);
  }

  getSpravka5(filter: Filter): Observable<Spravka5[]>{
    return this.api.getSpravka5(filter);
  }
  getSpravka6(filter: Filter): Observable<Spravka6[]>{
    return this.api.getSpravka6(filter);
  }
  getSpravka7(filter: Filter): Observable<Spravka7[]>{
    return this.api.getSpravka7(filter);
  }
  getSpravka8(filter: Filter): Observable<Spravka8[]>{
    return this.api.getSpravka8(filter);
  }
  getSpravka9(filter: Filter): Observable<Spravka5[]>{
    return this.api.getSpravka9(filter);
  }
  getSpravka10(filter: Filter): Observable<Spravka6[]>{
    return this.api.getSpravka10(filter);
  }
  getSpravka20(filter: Filter): Observable<Spravka20[]>{
    return this.api.getSpravka20(filter);
  }
  getSpravka11(filter: FilterA): Observable<Spravka11[]>{
    return this.api.getSpravka11(filter);
  }

  getSpravka12(filter: FilterA): Observable<Spravka11[]>{
    return this.api.getSpravka12(filter);
  }
  getSpravka13(filter: Filter): Observable<Spravka13[]>{
    return this.api.getSpravka13(filter);
  }
  getSpravka14(filter: Filter): Observable<Spravka14[]>{
    return this.api.getSpravka14(filter);
  }  
  getSpravka15(filter: Filter): Observable<Spravka15[]>{
    return this.api.getSpravka15(filter);
  }  
  getSpravka21(filter: Filter): Observable<Spravka21[]>{
    return this.api.getSpravka21(filter);
  }
  getSpravka23(filter: Filter): Observable<Spravka5[]>{
    return this.api.getSpravka23(filter);
  }
  getSpravka24(): Observable<Spravka24[]>{
    return this.api.getSpravka24();
  }
  getSpravka25(filter: Filter): Observable<Spravka25[]>{
    return this.api.getSpravka25(filter);
  }
  getOposPortret(filter: Filter): Observable<SpravkaOposPortret[]> {
    return this.api.getOposPortret(filter);
  }
  getSpravka50(filter: Filter): Observable<Spravka50[]>{
    return this.api.getSpravka50(filter);
  }
  getSpravka51(filter: Filter): Observable<Spravka50[]>{
    return this.api.getSpravka51(filter);
  }
  getSpravka52(): Observable<Spravka52[]> {
    return this.api.getSpravka52();
  }
  getSpravka53(): Observable<Spravka53[]>{
    return this.api.getSpravka53();
  }
  getSpravka54(): Observable<Spravka54[]>{
    return this.api.getSpravka54();
  }
  getSpravka55(tip: number): Observable<Spravka55[]>{
    return this.api.getSpravka55(tip);
  }

  getSpravka56(): Observable<Spravka55[]>{
    return this.api.getSpravka56();
  }

  getSpravka60(filter: FilterA): Observable<Spravka60[]>{
    return this.api.getSpravka60(filter);

  }
  getSpravka61(filter: FilterA): Observable<Spravka60[]>{
    return this.api.getSpravka61(filter);
  }

  getSpravka70(tip: number, filter: FilterA): Observable<Spravka70[]>{
    return this.api.getSpravka70(tip, filter);
  }

  getSpravka72(tip: number, filter: FilterA): Observable<Spravka78[]>{
    return this.api.getSpravka72(tip, filter);
  }

  getSpravka78(filter: FilterA): Observable<Spravka78[]>{
    return this.api.getSpravka78(filter);
  }
  getSpravka79(filter: FilterA): Observable<Spravka70[]>{
    return this.api.getSpravka79(filter);
  }
  setPorychkaStatus(idporychka: number, status: number): Observable<number>{
    return this.api.setPorychkaStatus(idporychka, status);
  }

  setPorychkaUnSign(idporychka: number): Observable<number>{
    return this.api.setPorychkaUnSign(idporychka);
  }
}

