import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ItemService } from '../services/item.service';
import { trigger, state, style, animate, animation, transition } from '@angular/animations';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css'],
  animations: [
    trigger('fade', [

      //state('faded', style({
      //  height: '200px',
      //  opacity: 1
      //})),

      //transition('void => *', [
      //  style({opacity: 0}), animate(2000)
      //]),

      transition('* => void', [
        animate(1000, style({opacity: 0, backgroundColor: 'red'}))
      ])
    ])
  ]
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
