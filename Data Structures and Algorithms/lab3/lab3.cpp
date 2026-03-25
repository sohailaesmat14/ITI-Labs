#include <iostream>
using namespace std;

struct Node {
    int data;
    Node *left, *right;
    Node(int val) {
        data = val;
        left = right = nullptr;
    }
};

Node* insert(Node* root, int val) {
    if (root == nullptr) return new Node(val);
    if (val < root->data) 
        root->left = insert(root->left, val);
    else 
        root->right = insert(root->right, val);
    return root;
}

void preorder(Node* root) {
    if (root == nullptr) return;
    cout << root->data << " ";
    preorder(root->left);
    preorder(root->right);
}

void inorder(Node* root) {
    if (root == nullptr) return;
    inorder(root->left);
    cout << root->data << " ";
    inorder(root->right);
}

void postorder(Node* root) {
    if (root == nullptr) return;
    postorder(root->left);
    postorder(root->right);
    cout << root->data << " ";
}

int main() {
    Node* root = nullptr;
    int values[] = {50, 30, 70, 20, 40, 60, 80};

    for(int x : values) {
        root = insert(root, x);
    }

    cout << "Preorder (Root-L-R):  ";
    preorder(root);
    cout << "\n\nInorder (L-Root-R):   ";
    inorder(root);
    cout << "\n\nPostorder (L-R-Root): ";
    postorder(root);
    cout << endl;

    return 0;
}