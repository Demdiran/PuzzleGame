import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Square } from '../shared/models/square';

@Component({
  selector: 'app-puzzle-square',
  templateUrl: './puzzle-square.component.html',
  styleUrls: ['./puzzle-square.component.css']
})
export class PuzzleSquareComponent implements OnInit {
  @Input() square: Square;
  @Input() backgroundColor: string = "white";
  @ViewChild("div") div;
  isSelected: boolean = false;
  deselectSquareRef = this.deselectSquare.bind(this);
  handleKeyboardEventRef = this.handleKeyboardEvent.bind(this);

  constructor() { }

  ngOnInit(): void {
  }

  click(){
    this.isSelected = !this.isSelected;
    if(this.isSelected){
      document.addEventListener('click', this.deselectSquareRef);
      document.addEventListener('keydown', this.handleKeyboardEventRef);
    }
    else{
      document.removeEventListener('click', this.deselectSquareRef);
      document.removeEventListener('keydown', this.handleKeyboardEventRef);
    }
  }
  
  deselectSquare(event: MouseEvent){
    const clickedThisSquare = this.div.nativeElement.contains(event.target);
    const selectingMultiple = event.ctrlKey;
    if(!clickedThisSquare && !selectingMultiple){
      this.isSelected = false;
      document.removeEventListener('click', this.deselectSquareRef);
      document.removeEventListener('keydown', this.handleKeyboardEventRef);
    }
  }

  handleKeyboardEvent(event: KeyboardEvent) { 
    let key = Number(event.key);
    if(!isNaN(key)){
      this.placeNumber(key);  
    }
  }

  placeNumber(number: number){
    if(!this.square.isHint){
      this.square.value = number;
    }
  }
}