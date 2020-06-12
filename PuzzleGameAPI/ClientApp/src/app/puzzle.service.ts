import { Injectable } from '@angular/core';
import { Puzzle } from './shared/models/puzzle';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Square } from './shared/models/square';

@Injectable({
  providedIn: 'root'
})
export class PuzzleService {

  private puzzleURL = "/puzzle";

  constructor(private http: HttpClient) { }


  getPuzzle(): Observable<Puzzle>{
    return this.http.get<Puzzle>(this.puzzleURL);
  }
}
