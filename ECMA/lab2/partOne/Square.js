import { Rectangle } from './Rectangle.js';

export class Square extends Rectangle {
    static sqCount = 0;

    constructor(color, side) {
        super(color, side, side); 
        Square.sqCount++;
    }

    toString() {
        return `Square -> Color: ${this.color}, Area: ${this.calcArea()}, Perimeter: ${this.calcPerimeter()}`;
    }

    static getSquareCount() { return Square.sqCount; }
}