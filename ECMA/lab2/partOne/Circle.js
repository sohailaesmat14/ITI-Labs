import { Shape } from './Shape.js';

export class Circle extends Shape {
    #radius;
    #x; #y;

    constructor(color, radius, x, y) {
        super(color);
        this.#radius = radius;
        this.#x = x;
        this.#y = y;
    }

    // Getters & Setters
    get radius() { return this.#radius; }
    set radius(v) { this.#radius = v; }

    calcArea() { return Math.PI * Math.pow(this.#radius, 2); }

    toString() {
        return `Circle -> Color: ${this.color}, Area: ${this.calcArea().toFixed(2)}, Position: (${this.#x}, ${this.#y})`;
    }
}