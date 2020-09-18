import { Injectable } from '@angular/core';
import { Assunto } from '../model/assunto';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AssuntoService {

  constructor(private _httpClient: HttpClient) { }
  private listAssuntos: Assunto[];

  private urlBase = 'https://localhost:44303/api/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getLivros(): Observable<Assunto[]> {
    return this._httpClient.get<Assunto[]>(this.urlBase + 'assunto');
  }

  insertLivro(assunto: Assunto): Observable<Assunto> {
    return this._httpClient.post<Assunto>(this.urlBase + 'assunto', assunto, this.httpOptions)
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
