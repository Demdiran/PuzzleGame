import { Square } from './square';

export interface Puzzle{
    id: number;
    name: string;
    board: Square[][];
}

export function createEmptyPuzzle(): Puzzle{
    let board: Square[][] = [];
    for(let i = 0; i < 9; i++){
        let row = createEmptyRow();
        board.push(row);
    }
    let puzzle: Puzzle = {
        id: undefined,
        name: "",
        board: board
    }
    return puzzle;
}

function createEmptyRow(): Square[]{
    let row: Square[] = [];
    for(let i = 0; i < 9; i++){
        let square: Square = {
            isHint: false,
            value: 0,
        }
        row.push(square);
    }
    return row;
}