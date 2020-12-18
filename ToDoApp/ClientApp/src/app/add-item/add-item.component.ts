import { Component, OnInit } from '@angular/core';
import { ItemService } from '../services/item.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent{

  constructor(private itemService : ItemService) { }

  public addItem(input: HTMLInputElement) {
    //let item 
  }


}
