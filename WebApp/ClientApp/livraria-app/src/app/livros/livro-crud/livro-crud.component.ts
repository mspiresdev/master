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
import { map, debounce } from 'rxjs/operators';
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
  autor: Autor;
  assunto: Assunto;

  dropdownListAutors = [];
  dropdownListAssuntos = [];
  selectedItemsAutors = [];
  selectedItemsAutors = [];
  dropdownSettings: IDropdownSettings;
 
  bindDrop() {

    
    
    this._assuntoService.getAssuntos().subscribe(l => {
      this.assuntos = l;
      this.dropdownListAssuntos = l.map(s => {
        var teste = {};
        teste.item_id = s.id;
        teste.item_text = s.descricao;
        return teste;
      });

    });
    this._autorService.getAutors().subscribe(l => {
      this.autors = l;
      this.dropdownListAutors = l.map(s => {
        var teste = {};
        teste.item_id = s.id;
        teste.item_text = s.nome;
        return teste;
      });

    });
    
   
  }

  bindAutor() {
    this.selectedItemsAutors = this.livro.autors.map(s => {
      var teste = {};
      teste.item_id = s.id;
      teste.item_text = s.nome;
      return teste;
    });
    
  }

  bindAssunto() {
    this.selectedItemsAssuntos = this.livro.assuntos.map(s => {
      var teste = {};
      teste.item_id = s.id;
      teste.item_text = s.descricao;
      return teste;
    });
  }

  inicialize() {
    this._route.paramMap.subscribe(param => {
      this.livro = {
        id: 0,
        titulo: null,
        edicao: null,
        anoPublicacao: null,
        editora: null,
        preco:null,
        autors: [],
        assuntos: []
      }
      const id = +param.get('id');
      if (id !== 0) {
        this._livroService.getLivro(id).subscribe((data: Livro) => {
          this.livro = data;
          this.bindAutor();
          this.bindAssunto();
        })
      }

    });
  }
  
  ngOnInit(): void {
    
    this.bindDrop();
    this.inicialize();

    //this.dropdownList = [
    //  { item_id: 1, item_text: 'Mumbai' },
    //  { item_id: 2, item_text: 'Bangaluru' },
    //  { item_id: 3, item_text: 'Pune' },
    //  { item_id: 4, item_text: 'Navsari' },
    //  { item_id: 5, item_text: 'New Delhi' }
    //];
    //this.selectedItems = [
    //  { item_id: 3, item_text: 'Pune' },
    //  { item_id: 4, item_text: 'Navsari' }
    //];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
   
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
    this.inicialize();
  }
  limpaLivro() {
   
    this.createLivroForm.reset();
    this.inicialize();
  }

  onItemSelectAutors(item: any) {
    
    this.autor = {
      id: item.item_id,
      nome: item.item_text
    }
    this.livro.autors.push(this.autor);

  }
  
  onItemDeSelectAutors(item: any) {
    this.autor = {
      id: item.item_id,
      nome: item.item_text
    }
    for (var i = 0; i < this.livro.autors.length; i++)
    {
      
      if (this.livro.autors[i].id === this.autor.id)
      {
        this.livro.autors.splice(i, 1); ;
      }
    }
   
  }

  onItemSelectAssuntos(item: any) {

    this.assunto = {
      id: item.item_id,
      descricao: item.item_text
    }
    this.livro.assuntos.push(this.assunto);

  }

  onItemDeSelectAssuntos(item: any) {
    this.assunto = {
      id: item.item_id,
      descricao: item.item_text
    }
    for (var i = 0; i < this.livro.assuntos.length; i++) {

      if (this.livro.assuntos[i].id === this.assunto.id) {
        this.livro.assuntos.splice(i, 1);;
      }
    }

  }
}
