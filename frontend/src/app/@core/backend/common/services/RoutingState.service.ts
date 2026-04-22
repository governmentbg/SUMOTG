import { Injectable } from '@angular/core';
import { Router, RoutesRecognized } from '@angular/router';
import { filter, pairwise } from 'rxjs/operators';
import { Location } from '@angular/common';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable()
export class RoutingState {
  public previousRoutePath = new BehaviorSubject<string>('');

  constructor(
    private router: Router,
    private location: Location
  ) {
    this.previousRoutePath.next(this.location.path());

    this.router.events
      .pipe(filter(e => e instanceof RoutesRecognized),pairwise())
      .subscribe((event: any[]) => {
        this.previousRoutePath.next(event[0].urlAfterRedirects);
      });
  }

  public getPreviousUrl()  {
    return this.previousRoutePath.value;
  } 
}