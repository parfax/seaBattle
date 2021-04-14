using System;
using System.Threading;

namespace ConsoleApplication2
{
    public class Program
    {
        // [* CONFIGURATION *]
        private static readonly int width = 10; // Игровое поле
        private static readonly int height = 10; // Игровое поле
        private static readonly char[,] field = new char[height, width];
        private static readonly char[,] botField = new char[height, width];
        private static readonly char[,] showBotField = new char[height, width];

        private static readonly string[]
            alphabet = {"а", "б", "в", "г", "д", "е", "ж", "з", "и", "к"}; // Нумерация и буквы

        private static readonly string[] numeration = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        private static string message;

        private static char symbol;
        public static int Step = new int(); // !!! Порешай чтобы их не было !!!
        private static readonly int[] Letter = new int[10]; // !!! Порешай чтобы их не было !!!
        private static readonly int[] Index = new int[10]; // !!! Порешай чтобы их не было !!!

        // MENU
        public static void Main(string[] args)
        {
            Console.Title = "Морской бой | Menu";

            Console.WriteLine("===============MENU===============\n" +
                              " Нажмите Enter чтобы Начать Игру\n" +
                              " Нажмите Esc чтобы Выйти из игры\n" +
                              "==================================\n" +
                              "Ваш выбор:");

            ConsoleKeyInfo keyPressed;
            keyPressed = Console.ReadKey();

            switch (keyPressed.Key)
            {
                case ConsoleKey.Enter:
                    GO();
                    break;

                case ConsoleKey.Escape:
                    Console.WriteLine(" Выходим из игры...");
                    Thread.Sleep(500);
                    break;
            }
        }

        private static void GO()
        {
            Console.Title = "Морской бой";
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                showBotField[i, j] = '/';
            generate_field(field);
            generate_field(botField);
            visualizeGame();

            while (true)
            {
                var isValid = true;
                while (isValid)
                {
                    Console.SetCursorPosition(30, 11);
                    Console.Write("Куда стрелять? Введите координаты: ");
                    switch (Console.Read())
                    {
                        case 'а':
                            Letter[Step] = 0;
                            isValid = false;
                            break;
                        case 'б':
                            Letter[Step] = 1;
                            isValid = false;
                            break;
                        case 'в':
                            Letter[Step] = 2;
                            isValid = false;
                            break;
                        case 'г':
                            Letter[Step] = 3;
                            isValid = false;
                            break;
                        case 'д':
                            Letter[Step] = 4;
                            isValid = false;
                            break;
                        case 'е':
                            Letter[Step] = 5;
                            isValid = false;
                            break;
                        case 'ж':
                            Letter[Step] = 6;
                            isValid = false;
                            break;
                        case 'з':
                            Letter[Step] = 7;
                            isValid = false;
                            break;
                        case 'и':
                            Letter[Step] = 8;
                            isValid = false;
                            break;
                        case 'к':
                            Letter[Step] = 9;
                            isValid = false;
                            break;
                        default:
                            message = "Введите координаты на кириллице, например д5";
                            visualizeGame();
                            break;
                    }
                }

                Index[Step] = int.Parse(Console.ReadLine()) - 1;
                Hit(Index[Step], Letter[Step]);
                visualizeGame();
            }
        }

        private static void visualizeGame()
        {
            Console.Clear();
            draw(field, 0);
            draw(showBotField, 13);
            Console.SetCursorPosition(30, 8);
            Console.Write("[ИНФОРМАЦИЯ]");
            Console.SetCursorPosition(30, 10);
            Console.Write(message);
        }

        public static void Hit(int x, int y)
        {
            if (showBotField[x, y] == '*' || showBotField[x, y] == 'X')
            {
                message = "Нельзя стрелять в эту клетку";
            }
            else if (botField[x, y] == '/')
            {
                showBotField[x, y] = '*';
                message = "Промах!";
            }
            else if (botField[x, y] == '\u25A0')
            {
                showBotField[x, y] = 'X';
                message = "Попадание!";
            }
        }

        private static void generate_field(char[,] field)
        {
            var rand = new Random();

            for (var x = 0; x < height; x++)
            for (var y = 0; y < width; y++)
            {
                if (rand.Next(1, 100) < 20)
                    symbol = '\u25A0';
                else
                    symbol = '/';
                field[x, y] = symbol;
            }
        }

        private static void draw(char[,] field, int crusr)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, crusr);
                Console.Write(alphabet[i]);
            }

            for (var i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + crusr + 1);
                Console.Write(numeration[i]);
                Console.SetCursorPosition(2, i + crusr + 1);
                Console.Write("|");
                Console.SetCursorPosition(3, i + crusr);
                for (var j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + crusr + 1);
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}