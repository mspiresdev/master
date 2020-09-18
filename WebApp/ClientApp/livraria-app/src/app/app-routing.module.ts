import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListLivroComponent } from 'src/app/livros/list-livro/list-livro.component';
import { LivroCrudComponent } from 'src/app/livros/livro-crud/livro-crud.component';
import { ListAutorComponent } from './autor/list-autor/list-autor.component';
import { CrudAutorComponent } from './autor/crud-autor/crud-autor.component';
import { ListAssuntoComponent } from './assunto/list-assunto/list-assunto.component';
import { CrudAssuntoComponent } from './assunto/crud-assunto/crud-assunto.component';

const routes: Routes = [
  {
    path: 'livros', component: ListLivroComponent
  },
  {
    path: 'livro', component: LivroCrudComponent
  },

  {
    path: 'autors', component: ListAutorComponent
  },
  {
    path: 'autor', component: CrudAutorComponent
  },
  {
    path: 'assuntos', component: ListAssuntoComponent
  },
  {
    path: 'assunto', component: CrudAssuntoComponent
  },
  {path:'', redirectTo:'/livros', pathMatch:'full'}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
