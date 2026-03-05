#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main() {
    ofstream outFile("my_text.txt"); 
    outFile << "Hello, this is line 1." << endl;
    outFile.close();

    cout << "----------------------" << endl;

    ifstream inFile("my_text.txt");
    string line;

    while (getline(inFile, line)) {
        cout << line << endl;
    }
    inFile.close();
    
    return 0;
}