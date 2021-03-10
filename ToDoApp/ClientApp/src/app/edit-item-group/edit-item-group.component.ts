import { HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../services/DataService';
import { ItemGroupService } from '../services/item-group.service';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-item-group',
  templateUrl: './edit-item-group.component.html',
  styleUrls: ['./edit-item-group.component.css']
})
export class EditItemGroupComponent implements OnInit{
  public name;
  public userId;
  public pageTitle = "Editing group name";
  idG: number;
  group: ITodoItemGroup;

  formGroup = new FormGroup({
    groupName: new FormControl('', [
      Validators.required,
      Validators.minLength(3)])
  })

  constructor(private route: ActivatedRoute,
    private groupService: ItemGroupService,
    private router: Router){
  }

  ngOnInit() {
    this.route.paramMap
      .subscribe(params => {
        this.idG = + params.get('id');
        this.getOneGroup();
      })
  }

  getOneGroup() {
    this.groupService.getDataById(this.idG).subscribe((group : ITodoItemGroup) => {
      this.group = group;
      this.formGroup.setValue({ groupName: group.name });
    }
    )}

  public addEditedGroup() {
    this.group.name = this.formGroup.get('groupName').value
    this.groupService.updateData(this.idG, this.group)
      .subscribe(status => {
        console.log(JSON.stringify(status));
        this.router.navigate(['/']);
      });
  }

}
