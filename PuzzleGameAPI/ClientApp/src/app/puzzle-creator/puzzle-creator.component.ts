import { Component, OnInit } from '@angular/core';
import { PuzzleService } from '../puzzle.service';
import { Puzzle } from '../shared/models/puzzle';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-puzzle-creator',
  templateUrl: './puzzle-creator.component.html',
  styleUrls: ['./puzzle-creator.component.css']
})
export class PuzzleCreatorComponent implements OnInit {
  puzzle: Puzzle;

  constructor(private puzzleService: PuzzleService,
    private router: Router, 
    private location: Location) { }

  ngOnInit(): void {
    this.getEmptyPuzzle();
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

  getEmptyPuzzle(){
    this.puzzleService.getEmptyPuzzle()
      .subscribe(puzzle => this.puzzle = puzzle);
  }
  
  goBack(){
    this.location.back();
  }

  toMainMenu(){
    this.router.navigate(['']);
  }

  save(){
    this.puzzleService.savePuzzle(this.puzzle)
      .subscribe(success => this.toMainMenu());
  }

}
