import { Injectable } from '@angular/core';
import { Puzzle } from './shared/models/puzzle';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CheckerService {

  private puzzleURL = "/puzzle/";

  constructor(private http: HttpClient) { }

  checkPuzzle(puzzle: Puzzle): Observable<number[]>{
    return this.http.post<number[]>(this.puzzleURL + "CheckPuzzle", puzzle);
  }
}
