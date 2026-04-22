import { HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CollectInfo, PublicData } from '../../../interfaces/common/public';
import { PublicApi } from '../api/public.api';

@Injectable()
export class PublicService extends PublicData {

  constructor(private api: PublicApi) {
    super();
  }

  setCollectInfo(item: CollectInfo): Observable<number>{
    return this.api.setCollectInfo(item);
  }
}