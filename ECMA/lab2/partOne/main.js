import { Rectangle } from './Rectangle.js';
import { Square } from './Square.js';
import { Circle } from './Circle.js';

const shapes = [
    new Rectangle("Red", 10, 5),
    new Square("Blue", 4),
    new Circle("Green", 7, 0, 0),
    new Rectangle("Yellow", 2, 8)
];

console.log("--- Displaying Areas ---");
shapes.forEach(shape => {
    console.log(shape.toString());
});

console.log("------------------------");
console.log(`Total Rectangles created: ${Rectangle.getCount()}`);
console.log(`Total Squares created: ${Square.getSquareCount()}`);