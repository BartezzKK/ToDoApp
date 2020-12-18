import { Component, OnInit } from '@angular/core';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { ItemGroupService } from '../services/item-group.service';

@Component({
  selector: 'app-add-item-group',
  templateUrl: './add-item-group.component.html',
  styleUrls: ['./add-item-group.component.css']
})
export class AddItemGroupComponent{

  constructor(private groupService : ItemGroupService) { }

  public addItemGroup(input: HTMLInputElement) {
    this.groupService.createData(input).subscribe(status => console.log(JSON.stringify(status)));
  }

}
