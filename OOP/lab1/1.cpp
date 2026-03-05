#include <iostream>
using namespace std;

int main() {
    double depth, celsius, fahrenheit;

    cout << "Enter depth inside the Earth in kilometers : ";
    cin >> depth;

    celsius = 10 * depth + 20;
    fahrenheit = 1.8 * celsius + 32;

    cout << "Temperature at " << depth << endl;
    cout << "Celsius: " << celsius << endl;
    cout << "Fahrenheit: " << fahrenheit << endl;

    return 0;
}

