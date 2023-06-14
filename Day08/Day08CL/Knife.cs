using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Knife : Weapon
    {
        public int Length { get; set; }
        public bool Serrated { get; set; }

        public Knife(int range, int damage, int length, bool serrated) : base(range, damage)
        {
            Length = length;
            Serrated = serrated;
        }
        public override void ShowMe()
        {
            base.ShowMe();
            Console.WriteLine($"\tLength: {Length}\tSerrated: {Serrated}");
        }
    }
}
