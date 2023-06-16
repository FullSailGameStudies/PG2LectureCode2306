namespace Day09
{
    static class Extensions
    {
        public static void PrintMe(this List<int> grades)
        {
            Console.WriteLine("   PG2 Grades   ");
            foreach (var grade in grades)
            {
                Console.WriteLine($"\t{grade,4}");
            }
        }
    }
    enum Superpower
    {
        Money, Strength, Flight, Swimming
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Gotham!");

            Calculator t1000 = new();
            int n1 = 5, n2 = 2;
            int sum = t1000.Sum(n1,n2);
            Console.WriteLine($"{n1} + {n2} = {sum}");

            Random rando = new();
            List<int> grades = new();
            for (int i = 0; i < 10; i++)
                grades.Add(rando.Next(101));

            grades.PrintMe();

        }
    }

    /*  
        ╔═════════════╗ 
        ║ OVERLOADING ║ - polymorphism by changing parameters
        ╚═════════════╝ 

        You can overload a method in 3 ways:
        1) different types on the parameters
        2) different number of parameters
        3) different order of parameters


        CHALLENGE 1:
            Add a overload of the Sum method to sum 2 doubles
    */

    class Calculator
    {
        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }
        public double Sum(double n1, double n2) { return n1 + n2; }
        public string Sum(string n1, string n2) { return n1 + n2; }
    }
}