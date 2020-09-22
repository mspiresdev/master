import { Injectable } from '@angular/core';
import { Assunto } from '../model/assunto';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import * as alertify from 'alertifyjs';

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
  getAssuntos(): Observable<Assunto[]> {
    return this._httpClient.get<Assunto[]>(this.urlBase + 'assunto');
  }

  delAssunto(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(this.urlBase + 'assunto/' + id);
  }

  getAssunto(id: number): Observable<Assunto> {
    return this._httpClient.get<Assunto>(this.urlBase + 'assunto/' + id);
  }

  insertAssunto(assunto: Assunto): Observable<Assunto> {
    return this._httpClient.post<Assunto>(this.urlBase + 'assunto', assunto, this.httpOptions);
  }

  updateAssunto(assunto: Assunto): Observable<Assunto> {
    return this._httpClient.put<Assunto>(this.urlBase + 'assunto', assunto, this.httpOptions);
  }
}
