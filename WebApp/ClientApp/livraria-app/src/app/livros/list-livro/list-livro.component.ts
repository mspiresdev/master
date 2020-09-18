import { Component, OnInit } from '@angular/core';
import { LivroService } from '../../service/livro.service';
import { Livro } from '../../model/livro';
@Component({
  selector: 'app-list-livro',
  templateUrl: './list-livro.component.html',
  styleUrls: ['./list-livro.component.css']
})
export class ListLivroComponent implements OnInit {

  livros: Livro[];
  constructor(private _livroService: LivroService) { }

  ngOnInit(): void {
      this._livroService.getLivros().subscribe(l => {
        this.livros = l as Livro[]
        
      });
    
  }

}
