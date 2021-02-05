import { TestBed } from '@angular/core/testing';

import { DeliListingService } from './deli-listing.service';

describe('DeliListingService', () => {
  let service: DeliListingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeliListingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
