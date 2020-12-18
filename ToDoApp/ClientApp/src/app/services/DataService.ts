import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { ToDoItemGroup } from "../to-do-group/to-do-group.component";

@Injectable({
  providedIn: 'root'
})

export class DataService {
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(@Inject(String) private url: string, private httpClient: HttpClient) { }

  public getData() {
    return this.httpClient.get(this.url)
      .pipe(catchError(this.handleError)).pipe(retry(3), catchError(this.handleError));
  }

  public getDataById(id: number) {
    return this.httpClient.get<ToDoItemGroup>(this.url + '/' + id)
      .pipe(catchError(this.handleError));
  }

  public deleteData(id) {
    return this.httpClient.delete(this.url + '/' + id).pipe(
      catchError(this.handleError));
  }

  public createData(resource){
    return this.httpClient.post(this.url, JSON.stringify(resource), this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  public updateData(id, resource) {
    return this.httpClient.put(this.url + "/" + id, resource);
  }


  handleError(error: HttpErrorResponse) {
    let errorMsg = 'Unknow eror';
    if (error.error instanceof ErrorEvent) {
      errorMsg = `Error: ${error.error.message}`;
    } else {
      errorMsg = `Error code: ${error.status} \nMessage: ${error.message}`;
    }
    window.alert(errorMsg);
    return throwError(errorMsg);
  }








  //constructor(@Inject(String) private url: string, private http: HttpClient) { }

  //getAll() {
  //  return this.http.get(this.url).pipe(catchError(this.handleError));
  //}

  //private handleError(error: Response) {
  //  if (error.status === 404) {
  //    console.log('Error 404');
  //    return throwError('Error 404 dataservice.ts');
  //  } 
      
  //  else {
  //    console.log('Error');
  //    return throwError('Other error dataservice.ts')
  //  }
       
  //}
}
