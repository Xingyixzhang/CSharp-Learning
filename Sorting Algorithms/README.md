## Sorting Algorithms --
1. **Insertoin** Sort (Move to Insert)  ================== O(n) - O(n^2) Time and O(1) Space. =================

[![Video Explaination for Insertion Sort](http://img.youtube.com/vi/OGzPmgsI-pQ/0.jpg)](http://www.youtube.com/watch?v=OGzPmgsI-pQ)
```cs
void InsertionSort(int[] arr){
  int j, temp;
  for (int i = 1, i < arr.Length; i++){
    temp = arr[i];
    j = i - 1;
    while (j >= 0 && arr[j] > temp){
      arr[j + 1] = arr[j];
      j--;
    }
    arr[j + 1] = temp;
  }
}
```
***
2. **Selection** Sort (Find min and Swap) ================== O(n^2) Time and O(1) Space. =================

[![Video Explaination for Selection Sort](http://img.youtube.com/vi/xWBP4lzkoyM/0.jpg)](http://www.youtube.com/watch?v=xWBP4lzkoyM)
```cs
void SelectionSort(int[] arr){
  int n = arr.Length;
  for (int i = 0; i < n; i++){
    int min_index = i;
    for (int j = i+1; j < n; j++){
      if (arr[j] < arr[min_index])  min_index = j;
    }
    // Swap arr[min_index] and arr[i]:
    int temp = arr[min_index];
    arr[min_index] = arr[i];
    arr[i] = temp;
  }
}
```
***
3. **Bubble** Sort (Compare and Swap)  ================== O(n) - O(n^2) Time and O(1) Space. =================

[![Video Explaination for Selection Sort](http://img.youtube.com/vi/nmhjrI-aW5o/0.jpg)](http://www.youtube.com/watch?v=nmhjrI-aW5o)
```cs
void BubbleSort(int[] arr){
  int n = arr.Length;
  for (int i = 0; i < n-1; i++)
    // since we found the max for each turn, those positions are set without further consideration
    for (int j = 0; j < n-i-1; j++)
      if (arr[j] > arr[j + 1]){
        // Swap arr[j] and arr[j + 1]
        int temp = arr[j+1];
        arr[j+1] = arr[j];
        arr[j] = temp;
      }
}
```
***
4. **Merge** Sort (Divide and Merge)  ==================== O(n log(n)) Time and O(n) Space. ==============

[![Video Explaination for Merge Sort](http://img.youtube.com/vi/KF2j-9iSf4Q/0.jpg)](https://www.youtube.com/watch?v=KF2j-9iSf4Q)
```cs
private static void MergeSort(int[] arr, int left, int right){
  if (left >= right)  return;
  int middle = (left + right) / 2;
  MergeSort(arr, left, middle);
  MergeSort(arr, middle + 1, right);
  Merge(arr, left, middle, right);
}

private static void Merge(int[] arr, int left, int middle, int right){
  int leftLen = middle - left + 1;
  int rightLen = right - middle;
  
  int[] leftArr = new int[leftLen];
  int[] rightArr = new int[rightLen];
  
  for (int i = 0; i < leftLen; i++){
    leftArr[i] = arr[left + i];
  }
  for (int i = 0; i < rightLen; i++){
    rightArr[i] = arr[middle + 1 + i];
  }
  
  int i = 0, j = 0, k = left;
  
  while (i < leftLen && j < rightLen){
    if (leftArr[i] < rightArr[j]){
      arr[k] = leftArr[i];
      i++;
    }
    else{
      arr[k] = rightArr[j];
      j++;
    }
    k++;
  }
  
  while (i < leftLen) {
    arr[k] = leftArr[i];
    i++;  k++;
  }
  
  while (j < rightLen) {
    arr[k] = rightArr[j];
    j++;  k++;
  }
}
```
***
5. **Quick** Sort (Pivot point)  ==================== O(n log(n)) - O(n^2) Time and O(log(n)) ============

[![Video Explaination for Merge Sort](http://img.youtube.com/vi/SLauY6PpjW4/0.jpg)](https://www.youtube.com/watch?v=SLauY6PpjW4)
```cs
private static void QuickSort(int[] arr, int left, int right){
  if (left >= right)  return;
  int pivot = arr[(left + right) / 2];
  int index = Partition(arr, left, right, pivot);
  QuickSort(arr, left, index - 1);
  QuickSort(arr, index, right);
}

private static int Partition(int[] arr, int left, int right, int pivot){
  while (left <= right){
    while (arr[left] < pivot) left++;
    while (arr[right] > pivot)  right--;
    if (left <= right){
      int temp = arr[right];
      arr[right] = arr[left];
      arr[left] = temp;
      left++;   right--;
    }
  }
  return left;
}
```

[**Sorting Algorithms and Data Structures Big O Notation Cheat Sheet**](https://cooervo.github.io/Algorithms-DataStructures-BigONotation/index.html)
