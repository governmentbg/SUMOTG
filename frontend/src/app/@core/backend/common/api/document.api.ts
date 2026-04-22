
import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FileToUpload } from '../../../interfaces/common/documents';
import { HttpService } from './http.service';

@Injectable()
export class DocumentApi {
  private readonly apiController: string = 'uploadfile';

  constructor(private api: HttpService) { }

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

  putFile(file: FileToUpload): Observable<any[]> {
    return this.api.post(`${this.apiController}/putfile`, file);
  }

}
