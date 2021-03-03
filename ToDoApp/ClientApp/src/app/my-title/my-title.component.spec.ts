import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MyTitleComponent } from './my-title.component';

describe('MyTitleComponent', () => {
  let component: MyTitleComponent;
  let fixture: ComponentFixture<MyTitleComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MyTitleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
