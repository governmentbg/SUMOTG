import { Observable } from 'rxjs';
import { DataSource } from 'ng2-smart-table/lib/lib/data-source/data-source';
import { Settings } from './settings';
import { HttpResponse } from '@angular/common/http';

export interface User {
  id: number;
  telefon: string;
  email: string;
  name?: string;
  login: string;
  picture: string;
  address: Address;
  settings: Settings;
  roleid: number;
  scopeid: number;
  raionid: string;
  status: number;
  password: string;
}

export interface Address {
  street: string;
  city: string;
  zipCode: string;
}


export interface Role {
  id: number;
  name: string;
}

export interface Obhvat {
  id: number;
  name: string;
}

export interface DashboardTbl {
  nkod: string;
  raion: string;
  formulqri: number;
  dogovori: number;
  uredi: number;
}
export abstract class UserData {
  abstract get gridDataSource(): DataSource;
  abstract getCurrentUser(): Observable<User>;
  abstract list(pageNumber: number, pageSize: number): Observable<User[]>;
  abstract get(id: number): Observable<User>;
  abstract update(user: User): Observable<User>;
  abstract updateCurrent(user: User): Observable<User>;
  abstract create(user: User): Observable<User>;
  abstract delete(id: number): Observable<boolean>;
  abstract getUsers(): Observable<User[]>;
  abstract getRoles(): Observable<Role[]>;
  abstract getObhvats(): Observable<Obhvat[]>;
  abstract changePassword(id:number, user:User): Observable<boolean>;
  abstract getDashboard(faza: number): Observable<DashboardTbl[]>;
  abstract downloadFile(filename: string): Observable<HttpResponse<Blob>>;
}