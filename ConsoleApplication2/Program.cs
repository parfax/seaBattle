using System;
using System.Threading;

namespace ConsoleApplication2
{
    public class Program
    {
        // [* CONFIGURATION *]
        private static int width = 10, height = 10; // Игровое поле
        static char[,] field = new char[height, width];
        static char[,] botField = new char[height, width];

        private static string[] alphabet = {"а", "б", "в", "г", "д", "е", "ж", "з", "и", "к"}; // Нумерация и буквы
        private static string[] numeration = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        static int shipCount = 0; // Кол-во кораблей (4й = макс 1, 3й = макс 2, 2й = макс 3, 1 = макс 4)

        static char symbol;
        public static int Step = new int();
        static int[] Letter = new int[11];
        static int[] Index = new int[11];

        // MENU
        public static void Main(string[] args)
        {
            Console.Title = "Морской бой | Menu";

            Console.WriteLine("===============MENU===============\n" +
                              " Нажмите Enter чтобы Начать Игру\n" +
                              " Нажмите Esc чтобы Выйти из игры\n==================================\nВаш выбор:");

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

        static void GO()
        {
            Console.Title = "Морской бой";
            Console.CursorVisible = false;
            
            Console.Clear();
            
            generate_field();draw();
            generate_Bot_field();
            drawBot();
            
            //
            //
            Console.Write("Куда стрелять? "); // Coming soon
            Boolean letter = true;
            while (letter)
            {
                Console.Write("Ваш выстрел: ");
                switch (Console.Read())
                {
                    case 'а':
                        Letter[Step] = 0;
                        letter = false;
                        break;
                    case 'б':
                        Letter[Step] = 1;
                        letter = false;
                        break;
                    case 'в':
                        Letter[Step] = 2;
                        letter = false;
                        break;
                    case 'г':
                        Letter[Step] = 3;
                        letter = false;
                        break;
                    case 'д':
                        Letter[Step] = 4;
                        letter = false;
                        break;
                    case 'е':
                        Letter[Step] = 5;
                        letter = false;
                        break;
                    case 'ж':
                        Letter[Step] = 6;
                        letter = false;
                        break;
                    case 'з':
                        Letter[Step] = 7;
                        letter = false;
                        break;
                    case 'и':
                        Letter[Step] = 8;
                        letter = false;
                        break;
                    case 'к':
                        Letter[Step] = 9;
                        letter = false;
                        break;
                }
            }
            Index[Step] = int.Parse(Console.ReadLine()) - 1;
            Hit(Letter[Step], Index[Step]);

        }
        public static bool Hit(int x, int y)
        {
            if (botField[x, y] == '/')
            {
                Console.SetCursorPosition(x+6, y+14);
                Console.Write('*');
                Console.SetCursorPosition(30, 10);
                Console.Write("Промах!   ");
                return false;
            }
            if (botField[x, y] =='\u25A0')
            {
                Console.SetCursorPosition(x+6, y+14);
                Console.Write('X');
                Console.SetCursorPosition(30, 11);
                Console.Write("Попадание!");
                return true;
            }
            Console.SetCursorPosition(30, 0);
            Console.Write("Нельзя стрелять в эту клетку");
            Console.SetCursorPosition(30, 4);
            Console.WriteLine();
            Step--;
            return true;
        }
        static void generate_field()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 0);
                Console.Write(alphabet[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write(numeration[i]);
                Console.SetCursorPosition(2, i + 1);
                Console.Write("|");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    Random rand = new Random();
            
                    for (int x = 0; x < height; x++)
                    {            
                        for (int y = 0; y < width; y++)
                        {
                            if (rand.Next(1, 100) < 20)
                                symbol = '\u25A0';
                            else
                                symbol = '/';

                                field[x, y]=symbol;
                            
                        }
                    }
                }
            }
        }
        static void draw()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(3, i + 1);
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    symbol = field[i, j];
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
        static void drawBot()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(3, i + 13);
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 14);
                    Console.Write('/');
                }
            }
        }

        static void generate_Bot_field()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 13);
                Console.Write(alphabet[i]);
            }
        
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 14);
                Console.Write(numeration[i]);
                Console.SetCursorPosition(2, i + 14);
                Console.Write("|");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    Random rand = new Random();
            
                    for (int x = 0; x < height; x++)
                    {            
                        for (int y = 0; y < width; y++)
                        {
                            if (rand.Next(1, 100) < 20)
                                symbol = '\u25A0';
                            else
                                symbol = '/';

                            botField[x, y]=symbol;
                        }
                    }
                }
            }
        }
        
        public static void Part(int a)
        {
            switch (a)
            {
                case 0:
                    Console.Write('/');
                    break;
                case 1:
                    Console.Write('\u25A0');
                    break;
                case 2:
                    Console.Write('X');
                    break;
                case 3:
                    Console.Write('•');
                    break;
            }
        }
    }
}