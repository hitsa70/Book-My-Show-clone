import { TestBed } from '@angular/core/testing';

import { GetHomePageService } from './get-home-page.service';

describe('GetHomePageService', () => {
  let service: GetHomePageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetHomePageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
