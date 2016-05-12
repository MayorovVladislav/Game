using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        static bool Start()
        {
            Console.Clear();
            bool b = false;
            WhatNumberLibrary.WhatNumber gamenumber = new WhatNumberLibrary.WhatNumber();
            while (gamenumber.Counter != 0)
            {
                Console.Write("Введите число: ");
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (gamenumber.Check(i) && gamenumber.Counter > 0)
                {
                    if (gamenumber.Win(i))
                    {
                        Console.WriteLine("Поздравляем вы победили.\nХотите начать новую игру?\nВведите y для продолжения.\nДля выхода из игры n");
                        if (Console.ReadLine() == "y")
                            b = true;
                        else
                            b = false;
                        break;
                    }
                    else if (gamenumber.MoreLess(i))
                        Console.WriteLine($"Загаднное число меньше. Осталось попыток: {gamenumber.Counter}");
                    else
                        Console.WriteLine($"Загаднное число больше. Осталось попыток: {gamenumber.Counter}");
                }
                else
                {
                    Console.WriteLine($"Вы исчерпали число попыток.\nЗагаданное число: {gamenumber.Random}\nХотите начать новую игру?\nДля продолжения нажмите \"y\". Для выхода из игры \"n\"");
                    if (Console.ReadLine() == "y")
                        b = true;
                    else
                        b = false;
                }
            }
            return b;
        }

        static void Main(string[] args)
        {
            Console.Title = "Угадай число";
            Console.WriteLine("Игра угадай число.\nВведите число от 0 до 100. Также у вас 3 попытки.\nТакже будут даваться подсказки.");
            Console.WriteLine("Для начала игры введите y. Для выхода введите n");
            bool b = true;
            if (Console.ReadLine() == "y")
                while (b)
                    b = Start();
        }
    }
}
