import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../services/DataService';
import { ItemGroupService } from '../services/item-group.service';
import { ToDoItemGroup } from '../to-do-group/to-do-group.component';

@Component({
  selector: 'app-edit-item-group',
  templateUrl: './edit-item-group.component.html',
  styleUrls: ['./edit-item-group.component.css']
})
export class EditItemGroupComponent implements OnInit{
  idG: number;
  group: ToDoItemGroup;
  constructor(private route: ActivatedRoute, private groupService: ItemGroupService) { }

  ngOnInit() {
    this.route.paramMap
      .subscribe(params => {
        this.idG = +params.get('id');
        console.log(this.idG);
        this.getOneGroup();
      })
  }

  getOneGroup() {
    this.groupService.getDataById(this.idG).subscribe(group => {
      this.group = group;
      console.log(group);
    }
    )}

  public addEditedGroup(input: HTMLInputElement) {
    
    this.groupService.updateData(this.idG, input)
      .subscribe(status => console.log(JSON.stringify(status)));
  }

}
