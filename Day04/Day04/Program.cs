﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Day04
{

    internal class Program
    {

        static void BubbleSort(List<string> A)
        {
            int n = A.Count;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i <= n-1; i++)
                {
                    if (A[i-1].CompareTo(A[i]) > 0)
                    {
                        string temp = A[i-1];
                        A[i-1] = A[i];
                        A[i] = temp;
                        swapped = true;
                    }
                }
                n = n - 1;
            } while (swapped);
        }

        static void Recur(int N)
        {
            Console.WriteLine(N);
            Recur(N+1);
        }
        static void Main(string[] args)
        {
            //Recur(5);
            string s1 = "Batman", s2 = "Aquaman";
            //CompareTo, or Compare
            // returns...
            // -1  LESS THAN
            //  0  EQUAL TO
            //  1  GREATER THAN
            int compareResult = s1.CompareTo(s2);
            if(compareResult == 0)
                Console.WriteLine($"{s1} EQUALS {s2}");
            else if(compareResult < 0)
                Console.WriteLine($"{s1} LESS THAN {s2}");
            else if (compareResult > 0)
                Console.WriteLine($"{s1} GREATER THAN {s2}");
            /*
                ╔═══════╗ 
                ║Sorting║
                ╚═══════╝ 
             
                Sorting is used to order the items in a list/array is a specific way
             
                CHALLENGE 1:

                    Convert this BubbleSort pseudo-code into a C# method             
                     
                    procedure bubbleSort(A : list of sortable items)
                      n := length(A)
                      repeat
                          swapped := false
                          for i := 1 to n - 1 inclusive do
                              if A[i - 1] > A[i] then
                                  swap(A, i - 1, i)
                                  swapped = true
                              end if
                          end for
                          n := n - 1
                      while swapped
                    end procedure
                    
            */


            List<string> A = new() { "Wonder Woman", "Batman", "Superman", "Flash", "Aquaman", "Blue Beetle", "Lobo" };
            //call your bubble sort method and pass the list to it
            //print the list after calling the method to prove it was sorted
            Console.WriteLine("___UNSORTED___");
            foreach (string s in A) Console.WriteLine(s);
            BubbleSort(A);
            Console.WriteLine("___SORTED___");
            foreach (string s in A) Console.WriteLine(s);
            Console.ReadKey();




            /*
                ╔═════════╗ 
                ║Recursion║
                ╚═════════╝ 
             
                Recursion happens when a method calls itself. This creates a recursive loop.
                
                All recursive methods need an exit condition, something that prevents the loop from continuing.
              
            */
            int N = 0;
            //RecursiveLoop(N);
            Console.ResetColor();


            /*
                CHALLENGE 2:

                    convert this for loop to a recursive method called Bats. Call Bats here in Main.
             
                    for(int i = 0;i < 100;i++)
                    {
                        Console.Write((char)78);
                        Console.Write((char)65);
                        Console.Write(' ');
                    }
            */

            //
            //call Bats here
            //
            Bats();
            Console.WriteLine();
            List<int> b = new() { 66, 65, 84, 77, 65, 78, 33, 33 };
            foreach (var item in b) Console.Write((char)item);
            Console.WriteLine();



        }

        static void Bats(int i = 0)
        {
            if(i < 100)
            {
                Console.Write((char)78);
                Console.Write((char)65);
                Console.Write(' ');
                Bats(i+1);
            }
        }


        static void RecursiveLoop(int N)
        {
            //an Exit Condition. This will stop the loop when N >= Console.WindowWidth
            //if (N == Console.WindowWidth) return;
            if (N < Console.WindowWidth)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(' ');
                Thread.Sleep(20);

                RecursiveLoop(N + 1);//calls itself which makes the method recursive

                Thread.Sleep(20);
                Console.CursorLeft = N;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(' ');
            }
        }
    }
}
