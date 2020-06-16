import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { PuzzleService } from '../puzzle.service';
import { Puzzle } from '../shared/models/puzzle';

@Component({
  selector: 'app-sudoku',
  templateUrl: './sudoku.component.html',
  styleUrls: ['./sudoku.component.css']
})
export class SudokuComponent implements OnInit {
  @ViewChild("board") board;

  puzzle: Puzzle;

  constructor(private puzzleservice: PuzzleService, 
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
}