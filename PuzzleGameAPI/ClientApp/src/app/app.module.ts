import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';

import { AppComponent } from './app.component';
import { SudokuComponent } from './sudoku/sudoku.component';
import { PuzzleSquareComponent } from './puzzle-square/puzzle-square.component';
import { PuzzleSelectionComponent } from './puzzle-selection/puzzle-selection.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    SudokuComponent,
    PuzzleSquareComponent,
    PuzzleSelectionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
