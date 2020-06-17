import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PuzzleSelectionComponent } from './puzzle-selection/puzzle-selection.component';
import { SudokuComponent } from './sudoku/sudoku.component';
import { PuzzleCreatorComponent } from './puzzle-creator/puzzle-creator.component';

const routes: Routes = [
  { path: '', component: PuzzleSelectionComponent},
  { path: 'puzzle/:id', component: SudokuComponent},
  { path: 'puzzlecreator', component: PuzzleCreatorComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
