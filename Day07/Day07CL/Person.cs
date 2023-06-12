using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Person
    {
        #region Fields
        private uint _age = 0;
        private static int _numberOfPeople = 0;
        #endregion

        #region Properties
        public uint Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 0 && value < 120)
                    _age = value;
            }
        }
        public string Name { get; set; } = "Bruce Wayne";
        #endregion

        #region Constructors
        public Person(string name, uint age)
        {
            Name = name;
            Age = age;
            _numberOfPeople++;
        }
        #endregion

        //there is a HIDDEN param called 'this'.
        //points to the variable that the method was called on
        public void WhoAmI()
        {
            //_age = (uint)(DateTime.Now.Year - age);
            Console.WriteLine($"I am {Name} and I am {Age} years old.");
            Console.WriteLine($"There are {_numberOfPeople} people in the 'world'");
        }

        public static void PeopleReport() //there is NO 'this'
        {
            //Console.WriteLine($"I am {Name} and I am {Age} years old.");
            Console.WriteLine($"There are {_numberOfPeople} people in the 'world'");
        }

        public void ItsMyBirthday()
        {
            Age++;
            Console.WriteLine($"It's my birthday! I'm turning {Age} years old!! Let's have some cake!");
        }
    }
}
