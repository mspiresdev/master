import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { AutorService } from '../../service/autor.service';
import { Autor } from '../../model/autor';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-crud-autor',
  templateUrl: './crud-autor.component.html',
  styleUrls: ['./crud-autor.component.css']
})
export class CrudAutorComponent implements OnInit {

  @ViewChild('autorForm') public createAutorForm: NgForm;
  constructor(private _autorService: AutorService,
    private _router: Router,
    private _route: ActivatedRoute) { }
  autor: Autor;

  ngOnInit(): void {
    this._route.paramMap.subscribe(param => {
      this.autor = {
        id: 0,
        nome: null,
        livros: []
      }
      const id = +param.get('id');
      if (id !== 0) {
      
        this._autorService.getAutor(id).subscribe((data: Autor) => {
          this.autor = data;
        })
      }

    });
  }

  saveAutor() {
    if (this.autor.id === 0 || this.autor.id === null) {
      this._autorService.insertAutor(this.autor).subscribe((data: Autor) => {
        console.log(data);
        alertify.success('Inserido com Sucesso');
      }, (erro: any) => {

        //console.log(erro);
      });
    } else {
      this._autorService.updateAutor(this.autor).subscribe((data: Autor) => {
        console.log(data);
        alertify.success('Atualizado com Sucesso');
      }, (erro: any) => {

        //console.log(erro);
      });
    }
    this.createAutorForm.reset();
  }
  limpaAutor() {

    this.createAutorForm.reset();
  }

}
