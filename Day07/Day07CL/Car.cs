using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Car
    {
        //a default ctor: no params
        //a non-default ctor: has params
        public Car(string make, string model) //constructor (ctor)
        {
            //make = Make;//WRONG!! BACKWARDS!!!!
            Make = make;
            Model = model;
        }
        private string _vin;
        private int _year;//private
        private ConsoleColor _color;

        //a FULL property
        public ConsoleColor Color
        {
            //getter (accessor)
            //same as...
            //public ConsoleColor GetColor() {return _color;}
            get //public
            { 
                return _color; 
            }

            //setter (mutator)
            //same as...
            //public void SetColor(ConsoleColor value) {_color = value;}
            private set
            { 
                if(value != ConsoleColor.DarkYellow)
                    _color = value; 
            }
        }

        //an AUTO property (compiler provides the FIELD and the code for the get/set)
        public string Make { get; private set; }
        public string Model { get; private set; }
    }
}
