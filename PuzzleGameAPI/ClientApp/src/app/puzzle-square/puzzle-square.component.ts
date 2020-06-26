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
  @Input() isSelected: boolean = false;
  @ViewChild("div") div;
  deselectSquareHandlerRef = this.deselectSquareHandler.bind(this);
  keyboardEventHandlerRef = this.keyboardEventHandler.bind(this);

  constructor() { }

  ngOnInit(): void {
  }

  click(){
    if(!this.isSelected){
      this.selectSquare();
    }
    else{
      this.deselectSquare();
    }
  }

  selectSquare(){
    this.isSelected = true;
    document.addEventListener('click', this.deselectSquareHandlerRef);
    document.addEventListener('keydown', this.keyboardEventHandlerRef);
  }

  deselectSquare(){
    this.isSelected = false;
    document.removeEventListener('click', this.deselectSquareHandlerRef);
    document.removeEventListener('keydown', this.keyboardEventHandlerRef);
  }
  
  deselectSquareHandler(event: MouseEvent){
    let element = <Element>event.target;
    if(element.id === "checkButton") return;
    const clickedThisSquare = this.div.nativeElement.contains(event.target);
    const selectingMultiple = event.ctrlKey;
    if(!clickedThisSquare && !selectingMultiple) this.deselectSquare();
  }

  keyboardEventHandler(event: KeyboardEvent) { 
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