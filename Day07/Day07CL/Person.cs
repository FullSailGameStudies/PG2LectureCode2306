﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Person
    {
        private int _age = 0;

        public void WhoAmI(int age)
        {
            _age = DateTime.Now.Year - age;
        }
    }
}
