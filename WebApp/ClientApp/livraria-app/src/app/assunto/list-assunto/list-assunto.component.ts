import { Component, OnInit } from '@angular/core';
import { AssuntoService } from '../../service/assunto.service';
import { Assunto } from '../../model/assunto';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-list-assunto',
  templateUrl: './list-assunto.component.html',
  styleUrls: ['./list-assunto.component.css']
})
export class ListAssuntoComponent implements OnInit {

  assuntos: Assunto[];
  constructor(private _assuntoService: AssuntoService) { }

  ngOnInit(): void {
    this._assuntoService.getAssuntos().subscribe(l => {
      this.assuntos = l as Assunto[]

    });
   
  }

 
  delete(id: number) {
   
    this._assuntoService.delAssunto(id).subscribe((data: boolean) => {
      if (data) {
        alertify.success("Item Excluido");
        this._assuntoService.getAssuntos().subscribe(l => {
          this.assuntos = l as Assunto[]

        });
      }
    });
    
  }
}
