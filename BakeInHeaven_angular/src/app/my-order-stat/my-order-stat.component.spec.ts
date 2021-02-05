import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyOrderStatComponent } from './my-order-stat.component';

describe('MyOrderStatComponent', () => {
  let component: MyOrderStatComponent;
  let fixture: ComponentFixture<MyOrderStatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyOrderStatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyOrderStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
