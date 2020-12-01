import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { DataService } from './DataService';

@Injectable({
  providedIn: 'root'
})
export class ItemGroupService extends DataService {
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(baseUrl, http);
  }
}
