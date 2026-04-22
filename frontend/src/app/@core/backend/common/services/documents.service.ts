import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentsData, FileToUpload,Dokument } from '../../../interfaces/common/documents';
import { DocumentApi } from '../api/document.api';

@Injectable()
export class DocumentService extends DocumentsData  {

  constructor(private api: DocumentApi) {
    super();
  }

  getDocuments(id: number, typedoc: number): Observable<Dokument[]>{
    return this.api.getDocuments(id, typedoc);
  }

  uploadFile(file: FileToUpload): Observable<any[]> {
    return this.api.uploadFile(file);
  }

  removeFile(id: number): Observable<number> {
    return this.api.removeFile(id);
  }

  downloadFile(id: number): Observable<HttpResponse<Blob>> {
    return this.api.downloadFile(id);
  }

  putFile(file: FileToUpload): Observable<any[]> {
    return this.api.putFile(file);
  }
  
}
