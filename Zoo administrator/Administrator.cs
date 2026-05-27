using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zoo

{
    internal class Administrator : Worker
    {
        int contract_num = 0;
        List<Guide> guides = new List<Guide>();
        List<Animal> animals = new List<Animal>();
        List<Cage> cages = new List<Cage>();
        List<Keeper> keepers = new List<Keeper>();

        public List<Animal> Animals => animals;
        public List<Cage> Cages => cages;
        public List<Keeper> Keepers => keepers;
        public List<Guide> Guides => guides;

        public Administrator(string name, string surname, Date date) : base(name, surname, date)
        {
        }

        public void AddEvent(short timeslot)
        {
            foreach (Guide guide in guides)
            {
                if (guide.free_timeslot.Contains(timeslot))
                {
                    short[] changed_timeslots = new short[guide.free_timeslot.Length - 1];
                    int counter = 0;

                    foreach (var ts in guide.free_timeslot)
                    {
                        if (ts != timeslot)
                        {
                            changed_timeslots[counter] = ts;
                            counter++;
                        }
                    }

                    guide.free_timeslot = changed_timeslots;
                    this.contract_num++;
                    Console.WriteLine("Вы записаны к " + guide.name + " " + guide.surname);
                    break;
                }
                else
                {
                    Console.WriteLine("Свободных мест у гида " + guide.name + " нет");
                }

                break;
            }
        }

        public void AddAnimalToCage(Cage? cage, Animal? animal)
        {
            animal.cage = cage;
            Console.WriteLine("Вы добавили " + animal.name + " в вольер");
        }

        public Fish AddFish(string name, char gender, bool sponsor, string legend, Date date, Enviroment liv_env)
        {
            Fish fish = new Fish(name, gender, sponsor, legend, date, liv_env);
            this.contract_num++;
            Console.WriteLine("Договор на новую рыбу подписан");
            return fish;
        }

        public Bird AddBird(string name, char gender, bool sponsor, string legend, Date date, bool flyingly)
        {
            Bird bird = new Bird(name, gender, sponsor, legend, date, flyingly);
            this.contract_num++;
            Console.WriteLine("Договор на новую птицу подписан");
            return bird;
        }

        public Primate AddPrimate(string name, char gender, bool sponsor, string legend, Date date, Suborder suborder)
        {
            Primate primate = new Primate(name, gender, sponsor, legend, date, suborder);
            this.contract_num++;
            Console.WriteLine("Договор на нового примата подписан");
            return primate;
        }

        public void AddTaskToKeeper(Cage? cage, Keeper? keeper)
        {
            keeper.clean_cage(cage);
        }

        public Guide AddGuide(string name, string surname, Date date, Languages language)
        {
            Guide guide = new Guide(name, surname, date, language);
            this.contract_num++;
            return guide;
        }

        public Keeper AddKeeper(string name, string surname, Date date, string work_area, bool tool)
        {
            Keeper keeper = new Keeper(name, surname, date, work_area, tool);
            this.contract_num++;
            return keeper;
        }

        public Cage AddCage(CageType type, short[] size)
        {
            Cage cage = new Cage(type, size);
            this.contract_num++;
            return cage;
        }
    }
}