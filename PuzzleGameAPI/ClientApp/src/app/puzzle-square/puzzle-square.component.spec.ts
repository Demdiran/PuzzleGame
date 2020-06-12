import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PuzzleSquareComponent } from './puzzle-square.component';

describe('PuzzleSquareComponent', () => {
  let component: PuzzleSquareComponent;
  let fixture: ComponentFixture<PuzzleSquareComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PuzzleSquareComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PuzzleSquareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
