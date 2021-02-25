import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { EditItemGroupComponent } from '../edit-item-group/edit-item-group.component';
import { ITodoItem } from '../interfaces/itodo-item';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { ItemGroupService } from '../services/item-group.service';
import { ItemService } from '../services/item.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.css'],
  animations: [
    trigger('dissapearGroup', [
      transition(':leave', [
        animate(1000, style({opacity: 0, backgroundColor: 'red'}))
      ])
    ])
  ]
})


export class ToDoGroupComponent implements OnInit, ITodoItemGroup{

  groups: ITodoItemGroup[];
  items: ITodoItem[];
  isLoading = false;

  constructor(private groupServcice: ItemGroupService,
    private itemService: ItemService,
    private router: Router,
    private dialog: MatDialog
    ) { }

  id: number;
  name: string;
  userId: string;
  isExpanded: boolean;

  ngOnInit() {
    this.groupServcice.getData().subscribe((data: ITodoItemGroup[]) => {
      this.groups = data;
      this.isLoading = true;
    })
    this.itemService.getData().subscribe((data: ITodoItem[]) => {
      this.items = data;
    })
  }

  deleteGroup(id: number) {
    this.groupServcice.deleteData(id).subscribe(result => {
      this.groups.splice(id, 1);
    });
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  openDialog() {
    this.dialog.open(EditItemGroupComponent)
  }
  
}


