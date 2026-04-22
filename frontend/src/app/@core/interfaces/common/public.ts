import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CollectInfo {
    id: number;
    ime: string;
    prezime: string;
    familiq: string;
    raionid: string;
    nm: string;
    kv: string;
    jk: string;
    ul: string;
    nomer: string;
    blok: string;
    vh: string;
    etaj: string;
    ap: string;
    email: string;
    tel: string;
    v1:number;
    v101:number;
    v2:number;
    v201:number;
}


export abstract class PublicData {
    abstract setCollectInfo(item: CollectInfo): Observable<number>;
}