import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { NbToastrService } from '@nebular/theme';
import { UserData, User, Role, Obhvat } from '../../../@core/interfaces/common/users';
import { EMAIL_PATTERN } from '../../../@auth/components';
import {getDeepFromObject, NbAuthOAuth2JWTToken, NbTokenService, NB_AUTH_OPTIONS} from '@nebular/auth';
import {UserStore} from '../../../@core/stores/user.store';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { RoleProvider } from '../../../@auth/role.provider';
import { ROLES } from '../../../@auth/roles';

export enum UserFormMode {
  VIEW = 'Преглед',
  EDIT = 'Редактиране',
  ADD = 'Добавяне',
  EDIT_SELF = 'Профил',
}

@Component({
  selector: 'ngx-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit{
  userForm: FormGroup;

  minLoginLength: number = 4;
  maxLoginLength: number = 50;
  isLoginRequired: boolean = true;
  isEmailRequired: boolean = true;
  redirectDelay: number = this.getConfigValue('forms.register.redirectDelay');
  showMessages: any = this.getConfigValue('forms.register.showMessages');
  strategy: string = this.getConfigValue('forms.register.strategy');

  isAdmin: boolean = false;
  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};

  id: number = 0;
  isProfile: string = '';

  roles: Role[] = [];
  scopes: Obhvat[] = [];
  raioni: ViewNom[];

  get login() { return this.userForm.get('login'); }
  get telefon() { return this.userForm.get('telefon'); }
  get email() { return this.userForm.get('email'); }
  get roleid() { return this.userForm.get('roleid'); }
  get scopeid() { return this.userForm.get('scopeid'); }
  get raionid() { return this.userForm.get('raionid'); }

  mode: UserFormMode;
  setViewMode(viewMode: UserFormMode) {
    this.mode = viewMode;
  }

  constructor(
    private usersService: UserData,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    private router: Router,
    private route: ActivatedRoute,
    private tokenService: NbTokenService,
    private userStore: UserStore,
    private toasterService: NbToastrService,
    private fb: FormBuilder,
    private nomenclatureService: NomenclatureData,
    private roleProvider: RoleProvider

  ) {
    this.isProfile = this.route.snapshot.queryParamMap.get('profile');
  }

  ngOnInit(): void {
    this.checkIsAdmin();
    this.initUserForm();
    this.loadLists();

    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
      this.loadUserData();
    });
  }

  initUserForm() {
    const loginValidators = [
      Validators.minLength(this.minLoginLength),
      Validators.maxLength(this.maxLoginLength),
    ];
    this.isLoginRequired && loginValidators.push(Validators.required);

    const emailValidators = [
      Validators.pattern(EMAIL_PATTERN),
    ];
    this.isEmailRequired && emailValidators.push(Validators.required);

    this.userForm = this.fb.group({
      id: this.fb.control(''),
      login: this.fb.control('', [...loginValidators]),
      email: this.fb.control('', [...emailValidators]),
      roleid: this.fb.control({value:'0', disabled: this.isAdmin},Validators.required),
      scopeid: this.fb.control({value:'0', disabled: this.isAdmin},Validators.required),
      raionid: this.fb.control({value:'0', disabled: this.isAdmin},),
      status: this.fb.control({value:'1', disabled: this.isAdmin},), 
      password: this.fb.control(''),
      telefon: this.fb.control(''),
    });
  }

  loadLists () {
   this.usersService.getRoles()
        .subscribe((r) => {
          this.roles = r;
    });

    this.usersService.getObhvats()
        .subscribe((s) => {
          this.scopes = s;
    });

    this.nomenclatureService
        .getNomenRaioni()
        .subscribe(result => {
        this.raioni = result.map(item => new ViewNom().convertNomRaion(item));
    });

  }

  loadUserData() {
    if (this.isProfile) {
      this.setViewMode(UserFormMode.EDIT_SELF);
      this.loadUser();
    } else {
      if (this.id !== 0) {
        if (this.userStore.getUser()) {
          const currentUserId = this.userStore.getUser().id;

          this.setViewMode(currentUserId === this.id ? UserFormMode.EDIT_SELF : UserFormMode.EDIT);
          this.loadUser();
        } else {
          if (this.id > 0) {
            this.setViewMode(UserFormMode.EDIT);
            this.loadUser();
          } else {
            this.setViewMode(UserFormMode.ADD);
          }
        }
      } else {
        this.setViewMode(UserFormMode.ADD);
      }
    }
  }


  loadUser() {
    const loadUser = this.mode === UserFormMode.EDIT_SELF
      ? this.usersService.getCurrentUser() : this.usersService.get(this.id);

    loadUser
      .subscribe((user) => {
        this.user = user;
      
        this.userForm.setValue({
          id: user.id ? user.id : '',
          roleid: user.roleid ? String(user.roleid) : '0',
          scopeid: user.scopeid ? String(user.scopeid) : '0',
          raionid: user.raionid ? user.raionid : '0',
          password: user.password ? user.password : '',
          telefon: user.telefon ? user.telefon : '',
          login: user.login ? user.login : '',
          email: user.email,
          status: (this.isProfile ? 1: user.status)
        });

      });
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }

  get canEdit(): boolean {
    return this.mode !== UserFormMode.VIEW;
  }

  convertToUser(value: any): User {
    const user: User = value;
    user.status = (this.isProfile ? 1 : (user.status ? 1 : 0))
    return user;
  }

  save() {
    const user: User = this.convertToUser(this.userForm.value);
    let observable = new Observable<User>();
    
    if (this.mode === UserFormMode.EDIT_SELF) {
      this.usersService.updateCurrent(user).subscribe((result: any) => {
          this.tokenService.set(new NbAuthOAuth2JWTToken(result, 'email', new Date()));
          this.handleSuccessResponse();
        },
        err => {
          this.handleWrongResponse();
        });
    } else {
      observable = user.id
        ? this.usersService.update(user)
        : this.usersService.create(user);
    }

    observable
      .subscribe(() => {
          this.handleSuccessResponse();
      },
      err => {
        this.handleWrongResponse();
      });    
  }

  checkIsAdmin()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s);
      if (role.toLowerCase() === ROLES.ADMIN)
          this.isAdmin = false;
      else
          this.isAdmin = true;
    });
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Потребителят ${this.mode === UserFormMode.ADD ? 'е създаден успешно' : 'е записан успешно'}!`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Този имейл вече се използва!`);
  }

  back() {
    debugger
    if(this.isProfile)
      this.router.navigate(['pages']);
    else
      this.router.navigate(['pages/usersreg']);
  }

  resetPassword () {
    const url = 'pages/usersreg/changepassword/' + this.id;
    this.router.navigate([url]);
  }

}
