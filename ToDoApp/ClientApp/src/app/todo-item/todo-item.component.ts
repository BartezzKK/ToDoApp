import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent{
  public items: TodoItems[];
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      http.get<TodoItems[]>(baseUrl + 'todoitem').subscribe(result => {
        this.items = result;
      }, error => console.error(error));
  }
 }

interface TodoItems {
  id: number,
  title: string,
  isDone: boolean,
  description: string
}
