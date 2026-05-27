using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zoo
{
    internal class Fish : Animal
    {
        Enviroment liv_env; // среда обитания

        public Fish(string name, char sex, bool sponsor, string legend, Date date, Enviroment liv_env) : base(name,
            sex, sponsor, legend, date)
        {
            this.liv_env = liv_env;
        }

        protected override void make_sound()
        {
            Console.WriteLine("Рыба издала звук питания");
        }
    }
}