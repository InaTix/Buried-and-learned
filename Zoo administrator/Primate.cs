using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo

{
    enum Suborder // подотряды приматов 
    { 
        Haplorhini, // сухоносые
        Strepsirrhini // мокроносые
    }

    internal class Primate : Animal
    {

        Suborder suborder;

        public Primate(string name, char gender, bool sponsor, string legend, Date date, Suborder suborder) : base(name, gender, sponsor, legend, date)
        {
            this.suborder = suborder;
        }

        protected override void make_sound()
        {
            Console.WriteLine("Обезъяна издала модулированное протяжное уханье с трёхкратным лаем");
        }


    }
}
