import { Component, OnInit, Input, HostListener, ViewChild } from '@angular/core';
import { Square } from '../shared/models/square';

@Component({
  selector: 'app-puzzle-square',
  templateUrl: './puzzle-square.component.html',
  styleUrls: ['./puzzle-square.component.css']
})
export class PuzzleSquareComponent implements OnInit {
  @Input() square: Square;
  @ViewChild("div") div;
  isSelected: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  click(){
    this.isSelected = !this.isSelected;
  }
  
  @HostListener('document:click', ['$event'])
  deselectSquare(event: MouseEvent){
    const clickedPuzzle = this.div.nativeElement.contains(event.target);
    if(!clickedPuzzle){
      this.isSelected = false;
    }
  }

  @HostListener('document:keypress', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) { 
    let key = Number(event.key);
    if(!isNaN(key)){
      this.placeNumber(key);  
    }
  }

  placeNumber(number: number){
    if(this.isSelected && !this.square.isHint){
      this.square.value = number;
    }
  }
}