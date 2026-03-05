#include<iostream>
#include<string>
using namespace std;

class Person {
protected:
    int id;
    string name;

public:
    Person() {
        id = 0;
        name = "";
    }

    Person(int _id, string _name) {
        id = _id;
        name = _name;
    }

    Person(string _name) {
        id = 0;
        name = _name;
    }

    virtual void Print() {
        cout << "Name: " << name << ", ID: " << id;
    }
};

class Employee : public Person {
    int salary;
public:
    Employee(string _name, int _salary) : Person(_name) {
        salary = _salary;
    }

    void Print() {
        Person::Print();
        cout << ", Salary: " << salary << endl;
    }
};

class Customer : public Person {
    string productName;
public:
    Customer(string _personName, string _productName) : Person(_personName) {
        productName = _productName;
    }

    void Print() {
        Person::Print();
        cout << ", Product: " << productName << endl;
    }
};

int main() {
    Person p1(1, "Ahmed");
    p1.Print();
    cout << endl;

    Employee e1("Mona", 5000);
    e1.Print();

    Customer c1("Omar", "Milk");
    c1.Print();

    return 0;
}