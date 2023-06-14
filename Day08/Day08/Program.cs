using Day08CL;

namespace Day08
{
    /*                    DERIVING CLASSESS          
                                                               
                                ╔═════════╗     ╔══════════╗ 
                 public  class  ║SomeClass║  :  ║OtherClass║ 
                                ╚═════════╝     ╚══════════╝
                                     │                │         
                                     └──┐             └──┐             
                                   ┌────▼────┐      ┌────▼────┐      
                                   │ Derived │      │  Base   │    
                                   │  Class  │      │  Class  │     
                                   └─────────┘      └─────────┘     

    
                CONSTRUCTORS: the derived constructor must call a base constructor
                public SomeClass(.....) : base(....)


     */

    class Person
    {
        public Person(int age, string name)
        {
            Age = age;
            //?? null-coalescing operator
            Name = name;// ?? throw new ArgumentNullException(nameof(name));
        }

        public int Age { get; set; }
        public string Name { get; set; }
    }
    enum Superpower
    {
        HeatRay, DimensionalTravel, Money, Strength, Swimming, Flight
    }
    class Superhero : Person 
    {
        public string Alias { get; set; }
        public Superpower Power { get; set; }

        public Superhero(string alias, Superpower power, int age, string name) 
            : base(age, name)
        {
            Alias = alias;
            Power = power;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
                CHALLENGE 1:

                    In the Day08CL project, add a new class, Pistol, 
                    that derives from Weapon.
                    Pistol should have properties for Rounds and MagCapacity.
                    Add a constructor that calls the base constructor
             
            */
            //Weapon pew = new Weapon();
            Pistol pew = new Pistol(50, 200, 10, 20);





            /*  
                ╔═══════════╗ 
                ║ UPCASTING ║ - converting a derived type variable to a base type variable
                ╚═══════════╝ 
                
                This is ALWAYS safe.

                DerivedType A = new DerivedType();
                BaseType B = A;
            



                CHALLENGE 2:
                    Create a List of Weapon. Create several Pistols and add them to the list of weapons.
            */

            int num = 5;
            long bigNum = num; //IMPLICIT cast
            num = (int)bigNum; //EXPLICIT cast

            Knife sting = new Knife(5, 100, 2, false);

            //UPCASTING: 
            //  casting from a DERIVED variable (pew) to a BASE variable (weapon)
            //  does NOT make a new instance
            Weapon weapon = pew;
            weapon = sting;
            GameObject gameObj = pew;

            List<GameObject> gameObjects = new();
            gameObjects.Add(sting); 
            gameObjects.Add(pew);

            //THIS IS ALWAYS SAFE!




            /*  
                ╔═════════════╗ 
                ║ DOWNCASTING ║ - converting a base type variable to a derived type variable
                ╚═════════════╝ 
                
                This is NOT SAFE!!!!!

            
                BaseType B = new DerivedType(); //upcasting
                DerivedType A = B; !! Build ERROR !!
            

                3 ways to downcast safely...
                1) explicit cast inside of a try-catch
                    try {  DerivedType A = B;  }
                    catch(Exception) { }

                2) use the 'as' keyword
                    NOTE: null will be assigned to A if B cannot be cast to DerivedType
                    DerivedType A = B as DerivedType;
                    if(A != null) { can use A }

                3) use 'is' in pattern matching
                    if(B is DerivedType A) { can use A }



                CHALLENGE 3:
                    Loop over the list of weapons.
                    Call ShowMe on each weapon.
                    Downcast to a Pistol and print the rounds and mag capacity of each pistol
            */

            weapon = pew;//pistol

            //1) explicit cast inside a try-catch
            try
            {
                Knife stabber = (Knife)weapon;
            }
            catch (Exception)
            {
            }

            //2) use the 'as' keyword
                //if doesn't work, will assign NULL to the variable
            Knife? knife = weapon as Knife;
            if(knife != null ) 
                Console.WriteLine(knife.Length);

            //3) use the 'is' keyword with a pattern match
            if(weapon is Knife knife2)
            {
                Console.WriteLine(knife2.Length);
            }








            /*  
                ╔═════════════╗ 
                ║ OVERRIDING  ║ - changing the behavior of a base method
                ╚═════════════╝ 
                
                2 things are required to override a base method:
                1) add 'virtual' to the base method
                2) add a method to the derived class that has the same signature as the base. put 'override' to the derived method


                FULLY OVERRIDING:
                    not calling the base method from the derived method

                EXTENDING:
                    calling the base method from the derived method




                CHALLENGE 4:
                    Override Weapon's ShowMe method in the Pistol method.
                    In Pistol's version, call the base version and print out the rounds and magCapacity
                    Fix the loop to remove the if-elseif.
            */
        }
    }
}