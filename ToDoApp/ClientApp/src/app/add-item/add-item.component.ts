import { Component, OnInit } from '@angular/core';
import { ITodoItem } from '../interfaces/itodo-item';
import { ItemService } from '../services/item.service';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { FormControl, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';


@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent{
  
  public item: ITodoItem = {} as ITodoItem
  public pageTitle = "Add Todo Item"
  private queryParamsGroupId: number;
  formGroup = new FormGroup({
    itemTitle: new FormControl('',[
      Validators.required,
      Validators.minLength(3)]),
    itemDescription: new FormControl('',[
      Validators.required,
      Validators.minLength(5)])
  })

  constructor(private itemService: ItemService,
              private route: ActivatedRoute,
              private router: Router) { }

  public addItem() {
    this.item.title = this.formGroup.get('itemTitle').value;
    this.item.description = this.formGroup.get('itemDescription').value;
    this.route.queryParams.pipe(filter(params => params.groupId))
      .subscribe(params => {
        this.queryParamsGroupId = params.groupId;
      })
    this.item.todoItemgroupId = this.queryParamsGroupId;
    this.itemService.createData(this.item).subscribe(status => {
      this.router.navigate(['/']);
    })
  }
}
