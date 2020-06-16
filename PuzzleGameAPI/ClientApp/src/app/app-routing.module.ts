import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PuzzleSelectionComponent } from './puzzle-selection/puzzle-selection.component';
import { SudokuComponent } from './sudoku/sudoku.component';

const routes: Routes = [
  { path: '', component: PuzzleSelectionComponent},
  { path: 'puzzle/:id', component: SudokuComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
