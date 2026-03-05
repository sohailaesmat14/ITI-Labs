#include <iostream>
#include <cmath>
using namespace std;

class Point{
    int x,y;

    public:
    //constructors
        Point(){
            x=y=0;
        }
        Point(int m){
            x=y=m;
        }
        Point(int m,int n){
            x=m;
            y=n;
        }

    //setters
        void setX(int m){
            x=m;
        }
        void setY(int n){
            y=n;
        }

    //getters
        int getX(){return x;}
        int getY(){return y;}
        
};
//composition
// class Rectangle_c{
//     Point pt1,pt2;
//     int length,width;

//     public:
//     //constructors
//         Rectangle_c(int x1,int y1,int x2,int y2):pt1(x1,y1),pt2(x2,y2){
//             length = abs(x2-x1);
//             width  = abs(y2-y1);
//         }

//     //setters
//         void setP1(int x , int y){
//             pt1.setX(x);
//             pt1.setY(y);
//             length = abs(pt2.getX()-x);
//             width = abs(pt2.getY()-y);
//         }
//         void setP2(int x , int y){
//             pt2.setX(x);
//             pt2.setY(y);
//             length = abs(x-pt1.getX());
//             width = abs(y-pt1.getY());
//         }

//     //getters
//     Point getPt1(){return pt1;}
//     Point getPt2(){return pt2;}

//     //methods
//     int area(){
//         return (length*width);
//     }
// };

class Rectangle_a{
    Point *pt1,*pt2;
    int length,width;

    public:
    //constructors
    Rectangle_a(){
        pt1=pt2=NULL;
        length=width=0;
    }
    Rectangle_a(Point *pa , Point *pb){
        pt1=pa;
        pt2=pb;
        if(pt1!=NULL && pt2!=NULL){
        length = abs(pt2->getX()-pt1->getX());
        width = abs(pt2->getY()-pt1->getY());
        }
        else{
            length=width=0;
        }
    }

    //setters
    void setP1(Point *pt){
        pt1=pt;
        if(pt1!=NULL && pt2!=NULL){
        length = abs(pt2->getX()-pt1->getX());
        width = abs(pt2->getY()-pt1->getY());
        }
        else{
            length=width=0;
        }
    }
    void setP2(Point *pt){
        pt2=pt;
        if(pt1!=NULL && pt2!=NULL){
        length = abs(pt2->getX()-pt1->getX());
        width = abs(pt2->getY()-pt1->getY());
        }
        else{
            length=width=0;
        }
    }

    //methods
    int area(){
        return (length*width);
    }
    
};

int main(){
    //Rectangle_c rect(10,20,50,80);
    Rectangle_a rect;
    Point pa (50,10);
    Point pb (80,20);

    rect.setP1(&pa);
    rect.setP2(&pb);
    cout<<rect.area();
}