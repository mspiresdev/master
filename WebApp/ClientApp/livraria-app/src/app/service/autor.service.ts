import { Injectable } from '@angular/core';
import { Autor } from '../model/autor';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  constructor(private _httpClient: HttpClient) { }
  private listAutors: Autor[];

  private urlBase = 'https://localhost:44303/api/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }
  getAutors(): Observable<Autor[]> {
    return this._httpClient.get<Autor[]>(this.urlBase + 'autor');
  }

  getAutorsReport(): Observable<Autor[]> {
    return this._httpClient.get<Autor[]>(this.urlBase + 'autor/report');
  }

  getAutor(id: number): Observable<Autor> {
    return this._httpClient.get<Autor>(this.urlBase + 'autor/' + id);
  }

  delAutor(id: number): Observable<boolean> {
    return this._httpClient.delete<boolean>(this.urlBase + 'autor/' + id);
  }

  insertAutor(autor: Autor): Observable<Autor> {
    return this._httpClient.post<Autor>(this.urlBase + 'autor', autor, this.httpOptions);
  }

  updateAutor(autor: Autor): Observable<Autor> {
    return this._httpClient.put<Autor>(this.urlBase + 'autor', autor, this.httpOptions);
  }
}
