#include<iostream>
using namespace std;

// BubbleSort
void BubbleSort(int arr[], int size) {
    int i, j, temp;
    for(i = 0; i < size - 1; i++) {
        for(j = 0; j < size - 1; j++) {
            if(arr[j] > arr[j + 1]) {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

void merge(int arr[], int start, int mid, int end) {
    int Temp[100];
    int list1 = start;
    int list2 = mid + 1;
    int i = start;

    while(list1 <= mid && list2 <= end) {
        if(arr[list1] < arr[list2]) {
            Temp[i] = arr[list1];
            list1++; 
            i++;
        } else {
            Temp[i] = arr[list2];
            list2++; 
            i++;
        }
    }

    if(list1 <= mid) {
        while(list1 <= mid) {
            Temp[i] = arr[list1];
            list1++; 
            i++;
        }
    } else {
        while(list2 <= end) {
            Temp[i] = arr[list2];
            list2++; 
            i++;
        }
    }

    for(i = start; i <= end; i++) {
        arr[i] = Temp[i];
    }
}

// mergeSort
void mergeSort(int arr[], int start, int end) {
    if (start < end) {
        int mid = (start + end) / 2;
        mergeSort(arr, start, mid);
        mergeSort(arr, mid + 1, end);
        merge(arr, start, mid, end);
    }
}


int partition(int arr[], int start, int end) {
    int pivot = arr[end];
    int i = (start - 1);

    for (int j = start; j <= end - 1; j++) {
        if (arr[j] < pivot) {
            i++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    int temp = arr[i + 1];
    arr[i + 1] = arr[end];
    arr[end] = temp;
    return (i + 1);
}

// quickSort
void quickSort(int arr[], int start, int end) {
    if (start < end) {
        int pi = partition(arr, start, end);
        quickSort(arr, start, pi - 1);
        quickSort(arr, pi + 1, end);
    }
}

void printArray(int arr[], int size) {
    for (int i = 0; i < size; i++)
        cout << arr[i] << " ";
    cout << endl;
}

int main (){
    int arr1[] = {64, 34, 25, 12, 22};
    cout << "Original array 1: "; printArray(arr1, 5);
    BubbleSort(arr1, 5);
    cout << "After Bubble Sort: "; printArray(arr1, 5);
    cout << "-------------------" << endl;

    int arr2[] = {38, 27, 43, 3, 9};
    cout << "Original array 2: "; printArray(arr2, 5);
    mergeSort(arr2, 0, 4);
    cout << "After Merge Sort: "; printArray(arr2, 5);
    cout << "-------------------" << endl;

    int arr3[] = {10, 7, 8, 9, 1};
    cout << "Original array 3: "; printArray(arr3, 5);
    quickSort(arr3, 0, 4);
    cout << "After Quick Sort: "; printArray(arr3, 5);

    return 0;
}