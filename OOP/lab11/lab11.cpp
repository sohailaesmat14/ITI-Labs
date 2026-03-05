#include<iostream>
using namespace std;

class Shape{
    protected:
        int dim1,dim2;
    public:
        Shape(){
            dim1=dim2=0;
        }
        Shape(int m){
            dim1=dim2=m;
        }
        Shape(int m , int n){
            dim1=m;
            dim2=2;
        }

        void setDim1(int m){
             dim1=m;
        }
        void setDim2(int n){
             dim2=n;
        }

        int getDim1(){
            return dim1;
        }
        int getDim2(){
            return dim2;
        }
        virtual float Area()=0;
};

class circle : public Shape {
    public:
        circle(){}
        circle(int n):Shape(n){ }
        float Area(){
            return (3.14*dim1*dim2);
        }
};

class Rectangle :public Shape {
    public:
        Rectangle(){ }
        Rectangle(int l , int w):Shape(l,w){ }
        float Area(){
            return (1.0*dim1*dim2);
        }
};

class Trinagle :public Shape {
    public:
        Trinagle(){ }
        Trinagle(int b , int h):Shape(b,h){ }
        float Area(){
            return (0.5*dim1*dim2);
        }
};

class Square : public Rectangle{
    public:
        Square (){ }
        Square (int s):Rectangle(s,s){ }
};

class geoShape{
    Shape *ptr[4];
    public:
        geoShape(Shape *p1 , Shape *p2 , Shape *p3 , Shape *p4){
            ptr[0]=p1;
            ptr[1]=p2;
            ptr[2]=p3;
            ptr[3]=p4;
        }
        float totalArea(){
            float sum =0;
            for (int i=0;i<4;i++){
                sum+=ptr[i]->Area();
            }
            return sum;
        }
};

int main(){
    circle c(7);
    Rectangle r(20,5);
    Trinagle t(10,20);
    Square s(6);
    geoShape g (&c,&r,&t,&s);
    cout<<"Total area is :"<<g.totalArea()<<endl;
    return 0;
}