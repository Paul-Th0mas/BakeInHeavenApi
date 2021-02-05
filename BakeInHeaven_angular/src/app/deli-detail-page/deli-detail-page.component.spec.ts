import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeliDetailPageComponent } from './deli-detail-page.component';

describe('DeliDetailPageComponent', () => {
  let component: DeliDetailPageComponent;
  let fixture: ComponentFixture<DeliDetailPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeliDetailPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeliDetailPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
