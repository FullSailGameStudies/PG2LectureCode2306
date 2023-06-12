using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Car
    {
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
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
