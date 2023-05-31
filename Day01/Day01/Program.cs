using System;
using System.Collections.Generic;
using System.Linq;

namespace Day01
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
    
            Vocabulary:
        
                  method (or function): https://www.w3schools.com/cs/cs_methods.php
                      a block of code that can be referenced by name to run the code it contains.

                  parameter: https://www.w3schools.com/cs/cs_method_parameters.php
                      a variable in the method definition.The list of parameters appear between the ( ) in a method header.

                  arguments:
                      when a method is called, arguments are the data you pass into the method's parameters
        
                  return type: https://www.w3schools.com/cs/cs_method_parameters_return.php
                      the value returned when a method finishes.
                      A return type must be specified on a method.
                      If no data is returned, use void.
    
        
                  List<T>: https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20-%20List%3CT%3E%201%20List%3CT%3E%20Characteristics%20List%3CT%3E%20equivalent,8%20Check%20Elements%20in%20List%20...%20More%20items
                    a collection of strongly typed objects that can be accessed by index. Indexes start at 0.



             Lecture videos:
                  METHODS LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/EW0hLKhQiBdFjOGq1WG6oRoB9TTQWJd1L9ic6VRiEYwgdg?e=J7uZXt
                  Chapters: Method Basics through Method Examples

                  LIST LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/ERG1iZHKJgFIoj6W8dhxPPgBIIY-Ot1b6Ueh-50Ggfcikg?e=goT9d6
                  Chapters: Array Basics through Looping Examples.

     */
    internal class Program
    {
        static void Print(int number)
        {
            //$ - interpolated string
            Console.WriteLine($"{number,10}");
        }

        static void Info(List<string> names)
        {
            //Capacity: length of the internal array
            //Count: # of items in the list
            Console.WriteLine($"Count: {names.Count}\tCapacity: {names.Capacity}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Hello Gotham!");
            int num = 5;
            Print(num);//pass by value (COPY)

            /*
              Calling a method
                use the methods name.
                1) if the method needs data (i.e. has parameters), you must pass data to the method that matches the parameter types
                2) if the method returns data, it is usually best to store that data in a variable on the line where you call the method.
             
            */

            /*
                ╔══════════════════════════╗ 
                ║Parameters: Pass by Value.║
                ╚══════════════════════════╝ 
             
                Copies the value to a new variable in the method.
                
                For example, the AddOne method has a parameter called localNumber. localNumber is a variable that is local ONLY to the method.
                The value of the variable in main, number, is COPIED to the variable in AddOne, localNumber.
              
            */
            int number = 5;
            int plusOne = AddOne(number);


            /*
                CHALLENGE 1:

                    Add an isEven method to the calculator.
                    It should take 1 parameter and return a bool.

                    Call the method on the t1000 calculator instance and print the results.

            */

            Calculator t1000 = new Calculator();//creating an instance
            int result = t1000.Sum(5, 2);
            Console.WriteLine($"The sum of 5 and 2 is {result}.");

            bool isEven = t1000.IsEven(num);
            Console.WriteLine($"Is {num} even? {isEven}");


            Calculator.WhoAmI();



            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 
                
                [  Creating a List  ]
                
                List<T>  - the T is a placeholder for a type. It is a "Generic Type Parameter" to the class.
                
                When you want to create a List variable, replace T with whatever type of data you want to store in the List.

            

                [  Adding items to a List  ]

                There are 2 ways to add items to a list:
                1) on the initializer. 
                2) using the Add method. 
            */
            List<string> names;//null
            names = new List<string>(11); //this list stores strings and only strings.
            Info(names);//Count: 0  Capacity: 0

            names.Add("The Bat");
            Info(names);//Count: 1  Capacity: 4
            names.Add("The Greatest Detective");//add the item to the END of the list
            names.Add("Batman");
            names.Add("Alfred");
            names.Add("Gordon");
            Info(names);//Count: 5  Capacity: 8 
            names.Add("Barbara");
            names.Add("Joker");
            names.Add("Poison Ivy");
            names.Add("Bane");
            Info(names);//Count: 9  Capacity: 11? 12?  
            names.Add("Nightwing");
            names.Add("Riddler");
            names.Add("Calendar Man");
            names.Add("Harley Quinn");
            Info(names);//Count: 15  Capacity: 11? 22?  

            string[] best = new string[3] { "Batman", "Bruce", "NOT Aquaman" };
            
            List<char> letters = new List<char>() { 'B', 'a', 't', 'm', 'a', 'n' };
            letters.Add('!');

            /*
                CHALLENGE 2:

                    Create a list that stores floats. Call the variable grades.
                    Add a few grades to the grades list.
             
            */
            Random rando = new Random();
            List<float> grades = new List<float>();
            for (int bob = 0; bob < 10; bob++) 
                grades.Add((float)(rando.NextDouble() * 100));






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Looping over a List  ]

                You can loop over a list with a for loop or a foreach loop.
                1) for loop. use the Count property in the for condition.
                2) foreach loop
            */
            for (int i = 0; i < letters.Count; i++)
                Console.Write($" {letters[i]}");

            foreach (char letter in letters)
                Console.Write($" {letter}");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            //anonymous types


            /*
                CHALLENGE 3:

                    loop over the grades list and print out each grade

            */
            Console.WriteLine("-------PG2 GRADES--------");
            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine(grades[i]);
            }


            Console.ReadKey();
            Console.WriteLine("-------PG2 GRADES--------");
            foreach (float grade in grades)
            {
                //ternary operator
                Console.ForegroundColor = (grade < 59.5) ? ConsoleColor.Red :
                                          (grade < 69.5) ? ConsoleColor.DarkYellow :
                                          (grade < 79.5) ? ConsoleColor.Yellow :
                                          (grade < 89.5) ? ConsoleColor.Blue :
                                          ConsoleColor.Green;

                Console.WriteLine($"\t{grade,7:N2}");
                Console.ResetColor();
            }
            Console.ResetColor();






            /*
                BOSS CHALLENGE:

                    1) Fix the Average method of the calculator class to calculate the average of the list parameter.
                    2) Call the Average method on the t1000 variable and pass your grades list to the method.
                    3) print the average that is returned.
             
            */
            float avg = t1000.Average(grades);
            Console.WriteLine($"The average grade: {avg:N2}");


            Console.ReadKey(true);
        }

        private static int AddOne(int localNumber)
        {
            return localNumber + 1;
        }


    }

    class Calculator
    {
        public static void WhoAmI()
        {
            Console.WriteLine("I am a Texas Instrument.");
        }

        public bool IsEven(int number)
        {
            return number % 2 == 0;
            //if (number % 2 == 0)
            //    return true;
            //return false;
        }

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }


        public float Average(List<float> numbers)
        {
            return numbers.Average();
            //float avg = 0F;
            //float sum = 0;
            ////loop over the numbers and calculate the average
            //foreach (float number in numbers)
            //{
            //    sum += number;
            //}
            //avg = sum / numbers.Count;
            //return avg;
        }
    }
}
