// const person = {
//     id: 1,
//     name: "Empty"
// };

// const employee = Object.create(person);

// let _salary = 0;
// Object.defineProperty(employee, "salary", {
//     get: function() {
//         return _salary;
//     },
//     set: function(value) {
//         _salary = value + (value * 0.20);
//     },
//     enumerable: true,
//     configurable: true
// });

// const hrEmployee = Object.create(employee);
// hrEmployee.location = "Cairo";

// console.log(Object.getPrototypeOf(hrEmployee) === employee);
// console.log(Object.getPrototypeOf(employee) === person);

// console.log(hrEmployee.id);
// console.log(hrEmployee.name);

// hrEmployee.id = 50;
// hrEmployee.name = "Ahmed";
// console.log(hrEmployee.id, hrEmployee.name); 
// console.log(person.id, person.name); 

// person.age = 30;
// console.log(hrEmployee.age);


// --------------------

// const personv2 = {};
// Object.defineProperties(personv2, {
//     id: { value: 1, writable: true, enumerable: true },
//     name: { value: "Empty", writable: true, enumerable: true }
// });

// const employeev2 = Object.create(personv2);
// let _salaryV2 = 0;
// Object.defineProperties(employeev2, {
//     salary: {
//         get: function() { return _salaryV2; },
//         set: function(value) { _salaryV2 = value * 1.2; },
//         enumerable: true
//     }
// });

// const hrEmployeev2 = Object.create(employeev2);
// Object.defineProperties(hrEmployeev2, {
//     location: { value: "Alexandria", writable: true, enumerable: true }
// });

// console.log(hrEmployeev2.id);
// console.log(hrEmployeev2.name);
// hrEmployeev2.salary = 1000;
// console.log(hrEmployeev2.salary);

// --------------------

var EmpArray = [
    { id: 1, name: "Ahmed", salary: 4000, department: "IT" },
    { id: 2, name: "Sara", salary: 5000, department: "HR" },
    { id: 3, name: "Mona", salary: 6000, department: "IT" }
];

function getEmployeeNameHandler() {
    return function(emp) {
        return emp.name;
    };
}

function createCounter() {
    var count = 0;
    return function() {
        count++;
        return count;
    };
}

function trackClicksAndChangeBg() {
    var clicks = 0;
    return function() {
        clicks++;
        var colors = ["#ff5733", "#33ff57", "#3357ff", "#f333ff"];
        document.body.style.backgroundColor = colors[clicks % colors.length];
        return clicks;
    };
}

function addFixedNumber(fixed) {
    return function(num) {
        return num + fixed;
    };
}

function employeeTracker() {
    var count = 0;
    return function() {
        count++;
        return count;
    };
}

function applyBonusToSalary(percentage) {
    return function(salary) {
        return salary + (salary * (percentage / 100));
    };
}

function createGreeting(deptName) {
    return function(empName) {
        return "Welcome " + empName + " to the " + deptName + " Department";
    };
}

var allNames = EmpArray.map(function(emp) {
    return emp.name;
});

var highSalaries = EmpArray.filter(function(emp) {
    return emp.salary > 4500;
});

var totalSalarySum = EmpArray.reduce(function(acc, emp) {
    return acc + emp.salary;
}, 0);

function pureIncreaseSalary(emp) {
    var newEmp = {};
    for (var key in emp) {
        newEmp[key] = emp[key];
    }
    newEmp.salary = newEmp.salary * 1.10;
    return newEmp;
}

function addEmployeeImmutably(arr, newEmp) {
    var copiedArr = arr.map(function(item) {
        return item;
    });
    copiedArr.push(newEmp);
    return copiedArr;
}

function applyBonus(fn, salary) {
    return fn(salary);
}

function filterByDeptCurried(dept) {
    return function(arr) {
        return arr.filter(function(emp) {
            return emp.department === dept;
        });
    };
}

var updatedSalariesArray = EmpArray.map(function(emp) {
    var empCopy = {};
    for (var key in emp) {
        empCopy[key] = emp[key];
    }
    empCopy.salary = empCopy.salary * 1.05;
    return empCopy;
});

var empNameGetter = getEmployeeNameHandler();
console.log(empNameGetter(EmpArray[0])); 

var myCounter = createCounter();
console.log(myCounter()); 
console.log(myCounter()); 

var bgCounter = trackClicksAndChangeBg();
console.log(bgCounter()); 

var addFive = addFixedNumber(5);
console.log(addFive(10)); 

var empCount = employeeTracker();
console.log(empCount()); 
console.log(empCount()); 

var tenPercentBonus = applyBonusToSalary(10);
console.log(tenPercentBonus(5000)); 

var itGreeting = createGreeting("IT");
console.log(itGreeting("Ahmed")); 

console.log(allNames); 

console.log(highSalaries); 

console.log(totalSalarySum); 

var updatedEmp = pureIncreaseSalary(EmpArray[0]);
console.log(updatedEmp); 
console.log(EmpArray[0]); 

var newEmpList = addEmployeeImmutably(EmpArray, { id: 4, name: "Zaki", salary: 3000, department: "Sales" });
console.log(newEmpList.length); 
console.log(EmpArray.length); 

console.log(applyBonus(tenPercentBonus, 1000)); 

var filterIT = filterByDeptCurried("IT");
console.log(filterIT(EmpArray)); 

console.log(updatedSalariesArray);