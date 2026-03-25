// part 1
// function Shape(color) {
//   if (this.constructor === Shape) {
//     throw new Error("Cannot instantiate abstract class Shape");
//   }
//   this.color = color;
// }

// Shape.prototype.printColor = function() {
//   return this.color;
// };

// Shape.prototype.calcArea = function() {
//   return 0;
// };

// Shape.prototype.calcPerimeter = function() {
//   return 0;
// };

// function Rect(color, width, height) {
//   Shape.call(this, color);
//   this.width = width || 0;
//   this.height = height || 0;
//   Rect.count++;
// }

// Rect.prototype = Object.create(Shape.prototype);
// Rect.prototype.constructor = Rect;
// Rect.count = 0;

// Rect.getInstancesCount = function() {
//   return Rect.count;
// };

// Rect.prototype.calcArea = function() {
//   return this.width * this.height;
// };

// Rect.prototype.calcPerimeter = function() {
//   return 2 * (this.width + this.height);
// };

// Rect.prototype.toString = function() {
//   return `Color: ${this.printColor()}, Area: ${this.calcArea()}, Perimeter: ${this.calcPerimeter()}`;
// };

// function Square(color, side) {
//   Rect.call(this, color, side, side);
//   Square.count++;
// }

// Square.prototype = Object.create(Rect.prototype);
// Square.prototype.constructor = Square;
// Square.count = 0;

// Square.getInstancesCount = function() {
//   return Square.count;
// };

// const shapes = [
//   new Rect("Red", 10, 5),
//   new Square("Blue", 4),
//   new Rect("Green", 2, 8),
//   new Square("Yellow", 10)
// ];

// shapes.forEach(shape => {
//   console.log(shape.toString());
// });

// console.log("Rectangles created:", Rect.getInstancesCount());
// console.log("Squares created:", Square.getInstancesCount());



// part2
// function Car(name, speed) {
//   this.name = name;
//   this.speed = speed;
// }

// Car.prototype.accelerate = function() {
//   this.speed += 10;
//   console.log(`${this.name} is going at ${this.speed} km/h`);
// };

// Car.prototype.brake = function() {
//   this.speed -= 5;
//   console.log(`${this.name} is going at ${this.speed} km/h`);
// };

// const car1 = new Car('BMW', 120);
// const car2 = new Car('Mercedes', 95);

// car1.accelerate();
// car1.accelerate();
// car1.brake();
// car1.accelerate();

// car2.brake();
// car2.brake();
// car2.accelerate();
// car2.brake();



// part3
function Car(name, speed) {
  this.name = name;
  this.speed = speed;
}

Car.prototype.accelerate = function() {
  this.speed += 10;
  console.log(`${this.name} is going at ${this.speed} km/h`);
};

Car.prototype.brake = function() {
  this.speed -= 5;
  console.log(`${this.name} is going at ${this.speed} km/h`);
};

function EV(name, speed, charge) {
  Car.call(this, name, speed);
  this.charge = charge;
}

EV.prototype = Object.create(Car.prototype);
EV.prototype.constructor = EV;

EV.prototype.chargeBattery = function(chargeTo) {
  this.charge = chargeTo;
};

EV.prototype.accelerate = function() {
  this.speed += 20;
  this.charge--;
  console.log(`${this.name} going at ${this.speed} km/h, with a charge of ${this.charge}%`);
};

const tesla = new EV('Tesla', 120, 23);

tesla.accelerate();
tesla.brake();
tesla.chargeBattery(90);
tesla.accelerate();