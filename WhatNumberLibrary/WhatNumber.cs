using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatNumberLibrary
{
    /// <summary>
    /// Логика игры "Угадай число".
    /// </summary>
    public class WhatNumber
    {
        int counter = 3;
        int random;
        /// <summary>
        /// Создание новой игры.
        /// </summary>
        public WhatNumber()
        {
            random = new Random().Next(0, 101);
        }
        /// <summary>
        /// Возвращает загаданное число.
        /// </summary>
        public int Random
        {
            get
            {
                return random;
            }
        }
        /// <summary>
        /// Возвращает количество попыток.
        /// </summary>
        public int Counter
        {
            get
            {
                return counter;
            }
        }
        /// <summary>
        /// Проверка правильности ввода значени: если верно - проходит попытка ввода.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Check(int number)
        {
            if (number > 100 || number < 0)
                return false;
            else
            {
                --counter;
                return true;
            }
        }
        /// <summary>
        /// Проверка на равенство загаданного значения и вводимого значения.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Win(int number)
        {
            return number == random;
        }
        /// <summary>
        /// Проверка на больше/меньше загаданного значения и вводимого значения.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool MoreLess(int number)
        {
            return number > random;
        }
    }
}

