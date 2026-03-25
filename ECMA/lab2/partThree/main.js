import { EV } from './EV.js';

const electricCars = [
  new EV('Tesla', 120, 23)
];

const tesla = electricCars[0];

tesla.accelerate();
tesla.brake();
tesla.chargeBattery(90);
tesla.accelerate();