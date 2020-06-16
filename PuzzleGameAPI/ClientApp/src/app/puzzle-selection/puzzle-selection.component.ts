import { Component, OnInit } from '@angular/core';
import { PuzzleService } from '../puzzle.service';

@Component({
  selector: 'app-puzzle-selection',
  templateUrl: './puzzle-selection.component.html',
  styleUrls: ['./puzzle-selection.component.css']
})
export class PuzzleSelectionComponent implements OnInit {
  ids: number[];

  constructor(private puzzleService: PuzzleService) { }

  ngOnInit(): void {
    this.getIds();
  }

  getIds(): void{
    this.puzzleService.getPuzzleIds()
      .subscribe(ids => this.ids = ids);
  }
}
