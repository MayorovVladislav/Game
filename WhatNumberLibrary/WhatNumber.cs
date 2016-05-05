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
        /// <summary>
        /// Класс для вывода сообщений.
        /// </summary>
        public class EventMessage : EventArgs
        {
            /// <summary>
            /// Сообщение для вывода.
            /// </summary>
            public string Message { get; private set; }

            /// <summary>
            /// Конструктор для сохранения сообщения.
            /// </summary>
            /// <param name="message"></param>
            public EventMessage(string message)
            {
                Message = message;
            }
        }

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
        /// Проверка введенного значения.
        /// </summary>
        /// <param name="number">Пользовательское число.</param>
        public void Check(int number)
        {
            EventMessage eventmessage = new EventMessage("");

            if (number <= 100 || number >= 0)
            {
                counter--;
                if (counter != 0)
                {
                    if (number > random)
                        eventmessage = new EventMessage($"Ваше число больше загаданного!\nОсталось попыток: {counter }");
                    else if (number < random)
                        eventmessage = new EventMessage($"Ваше число меньше загаданного!\nОсталось попыток: {counter }");
                    else
                    {
                        eventmessage = new EventMessage("Вы угадали число!\nХотите начать новую игру?");
                        GemeOverOutPut(eventmessage);
                        return;
                    }
                }
                else
                {
                    if (number == random)
                        eventmessage = new EventMessage("Вы угадали число!\nХотите начать новую игру?");
                    else
                        eventmessage = new EventMessage("Вы не угадали число!\nХотите начать новую игру?");
                    GemeOverOutPut(eventmessage);
                    return;
                }
            }
            else
                eventmessage = new EventMessage("Пожалуйства введите число в пределах 0 - 100.");
            OutPut(eventmessage);
        }

        /// <summary>
        /// Происходит при поиске случайного числа.
        /// </summary>
        public event EventHandler<EventMessage> message;
        /// <summary>
        /// Происходит при последней попытке и выводит сообщение об окончании игры.
        /// </summary>
        public event EventHandler<EventMessage> gameover;

        /// <summary>
        /// Вызов события.
        /// </summary>
        /// <param name="eventmessage"></param>
        private void OutPut(EventMessage eventmessage)
        {
            if (message != null)
                message(this, eventmessage);
        }
        /// <summary>
        /// Вызов события.
        /// </summary>
        /// <param name="eventmessage"></param>
        private void GemeOverOutPut(EventMessage eventmessage)
        {
            if (gameover != null)
                gameover(this, eventmessage);
        }
    }
}

