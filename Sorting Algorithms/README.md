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

```
***
5. **Quick** Sort (Pivot point)  ==================== O(n log(n)) - O(n^2) Time and O(log(n)) ============

[![Video Explaination for Merge Sort](http://img.youtube.com/vi/SLauY6PpjW4/0.jpg)](https://www.youtube.com/watch?v=SLauY6PpjW4)
```cs

```
