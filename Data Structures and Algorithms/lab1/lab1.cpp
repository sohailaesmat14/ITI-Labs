#include <iostream>
#include <string>

using namespace std;

struct Student {
    int id;
    string name;
};

struct Node {
    Student data;
    Node* next;
    Node* prev;
};

class StudentList {
private:
    Node* head;
    Node* tail;

public:
    StudentList() {
        head = NULL;
        tail = NULL;
    }

    void addStudent(int id, string name) {
        Node* newNode = new Node();
        newNode->data.id = id;
        newNode->data.name = name;
        newNode->next = NULL;
        newNode->prev = NULL;

        if (head == NULL) {
            head = tail = newNode;
        } else {
            tail->next = newNode;
            newNode->prev = tail;
            tail = newNode;
        }
    }

    void insertInLocation(int position, int id, string name) {
        Node* newNode = new Node();
        newNode->data.id = id;
        newNode->data.name = name;

        if (position == 0) {
            if (head == NULL) {
                head = tail = newNode;
                newNode->next = newNode->prev = NULL;
            } else {
                newNode->next = head;
                head->prev = newNode;
                head = newNode;
                newNode->prev = NULL;
            }
            return;
        }

        Node* temp = head;
        for (int i = 0; i < position - 1 && temp != NULL; i++) {
            temp = temp->next;
        }

        if (temp == NULL) {
            cout << "Position out of range!\n";
            return;
        }

        if (temp == tail) {
            addStudent(id, name);
            return;
        }

        newNode->next = temp->next;
        newNode->prev = temp;
        
        if (temp->next != NULL) {
            temp->next->prev = newNode;
        }
        temp->next = newNode;
    }

    void searchById(int id) {
        Node* temp = head;
        bool found = false;

        while (temp != NULL) {
            if (temp->data.id == id) {
                cout << "Found Student: " << temp->data.name << endl;
                found = true;
                break;
            }
            temp = temp->next;
        }

        if (!found) {
            cout << "Student with ID " << id << " not found!" << endl;
        }
    }

    void display() {
        Node* temp = head;
        while (temp != NULL) {
            cout << temp->data.id << ": " << temp->data.name << endl;
            temp = temp->next;
        }
    }
};

int main() {
    StudentList list;

    list.addStudent(1, "Ahmed");
    list.addStudent(2, "Mohamed");
    
    list.insertInLocation(1, 3, "Ali");

    list.display();

    list.searchById(2);
    list.searchById(10);

    return 0;
}