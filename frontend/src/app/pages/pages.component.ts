import { Component, OnDestroy, OnInit } from '@angular/core';
import { takeWhile } from 'rxjs/operators';
import { NbTokenService } from '@nebular/auth';
import { NbMenuItem } from '@nebular/theme';
import { PagesMenu } from './pages-menu';
import { RoleProvider } from '../@auth/role.provider';
import IdleTimeoutManager from '../@core/utils/IdleTimeoutManager';
import { Router } from '@angular/router';
import { DEFAULT_INTERRUPTSOURCES, Idle } from '@ng-idle/core';
import { Keepalive } from '@ng-idle/keepalive';

@Component({
  selector: 'ngx-pages',
  styleUrls: ['pages.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PagesComponent implements OnInit, OnDestroy {
  public static raion: string = '';

  timer: IdleTimeoutManager;
  menu: NbMenuItem[];
  alive: boolean = true;
  role: string = '';

  
  idleState = 'Not started.';
  timedOut = false;
  lastPing?: Date = null;
  
  constructor(
    private pagesMenu: PagesMenu,
    private tokenService: NbTokenService,
    private roleProvider: RoleProvider,
    protected router: Router,
    private idle: Idle, 
    private keepalive: Keepalive
  ) {
    this.getUserRole();
    this.getUserScopeRaion();
    this.initMenu();

    this.tokenService.tokenChange()
      .pipe(takeWhile(() => this.alive))
      .subscribe(() => {
        this.initMenu();
      });
    
      this.initIdle();
  }

  initIdle () {
    // sets an idle timeout of 30 min
    this.idle.setIdle(30*60);
    // sets a timeout period of 15 seconds.
    this.idle.setTimeout(15);
    // sets the default interrupts, in this case, things like clicks, scrolls, touches to the document
    this.idle.setInterrupts(DEFAULT_INTERRUPTSOURCES);

    this.idle.onIdleEnd.subscribe(() => { 
      this.idleState = 'No longer idle.'
      this.resetIdle();
    });

    this.idle.onTimeout.subscribe(() => {
      this.idleState = 'Timed out!';
      this.timedOut = true;
      this.router.navigateByUrl('/auth/logout');
    });

    this.idle.onIdleStart.subscribe(() => {
        this.idleState = 'You\'ve gone idle!'
    });

    this.idle.onTimeoutWarning.subscribe((countdown) => {
      this.idleState = 'You will time out in ' + countdown + ' seconds!'
    });

    // sets the ping interval to 15 seconds
    this.keepalive.interval(15);
    this.keepalive.onPing.subscribe(() => this.lastPing = new Date());

    this.resetIdle();
  }

  resetIdle() {
    this.idle.watch();
    this.idleState = 'Started.';
    this.timedOut = false;
  }

  initMenu() {
    this.pagesMenu.getMenu(this.role)
      .pipe(takeWhile(() => this.alive))
      .subscribe(menu => {
        this.menu = menu;
      });
  }

  ngOnInit() {
    this.timer = new IdleTimeoutManager({
      timeout: 30*60,                                  //expired after 30 min
      onTimeout: () => {
        // this.router.navigateByUrl('/auth/logout')        
      },
      onExpired: () => {
        // this.router.navigateByUrl('/auth/logout')        
      }
    });
  }
  
  ngOnDestroy(): void {
    this.alive = false;
    this.timer.cleanUp();
  }

  
  getUserRole()  {
    this.roleProvider.getRole().subscribe(s =>{
      this.role = String(s);
    });
  }

  getUserScopeRaion()  {
    this.roleProvider.getScopeRaion().subscribe(s =>{
      if (s != '0')
        PagesComponent.raion = String(s);
      else   
        PagesComponent.raion = '';
    });
  }
}
