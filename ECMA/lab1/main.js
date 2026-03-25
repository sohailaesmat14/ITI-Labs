// 1-
// let numbers = [10, 85, 20, 45, 90, 5, 60];

// numbers.sort((a, b) => a - b);
// console.log(numbers);

// numbers.sort((a, b) => b - a);
// console.log(numbers);

// let filteredNumbers = numbers.filter(num => num > 50);
// console.log(filteredNumbers);

// console.log(Math.max(...numbers));
// console.log(Math.min(...numbers));



// 2-
// function calculate(operator, ...nums) {
//     let result = nums[0];
//     for (let i = 1; i < nums.length; i++) {
//         if (operator === "+") result += nums[i];
//         else if (operator === "-") result -= nums[i];
//         else if (operator === "*") result *= nums[i];
//         else if (operator === "/") result /= nums[i];
//     }
//     console.log(`result of ${operator} operation for ${nums.join(",")} is ${result}`);
// }

// calculate("+", 3, 1, 6, 3);



// 3-
const id = prompt("Enter Project ID:");
const name = prompt("Enter Project Name:");
const time = prompt("Enter Duration:");

const project = {
    projectId: id,
    projectName: name,
    duration: time,
    printData() {
        console.log(this.projectId, this.projectName, this.duration);
    }
};

project.printData();