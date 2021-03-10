import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TodoItemComponent } from './todo-item.component';
import { HttpClient } from '@angular/common/http';
import { AppModule } from '../app.module';
import { ItemService } from '../services/item.service';
import { RouterModule } from '@angular/router';
import { MatComponentsModule } from '../mat-components.module';
import { MyTitleComponent } from '../my-title/my-title.component';
import { ITodoItem } from '../interfaces/itodo-item';
import { from } from 'rxjs/internal/observable/from';

describe('TodoItemComponent', () => {
  let component: TodoItemComponent;
  let fixture: ComponentFixture<TodoItemComponent>;
  let service: ItemService;
  let httpClient: HttpClient;
  //let httpTestingController: HttpTestingController;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [MatComponentsModule, RouterModule, /*HttpClientTestingModule*/, AppModule],
      declarations: [TodoItemComponent, MyTitleComponent]
    })
      .compileComponents();
  }));


  beforeEach(() => {
    fixture = TestBed.createComponent(TodoItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  beforeEach(() => {
    service = new ItemService(null);
    component = new TodoItemComponent(service);
  });

  it('should set todos property with the items returned from the server', async () => {
    let items: ITodoItem [] = [{ id: 1, title: 'jeden', isDone: false, description: 'jeden', todoItemgroupId: 1 },
      { id: 2, title: 'dwa', isDone: false, description: 'dwa', todoItemgroupId: 4 },
      { id: 3, title: 'trzy', isDone: false, description: 'trzy', todoItemgroupId: 1 }
    ];

    let items2 = [1, 2, 3];
    spyOn(service, 'getData').and.callFake(() => {

      return from([items]);
    });

    component.ngOnInit();

    expect(component.items.length).toBeGreaterThan(1);
  });

});
