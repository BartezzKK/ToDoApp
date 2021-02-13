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
export class AddItemComponent implements ITodoItem {
  public title;
  public description: string;
  public id: number;
  public todoItemgroupId: number;
  public isDone: boolean;
  public item: ITodoItem = {} as ITodoItem
  public pageTitle = "Add Todo Item"
  private queryParamsGroupId: number;

  constructor(private itemService: ItemService, private route: ActivatedRoute, private router: Router) { }


  public addItem(item: ITodoItem) {
    this.route.queryParams.pipe(filter(params => params.groupId))
      .subscribe(params => {
        this.queryParamsGroupId = params.groupId;
      })
    item.todoItemgroupId = this.queryParamsGroupId;
    console.log(this.queryParamsGroupId);
    this.itemService.createData(item).subscribe(status => {
      console.log(JSON.stringify(status));
      this.router.navigate(['/']);
    })
  }
}
