import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudAssuntoComponent } from './crud-assunto.component';

describe('CrudAssuntoComponent', () => {
  let component: CrudAssuntoComponent;
  let fixture: ComponentFixture<CrudAssuntoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudAssuntoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudAssuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
