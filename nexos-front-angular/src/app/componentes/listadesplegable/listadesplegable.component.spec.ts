import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadesplegableComponent } from './listadesplegable.component';

describe('ListadesplegableComponent', () => {
  let component: ListadesplegableComponent;
  let fixture: ComponentFixture<ListadesplegableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListadesplegableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadesplegableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
