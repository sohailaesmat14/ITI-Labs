#include <iostream>
#include <cstring>
using namespace std;

class Student
{
    int id;
    char name[20];
    float* grades;
    int size;
    static int count;

public:

    // Default constructor
    Student() {
        id = 0;
        strcpy(name, "Unknown");
        size = 5;
        grades = new float[size];
        for (int i = 0; i < size; i++)
            grades[i] = 0;
        count++;
    }
    // Copy Constructor
    Student(const Student& s) {
        id = s.id;
        strcpy(name, s.name);
        size = s.size;
        grades = new float[size]; 
        for(int i=0; i<size; i++) 
            grades[i] = s.grades[i];
        count++;
    }

    // Parameterized + grades constructor
    Student(int _id, char _name[], float _grades[]) {
        id = _id;
        strcpy(name, _name);
        size = 5;
        grades = new float[size];
        for (int i = 0; i < size; i++)
            grades[i] = _grades[i];
        count++;
    }

    // Constructor with id + name only
    Student(int _id, char _name[]) {
        id = _id;
        strcpy(name, _name);
        size = 5;
        grades = new float[size];
        for (int i = 0; i < size; i++)
            grades[i] = 0;
        count++;
    }

    // Constructor with name only
    Student(char _name[]) {
        id = 0;
        strcpy(name, _name);
        size = 5;
        grades = new float[size];
        for (int i = 0; i < size; i++)
            grades[i] = 0;
        count++;
    }

    // setters
    void setID(int _id) { id = _id; }

    void setName(char _name[]) {
        strcpy(name, _name);
    }

    void setGrades(float _grades[5]) {
        for (int i = 0; i < 5; i++)
            grades[i] = _grades[i];
    }

    // getters
    int getID() { return id; }
    char* getName() { return name; }
    float* getGrades() { return grades; }
    static int getcount(){return count;}

    // methods
    void printStudent() {
        cout << "The name of student is: " << name << endl;
        cout << "The ID of student is: " << id << endl;
        for (int i = 0; i < size; i++) {
            cout << "Grade " << i + 1 << ": " << grades[i] << endl;
        }
        cout << "------" << endl;
    }

    // Operators
    // ++obj → increment id
    Student operator++(int d) {
        Student temp;
        temp = *this;
        id++;
        return temp;
    }

    // obj++  increases array size
    Student operator++() {
        Student temp = *this;

        float* newArr = new float[size + 1];

        for (int i = 0; i < size; i++)
            newArr[i] = grades[i];

        newArr[size] = 0;

        delete[] grades;
        grades = newArr;
        size++;

        return temp;
    }

    // Student + Student
    Student operator+(Student s) {
        Student temp;
        strcpy(temp.name, this->name);
        strcat(temp.name, s.name);
        temp.id = this->id + s.id;
        for (int i = 0; i < 5; i++)
            temp.grades[i] = this->grades[i] + s.grades[i];
        return temp;
    }

    int operator==(Student s) {
        return (this->id == s.id && strcmp(this->name, s.name) == 0);
    }

    // Assignment
    Student& operator=(const Student& s) {
        if (this != &s) {
            id = s.id;
            strcpy(name, s.name);
            delete[] grades;
            size = s.size;
            grades = new float[size];
            for (int i = 0; i < size; i++)
                grades[i] = s.grades[i];
        }
        return *this;
    }

    // cast to char
    operator char*() {
        return name;
    }

    operator int*() {
        int* intGrades = new int[size]; 
        
        for(int i = 0; i < size; i++) {
            intGrades[i] = (int)grades[i];
        }
        
        return intGrades;
    }

    // obj + number
    Student operator+(int n) {
        Student temp = *this;
    
        for (int i = 0; i < size; i++) {
            temp.grades[i] += n; 
        }
        
        return temp; 
    }

    // friend number + obj
    friend Student operator+(int n, Student s) {
        Student temp = s; 
        for (int i = 0; i < temp.size; i++) {
            temp.grades[i] += n;
        }
        
        return temp;
    }

    // destructor
    ~Student() {
        delete[] grades;
        count--;
    }
};
int Student :: count=0;

int main()
{
    float aliGrades[] = {1,2,3,4,5};

    Student s1;
    Student s2((char*)"Ali");
    Student s3(2, (char*)"ghada");
    Student s4(1, (char*)"Ali", aliGrades);  
    s4.printStudent();
    s4++;     
    s4.printStudent();
    cout<<"-------------------"<<endl;
    ++s4;        
    s4.printStudent();
    cout<<"-------------------"<<endl;
    s1=s1+s2;
    s1.printStudent();
    cout<<"-------------------"<<endl;
    cout<<"the value of equalty :"<<(s1==s2)<<endl;
    cout<<"-------------------"<<endl;
    s1=s2;
    s1.printStudent();
    cout<<"-------------------"<<endl;
    char* studentName = (char*) s4;
    cout << "Student Name: " << studentName << endl;
    cout<<"-------------------"<<endl;
    int* integerGrades = (int*) s4;
    cout << "Integer Grades: ";
    for(int i=0; i < 5; i++) {
        cout << integerGrades[i] << " ";
    }
    cout << endl;
    cout<<"-------------------"<<endl;
    s1=s1+1;
    s1.printStudent();
    cout<<"-------------------"<<endl;
    s1=1+s1;
    s1.printStudent();
    cout<<"-------------------"<<endl;
    cout<<Student::getcount();

    return 0;
}