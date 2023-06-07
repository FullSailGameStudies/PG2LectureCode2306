using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        enum Weapon
        {
            Sword, Axe, Spear, Mace
        }
        static void Main(string[] args)
        {
            /*
                ╔═════════╗ 
                ║Searching║
                ╚═════════╝ 
             
                There are 2 ways to search a list: linear search or binary search
             
                CHALLENGE 1:

                    Convert Linear Search algorithm into a method. 
                        The method should take 2 parameters: 
                            list of ints to search
                            int to search for.
                        The method should return -1 if NOT found or the index if found.
                     
                    The algorithm:
                        1) start at the beginning of the list
                        2) compare each item in the list to the search item
                        3) if found, return the index
                        4) if reach the end of the list, return -1 which means not found
                    
            */
            List<int> nums = new List<int>() { 1, 2, 420, 3, 4, 5};//N = 6 O(N)
            int numberToFind = 1000;
            int foundIndex = LinearSearch(nums, numberToFind);
            if(foundIndex == -1) Console.WriteLine($"{numberToFind} was NOT found.");
            else                 Console.WriteLine($"{numberToFind} was found at index {foundIndex}.");


            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 
                
                [  Creating a Dictionary  ]
                
                Dictionary<TKey, TValue>  - the TKey is a placeholder for the type of the keys. TValue is a placeholder for the type of the values.
                
                When you want to create a Dictionary variable, replace TKey with whatever type of data you want to use for the keys and
                replace TValue with the type you want to use for the values.

            */

            Dictionary<Weapon, int> backpack = new Dictionary<Weapon, int>();//will store the counts of each kind of weapon

            Dictionary<string, float> menu = new()
            {
                //{ key, value }  key-value-pair
                { "Beef Wellington", 28.99F },
                { "NY Strip", 18.99F },
                { "Crunchy Roll", 9.99F }
            };
            menu.Add("Quarter Pounder", 5.63F);
            menu.Add("Belgian Waffles", 12.99F);

            menu["Hawaiian Pizza"] = 19.99F;
            menu["Lobster Pomodore"] = 59.99F;


            /*  
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 


                [  Adding items to a Dictionary  ]

                There are 3 ways to add items to a Dictionaruy:
                1) on the initializer. 
                2) using the Add method. 
                3) using [key] = value
            */
            backpack = new Dictionary<Weapon, int>()
            {
                {Weapon.Sword, 5 }
            };
            backpack.Add(Weapon.Axe, 2);
            backpack[Weapon.Spear] = 1;

            List<string> students = new() { "Jessica", "Jasen", "Paulo", "Christian", "Daniel", "Anthony", "Mackenzie", "Ryan", "Elijah", "Tyler", "ZaMere", "Xavier",
            "Jose", "Jack", "Raul", "Dillon", "David", "Damien", "Kenya", "James", "Saul"};

            Dictionary<string, double> grades = new()
            {
                {"Bruce", 100 },
                {"Clark", 90 },
                {"Arthur", 35 }
            };
            Random rando = new();
            foreach (string student in students)
            {
                grades.Add(student, rando.NextDouble() * 100);
            }
            /*
                CHALLENGE 2:

                    Create a Dictionary that stores names (string) and grades. 
                    Call the variable grades.
             
            */
            /*
                CHALLENGE 3:

                    Add students and grades to your dictionary that you created in CHALLENGE 2.
             
            */






            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Looping over a Dictionary  ]

                You should use a foreach loop when needing to loop over the entire dictionary.
               
            */
            foreach (KeyValuePair<Weapon,int> weaponCount in backpack)
                Console.WriteLine($"You have {weaponCount.Value} {weaponCount.Key}");

            Console.OutputEncoding = Encoding.UTF8;
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            
            Console.WriteLine(" Welcome to Applebees ");
            foreach (KeyValuePair<string,float> menuItem in menu)
            {
                float price = menuItem.Value;
                string name = menuItem.Key;
                Console.WriteLine($"{price,8:C2} {name}");
            }


            /*
                CHALLENGE 4:

                    Loop over your grades dictionary and 
                    print each student name and grade.
             
            */
            PrintGrades(grades);





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Checking for a key in a Dictionary  ]

                There are 2 ways to see if a key is in the dictionary:
                1) ContainsKey(key)
                2) TryGetValue(key, out value)
               
            */            
            if(backpack.ContainsKey(Weapon.Axe))
                Console.WriteLine($"{Weapon.Axe} count: {backpack[Weapon.Axe]}");

            if(backpack.TryGetValue(Weapon.Spear, out int spearCount))
                Console.WriteLine($"{Weapon.Spear} count: {spearCount}");


            /*
                CHALLENGE 5:

                    Using either of the 2 ways to check for a key, look for a specific student in the dictionary. 
                    If the student is found, print out the student's grade
                    else print out a message that the student was not found
             
            */







            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Updating a value for a key in a Dictionary  ]

                To update an exisiting value in the dictionary, use the [ ]
                
               
            */
            backpack[Weapon.Mace] = 0; //sell all maces



            /*
                CHALLENGE 6:

                    Pick any student and curve the grade (add 5) that is stored in the grades dictionary
             
            */
        }

        private static void PrintGrades(Dictionary<string, double> course)
        {
            Console.WriteLine("------PG2 2306------");
            foreach (var student in course)
            {
                PrintGrade(student.Value);
                Console.WriteLine($" {student.Key}");
            }
        }

        private static void PrintGrade(double grade)
        {
            Console.ForegroundColor = (grade < 59.5) ? ConsoleColor.Red :
                                      (grade < 69.5) ? ConsoleColor.DarkYellow :
                                      (grade < 79.5) ? ConsoleColor.Yellow :
                                      (grade < 89.5) ? ConsoleColor.Blue :
                                                       ConsoleColor.Green;
            Console.Write($"{grade,7:N2}");
            Console.ResetColor();
        }

        private static int LinearSearch(List<int> nums, int numberToFind)
        {
            int index = -1;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == numberToFind)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
