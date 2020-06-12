import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';

import { AppComponent } from './app.component';
import { SudokuComponent } from './sudoku/sudoku.component';
import { PuzzleSquareComponent } from './puzzle-square/puzzle-square.component';

@NgModule({
  declarations: [
    AppComponent,
    SudokuComponent,
    PuzzleSquareComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
