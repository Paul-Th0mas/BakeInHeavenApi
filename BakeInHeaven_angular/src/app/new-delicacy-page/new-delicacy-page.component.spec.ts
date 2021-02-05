import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewDelicacyPageComponent } from './new-delicacy-page.component';

describe('NewDelicacyPageComponent', () => {
  let component: NewDelicacyPageComponent;
  let fixture: ComponentFixture<NewDelicacyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewDelicacyPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewDelicacyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
