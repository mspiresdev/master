import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivroCrudComponent } from './livro-crud.component';

describe('LivroCrudComponent', () => {
  let component: LivroCrudComponent;
  let fixture: ComponentFixture<LivroCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivroCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LivroCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
