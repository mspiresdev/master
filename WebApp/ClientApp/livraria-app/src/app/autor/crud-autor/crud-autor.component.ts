import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { AutorService } from '../../service/autor.service';
import { Autor } from '../../model/autor';

@Component({
  selector: 'app-crud-autor',
  templateUrl: './crud-autor.component.html',
  styleUrls: ['./crud-autor.component.css']
})
export class CrudAutorComponent implements OnInit {

  @ViewChild('autorForm') public createAutorForm: NgForm;
  constructor(private _autorService: AutorService) { }
  autor: Autor;

  ngOnInit(): void {
    this.autor = {
      id: 0,
      nome: null
    }
  }

  saveAutor() {

    this._autorService.insertAutor(this.autor).subscribe((data: Autor) => {
      console.log(data);

    }, (erro: any) => console.log(erro));
    this.createAutorForm.reset();
  }
  limpaAutor() {

    this.createAutorForm.reset();
  }

}
