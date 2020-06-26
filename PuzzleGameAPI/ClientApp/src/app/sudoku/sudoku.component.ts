import { Component, OnInit, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { PuzzleService } from '../puzzle.service';
import { Puzzle } from '../shared/models/puzzle';
import { PuzzleSquareComponent } from '../puzzle-square/puzzle-square.component';
import { CheckerService } from '../checker.service';

@Component({
  selector: 'app-sudoku',
  templateUrl: './sudoku.component.html',
  styleUrls: ['./sudoku.component.css']
})
export class SudokuComponent implements OnInit {
  @ViewChild("board") board;
  @ViewChildren("puzzleSquare") squareComponents: QueryList<PuzzleSquareComponent>;

  puzzle: Puzzle;

  constructor(private puzzleservice: PuzzleService,
        private checkerservice: CheckerService,
        private route: ActivatedRoute, 
        private location: Location) { }

  ngOnInit(): void {
    this.getPuzzle();
  }

  getPuzzle(){
    const id = +this.route.snapshot.paramMap.get('id');
    this.puzzleservice.getPuzzle(id)
      .subscribe(puzzle => this.puzzle = puzzle);
  }

  setBorders(rowNr: number, columnNr: number){
    let style = {
      borderBottomWidth: "1px",
      borderRightWidth: "1px",
    };
    if((rowNr + 1) % 3 == 0){
      style.borderBottomWidth = "3px";
    }
    if((columnNr + 1) % 3 == 0){
      style.borderRightWidth = "3px";
    }
    return style;
  };

  goBack(){
    this.location.back();
  }

  Check(){
    this.checkerservice.checkPuzzle(this.puzzle)
      .subscribe(numbers => this.selectSquares(numbers))
  }

  selectSquares(numbers: number[]){
    let squares = this.squareComponents.toArray();
    squares.forEach(square => {
      square.deselectSquare();
    })
    numbers.forEach(number => {
      squares[number].selectSquare();
    })
  }
}