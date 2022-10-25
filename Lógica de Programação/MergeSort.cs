using System;

void mergeSort(
    int[] arr, int[] arraux, 
    int s, int e
    )
{
    if (e - s < 2)
        return;
    int p = (s + e) / 2;
    mergeSort(arr, arraux, s, p);
    mergeSort(arr, arraux, p, e);
    merge(arr, arraux, s, p , e);
}


void merge(
    int[] arr, int[] arraux, 
    int s, int p, int e
    )
{
    int i = s, j = p, index = s;
    while (i < p && j < e)
    {
        if (arr[i] < arr[j]) {
            arraux[index] = arr[i];
            i++;
        } else {
            arraux[index] = arr[j];
            j++;
        }
        index++;
    }
    
    while (i < p)
    {
        arraux[index] = arr[i];
        i++;
        index++;
    }

    while (j < e)
    {
        arraux[index] = arr[j];
        j++;
        index++;
    }

    for (int t = s; t < e; t++)
    {
        arr[t] = arraux[t];
    }
}




int[] arr = new int[]
    { 1, 8, 2, 9, 3, 37 };


int e = arr.Length;
int[] arraux = new int[e];
mergeSort(arr, arraux, 0, e);

foreach (var item in arr[..^1])
{
    Console.Write($"{item}, ");
}
Console.Write($"{arr[arr.Length - 1]}");