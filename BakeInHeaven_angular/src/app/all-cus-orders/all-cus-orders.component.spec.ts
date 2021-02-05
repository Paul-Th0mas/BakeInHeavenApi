import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCusOrdersComponent } from './all-cus-orders.component';

describe('AllCusOrdersComponent', () => {
  let component: AllCusOrdersComponent;
  let fixture: ComponentFixture<AllCusOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllCusOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllCusOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
