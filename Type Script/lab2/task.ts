// e. Generics
function echo<T>(arg: T): T {
    return arg
}
let result = echo<string>("Hello")

// f. Decorator
function Logger(constructor: Function) {
    console.log("Logging class:", constructor.name)
}

@Logger
class Person {
    constructor() {
        console.log("Person created")
    }
}

// g. Modules
export const moduleValue = 100