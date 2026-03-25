// 1 ----------------------------------------------
const todoList = {
  tasks: [],

  addTask: function(task) {
    this.tasks.push(task);
  },

  removeTask: function(task) {
    const index = this.tasks.indexOf(task);
    if (index !== -1) {
      this.tasks.splice(index, 1);
    }
  },

  listTasks: function() {
    this.tasks.forEach(task => {
      console.log(task);
    });
  }
};
todoList.addTask("JS");
todoList.addTask("ITI Project");
todoList.listTasks();
todoList.removeTask("JS");
todoList.listTasks();

// 2 ----------------------------------------------
const user = {
  name: "Sara",
  age: 26,
  address: {
    street: "123 Main St",
    city: "Anytown"
  },
  getFullAddress: function() {
    return `${this.address.street}, ${this.address.city}`;
  }
};

const users = [
  { name: "Ahmed", age: 30, address: { street: "St 1", city: "Cairo" } },
  { name: "Mona", age: 22, address: { street: "St 2", city: "Giza" } },
  { name: "Sara", age: 26, address: { street: "St 3", city: "Alex" } },
  { name: "Ziad", age: 20, address: { street: "St 4", city: "Luxor" } }
];

const sortedByName = [...users].sort((a, b) => a.name.localeCompare(b.name));
console.log("Sorted by Name:", sortedByName);

const sortedByAge = [...users].sort((a, b) => a.age - b.age);
console.log("Sorted by Age:", sortedByAge);

const filteredUsers = users.filter(u => u.age > 24);
console.log("Users older than 24:", filteredUsers);

console.log("Full Address for Sara:", user.getFullAddress());
