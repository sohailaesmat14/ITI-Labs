export class Shape {
    #color; 

    constructor(color) {
        if (this.constructor === Shape) {
            throw new Error("Abstract classes can't be instantiated.");
        }
        this.#color = color;
    }
    
    get color() { return this.#color; }
    set color(value) { this.#color = value; }

    printColor() {
        console.log(`Shape Color: ${this.#color}`);
    }

    calcArea() { return 0; }
    calcPerimeter() { return 0; }
}