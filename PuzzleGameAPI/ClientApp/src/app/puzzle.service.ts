import { Injectable } from '@angular/core';
import { Puzzle } from './shared/models/puzzle';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PuzzleService {

  private puzzleURL = "/puzzle/";

  constructor(private http: HttpClient) { }

  getPuzzle(id: number): Observable<Puzzle>{
    return this.http.get<Puzzle>(this.puzzleURL + "GetPuzzle/" + id);
  }

  getPuzzleIds(): Observable<number[]>{
    return this.http.get<number[]>(this.puzzleURL + "GetPuzzleIds");
  }

  getPuzzleNames(): Observable<string[]>{
    return this.http.get<string[]>(this.puzzleURL + "GetPuzzleNames");
  }

  getEmptyPuzzle(): Observable<Puzzle>{
    return this.http.get<Puzzle>(this.puzzleURL + "GetEmptyPuzzle");
  }

  savePuzzle(puzzle: Puzzle): Observable<boolean>{
    return this.http.post<boolean>(this.puzzleURL + "SavePuzzle", puzzle);
  }
}
