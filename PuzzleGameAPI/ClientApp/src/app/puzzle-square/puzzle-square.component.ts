import { Component, OnInit, Input, HostListener, ViewChild } from '@angular/core';
import { Square } from '../shared/models/square';
import { Console } from 'console';

@Component({
  selector: 'app-puzzle-square',
  templateUrl: './puzzle-square.component.html',
  styleUrls: ['./puzzle-square.component.css']
})
export class PuzzleSquareComponent implements OnInit {
  @Input() square: Square;
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
      document.addEventListener('keypress', this.handleKeyboardEventRef);
    }
    else{
      document.removeEventListener('click', this.deselectSquareRef);
      document.removeEventListener('keypress', this.handleKeyboardEventRef);
    }
  }
  
  deselectSquare(event: MouseEvent){
    const clickedThisSquare = this.div.nativeElement.contains(event.target);
    const selectingMultiple = event.ctrlKey;
    if(!clickedThisSquare && !selectingMultiple){
      this.isSelected = false;
      document.removeEventListener('click', this.deselectSquareRef);
      document.removeEventListener('keypress', this.handleKeyboardEventRef);
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