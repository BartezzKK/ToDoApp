import { TestBed } from '@angular/core/testing';

import { ItemGroupService } from './item-group.service';

describe('ItemGroupService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ItemGroupService = TestBed.get(ItemGroupService);
    expect(service).toBeTruthy();
  });
});
