﻿// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

Console.WriteLine("Updating to test in github update.");

int[][] points = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {1, 5, 1},
            new int[] {3, 1, 1}
        };

        long result = MaxPoints(points);

        Console.WriteLine("Max Points: " + result);


/*
You can see that int:
°° Is defined using the struct keyword.
°° Is in the System.Runtime assembly.
°° Is in the System namespace.
°° Is named Int32.
°° Is therefore an alias for the System.Int32 type.
°° Implements interfaces such as IComparable.
°° Has constant values for its maximum and minimum values.
°° Has methods like Parse.*/

     long MaxPoints(int[][] points) {
         int m = points.Length;
        int n = points[0].Length;
        long[] prevRow = new long[n];

     
        for (int c = 0; c < n; c++)
        {
            prevRow[c] = points[0][c];
        }

     
        for (int r = 1; r < m; r++)
        {
            long[] left = new long[n];
            long[] right = new long[n];
            long[] currRow = new long[n];

           
            left[0] = prevRow[0];
            for (int c = 1; c < n; c++)
            {
                left[c] = Math.Max(left[c - 1] - 1, prevRow[c]);
            }

           
            right[n - 1] = prevRow[n - 1];
            for (int c = n - 2; c >= 0; c--)
            {
                right[c] = Math.Max(right[c + 1] - 1, prevRow[c]);
            }

       
            for (int c = 0; c < n; c++)
            {
                currRow[c] = points[r][c] + Math.Max(left[c], right[c]);
            }

         
            prevRow = currRow;
        }

       
        long maxPoints = prevRow.Max();
        return maxPoints;
    }