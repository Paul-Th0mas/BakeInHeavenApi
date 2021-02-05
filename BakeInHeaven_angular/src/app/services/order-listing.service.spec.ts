import { TestBed } from '@angular/core/testing';

import { OrderListingService } from './order-listing.service';

describe('OrderListingService', () => {
  let service: OrderListingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderListingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
