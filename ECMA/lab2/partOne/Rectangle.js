import { Shape } from './Shape.js';

export class Rectangle extends Shape {
    #width;
    #height;
    static count = 0; 

    constructor(color, width, height) {
        super(color);
        this.width = width;  
        this.height = height;
        Rectangle.count++;
    }

    get width() { return this.#width; }
    set width(value) {
        if (value <= 0) return console.error("Width must be positive!");
        this.#width = value;
    }

    get height() { return this.#height; }
    set height(value) {
        if (value <= 0) return console.error("Height must be positive!");
        this.#height = value;
    }

    calcArea() { return this.#width * this.#height; }
    calcPerimeter() { return 2 * (this.#width + this.#height); }

    toString() {
        return `Rect -> Color: ${this.color}, Area: ${this.calcArea()}, Perimeter: ${this.calcPerimeter()}`;
    }

    static getCount() { return Rectangle.count; }
}