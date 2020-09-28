import { Component, OnInit } from '@angular/core';
import { AutorService } from '../../service/autor.service';
import { Autor } from '../../model/autor';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-report-autor',
  templateUrl: './report-autor.component.html',
  styleUrls: ['./report-autor.component.css']
})
export class ReportAutorComponent implements OnInit {

  autors: Autor[];
  constructor(private _autorService: AutorService) { }

  ngOnInit(): void {
    this._autorService.getAutorsReport().subscribe(l => {
      this.autors = l as Autor[]

    });
  }

}
