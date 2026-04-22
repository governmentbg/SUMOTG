/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NB_AUTH_OPTIONS, NbAuthService, NbAuthResult, getDeepFromObject } from '@nebular/auth';
import { Location } from '@angular/common'
import { UserData } from '../../../@core/interfaces/common/users';
import { NbToastrService } from '@nebular/theme';
@Component({
  selector: 'ngx-reset-password-page',
  styleUrls: ['./reset-password.component.scss'],
  templateUrl: './reset-password.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ResetPasswordComponent implements OnInit {
  minLength: number = this.getConfigValue('forms.validation.password.minLength');
  maxLength: number = this.getConfigValue('forms.validation.password.maxLength');
  redirectDelay: number = this.getConfigValue('forms.resetPassword.redirectDelay');
  showMessages: any = this.getConfigValue('forms.resetPassword.showMessages');
  strategy: string = this.getConfigValue('forms.resetPassword.strategy');
  isPasswordRequired: boolean = this.getConfigValue('forms.validation.password.required');

  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};
  resetPasswordForm: FormGroup;
  id: number = 0;
  
  constructor(
    private usersService: UserData,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    protected cd: ChangeDetectorRef,
    protected fb: FormBuilder,
    protected router: Router,
    private route: ActivatedRoute,
    private navigation: Location,
    private toasterService: NbToastrService,
  ) { 
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe( params => {
      this.id = Number(params.get('id'));
    });

    const passwordValidators = [
      Validators.minLength(this.minLength),
      Validators.maxLength(this.maxLength),
    ];
    this.isPasswordRequired && passwordValidators.push(Validators.required);

    this.resetPasswordForm = this.fb.group({
      password: this.fb.control('', [...passwordValidators]),
      confirmPassword: this.fb.control('', [...passwordValidators]),
    });
  }

  get password() { return this.resetPasswordForm.get('password'); }
  get confirmPassword() { return this.resetPasswordForm.get('confirmPassword'); }

  resetPass(): void {
    this.errors = this.messages = [];
    this.submitted = true;
    this.user = this.resetPasswordForm.value;

      this.usersService
      .changePassword(this.id, this.user)
      .subscribe(() => {
        this.submitted = false;
        this.handleSuccessResponse();
      },
      err => {
        this.handleWrongResponse();
      });
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешен запис.`);
    this.back();
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при запис!`);
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }

  back(): void {
    this.navigation.back()
  }
}

