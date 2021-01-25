import { Component, OnInit } from '@angular/core';
import { ITodoItem } from '../interfaces/itodo-item';
import { ItemService } from '../services/item.service';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { FormControl, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
//import 'rxjs/add/operator/filter';


@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements ITodoItem{
  constructor(private itemService: ItemService, private route: ActivatedRoute, private router: Router) { }

  queryParamsGroupId: number;
  id: number;
  public title;
  isDone: boolean;
  description: string;
  todoItemgroupId: number;
  public item: ITodoItem = {} as ITodoItem

  //itemFG = new FormGroup({
  //  titleFC: new FormControl('', Validators.required ),
  //  descriptionFC: new FormControl('')
  //});

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

  //public onSubmi() {
  //  console.log(this.itemFG.value);
  //}


}
