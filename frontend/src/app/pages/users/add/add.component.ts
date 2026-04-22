import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NB_AUTH_OPTIONS, NbAuthService, NbAuthResult, getDeepFromObject } from '@nebular/auth';
import { NbToastrService } from '@nebular/theme';
import { EMAIL_PATTERN } from '../../../@auth/components';
import { NomenclatureData, ViewNom } from '../../../@core/interfaces/common/nomenclatures';
import { Obhvat, Role, UserData } from '../../../@core/interfaces/common/users';
import { InitUserService } from '../../../@theme/services/init-user.service';

@Component({
  selector: 'ngx-adduser',
  styleUrls: ['./add.component.scss'],
  templateUrl: './add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddUserComponent implements OnInit{
  minLoginLength: number = 6;
  maxLoginLength: number = 50;
  minLength: number = 6;
  maxLength: number = 20;
  isLoginRequired: boolean = true;
  isEmailRequired: boolean = true;
  redirectDelay: number = this.getConfigValue('forms.register.redirectDelay');
  showMessages: any = this.getConfigValue('forms.register.showMessages');
  strategy: string = this.getConfigValue('forms.register.strategy');

  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};

  roles: Role[] = [];
  scopes: Obhvat[] = [];
  raioni: ViewNom[];

  registerForm: FormGroup;
  
  constructor(protected service: NbAuthService,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    private fb: FormBuilder,
    protected router: Router,
    protected initUserService: InitUserService,
    private usersService: UserData,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
  ) {
  }

  get login() { return this.registerForm.get('login'); }
  get email() { return this.registerForm.get('email'); }
  get telefon() { return this.registerForm.get('telefon'); }
  get password() { return this.registerForm.get('password'); }
  get confirmPassword() { return this.registerForm.get('confirmPassword'); }
  get roleid() { return this.registerForm.get('roleid'); }
  get scopeid() { return this.registerForm.get('scopeid'); }
  get raionid() { return this.registerForm.get('raionid'); }

  ngOnInit(): void {
    this.loadLists ();

    const loginValidators = [
      Validators.minLength(this.minLoginLength),
      Validators.maxLength(this.maxLoginLength),
    ];
    loginValidators.push(Validators.required);

    const emailValidators = [
      Validators.pattern(EMAIL_PATTERN),
    ];
    emailValidators.push(Validators.required);

    const passwordValidators = [
      Validators.minLength(this.minLength),
      Validators.maxLength(this.maxLength),
    ];
    passwordValidators.push(Validators.required);

    this.registerForm = this.fb.group({
      login: this.fb.control('', [...loginValidators]),
      email: this.fb.control('', [...emailValidators]),
      telefon: this.fb.control(''),
      password: this.fb.control('', [...passwordValidators]),
      confirmPassword: this.fb.control('', [...passwordValidators]),
      roleid: this.fb.control('0',Validators.required),
      scopeid: this.fb.control('0',Validators.required),
      raionid: this.fb.control('0'),
      status: this.fb.control('1'),
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
 
  register(): void {
    this.user = this.registerForm.value;
    this.errors = this.messages = [];
    this.submitted = true;

    this.usersService.create(this.user).subscribe((result: any) => {
        this.usersService
            .changePassword(result.id, this.user)
            .subscribe(() => {
              this.handleSuccessResponse();
            },
            err => {
              this.handleWrongResponse( `Грешка при запис!`);
            });              
      },
      err => {
        this.handleWrongResponse( `Този имейл вече се използва!`);
      });
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Потребителят е добавен успешно!`);
    this.back();
  }

  handleWrongResponse(errmsg: string) {
    this.submitted = false;
    this.toasterService.danger('',errmsg);
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }

  back() {
    this.router.navigate(['pages/usersreg']);
  }
}
