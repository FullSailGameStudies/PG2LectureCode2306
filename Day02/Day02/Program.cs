using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    /*                    METHODS          
                                                               
                ╔══════╗ ╔═══╗ ╔══════════╗ ╔════════════════╗ 
                ║public║ ║int║ ║SomeMethod║ ║(int someParam) ║ 
                ╚══════╝ ╚═══╝ ╚══════════╝ ╚════════════════╝ 
                    │      │         │               │         
              ┌─────┘      │         └──┐            └───┐     
         ┌────▼────┐   ┌───▼───┐   ┌────▼───┐       ┌────▼────┐
         │ Access  │   │ Return│   │ Method │       │Parameter│
         │ modifier│   │ type  │   │  Name  │       │  list   │
         └─────────┘   └───────┘   └────────┘       └─────────┘


    
    ╔═══════════╗ 
    ║Return type║ Return type defines the type of the data being returned.
    ╚═══════════╝
    │
    │
    └── If NO data is returned, then use "void" for the return type.
    │    public void PrintSomething()
    │    {
    │        Console.WriteLine("Something");
    │    }
    │
    │
    └── If a method returns data, then the return type must match the type of the data being returned.
        public float GetMyGrade()
        {
            return 99.9F; //returning a float so set return type to float
        }

    ╔══════════╗ 
    ║Parameters║ Parameters define the data passed to the method.
    ╚══════════╝
    │
    │
    └── If NO data is passed to the method, leave the parenthesis empty. EX: ( )
    │    public void PrintSomething()
    │   {  }
    │
    │
    └── If passing data to the method, then define the variable the method will use to store the data.
        Parameters are just variables therefore parameters need 2 things: <type> <name>
        Example:
        public void PrintMyGrade(float myGrade)
        {
            Console.WriteLine($"My grade is {myGrade}");
        }

        

     */
    internal class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {

            /*   
                ╔══════════════════════════════╗ 
                ║Parameters: Pass by Reference.║
                ╚══════════════════════════════╝ 
                Sends the variable itself to the method. The method parameter gives the variable a NEW name (i.e. an alias)
                  
                NOTE: if the method assigns a new value to the parameter, the variable used when calling the method will change too.
                    This is because the parameter is actually just a new name for the other variable.
            */
            string spider = "Spiderman";
            Console.WriteLine(spider);
            bool isEven = PostFix(ref spider);
            Console.WriteLine(spider);

            string hulk = "Hulk";
            isEven = PostFix(ref hulk);

            /*
                CHALLENGE 1:

                    Write a method to create and fill a list of floats with grades.
                    1) pass it in a list variable by reference
                    2) add 10 grades to the list

            */
            List<float> grades = null;// new List<float>();
            GetGrades(ref grades);
            if (grades != null)
            {
                PrintGrades(grades);
            }
            Console.ReadKey();



            /*  
                ╔═══════════════════════════╗ 
                ║Parameters: Out Parameters.║
                ╚═══════════════════════════╝  
                  A special pass by reference parameter. 
                  DIFFERENCES:
                    the out parameter does NOT have to be initialized before sending to the method
                    the method MUST assign a value to the parameter before returning

            */
            ConsoleColor foreground, background; //don't have to initialize it
            //while (true)
            {
                //Console.SetCursorPosition(
                //    randy.Next(Console.WindowWidth), 
                //    randy.Next(Console.WindowHeight));
                GetRandomColor(out foreground, out background);
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;
                Console.Write("Hello Gotham!"); 
            }

            Console.ResetColor();
            Console.ReadKey();

            /*
                CHALLENGE 2:

                    Write a method to calculate the stats on a list of grades
                    1) create a method to calculate the min, max, and avg. 
                        pass in the list of grades.
                        use out parameters to pass this data back from the method.
                    3) print out the min, max, and avg
             
            */
            CalculateStats(grades, out float min, out float max, out float avg);
            Console.WriteLine($"Min: {min}\tMax: {max}\tAverage: {avg}");



            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Removing from a List  ]

                There are 2 main ways to remove from a list:
                1) bool Remove(item).  will remove the first one in the list that matches item. returns true if a match is found else removes false.
                2) RemoveAt(index). will remove the item from the list at the index

            */
            List<string> dc = new() { "Batman", "Wonder Woman", "Aquaman", "Superman", "Aquaman" };
            bool found = dc.Remove("Aquaman");
            foreach (var hero in dc)
            {
                Console.Write($"{hero} ");
            }
            Console.WriteLine();

            dc.RemoveAt(dc.Count - 1);//removes the last item

            /*
                CHALLENGE 3:

                    Using the list of grades you created, 
                    Remove all the failing grades (grades < 59.5).
                    Print the grades.
            */
            //for (int i = 0; i < grades.Count; i++)
            //{
            //    if (grades[i] < 59.5)
            //    {
            //        grades.RemoveAt(i);
            //        i--;
            //    }
            //}

            //for (int i = 0; i < grades.Count; )
            //{
            //    if (grades[i] < 59.5)
            //        grades.RemoveAt(i);
            //    else i++;
            //}
            //reverse for loop
            for (int i = grades.Count - 1; i >= 0; i--)
            {
                if (grades[i] < 59.5)
                {
                    grades.RemoveAt(i);
                }
            }

            PrintGrades(grades);






            /*   
                ╔═══════════════════════════════╗ 
                ║Parameters: optional parameters║
                ╚═══════════════════════════════╝ 
                
                Unless specified, parameters to a method are required.
                However, you can make parameters optional, meaning when calling the method, you aren't required to pass values for the optional parameters.

                REQUIREMENT:
                    - all optional parameters have to be at the end of the list of parameters
                    - in the list of parameters, assign a value to any parameter you want to be optional
            */
            string file = "highScores";
            string postfile = PostFix(file); //if you don't pass a value, the default value will be used for the optional parameter
            postfile = PostFix(file, 5); //if a value is passed, it will be used for the optional parameter


            /*
                CHALLENGE 4:

                    Write a method called batTheme.
                    Add an optional parameter to determine how many "na" are printed. The default value should be 13.

                    If the calling code does not pass a value for the parameter, print "na na na na na na na na na na na na na Batman".
                    If a value is passed, print the number of "na" equal to the value.
                    EX: if 6 is passed, print "na na na na na na Batman"

            */




            /*
                CHALLENGE 5:

                    Write a ColorWriteLine method to print a message with a foreground color in the console.
                    1) add a string message parameter AND an optional color parameter. Choose whatever default color you want.
                    2) in the method, set the foreground color to the optional parameter
                    3) print the message
             
            */
        }

        private static void PrintGrades(List<float> grades)
        {
            Console.WriteLine("----GRADES-----");
            foreach (var grade in grades)
            {
                Console.WriteLine($"{grade:N2}");
            }
        }

        private static void CalculateStats(List<float> grades, out float min, out float max, out float avg)
        {
            //min = grades.Min();
            //max = grades.Max();
            //avg = grades.Average();
            min = float.MaxValue;
            max = float.MinValue;
            avg = 0;
            foreach (var grade in grades)
            {
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
                avg += grade;
            }
            avg /= grades.Count;
        }

        private static void GetGrades(ref List<float> studentGrades)
        {
            //create a list
            //loop 
            //  create a grade
            //  add the grade to the list
            studentGrades = new List<float>();
            for (int i = 0; i < 10; i++)
            {
                studentGrades.Add((float)randy.NextDouble() * 100);
            }

        }

        private static bool GetRandomColor(out ConsoleColor foreColor, out ConsoleColor backColor)
        {
            //the method MUST initialize the outColor parameter
            foreColor = (ConsoleColor)randy.Next(16);
            backColor = (ConsoleColor)randy.Next(16);
            return foreColor == backColor;
        }

        static bool PostFix(ref string hero) //hero is now an alias to the variable used when calling PostFix. In this case, hero is an alias to the spider variable.
        {
            int postFix = randy.Next(100);
            //hero += $"-{postFix}"; //updating hero now also updates spider
            return postFix % 2 == 0; //isEven
        }

        static string PostFix(string fileName, int postFixNumber = 1) //postFixNumber is optional
        {
            return fileName + postFixNumber;
        }
    }
}
