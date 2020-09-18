import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListLivroComponent } from 'src/app/livros/list-livro/list-livro.component';
import { LivroCrudComponent } from 'src/app/livros/livro-crud/livro-crud.component';

const routes: Routes = [
  {
    path: 'livros', component: ListLivroComponent
  },
  {
    path: 'livro', component: LivroCrudComponent
  },
  {path:'', redirectTo:'/livros', pathMatch:'full'}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
