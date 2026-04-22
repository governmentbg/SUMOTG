/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import {
  NbMediaBreakpointsService,
  NbMenuService,
  NbSidebarService,
  NbThemeService,
} from '@nebular/theme';

import { LayoutService, RippleService } from '../../../@core/utils';
import { map, takeUntil } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';
import { UserStore } from '../../../@core/stores/user.store';
import { SettingsData } from '../../../@core/interfaces/common/settings';
import { User } from '../../../@core/interfaces/common/users';
import { UsersService } from '../../../@core/backend/common/services/users.service';
import { Router } from '@angular/router';
import { environment } from '../../../../environments/environment';
import { RoleProvider } from '../../../@auth/role.provider';
import { ROLES } from '../../../@auth/roles';
import { PagesComponent } from '../../../pages/pages.component';


@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, OnDestroy {
  public static faza: number = 2;
  public dbname = environment.dbname;
  
  public readonly materialTheme$: Observable<boolean>;
  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  userShowInitials: boolean = true;
  user: User;

  userTasks: string = '';
  selectedPhase: string = '2';
  isCompactSidebarState: boolean = true;
  alive: boolean = true;
  canShowItem: boolean = false;

  currentTheme = 'cosmic';
  userMenu = this.getMenuItems();

  constructor(
    private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private themeService: NbThemeService,
    private userStore: UserStore,
    private settingsService: SettingsData,
    private layoutService: LayoutService,
    private breakpointService: NbMediaBreakpointsService,
    private rippleService: RippleService,
    private router: Router,
    protected usersService: UsersService,
    protected roleProvider: RoleProvider
  ) {
    this.canEdit() ;
    this.selectedPhase = String(HeaderComponent.faza); 

    this.materialTheme$ = this.themeService.onThemeChange().pipe(
      map((theme) => {
        const themeName: string = (theme && theme.name) || '';

        return themeName.startsWith('cosmic');
      }),
    );
  }

  get faza() {
    return HeaderComponent.faza;
  }

  canEdit()  {
    this.roleProvider.getRole().subscribe(s =>{
      const role = String(s).toLowerCase();
      if (role === ROLES.ADMIN || (role==ROLES.USER && PagesComponent.raion.length==0))
        this.canShowItem = true;
      else
        this.canShowItem = false;
    });
  }

  getMenuItems() {
    const userLink = this.user ? '/pages/usersreg/current': '';

    return [
      { title: 'Профил', link: userLink, queryParams: { profile: true } },
      { title: 'Изход', link: '/auth/logout' },
    ];
  }

  ngOnInit() {
    this.currentTheme = this.themeService.currentTheme;

    this.userStore
      .onUserStateChange()
      .pipe(takeUntil(this.destroy$))
      .subscribe((user: User) => {
        this.user = user;

        if (!this.user.id) {
          this.usersService
            .getCurrentUser()
            .subscribe((user) => (this.user = user));
        }

        this.userMenu = this.getMenuItems();
      });

    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService
      .onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$),
      )
      .subscribe(
        (isLessThanXl: boolean) => (this.userPictureOnly = isLessThanXl),
      );

    this.themeService
      .onThemeChange()
      .pipe(
        map(({ name }) => name),
        takeUntil(this.destroy$),
      )
      .subscribe((themeName) => {
        this.currentTheme = themeName;
        this.rippleService.toggle(themeName.startsWith('cosmic'));
      });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  changeTheme(themeName: string) {
    this.userStore.setSetting(themeName);
    this.settingsService
      .updateCurrent(this.userStore.getUser().settings)
      .pipe(takeUntil(this.destroy$))
      .subscribe();

    this.themeService.changeTheme(themeName);
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    this.layoutService.changeLayoutSize();

    return false;
  }

  navigateHome() {
    this.menuService.navigateHome();
    return false;
  }

  changePhaseSelection($event: any) {
    HeaderComponent.faza = Number(this.selectedPhase);
    let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
  }
}
