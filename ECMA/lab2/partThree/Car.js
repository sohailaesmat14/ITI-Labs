export class Car {
  constructor(name, speed) {
    this.name = name;
    this.speed = speed;
  }

  brake() {
    this.speed -= 5;
    console.log(`${this.name} is slowing down to ${this.speed} km/h`);
  }
}