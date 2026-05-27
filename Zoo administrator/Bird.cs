using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo

{
    internal class Bird : Animal
    {
        bool flyingly; // умеет ли летать?

        public Bird(string name, char gender, bool sponsor, string legend, Date date, bool flyingly) : base(name, gender, sponsor, legend, date)
        {
            this.flyingly = flyingly;

        }

        protected override void make_sound()
        {
            Console.WriteLine("Птица издала звук позывов");
        }


    }
}
