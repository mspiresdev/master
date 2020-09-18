import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { LivroService } from '../../service/livro.service';
import { Livro } from '../../model/livro';
@Component({
  selector: 'app-livro-crud',
  templateUrl: './livro-crud.component.html',
  styleUrls: ['./livro-crud.component.css']
})
export class LivroCrudComponent implements OnInit {
  @ViewChild('livroForm') public createLivroForm: NgForm;
  constructor(private _livroService: LivroService) { }
  livro: Livro;
 
  ngOnInit(): void {
    this.livro = {
      id:0,
      titulo: null,
      edicao: null,
      anoPublicacao: null,
      editora:null
    }
  }

  saveLivro() {
    
    this._livroService.insertLivro(this.livro).subscribe((data: Livro) => {
      console.log(data);

    },(erro:any)=> console.log(erro));
    this.createLivroForm.reset();
  }
  limpaLivro() {
   
    this.createLivroForm.reset();
  }
}
