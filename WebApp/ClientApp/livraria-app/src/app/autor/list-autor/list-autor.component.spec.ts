import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAutorComponent } from './list-autor.component';

describe('ListAutorComponent', () => {
  let component: ListAutorComponent;
  let fixture: ComponentFixture<ListAutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAutorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
