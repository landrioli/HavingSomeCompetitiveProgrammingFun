using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    //https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
    //Formulas to rotate array:
    //  - RIGHT: (i + NumbRotation) % nums.length
    //  - LEFT: i + (lengthOfArray - shiftAmount)) % lengthOfArray
    class RotateLeft
    {
        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            int[] temp = new int[a.Length];
            Array.Copy(a, temp, a.Length);

            for (int i = 0; i < a.Length; i++)
            {
                int newLocation = (i - d + a.Length) % a.Length;
                a[newLocation] = temp[i];
            }
            return a;
            //Brute Force for Right Rot
            //for (int i = 0; i < remainingChanges; i++)
            //{
            //    int tempFistValue = a[0];
            //    for (int j = 0; j < a.Length - 1; j++)
            //    {
            //        a[j] = a[j + 1];
            //    }
            //    a[a.Length -1] = tempFistValue;
            //}
            //return a;
        }
    }
}
