import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { ItemGroupService } from '../services/item-group.service';

@Component({
  selector: 'app-add-item-group',
  templateUrl: './add-item-group.component.html',
  styleUrls: ['./add-item-group.component.css']
})
export class AddItemGroupComponent{
  public pageTitle = "Add Item Group"
  public name;
  public todoGroup: ITodoItemGroup = {} as ITodoItemGroup;

  constructor(private groupService : ItemGroupService, private router: Router) { }

  public addItemGroup(todoGroup: ITodoItemGroup) {
    this.groupService.createData(todoGroup).subscribe(status => {

      console.log(JSON.stringify(status))
      this.router.navigate(['/']);
    });
  }

}
