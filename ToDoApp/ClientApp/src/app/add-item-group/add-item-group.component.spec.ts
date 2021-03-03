import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { AddItemGroupComponent } from './add-item-group.component';

describe('AddItemGroupComponent', () => {
  let component: AddItemGroupComponent;
  let fixture: ComponentFixture<AddItemGroupComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AddItemGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddItemGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
