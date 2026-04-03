// a. Types & b. Union types
let studentName: string = "Sohaila"
let studentAge: number | string = 24 

// c. Function with typed arguments and return type
function calculateTotal(price: number, tax: number): number {
    return price + tax
}

// d. Enum in typescript
enum Directions {
    Up,
    Down,
    Left,
    Right
}
let myDirection: Directions = Directions.Up
