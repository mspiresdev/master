import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAssuntoComponent } from './list-assunto.component';

describe('ListAssuntoComponent', () => {
  let component: ListAssuntoComponent;
  let fixture: ComponentFixture<ListAssuntoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAssuntoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAssuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
