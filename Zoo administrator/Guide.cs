using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    enum Languages
    {
        Russian,
        English,
        Spanish
    }

    internal class Guide : Worker
    {
        public Languages language;
        public short[] free_timeslot = [9, 11, 13, 15, 17, 19];

        public Guide(string name, string surname, Date date, Languages language) : base(name, surname, date)
        {
            this.language = language;
        }

        // рассказать историю о животном
        public void TellAboutAnimal(Animal animal)
        {
            switch (language)
            {
                case Languages.Russian:
                    Console.WriteLine("Имя: " + name);
                    Console.WriteLine("Пол: " + animal.sex);
                    Console.WriteLine("Есть ли попечитель: " + (animal.sponsor ? "Да" : "Нет"));
                    Console.WriteLine("История: " + animal.legend);
                    Console.WriteLine("Дата рождения: " + animal.date.PrintDate());
                    Console.WriteLine("Накормлено ли: " + (animal.fed ? "Да" : "Нет"));
                    break;
                case Languages.English:
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Gender: " + animal.sex);
                    Console.WriteLine("Is there a guardian: " + (animal.sponsor ? "Yes" : "No"));
                    Console.WriteLine("Backstory: " + animal.legend);
                    Console.WriteLine("Date of birth: " + animal.date.PrintDate());
                    Console.WriteLine("Is fed: " + (animal.fed ? "Yes" : "No"));
                    break;
                case Languages.Spanish:
                    Console.WriteLine("Nombre: " + name);
                    Console.WriteLine("Género: " + animal.sex);
                    Console.WriteLine("¿Hay un tutor?: " + (animal.sponsor ? "Sí" : "No"));
                    Console.WriteLine("Historia: " + animal.legend);
                    Console.WriteLine("Fecha de nacimiento: " + animal.date.PrintDate());
                    Console.WriteLine("¿Está alimentado?: " + (animal.fed ? "Sí" : "No"));
                    break;
            }
        }
    }
}