import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { NbRoleProvider } from "@nebular/security";
import { ROLES } from "./roles";
import { CustomToastrService } from "../@core/backend/common/custom-toastr.service";

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(
    private roleProvider: NbRoleProvider,
    private toasrt: CustomToastrService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.roleProvider.getRole().pipe(
      map((role) => {

        const roles = role instanceof Array ? role : [role];
        let result = roles.some((x) => x && x.toLowerCase() === ROLES.ADMIN);

        if (result === false) {
          this.toasrt.showToast("danger", "Нямате права за тази страница!");
        }
        return result;
      })
    );
  }
}
