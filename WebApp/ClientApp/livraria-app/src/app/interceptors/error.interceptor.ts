import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, debounce } from 'rxjs/operators';
import * as alertify from 'alertifyjs';

export class HttpErrorInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMsg = '';
          if (error.error instanceof ErrorEvent) {
           
            errorMsg = `Error: ${error.error.message}`;
          }
          else {
            console.log('this is server side error');
            errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
          }
        alertify.error(errorMsg);
          return throwError(errorMsg);
        })
      );
  }
}
