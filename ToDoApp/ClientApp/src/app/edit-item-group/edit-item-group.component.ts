import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../services/DataService';
import { ItemGroupService } from '../services/item-group.service';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';

@Component({
  selector: 'app-edit-item-group',
  templateUrl: './edit-item-group.component.html',
  styleUrls: ['./edit-item-group.component.css']
})
export class EditItemGroupComponent implements OnInit{
  public name;
  public userId;
  idG: number;
  group: ITodoItemGroup;
  constructor(private route: ActivatedRoute, private groupService: ItemGroupService, private router: Router) { }

  ngOnInit() {
    this.route.paramMap
      .subscribe(params => {
        this.idG = + params.get('id');
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

  //public submit() {
  //  this.router.navigate(['/']);
  //}

  public addEditedGroup(input: HTMLInputElement) {
    this.groupService.updateData(this.idG, input)
      .subscribe(status => {
        console.log(JSON.stringify(status));
        this.router.navigate(['/']);
      });
    console.log(status);
    console.log("input element:");
    console.log(input);
    //this.submit();
    //this.router.navigate(['/']);
  }

}
