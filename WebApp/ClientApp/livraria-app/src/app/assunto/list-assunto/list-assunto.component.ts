import { Component, OnInit } from '@angular/core';
import { AssuntoService } from '../../service/assunto.service';
import { Assunto } from '../../model/assunto';
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

}
