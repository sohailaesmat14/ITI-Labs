// 2- Create class point2D
class Point2D {
    x: number
    y: number

    constructor(x: number, y: number) {
        this.x = x
        this.y = y
    }

    calculateLength(otherPoint: Point2D): number {
        let dx = this.x - otherPoint.x
        let dy = this.y - otherPoint.y
        return Math.sqrt(dx * dx + dy * dy)
    }
}

// 3- Make class point3D inherit class point2D
class Point3D extends Point2D {
    z: number

    constructor(x: number, y: number, z: number) {
        super(x, y) 
        this.z = z
    }

    // Overriding the calculateLength method for 3 points
    calculateLength(otherPoint: Point3D): number {
        let dx = this.x - otherPoint.x
        let dy = this.y - otherPoint.y
        let dz = this.z - otherPoint.z
        return Math.sqrt(dx * dx + dy * dy + dz * dz)
    }
}

let p1 = new Point2D(0, 0)
let p2 = new Point2D(3, 4)
console.log("Distance 2D:", p1.calculateLength(p2)) // 5

let p3 = new Point3D(0, 0, 0)
let p4 = new Point3D(1, 2, 2)
console.log("Distance 3D:", p3.calculateLength(p4)) // 3