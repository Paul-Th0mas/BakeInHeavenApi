import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyDeliComponent } from './modify-deli.component';

describe('ModifyDeliComponent', () => {
  let component: ModifyDeliComponent;
  let fixture: ComponentFixture<ModifyDeliComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifyDeliComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyDeliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
