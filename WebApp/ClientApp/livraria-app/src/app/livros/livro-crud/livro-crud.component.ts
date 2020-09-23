import { Component, OnInit, ViewChild } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { LivroService } from '../../service/livro.service';
import { Livro } from '../../model/livro';
import { AutorService } from '../../service/autor.service';
import { AssuntoService } from '../../service/assunto.service';
import { Autor } from '../../model/autor';
import * as alertify from 'alertifyjs';
import { ENGINE_METHOD_ALL } from 'constants';
import { map } from 'rxjs/operators';
import { Assunto } from 'src/app/model/assunto';



@Component({
  selector: 'app-livro-crud',
  templateUrl: './livro-crud.component.html',
  styleUrls: ['./livro-crud.component.css']
})
export class LivroCrudComponent implements OnInit {
  @ViewChild('livroForm') public createLivroForm: NgForm;
  constructor(private _livroService: LivroService,
    private _autorService: AutorService,
    private _assuntoService: AssuntoService,
    private _router: Router,
    private _route: ActivatedRoute) { }
  livro: Livro;
  autors: Autor[];
  assuntos: Assunto[];
 
  bindDrop() {
   
    this._autorService.getAutors().subscribe(l => {
      this.autors = l;
      
    });
    
    this._assuntoService.getAssuntos().subscribe(l => {
      this.assuntos = l;

    });
  }
  
  ngOnInit(): void {
    
    this.bindDrop();
    this._route.paramMap.subscribe(param => {
      this.livro = {
        id: 0,
        titulo: null,
        edicao: null,
        anoPublicacao: null,
        editora: null,
        autors: [],
        assuntos: []
      }
      const id = +param.get('id');
      if (id !== 0) {
        this._livroService.getLivro(id).subscribe((data: Livro) => {
          this.livro = data;
        })
      }

    });
  }
  addAutor(obj: Autor) {
    
    if (this.livro.autors !== undefined) {
      if (this.livro.autors.filter(order => (order.id === obj.id)).length <= 0)
      {
        this.livro.autors.push(obj);
      }
    }
  }

  addAssunto(obj: Assunto) {

    if (this.livro.assuntos !== undefined) {
      if (this.livro.assuntos.filter(order => (order.id === obj.id)).length <= 0) {
        this.livro.assuntos.push(obj);
      }
    }
  }
  remove(obj: object, listObj: object[]) {
    
    listObj.splice(listObj.indexOf(obj), 1);
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

  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
}
