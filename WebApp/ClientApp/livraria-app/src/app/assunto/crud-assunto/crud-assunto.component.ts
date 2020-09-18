import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { AssuntoService } from '../../service/assunto.service';
import { Assunto } from '../../model/assunto';

@Component({
  selector: 'app-crud-assunto',
  templateUrl: './crud-assunto.component.html',
  styleUrls: ['./crud-assunto.component.css']
})
export class CrudAssuntoComponent implements OnInit {

  @ViewChild('assuntoForm') public createAssuntoForm: NgForm;
  constructor(private _assuntoService: AssuntoService) { }
  assunto: Assunto;

  ngOnInit(): void {
    this.assunto = {
      id: 0,
      descricao: null
    }
  }

  saveAutor() {

    this._assuntoService.insertAssunto(this.assunto).subscribe((data: Assunto) => {
      console.log(data);

    }, (erro: any) => console.log(erro));
    this.createAssuntoForm.reset();
  }
  limpaAssunto() {

    this.createAssuntoForm.reset();
  }

}
