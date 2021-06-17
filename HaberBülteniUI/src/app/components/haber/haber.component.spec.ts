/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HaberComponent } from './haber.component';

describe('HaberComponent', () => {
  let component: HaberComponent;
  let fixture: ComponentFixture<HaberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HaberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HaberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
