import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'livraria-app';

  reportServer: string = 'http://myreportserver/reportserver';
  reportUrl: string = 'MyReports/SampleReport';
  showParameters: string = "true";
  parameters: any = {
    "SampleStringParameter": null,
    "SampleBooleanParameter": false,
    "SampleDateTimeParameter": "11/1/2020",
    "SampleIntParameter": 1,
    "SampleFloatParameter": "123.1234",
    "SampleMultipleStringParameter": ["Parameter1", "Parameter2"]
  };
  language: string = "en-us";
  width: number = 100;
  height: number = 100;
  toolbar: string = "true";
}
