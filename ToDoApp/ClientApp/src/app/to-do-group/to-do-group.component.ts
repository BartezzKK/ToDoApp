import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ITodoItem } from '../interfaces/itodo-item';
import { ITodoItemGroup } from '../interfaces/itodo-item-group';
import { DataService } from '../services/DataService';
import { ItemGroupService } from '../services/item-group.service';
import { ItemService } from '../services/item.service';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.css']
})


export class ToDoGroupComponent implements OnInit, ITodoItemGroup{

  groups: ITodoItemGroup[];
  items: ITodoItem[];
  //groups$;

  constructor(private groupServcice: ItemGroupService,
    private itemService: ItemService,
    private router: Router) { }
    id: number;
    name: string;
    userId: string;

  ngOnInit() {

    //this.groups$ = this.groupServcice.getData().subscribe((data: ToDoItemGroup[]) => {
    //  this.
    //})
    this.groupServcice.getData().subscribe((data: ITodoItemGroup[]) => {
      this.groups = data;
    })
    this.itemService.getData().subscribe((data: ITodoItem[]) => {
      this.items = data;
    })
  }
}


