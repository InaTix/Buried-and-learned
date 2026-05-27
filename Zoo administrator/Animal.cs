using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo

{
    internal abstract class Animal
    {
        public string name; // имя
        public char sex; //  пол
        public bool sponsor; // наличие попечителя 
        public string legend; // история о животном
        public Date date; // Дата рождения животного
        public bool fed = false; // Кормили животное? Дефолтно - голоден.
        public Cage? cage = null;


        protected Animal(string name, char sex, bool sponsor, string legend, Date date)
        {
            this.name = name;
            this.sex = sex;
            this.sponsor = sponsor;
            this.legend = legend;
            this.date = date;
        }

        protected abstract void make_sound();

        public void feed()
        {
            make_sound();

            if (fed)
            {
                Console.WriteLine("Животное уже накормлено. Вы хотите, чтобы оно умерло от разрыва желудка?");
            }
            else
            {
                Console.WriteLine("Вы накормили животное");
                fed = true;
            }
        }
    }
}