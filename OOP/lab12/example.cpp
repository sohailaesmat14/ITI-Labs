#include <iostream>
#include <fstream>
using namespace std;

class Client {
    int id;
    double balance;
public:
    Client() { id = 0; balance = 0; }
    Client(int i, double b) { id = i; balance = b; }

    // دوال مساعدة عشان نعرف نطلع البيانات ونكتبها
    int getId() { return id; }
    double getBalance() { return balance; }

    void showData() {
        cout << "Client ID: " << id << "\t Balance: " << balance << endl;
    }
};

int main() {
    // ---------------------------------------------------------
    // الجزء الأول: الكتابة في ملف نصي (Text File)
    // ---------------------------------------------------------
    
    // 1. تجهيز البيانات
    Client data[3] = {
        Client(101, 5000.5),
        Client(102, 1200.0),
        Client(103, 8500.75)
    };

    // 2. فتح الملف (لاحظي الامتداد .txt ومفيش binary)
    ofstream outFile("bank_data.txt");

    if (!outFile) {
        cout << "Error opening file for writing!" << endl;
        return 1;
    }

    // 3. الكتابة باستخدام <<
    cout << "Writing data to bank_data.txt..." << endl;
    for(int i=0; i<3; i++) {
        // بنكتب الـ ID وبعدين مسافة وبعدين الرصيد وبعدين سطر جديد
        outFile << data[i].getId() << " " << data[i].getBalance() << endl;
    }

    outFile.close(); 
    cout << "Data saved successfully! You can open the file now.\n" << endl;


    // ---------------------------------------------------------
    // الجزء التاني: القراءة من ملف نصي
    // ---------------------------------------------------------
    
    ifstream inFile("bank_data.txt");
    
    if (!inFile) {
        cout << "Error opening file for reading!" << endl;
        return 1;
    }

    int tempId;
    double tempBalance;
    
    cout << "--- Reading File Content ---" << endl;
    
    // 4. القراءة باستخدام >> (بيسحب كلمة كلمة)
    // اللوب دي معناها: طول ما أنت ناجح إنك تقرا ID و Balance كمل شغل
    while (inFile >> tempId >> tempBalance) {
        // بنحط البيانات في كائن جديد عشان نعرضها
        Client temp(tempId, tempBalance);
        temp.showData();
    }

    inFile.close();
    return 0;
}