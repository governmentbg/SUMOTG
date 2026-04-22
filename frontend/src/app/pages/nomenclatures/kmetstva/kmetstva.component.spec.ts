import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KmetstvaComponent } from './kmetstva.component';

describe('KmetstvaComponent', () => {
  let component: KmetstvaComponent;
  let fixture: ComponentFixture<KmetstvaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KmetstvaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KmetstvaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
