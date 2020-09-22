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

  getLivro(id: number): Observable<Livro> {
    return this._httpClient.get<Livro>(this.urlBase + 'livro/'+id);
  }

  delLivro(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(this.urlBase + 'livro/' + id);
  }

  insertLivro(livro: Livro): Observable<Livro> {
    return this._httpClient.post<Livro>(this.urlBase + 'livro', livro, this.httpOptions);
  }

  updateLivro(livro: Livro): Observable<Livro> {
    return this._httpClient.put<Livro>(this.urlBase + 'livro', livro, this.httpOptions);
  }
  
}
