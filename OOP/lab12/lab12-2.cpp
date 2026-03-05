#include <iostream>
#include <fstream>

using namespace std;

int main() {
    char text[] = "Hello World";

    ofstream outFile("data.bin", ios::binary);
    outFile.write(text, sizeof(text));
    outFile.close();

    char loadedText[100];

    ifstream inFile("data.bin", ios::binary);
    inFile.read(loadedText, sizeof(text));
    inFile.close();

    cout << loadedText << endl;

    return 0;
}