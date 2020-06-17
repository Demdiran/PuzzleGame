import { Component, OnInit } from '@angular/core';
import { PuzzleService } from '../puzzle.service';

@Component({
  selector: 'app-puzzle-selection',
  templateUrl: './puzzle-selection.component.html',
  styleUrls: ['./puzzle-selection.component.css']
})
export class PuzzleSelectionComponent implements OnInit {
  names: string[];
  ids: number[];

  constructor(private puzzleService: PuzzleService) { }

  ngOnInit(): void {
    this.getPuzzleIds();
    this.getPuzzleNames();
  }

  getPuzzleIds(): void{
    this.puzzleService.getPuzzleIds()
      .subscribe(ids => this.ids = ids);
  }

  getPuzzleNames(): void{
    this.puzzleService.getPuzzleNames()
      .subscribe(names => this.names = names);
  }
}
