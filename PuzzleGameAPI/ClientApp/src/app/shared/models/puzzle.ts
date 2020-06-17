import { Square } from './square';

export interface Puzzle{
    id: number;
    name: string;
    board: Square[][];
}