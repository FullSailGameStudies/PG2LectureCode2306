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
        }
        #endregion

        public void WhoAmI(int age)
        {
            _age = (uint)(DateTime.Now.Year - age);
        }
    }
}
