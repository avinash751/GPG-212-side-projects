using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BST : MonoBehaviour
{
    [SerializeField] int[] RandomArray = new int[30];
    void Start()
    {
        FillRandomArray(RandomArray);
        BubbleSortArrayInDescendingOrder(RandomArray);
        Debug.Log("Index of Random Selected Number is " + FindIndexOfRandomNumberInArray(RandomArray));
    }

    void FillRandomArray(int[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(0, array.Length + 1);
        }
    }

    void BubbleSortArrayInDescendingOrder(int[]array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[i]> array[j])
                {
                    var tempNum = array[i];
                    array[i] = array[j];
                    array[j] = tempNum;
                }
            }
        }
    }

    int SelectARandomNumberFromArray(int[] array)
    {
        int targetnum = Random.Range(0, array.Length + 1);
        Debug.Log("Selected Number To Search " + targetnum);
        return targetnum;
    }

    int FindIndexOfRandomNumberInArray(int[] array) // binary search tree code 
    {
        int targetnum = SelectARandomNumberFromArray(array);
        int start = 0;
        int end = array.Length - 1;
        int middle =0;

        if (array[start] == targetnum) { return start; }
        else if (array[end] == targetnum) { return end; }


        while ( start -end !=-1)
        {
            middle = (start + end)/2;

            if (array[middle] == targetnum) { return middle; }
            else if(array[middle] > targetnum) { end= middle; }
            else if(targetnum> array[middle]) { start= middle; }  
        }
        if(targetnum == array[start]) { return start; }
        return -1;
    }

   
}
