import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EditItemGroupComponent } from './edit-item-group.component';

describe('EditItemGroupComponent', () => {
  let component: EditItemGroupComponent;
  let fixture: ComponentFixture<EditItemGroupComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EditItemGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditItemGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
