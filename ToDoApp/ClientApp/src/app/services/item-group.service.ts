import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//import { AuthHttp } from 'angular2-jwt';
import { Injectable} from '@angular/core';
import { DataService } from './DataService';

@Injectable({
  providedIn: 'root'
})
export class ItemGroupService extends DataService{
  //dodany AuthHttp sprawdzić to
  constructor(httpClient: HttpClient) {
    super('https://localhost:44381/todoitemgroup', httpClient);}

   
}
