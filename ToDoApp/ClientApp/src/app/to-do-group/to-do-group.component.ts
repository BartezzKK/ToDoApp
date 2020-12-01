import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, Injectable, Input, OnInit } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ItemGroupService } from '../services/item-group.service';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.css']
})


export class ToDoGroupComponent {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  public groups: ToDoItemGroup[];
  //http: HttpClient;
  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<ToDoItemGroup[]>(baseUrl + 'todoitemgroup').subscribe(result => {
  //    this.groups = result;
  //  }, error => console.error(error));
  //}
  constructor(private service: ItemGroupService) {}

  ngOnInit() {
    this.service.getAll().subscribe(response => {
      this.groups = JSON.parse(JSON.stringify(response));
    });
  }

  //addGroup(group: HTMLInputElement, @Inject('BASE_URL') baseUrl: string) {
  //  let groupName: ToDoItemGroup;
  //  console.log('32132132141');
  //  return this.http.post<ToDoItemGroup>(baseUrl + 'todoitemgroup', group, this.httpOptions)
  //    .pipe(
  //      catchError((err) => this.handleError(err))
  //    );
  //}

  //addGroup()


  //private handleError(error: HttpErrorResponse) {
  //  if (error.error instanceof ErrorEvent) {
  //    console.error('Error occured:', error.error.message);
  //  } else {
  //    console.error('Backend returned code ${error.status}, ' +
  //      'body was: ${error.error}');
  //  }
  //  return throwError('Smething bad happened error todogroupcomponent.ts');
  //}
}

interface ToDoItemGroup {
  name: string;
}
