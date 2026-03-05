#include <iostream>
using namespace std;

class Base {
protected:
    int z;
public:
    Base() { 
        z = 0; 
    }
    Base(int m) { 
        z = m; 
    }
    void SetZ(int m) { 
        z = m; 
    }
    int GetZ() { 
        return z; 
    }
};

class Base1 : virtual public Base {
protected:
    int x;
public:
    Base1() { 
        x = 0; 
    }
    Base1(int m) : Base(m) { 
        x = m; 
    }
    void SetX(int m) { 
        x = m; 
    }
    int GetX() { 
        return x; 
    }
};

class Base2 : virtual public Base {
protected:
    int y;
public:
    Base2() { 
        y = 0; 
    }
    Base2(int m) : Base(m) { 
        y = m; 
    }
    void SetY(int m) { 
        y = m; 
    }
    int GetY() { 
        return y; 
    }
};

class Derived : public Base1, public Base2 {
public:
    Derived(int m, int n) : Base2(m), Base1(n) {
    }

    int Product() {
        return (x * y * z);
    }

    int Sum() {
        return (x + y);
    }
};

int main() {
    Derived drv(3, 4); 
    

    cout << "Product: " << drv.Product() << endl;
    cout << "Sum: " << drv.Sum() << endl;

    return 0;
}