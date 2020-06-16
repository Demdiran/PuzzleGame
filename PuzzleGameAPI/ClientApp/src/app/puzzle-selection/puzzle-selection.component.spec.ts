import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PuzzleSelectionComponent } from './puzzle-selection.component';

describe('PuzzleSelectionComponent', () => {
  let component: PuzzleSelectionComponent;
  let fixture: ComponentFixture<PuzzleSelectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PuzzleSelectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PuzzleSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
