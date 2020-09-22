import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { AssuntoService } from '../../service/assunto.service';
import { Assunto } from '../../model/assunto';
import * as alertify from 'alertifyjs';
import { element } from 'protractor';
import { debounce } from 'rxjs/operators';

@Component({
  selector: 'app-crud-assunto',
  templateUrl: './crud-assunto.component.html',
  styleUrls: ['./crud-assunto.component.css']
})
export class CrudAssuntoComponent implements OnInit {

  @ViewChild('assuntoForm') public createAssuntoForm: NgForm;
  constructor(private _assuntoService: AssuntoService,
    private _router: Router,
    private _route: ActivatedRoute) { }
  assunto: Assunto;

  ngOnInit(): void {
    this._route.paramMap.subscribe(param => {
      this.assunto = {
        id: 0,
        descricao: null
      }
      const id = +param.get('id');
      if (id !== 0) {
      this._assuntoService.getAssunto(id).subscribe((data: Assunto) => {
          
          this.assunto = data;
        })
      }
      
    });
   
  }

  saveAssunto() {
    if (this.assunto.id === 0 || this.assunto.id === null) {
      this._assuntoService.insertAssunto(this.assunto).subscribe((data: Assunto) => {
        console.log(data);
        alertify.success('Inserido com Sucesso');
      }, (erro: any) => console.log(erro));
    } else {
      this._assuntoService.updateAssunto(this.assunto).subscribe((data: Assunto) => {
        console.log(data);
        alertify.success('Atualizado com Sucesso');
      }, (erro: any) => console.log(erro));
    }
    this.createAssuntoForm.reset();
  }
  limpaAssunto() {

    this.createAssuntoForm.reset();
  }

}
