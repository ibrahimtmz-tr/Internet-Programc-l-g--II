/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AdminYazarComponent } from './admin-yazar.component';

describe('AdminYazarComponent', () => {
  let component: AdminYazarComponent;
  let fixture: ComponentFixture<AdminYazarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminYazarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminYazarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
