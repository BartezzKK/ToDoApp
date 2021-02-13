import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ItemService } from '../services/item.service';
import { trigger, state, style, animate, animation, transition } from '@angular/animations';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css'],
  animations: [
    trigger('fade', [
      transition(':leave', [
        
        animate(1000, style({ opacity: 0, backgroundColor: 'red', transform: 'translateX(50%)' }))
      ]),

      transition(':enter', [
        style({ transform: 'translateX(-10px)' }),
        animate(500)
      ])
    ])
  ]
})
export class TodoItemComponent implements OnInit {
  @Input() idOfGroup: number;
  public items: TodoItems[];
  constructor(private itemService: ItemService) { }

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

  completeTask(item: TodoItems) {
    item.isDone = !item.isDone;
    this.itemService.updateData(item.id, item).subscribe(result => {
      console.log('Task state has been changed');
    });
  }

}

interface TodoItems {
  id: number,
  title: string,
  isDone: boolean,
  description: string,
  toDoItemGroupId: number
}
