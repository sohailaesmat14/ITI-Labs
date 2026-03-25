import { Car } from './Car.js';

export class EV extends Car {
  constructor(name, speed, charge) {
    super(name, speed);
    this.charge = charge;
  }

  chargeBattery(chargeTo) {
    this.charge = chargeTo;
  }

  accelerate() {
    this.speed += 20;
    this.charge -= 1;
    console.log(`${this.name} going at ${this.speed} km/h, with a charge of ${this.charge}%`);
  }
}