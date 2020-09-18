import { Component, OnInit } from '@angular/core';
import { AutorService } from '../../service/autor.service';
import { Autor } from '../../model/autor';

@Component({
  selector: 'app-list-autor',
  templateUrl: './list-autor.component.html',
  styleUrls: ['./list-autor.component.css']
})
export class ListAutorComponent implements OnInit {

  autors: Autor[];
  constructor(private _autorService: AutorService) { }

  ngOnInit(): void {
    this._autorService.getAutors().subscribe(l => {
      this.autors = l as Autor[]

    });

  }
}
