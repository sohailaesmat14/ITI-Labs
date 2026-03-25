export class Car {
  static #count = 0;
  #serial;
  #name;
  #speed;

  constructor(name, speed) {
    this.#serial = Math.floor(Math.random() * 1000000);
    this.#name = name;
    this.#speed = speed;
    Car.#count++;
  }

  accelerate() {
    this.#speed += 10;
    console.log(`${this.#name} new speed: ${this.#speed} km/h`);
  }

  brake() {
    this.#speed -= 5;
    console.log(`${this.#name} new speed: ${this.#speed} km/h`);
  }

  static getCarStats(carInstance) {
    console.log(`Car Serial: ${carInstance.#serial}`);
    console.log(`Total Cars Created: ${Car.#count}`);
  }
}