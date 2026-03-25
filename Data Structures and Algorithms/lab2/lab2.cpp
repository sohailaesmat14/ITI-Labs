#include <iostream>
using namespace std;

// Node structure for the Stack
struct Node {
    int data;
    Node* next;
};

class MyStack {
    Node* top;

public:
    MyStack() {
        top = NULL;
    }

    bool Push_data(int val) {
        Node* newNode = new Node();
        if (!newNode) { 
            cout << "Heap Overflow" << endl;
            return false;
        }
        newNode->data = val;
        newNode->next = top;
        top = newNode;
        
        cout << "Pushed: " << val << endl;
        return true;
    }

    bool Pop_data() {
        if (top == NULL) {
            cout << "stack is empty" << endl;
            return false;
        }
        
        Node* temp = top;
        int poppedVal = top->data;
        top = top->next;
        delete temp; // Free memory

        cout << "Popped: " << poppedVal << endl;
        return true;
    }
};

class MyQueue {
    int rear;
    int size;
    int arr[5];

public:
    MyQueue() {
        rear = -1; 
        size = 5;
    }

    bool insert_data(int val) {
        if (rear == size - 1) {
            cout << "queue is full" << endl;
            return false;
        }

        rear++;
        arr[rear] = val;
        cout << "Inserted: " << val << endl;
        return true;
    }

    bool delete_data() {
        if (rear == -1) {
            cout << "Queue is empty" << endl;
            return false;
        }

        cout << "Deleted: " << arr[0] << endl;
        for (int i = 0; i < rear; i++) {
            arr[i] = arr[i + 1];
        }

        rear--; 
        return true;
    }
};

int main() {
    cout << "--- Stack ---" << endl;
    MyStack s;
    s.Pop_data(); 
    s.Push_data(10);
    s.Push_data(20);
    s.Pop_data(); 

    cout << "\n--- Queue ---" << endl;
    MyQueue q;
    q.insert_data(1);
    q.insert_data(2);
    q.insert_data(3);
    q.insert_data(4);
    q.insert_data(5);  
    q.insert_data(6);
    q.delete_data(); 
    q.insert_data(6);

    return 0;
}