import { HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";

export class FileToUpload {
    idDog: number = 0;
    docType: number = 0;
    fileName: string = "";
    fileSize: number = 0;
    fileType: string = "";
    description: string = ''; 
    fileAsBase64: string = "";
    rawFile: BlobPart;
    type: string;
    status: number = 1;
}

export interface Dokument {
    id: number;
    iddog: number;
    description: string;
    filename: string
    status: string;
}

export abstract class DocumentsData {
    abstract getDocuments(id: number, typedoc: number): Observable<Dokument[]>;
    abstract uploadFile(file: FileToUpload): Observable<any[]>;
    abstract removeFile(id: number): Observable<number>;
    abstract downloadFile(id: number): Observable<HttpResponse<Blob>>;
    abstract putFile(file: FileToUpload): Observable<any[]>;
}