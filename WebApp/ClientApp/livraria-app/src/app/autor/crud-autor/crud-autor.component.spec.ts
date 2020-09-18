import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudAutorComponent } from './crud-autor.component';

describe('CrudAutorComponent', () => {
  let component: CrudAutorComponent;
  let fixture: ComponentFixture<CrudAutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudAutorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudAutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
