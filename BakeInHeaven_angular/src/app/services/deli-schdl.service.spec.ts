import { TestBed } from '@angular/core/testing';

import { DeliSchdlService } from './deli-schdl.service';

describe('DeliSchdlService', () => {
  let service: DeliSchdlService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeliSchdlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
