using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort 
{
    public class MergeSortClass
    {

        private T[] Merge<T>(T[] leftArray, T[] rightArray) where T : IComparable<T>
        {
            int newSize = leftArray.Length + rightArray.Length;
            T[] mergedArray = new T[newSize];


            int leftIndex = 0;
            int rightIndex = 0;
            int indexCount = 0;
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                {
                    mergedArray[indexCount] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[indexCount] = rightArray[rightIndex];
                    rightIndex++;
                }

                indexCount++;
            }

            while (leftIndex < leftArray.Length)
            {
                mergedArray[indexCount] = leftArray[leftIndex];
                leftIndex++;
                indexCount++;
            }
            while (rightIndex < rightArray.Length)
            {
                mergedArray[indexCount] = rightArray[rightIndex];
                rightIndex++;
                indexCount++;
            }

            return mergedArray;
        }

        public T[] MergeSort<T>(T[] unsortedCollection) where T : IComparable<T>
        {
            if (unsortedCollection.Length == 1)
            {
                return unsortedCollection;
            }

            int halfIndex = unsortedCollection.Length / 2;
            T[] leftHalf = new T[halfIndex];
            T[] rightHalf = new T[unsortedCollection.Length - halfIndex];

            for (int i = 0; i < unsortedCollection.Length; i++)
            {
                if (i < halfIndex)
                {
                    leftHalf[i] = unsortedCollection[i];
                }
                else
                {
                    rightHalf[i - halfIndex] = unsortedCollection[i];
                }
                
            }

            return Merge(MergeSort(leftHalf), MergeSort(rightHalf));
            
        }
    }
}
