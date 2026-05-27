using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Worker
    {
        public string name;
        public string surname;
        Date date;

        public Worker(string name, string surname, Date date) 
        { 
            this.name = name;
            this.surname = surname;
            this.date = date;
        }
    }
}
