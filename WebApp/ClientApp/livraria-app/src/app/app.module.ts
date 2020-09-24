import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListLivroComponent } from './livros/list-livro/list-livro.component';
import { HttpClientModule,  HTTP_INTERCEPTORS } from '@angular/common/http';
import { LivroService } from './service/livro.service';
import { LivroCrudComponent } from './livros/livro-crud/livro-crud.component';
import { ListAutorComponent } from './autor/list-autor/list-autor.component';
import { CrudAutorComponent } from './autor/crud-autor/crud-autor.component';
import { CrudAssuntoComponent } from './assunto/crud-assunto/crud-assunto.component';
import { ListAssuntoComponent } from './assunto/list-assunto/list-assunto.component';
import { HttpErrorInterceptor } from './interceptors/error.interceptor';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { ReportViewerModule } from 'ngx-ssrs-reportviewer';

@NgModule({
  declarations: [
    AppComponent,
    ListLivroComponent,
    LivroCrudComponent,
    ListAutorComponent,
    CrudAutorComponent,
    CrudAssuntoComponent,
    ListAssuntoComponent
  ],
  imports: [
    BrowserModule,
    ReportViewerModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot(),
    CommonModule,
    CurrencyMaskModule
  ],
  providers: [LivroService, {
    provide: HTTP_INTERCEPTORS,
    useClass: HttpErrorInterceptor,
    multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
