﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Hаписать приложение, имитирующее работу банкомата
// Реализовать классы Banc, Client, Account.

// Изначально клиенту нужно открыть счёт в банке, получить номер счёта,
// получить свой пароль, положить сумму на счёт.

// 1. Приложение предлагает ввести пароль предполагаемой кредитной карточки, 
//   даётся 3 попытки на правильный ввод пароля. Если попытки исчерпаны,
//   приложение выдаёт соответствующее сообщение и завершается.
// 2. При успешном вводе пароля выводится меню.
//   Пользователь может выбрать одно из нескольких действий:
//    -  вывод баланса на экран;
//    -  пополнение счёта;
//    -  снять деньги со счёта;
//    -  выход.
// 3. Если пользователь выбирает вывод баланса на экран, 
//   приложение отображает состояние предполагаемого счёта, 
//   после чего предлагает либо вернуться в меню, либо совершить выход.
// 4. Если пользователь выбирает пополнение счёта,
//   программа запрашивает сумму для пополнения и выполняет операцию, 
//   сопровождая её выводом соответствующего комментария.
//   Затем следует предложение вернуться в меню или выполнить выход.
// 5. Если пользователь выбирает снять деньг со счёта, программа запрашивает сумму.
//   Если сумма превышает сумму счёта пользователя, программа выдаёт сообщение и 
//   переводит пользователя в меню. Иначе - отображает сообщение о том, 
//   что сумма снята со счёта и уменьшает сумму счёта на указанную величину.

// Все данные о клиенте хранить в файле.
// Предусмотреть возможность авторизации нескольких клиентов.
// Если были произведены попытки авторизации с тремя вводами неверного пароля - 
// в файл записывать данные о попытке и при последующем обращении - 
// выводить пользователю данной карты информацию о попытках неавторизованного входа.

// Предусмотреть набор событий, которые возникают в случае:
//   попытки снятия большего количества средств, чем есть на счету.
//   Попытки смены пароля
//   При выходе балланса в ноль передавать в событие лямбду. с сообщением. "Ваш балланс равен 0"

// Для всех изменений пользовательских данных предусмотреть событиие.

namespace dotnet_bank_bankomat_client
{
    class Program
    {

        static void Main(string[] args)
        {
            bool isNotExit = true;
			Bank bank = new Bank();

			Menu.SetUp("Что делаем?", Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 8);
			Menu.AddMenu("Получить новую карту", () => {
				bank.NewClient();
			});

            Menu.AddMenu("Показать клиентов", () => {
				Menu.Clear();
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(bank);
				Console.ReadKey();

			});

			Menu.AddMenu("Clear", () => {
				Menu.Clear();
				Console.ReadKey();
			});

			Menu.AddMenu("4", () => {

			});

			Menu.AddMenu("Выход", () => { isNotExit = false; });




			

			Console.CursorVisible = false;
            Menu.DrawMenu();

			do
            {
                Menu.Action(Console.ReadKey());
            } while (isNotExit);


        }
    }
}
