import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportAutorComponent } from './report-autor.component';

describe('ReportAutorComponent', () => {
  let component: ReportAutorComponent;
  let fixture: ComponentFixture<ReportAutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportAutorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportAutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
