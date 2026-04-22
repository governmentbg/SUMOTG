import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpService } from './http.service';
import { map } from 'rxjs/operators';
import { DataSource } from 'ng2-smart-table/lib/lib/data-source/data-source';

@Injectable()
export class UsersApi {
  private readonly apiController: string = 'users';

  constructor(private api: HttpService) {}

  get usersDataSource(): DataSource {
    return this.api.getServerDataSource(`${this.api.apiUrl}/${this.apiController}`);
  }

  list(pageNumber: number = 1, pageSize: number = 10): Observable<any[]> {
    const params = new HttpParams()
      .set('pageNumber', `${pageNumber}`)
      .set('pageSize', `${pageSize}`);

    return this.api.get(this.apiController, { params })
      .pipe(map(data => data.map(item => {
        const picture = `${this.api.apiUrl}/${this.apiController}/${item.id}/photo`;
        return { ...item, picture };
      })));
  }

  getCurrent(): Observable<any> {
    return this.api.get(`${this.apiController}/current`)
      .pipe(map(data => {
        const picture = `${this.api.apiUrl}/${this.apiController}/${data.id}/photo`;
        return { ...data, picture };
      }));
  }

  get(id: number): Observable<any> {
    return this.api.get(`${this.apiController}/${id}`)
      .pipe(map(data => {
        const picture = `${this.api.apiUrl}/${this.apiController}/${data.id}/photo`;
        return { ...data, picture };
      }));
  }

  delete(id: number): Observable<boolean> {
    return this.api.delete(`${this.apiController}/deluser/${id}`);
  }

  add(item: any): Observable<any> {
    return this.api.post(this.apiController, item);
  }

  updateCurrent(item: any): Observable<any> {
    return this.api.put(`${this.apiController}/current`, item);
  }

  update(item: any): Observable<any> {
    return this.api.put(`${this.apiController}/update`, item);
  }

  getUsers(): Observable<any> {
    return this.api.get(`${this.apiController}/getusers`);
  }

  getRoles(): Observable<any[]> {
    return this.api.get(`${this.apiController}/getroles`);
  }

  getObhvats(): Observable<any[]> {
    return this.api.get(`${this.apiController}/getobhvats`);
  }

  changePassword(id: number, item: any): Observable<boolean> {
    const r = this.api.put(`${this.apiController}/changepass/${id}`, item);
    r.subscribe(r=> {
    })
    return r;
  }

  getDashboard(faza: number): Observable<any[]>{
    const params = new HttpParams()
      .set('faza', `${faza}`)
      
      return this.api.get(`${this.apiController}/getdashboard`, {params});
  }

  downloadFile(filename: string): Observable<HttpResponse<Blob>>{
    const params = new HttpParams()
      .set('filename', `${filename}`)

    return this.api.get(`${this.apiController}/downloadfile?file=${filename}`
                      ,{responseType: 'blob' as 'json'});

  }
}
