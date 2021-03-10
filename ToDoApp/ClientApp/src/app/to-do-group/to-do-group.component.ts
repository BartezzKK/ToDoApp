import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EditItemGroupComponent } from '../edit-item-group/edit-item-group.component';
import { ITodoItem } from '../interfaces/itodo-item';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { ItemGroupService } from '../services/item-group.service';
import { ItemService } from '../services/item.service';
import { RouterModule } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.css'],
  animations: [
    trigger('dissapearGroup', [
      transition(':leave', [
        animate(1000, style({ opacity: 0, backgroundColor: 'red', transform: 'translateX(50%)' }))
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
    public dialog: MatDialog
  ) { }

  id: number;
  name: string;
  userId: string;
  isExpanded: boolean;

  ngOnInit() {
    this.groupServcice.getData().subscribe((data: ITodoItemGroup[]) => {
      this.groups = data;
      this.isLoading = true;
      this.itemService.getData().subscribe((data: ITodoItem[]) => {
        this.items = data;
      });
    })
  }

  deleteGroup(group: any) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: {
        title: "Deleting",
        message: "Are you sure to delete this group with all items?"
      }
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.groupServcice.deleteData(group.id).subscribe(result => {
          let index = this.groups.indexOf(group);
          this.groups.splice(index, 1);
        });
      }
    });
    
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}


