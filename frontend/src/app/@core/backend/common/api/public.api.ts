import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';

@Injectable()
export class PublicApi {
  private readonly apiController: string = 'public';

  constructor(private api: HttpService) {}

  setCollectInfo(item: any): Observable<number> {
    return this.api.post(`${this.apiController}/setcollectinfo`, item);
  }

}