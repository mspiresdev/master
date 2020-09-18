import { Injectable } from '@angular/core';
import { Livro } from '../model/livro';
import { HttpClient , HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable()
export class LivroService {

  constructor(private _httpClient: HttpClient) { }
  private listLivros: Livro[];

  private urlBase = 'https://localhost:44303/api/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getLivros(): Observable<Livro[]> {
    return this._httpClient.get<Livro[]>(this.urlBase+'livro');
  }

  insertLivro(livro: Livro): Observable<Livro> {
    return this._httpClient.post<Livro>(this.urlBase + 'livro', livro, this.httpOptions)
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
