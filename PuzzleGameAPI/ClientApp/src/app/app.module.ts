import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SudokuComponent } from './sudoku/sudoku.component';
import { PuzzleSquareComponent } from './puzzle-square/puzzle-square.component';
import { PuzzleSelectionComponent } from './puzzle-selection/puzzle-selection.component';
import { AppRoutingModule } from './app-routing.module';
import { PuzzleCreatorComponent } from './puzzle-creator/puzzle-creator.component';

@NgModule({
  declarations: [
    AppComponent,
    SudokuComponent,
    PuzzleSquareComponent,
    PuzzleSelectionComponent,
    PuzzleCreatorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
