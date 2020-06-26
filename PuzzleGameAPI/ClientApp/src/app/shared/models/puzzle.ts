import { Square } from './square';
import { Rule } from './rule';

export interface Puzzle{
    id: number;
    name: string;
    board: Square[][];
    rules: Rule[];
}