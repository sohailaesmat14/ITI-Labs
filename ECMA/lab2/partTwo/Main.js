import { Car } from './Car.js';

const cars = [
  new Car('BMW', 120),
  new Car('Mercedes', 95)
];

const [car1, car2] = cars;

car1.accelerate();
car1.accelerate();
car1.brake();
Car.getCarStats(car1);

car2.accelerate();
car2.brake();
car2.brake();
Car.getCarStats(car2);