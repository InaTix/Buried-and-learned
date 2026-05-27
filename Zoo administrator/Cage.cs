using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    enum CageType
    { 
        FreshWater,
        SaltedWater,
        FreeCage,
        ClosedCage
    }
    internal class Cage 
    {
        public CageType type; // Тип вольера.
        short[] size; // инициализация массива из трех элементов (длина, ширина, высота)
        public bool clean = false; // Чистый ли вольер?
        public List<Animal> contained_animals = new List<Animal>();

        public short[] Size => size;

        //По умолчанию вольер пустой, а добавить внутрь может только Управляющий
        public Cage(CageType type, short[] size)
        {
            this.type = type;
            this.size = size;
        }
    }
}