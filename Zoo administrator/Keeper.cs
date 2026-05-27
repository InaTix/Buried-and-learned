using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Zoo

{
    internal class Keeper : Worker
    {
        public string work_area; // зоны работы
        bool tool; // есть ли инструмент

        public Keeper(string name, string surname, Date date, string work_area, bool tool) : base(name, surname, date)
        {
            this.work_area = work_area;
            this.tool = tool;
        }

        // Почистить вольер
        public void clean_cage(Cage? cage)
        {
            if (!cage.clean && this.tool)
            {
                cage.clean = true;
                Console.WriteLine("Клетка очищена");
            }
        }

        public void feed_animal(Animal animal)
        {
            Console.WriteLine("Вы решили накормить животное");
            animal.feed();
        }
    }
}