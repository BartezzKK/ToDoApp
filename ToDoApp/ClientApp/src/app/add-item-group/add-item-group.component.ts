import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  public todoGroup: ITodoItemGroup = {} as ITodoItemGroup;
  formGroup = new FormGroup({
    groupName: new FormControl('')
  });

  constructor(private groupService : ItemGroupService, private router: Router) { }

  public addItemGroup() {
    this.todoGroup.name = this.formGroup.get('groupName').value;

    this.groupService.createData(this.todoGroup).subscribe(status => {
      console.log(JSON.stringify(status))
      this.router.navigate(['/']);
    });
    
  }

}
