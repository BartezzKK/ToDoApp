import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DataService } from './DataService';

@Injectable({
  providedIn: 'root'
})
export class ItemGroupService extends DataService {
  constructor(httpClient: HttpClient) {
    super('https://localhost:44381/todoitemgroup', httpClient);
  }
}
