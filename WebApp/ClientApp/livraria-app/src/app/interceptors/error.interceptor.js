//import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
//import { Observable, throwError } from 'rxjs';
//import { catchError, debounce } from 'rxjs/operators';
//export class HttpErrorInterceptor implements HttpInterceptor {
//  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//    return next.handle(request)
//      .pipe(
//      catchError((error: HttpErrorResponse) => {
//        debugger
//          let errorMsg = '';
//          if (error.error instanceof ErrorEvent) {
//           alert('this is client side error');
//            errorMsg = `Error: ${error.error.message}`;
//          }
//          else {
//            console.log('this is server side error');
//            errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
//          }
//        alert(errorMsg);
//          return throwError(errorMsg);
//        })
//      );
//  }
//}
//# sourceMappingURL=error.interceptor.js.map