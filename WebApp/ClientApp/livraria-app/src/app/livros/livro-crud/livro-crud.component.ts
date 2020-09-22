import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { LivroService } from '../../service/livro.service';
import { Livro } from '../../model/livro';
import * as alertify from 'alertifyjs';
import { ENGINE_METHOD_ALL } from 'constants';


@Component({
  selector: 'app-livro-crud',
  templateUrl: './livro-crud.component.html',
  styleUrls: ['./livro-crud.component.css']
})
export class LivroCrudComponent implements OnInit {
  @ViewChild('livroForm') public createLivroForm: NgForm;
  constructor(private _livroService: LivroService,
    private _router: Router,
    private _route: ActivatedRoute) { }
  livro: Livro;
 
  ngOnInit(): void {
   
    this._route.paramMap.subscribe(param => {
      this.livro = {
        id: 0,
        titulo: null,
        edicao: null,
        anoPublicacao: null,
        editora: null
      }
      const id = +param.get('id');
      if (id !== 0) {
        this._livroService.getLivro(id).subscribe((data: Livro) => {
          this.livro = data;
        })
      }

    });
  }

  saveLivro() {
    if (this.livro.id === 0 || this.livro.id === null){
      this._livroService.insertLivro(this.livro).subscribe((data: Livro) => {
        console.log(data);

        alertify.success('Inserido com Sucesso');
      }, (erro: any) => console.log(erro));
    } else {
      this._livroService.updateLivro(this.livro).subscribe((data: Livro) => {
        console.log(data);

        alertify.success('Atualizado com Sucesso');
      }, (erro: any) => console.log(erro));
    }
    this.createLivroForm.reset();
  }
  limpaLivro() {
   
    this.createLivroForm.reset();
  }
}
