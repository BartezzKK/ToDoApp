import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { DataService } from '../services/DataService';
import { ItemGroupService } from '../services/item-group.service';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.css']
})


export class ToDoGroupComponent implements OnInit{
  
  constructor(private groupServcice: ItemGroupService) { }

  ngOnInit() {
    this.groupServcice.getData().subscribe((data: ToDoItemGroup[]) => {
      this.groups = data;
    })
  }
  public groups: ToDoItemGroup[];
}

export interface ToDoItemGroup {
  name: string;
}
