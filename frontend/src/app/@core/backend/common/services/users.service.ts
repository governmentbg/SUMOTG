import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsersApi } from '../api/users.api';
import { UserData, User, Obhvat, Role, DashboardTbl } from '../../../interfaces/common/users';
import { DataSource } from 'ng2-smart-table/lib/lib/data-source/data-source';
import { map } from 'rxjs/operators';
import { NbAuthResult } from '@nebular/auth';
import { HttpResponse } from '@angular/common/http';

@Injectable()
export class UsersService extends UserData {

  constructor(private api: UsersApi) {
    super();
  }

  get gridDataSource(): DataSource {
    return this.api.usersDataSource;
  }

  list(pageNumber: number = 1, pageSize: number = 10): Observable<User[]> {
    return this.api.list(pageNumber, pageSize);
  }

  getUsers(): Observable<User[]> {
    return this.api.getUsers();
  }

  getCurrentUser(): Observable<User> {
    return this.api.getCurrent()
      .pipe(
        map(u => {
          if (u && !u.setting) {
            u.setting = {};
          }
        return u;
      }));
  }

  get(id: number): Observable<User> {
    return this.api.get(id);
  }

  create(user: any): Observable<User> {
    return this.api.add(user);
  }

  update(user: any): Observable<User> {
    return this.api.update(user);
  }

  updateCurrent(user: any): Observable<User> {
    return this.api.updateCurrent(user);
  }

  delete(id: number): Observable<boolean> {
    return this.api.delete(id);
  }

  getRoles(): Observable<Role[]> {
    return this.api.getRoles();
  }
  getObhvats(): Observable<Obhvat[]> {
    return this.api.getObhvats();
  }

  changePassword(id: number, user: User): Observable<boolean> {
    return this.api.changePassword(id, user);
  }

  getDashboard(faza: number): Observable<DashboardTbl[]>{
    return this.api.getDashboard(faza);
  }

  downloadFile(filename: string): Observable<HttpResponse<Blob>>{
    return this.api.downloadFile(filename);
  }
}
