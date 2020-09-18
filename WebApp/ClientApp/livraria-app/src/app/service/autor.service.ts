import { Injectable } from '@angular/core';
import { Autor } from '../model/autor';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  constructor(private _httpClient: HttpClient) { }
  private listAutors: Autor[];

  private urlBase = 'https://localhost:44303/api/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getAutors(): Observable<Autor[]> {
    return this._httpClient.get<Autor[]>(this.urlBase + 'autor');
  }

  insertAutor(autor: Autor): Observable<Autor> {
    return this._httpClient.post<Autor>(this.urlBase + 'autor', autor, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = 'Código do erro: ${error.status}, ' + 'menssagem: ${error.message}';
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
