import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ItemService } from '../services/item.service';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent implements OnInit{
  public items: TodoItems[];
  constructor(private itemService: ItemService) {}

  ngOnInit() {
    this.itemService.getData().subscribe((data: TodoItems[]) => {
      this.items = data;
    })
  }

  deleteItem(item) {
    this.itemService.deleteData(item.id).subscribe(response => {
      let index = this.items.indexOf(item);
      this.items.splice(index, 1);
    });
  }

 }

interface TodoItems {
  id: number,
  title: string,
  isDone: boolean,
  description: string
}
