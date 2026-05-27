using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal struct Date
    {
        public short year;
        public short month;
        public short day;

        public string PrintDate()
        {
            return year + "-" + month + "-" + day;
        }
    }
}
