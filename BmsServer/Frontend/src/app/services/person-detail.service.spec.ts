import { TestBed } from '@angular/core/testing';

import { PersonDetailService } from './person-detail.service';

describe('PersonDetailService', () => {
  let service: PersonDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
