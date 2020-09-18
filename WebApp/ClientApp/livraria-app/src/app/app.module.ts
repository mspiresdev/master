import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListLivroComponent } from './livros/list-livro/list-livro.component';
import { HttpClientModule } from '@angular/common/http';
import { LivroService } from './service/livro.service';
import { LivroCrudComponent } from './livros/livro-crud/livro-crud.component';

@NgModule({
  declarations: [
    AppComponent,
    ListLivroComponent,
    LivroCrudComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [LivroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
