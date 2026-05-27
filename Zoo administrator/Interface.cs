using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo;

namespace Interface
{
    internal class Interface
    {
        readonly Administrator administrator;
        List<short> timeslots = [9, 11, 13, 15, 17, 19];

        public Interface()
        {
            Console.WriteLine(
                "Здравствуйте, вы находитесь в сервисе администрирования 'Натуралистка им.Н.Н. Дроздова.'\n");
            Console.WriteLine("Для начала наймите администратора:");
            administrator = CreateAdmin();
            Execute();
        }

        private short ReadValidShort(string field, int min = short.MinValue, int max = short.MaxValue)
        {
            short value;
            do
            {
                Console.Write($"Введите {field}: ");
            } while (!short.TryParse(Console.ReadLine(), out value) || value < min || value > max);

            return value;
        }

        private string ReadRequiredString()
        {
            string? input;
            do
            {
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private Date ReadDate()
        {
            short day = ReadValidShort("число", 1, 31);
            short month = ReadValidShort("месяц", 1, 12);
            short year = ReadValidShort("год", 1900, DateTime.Now.Year);

            return new Date { day = day, month = month, year = year };
        }

        private char ReadValidChar(string validOptions, bool ignoreCase = true)
        {
            char result;
            bool isValid;
            string? input;

            do
            {
                input = Console.ReadLine()?.Trim();

                isValid = input != null &&
                          input.Length == 1 &&
                          (ignoreCase ? validOptions.ToUpper() : validOptions)
                          .Contains(ignoreCase ? input.ToUpper()[0] : input[0]);

                if (!isValid)
                {
                    Console.WriteLine($"Недопустимый символ. Допустимые значения: {validOptions}");
                }
            } while (!isValid);

            return ignoreCase ? char.ToUpper(input![0]) : input![0];
        }

        private T? SelectWorker<T>(List<T> workerList) where T : Worker
        {
            // Получаем доступных гидов
            var workers = workerList;
            if (workers.Count == 0)
            {
                Console.WriteLine("Нет доступных работников.");
                return null;
            }

            // Выбираем гида
            Console.WriteLine("Выберите работника:");
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {workers[i].name} {workers[i].surname}");
            }

            int workerIndex = ReadValidShort("номер работника", 1, workers.Count) - 1;
            return workers[workerIndex];
        }

        private Animal? SelectAnimal(List<Animal> animalList)
        {
            // Получаем доступных гидов
            var animals = animalList;
            if (animals.Count == 0)
            {
                Console.WriteLine("Нет доступных животного.");
                return null;
            }

            // Выбираем гида
            Console.WriteLine("Выберите животное:");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {animals[i].name}");
            }

            int animalIndex = ReadValidShort("номер животного", 1, animals.Count) - 1;
            return animals[animalIndex];
        }

        private Cage? SelectCage(List<Cage> cageList)
        {
            // Получаем доступных гидов
            var cages = cageList;
            if (cages.Count == 0)
            {
                Console.WriteLine("Нет доступных вольеров.");
                return null;
            }

            Console.WriteLine("Выберите вольер:");
            for (int i = 0; i < cages.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. Тип: {cages[i].type}, Размер: {cages[i].Size[0]}x{cages[i].Size[1]}x{cages[i].Size[2]}");
            }

            int cageIndex = ReadValidShort("номер вольера", 1, cages.Count) - 1;
            return cages[cageIndex];
        }

        private Administrator CreateAdmin()
        {
            Console.WriteLine("Введите имя Администратора");
            string name = ReadRequiredString();

            Console.WriteLine("Введите фамилию Администратора");
            string surname = ReadRequiredString();


            Console.WriteLine("Введите дату рождения");
            Date date = ReadDate();
            Administrator admin = new Administrator(name, surname, date);

            return admin;
        }

        private void CreateAnimal()
        {
            Console.WriteLine("Выберите тип животного: 1 - рыба, 2 - птица, 3 - примат");
            char choisedAnimal = ReadValidChar("123");

            Console.WriteLine("Введите имя животного");
            string name = ReadRequiredString();

            Console.WriteLine("Введите пол животного: M - для самца, F - для самки");
            char sex = ReadValidChar("MF");

            Console.WriteLine("Введите дату приема животного");
            Date date = ReadDate();

            Console.WriteLine("Создайте описание животного");
            string legend = ReadRequiredString();

            Console.WriteLine("Есть ли у животного спонсор. Введите 1 если 'да', иначе - 0");
            bool sponsor = ReadValidChar("10") == '1';

            switch (choisedAnimal)
            {
                case '1':
                    Console.WriteLine("Выберите, какая у вас рыба: 1 - пресноводная, 2 - морская");
                    Enviroment liv_env = ReadValidChar("12") == '1'
                        ? Enviroment.Fresh_water
                        : Enviroment.Salted_water;
                    administrator.AddFish(name, sex, sponsor, legend, date, liv_env);
                    break;

                case '2':
                    Console.WriteLine("Выберите тип птицы: 1 - летающая, 0 - нелетающая");
                    bool flyingly = ReadValidChar("01") == '1';
                    administrator.AddBird(name, sex, sponsor, legend, date, flyingly);
                    break;

                case '3':
                    Console.WriteLine("Выберите подотряд примата: 1 - Сухоносые, 2 - Мокроносые");
                    Suborder suborder = ReadValidChar("12") == '1'
                        ? Suborder.Haplorhini
                        : Suborder.Strepsirrhini;
                    administrator.AddPrimate(name, sex, sponsor, legend, date, suborder);
                    break;
            }
        }
        
        private void CreateEvent()
        {
            Console.WriteLine("Введите ");
            short timeslot = ReadValidShort("время на которое вам удобно записаться.\n" +
                                            "Длительность экскурсии 1 час 40 минут. Введите время начала экскурсии:\n" +
                                            "9 (с 9 утра)\n 11 (с 11 утра)\n, 13 (с 13 дня)\n, 15 (с 15 дня)\n 17 (с 17 вечера)\n 19 (с 19 вечера)\n)",
                9, 19);
            if (timeslots.Contains(timeslot))
            {
                administrator.AddEvent(timeslot);
            }
        }

        private void HireWorker()
        {
            Console.WriteLine("1 - внести гида, 2 - внести кипера.");
            char option = ReadValidChar("12");
            string name = ReadRequiredString();
            string surname = ReadRequiredString();
            Date date = ReadDate();
            switch (option)
            {
                case '1':
                    Console.WriteLine("Укажите язык гида: (по умолчанию Русский)" +
                                      "1. Английский" +
                                      "2. Испанский");
                    char language_mark = ReadValidChar("123");
                    Languages language;
                    switch (language_mark)
                    {
                        case '1':
                            language = Languages.English;
                            break;
                        case '2':
                            language = Languages.Spanish;
                            break;
                        default:
                            language = Languages.Russian;
                            break;
                    }

                    administrator.AddGuide(name, surname, date, language);
                    break;
                case '2':
                    Console.WriteLine("Укажите зону работы кипера:");
                    string work_area = ReadRequiredString();

                    Console.WriteLine("Есть ли у кипера инструмент: 1 - да, 2 - нет");
                    bool tool = ReadValidChar("01") == '1';
                    administrator.AddKeeper(name, surname, date, work_area, tool);
                    break;
            }
        }

        private void AddCage()
        {
            Console.WriteLine("Введите тип вольера: (по умолчанию открытого типа)" +
                              "1 - Пресная вода" +
                              "2 - Соленая вода" +
                              "3 - Закрытого типа");
            char type_mark = ReadValidChar("1234");
            CageType type;
            switch (type_mark)
            {
                case '1':
                    type = CageType.FreshWater;
                    break;
                case '2':
                    type = CageType.SaltedWater;
                    break;
                case '3':
                    type = CageType.ClosedCage;
                    break;
                default:
                    type = CageType.FreeCage;
                    break;
            }

            short length = ReadValidShort("длину вольера");
            short width = ReadValidShort("ширину вольера");
            short height = ReadValidShort("высоту вольера");
            short[] size = [length, width, height];

            administrator.Cages.Add(administrator.AddCage(type, size));
        }

        private void AddAnimalToCage()
        {
            Cage? selectedCage;
            do
            {
                selectedCage = SelectCage(administrator.Cages);
            } while (selectedCage == null);

            var animals = administrator.Animals.Where(a => a.cage == null).ToList();
            if (animals.Count == 0)
            {
                Console.WriteLine("Нет животных без вольера.");
                return;
            }

            Animal? selectedAnimal;
            do
            {
                selectedAnimal = SelectAnimal(animals);
            } while (selectedAnimal == null);

            administrator.AddAnimalToCage(selectedCage, selectedAnimal);
        }

        private void CleanCage()
        {
            Cage? selectedCage;
            do
            {
                selectedCage = SelectCage(administrator.Cages);
            } while (selectedCage == null);

            Keeper? selectedKeeper;
            do
            {
                selectedKeeper = SelectWorker(administrator.Keepers);
            } while (selectedKeeper == null);

            administrator.AddTaskToKeeper(selectedCage, selectedKeeper);
            Console.WriteLine("Уборка вольера успешно назначена.");
        }

        private void TellAboutAnimal()
        {
            Guide? selectedGuide;
            do
            {
                selectedGuide = SelectWorker(administrator.Guides);
            } while (selectedGuide == null);

            Cage? selectedCage;
            do
            {
                selectedCage = SelectCage(administrator.Cages);
            } while (selectedCage == null);

            Animal? selectedAnimal;
            do
            {
                selectedAnimal = SelectAnimal(selectedCage?.contained_animals ?? []);
            } while (selectedAnimal == null);

            // Гид рассказывает о животном
            selectedGuide.TellAboutAnimal(selectedAnimal);
            Console.WriteLine("Гид успешно рассказал о животном.");
        }

        private void FeedAnimal()
        {
            Keeper? selectedLKeeper;
            do
            {
                selectedLKeeper = SelectWorker(administrator.Keepers);
            } while (selectedLKeeper == null);

            Cage? selectedCage;
            do
            {
                selectedCage = SelectCage(administrator.Cages);
            } while (selectedCage == null);

            Animal? selectedAnimal;
            do
            {
                selectedAnimal = SelectAnimal(selectedCage?.contained_animals ?? []);
            } while (selectedAnimal == null);
            
            selectedLKeeper.feed_animal(selectedAnimal);
            Console.WriteLine("Гид успешно рассказал о животном.");
        }

        private void Execute()
        {
            Console.WriteLine(
                "Введите следующие число для выбора опции:" +
                "1. Добавить экскурсию" +
                "2. Добавить животное в зоопарк " +
                "3. Внести запись о новом работнике" +
                "4. Добавить новый вольер" +
                "5. Добавить животное в вольер" +
                "6. Убрать вольер" +
                "7. Рассказать о животном" +
                "8. Накормить животное");
            char choice = ReadValidChar("1234567");

            switch (choice)
            {
                case '1':
                    CreateEvent();
                    break;
                case '2':
                    CreateAnimal();
                    break;
                case '3':
                    HireWorker();
                    break;
                case '4':
                    AddCage();
                    break;
                case '5':
                    AddAnimalToCage();
                    break;
                case '6':
                    CleanCage();
                    break;
                case '7':
                    TellAboutAnimal();
                    break;
                case '8':
                    FeedAnimal();
                    break;
            }
        }
    }
}