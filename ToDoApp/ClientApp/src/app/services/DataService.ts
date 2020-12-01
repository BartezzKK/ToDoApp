import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { throwError } from "rxjs";
import { catchError } from "rxjs/operators";

export class DataService {
  constructor(@Inject(String) private url: string, private http: HttpClient) { }

  getAll() {
    return this.http.get(this.url).pipe(catchError(this.handleError));
  }

  private handleError(error: Response) {
    if (error.status === 404) {
      console.log('Error 404');
      return throwError('Error 404 dataservice.ts');
    } 
      
    else {
      console.log('Error');
      return throwError('Other error dataservice.ts')
    }
       
  }
}
