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
  public name;
  constructor(private groupService : ItemGroupService, private router: Router) { }

  public addItemGroup(input: HTMLInputElement) {
    this.groupService.createData(input).subscribe(status => {

      console.log(JSON.stringify(status))
      this.router.navigate(['/']);
    });
  }

}
