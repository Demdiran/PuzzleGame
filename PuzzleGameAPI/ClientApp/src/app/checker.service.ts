import { Injectable } from '@angular/core';
import { Puzzle } from './shared/models/puzzle';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CheckerService {

  private checkerURL = "/checker/";

  constructor(private http: HttpClient) { }

  checkPuzzle(puzzle: Puzzle): Observable<number[]>{
    return of([0,1,5,8,9,15,22]);
  }
}
