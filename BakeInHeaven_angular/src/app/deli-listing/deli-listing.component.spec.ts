import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeliListingComponent } from './deli-listing.component';

describe('DeliListingComponent', () => {
  let component: DeliListingComponent;
  let fixture: ComponentFixture<DeliListingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeliListingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeliListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
