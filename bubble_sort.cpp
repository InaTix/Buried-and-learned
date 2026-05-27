#include <iostream> // работа с потоками
#include <chrono> // время
#include <random> // для подключения функций рандомизации

using namespace std;

enum ArrayLength : short
{
    small, medium, large
};

// структура, которая вернет массив и его размер
struct Array
{
    int size;
    int* array;
};

// Генерация массива. Возвращает структуру Array (c двумя полями)
/*Принимает на вход размер типа enum и максимальное число для диапазона генерации чисел
*/
Array generateArray(ArrayLength size, int maxValueGenerate)
{
    Array arrayInfo{};
    if (size == small)
    {
        arrayInfo.size = 100;
    }
    if (size == medium)
    {
        arrayInfo.size = 1000;
    }
    if (size == large)
    {
        arrayInfo.size = 10000;
    }

    /* сделать обработку ошибки выделения памяти nothrow и try cathe */
    arrayInfo.array = new int[arrayInfo.size];
    for (int i = 0; i < arrayInfo.size; i++)
    {
        *(arrayInfo.array + i) = rand() % maxValueGenerate;
    }

    return arrayInfo;
}

void copyArray(Array orig, Array copy)
{
    copy.size = orig.size;
    for (int i = 0; i < copy.size; i++)
    {
        *(copy.array + i) = *(orig.array + i);
    }
}

void printArray(Array array)
{   
    cout << "Текущий массив:\n";
    for (int i = 0; i < array.size; i++)
    {
        cout << *(array.array + i) << ' ';
    }
    cout << '\n';
}

void bubbleSort(Array array) 
{  
    for (int i = 0; i < array.size - 1; i++)
    {
        for (int j = 0; j < array.size - 1 - i; j++)
        {
            if (array.array[j] > array.array[j + 1])
            {
                swap(array.array[j], array.array[j+1]);
            }
        }
    }
}

void insertionSort()
{

}

void mergeSort()
{

}
int main()
{
    setlocale(LC_ALL, "rus");
    int choice;
    const short maxValue = 10000;
    Array array;
    ArrayLength length;
    Array copy;

    printf("Введите число для выбора количества элементов в массиве:\n1. 100\n2. 1000\n3. 10000\n");
    while (true)
    {
	    
        cin >> choice;
        // cin.peek() - извлекает, но не использует следующий символ из потока. "Подсматривает" за следующим символом
        if (cin.peek() != '\n')
        {
	        // cin.clear() - возвращает поток во флаг good, перемещая указатель на первый символ, не подходящий под тип данных.
            cin.clear();
            // если этим символом оказался непробельный символ, то это точно число, но оно не помещается в тип данных.
            if (cin.peek() == '\n')
            {
                cout << "Слишком большое число\n";
            }
            else
            {
                cout << "Вы ввели неверный формат\n";
                // игнорируем неверные символы, чистаем все, что у него в буфере и пропускаем, чтобы при следующем вызове у нас не вышло ошибки.
                cin.ignore(cin.rdbuf()->in_avail());
            }
            continue;
        }

        switch (choice)
        {
            case 1:
                length = small;
                break;

            case 2:
                length = medium;
                break;

            case 3:
                length = large;
                break;

            default:
                cout << "Такого пункта не существует\n";
                continue;
        }

        array = generateArray(length, maxValue);
        printArray(array);
        bubbleSort(array);
        printArray(array);
        // Реализовать освобождение памяти и указателей
    }
}