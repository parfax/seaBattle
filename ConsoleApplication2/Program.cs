using System;
using System.Threading;

namespace ConsoleApplication2
{
    public class Program
    {
        // [* CONFIGURATION *]
        private static int width = 10, height = 10; // Игровое поле
        static int[,]field = new int[height, width];
        static int[,]botField = new int[height, width];
        
        private static string[] alphabet = {"а", "б", "в", "г", "д", "е", "ж", "з", "и", "к"}; // Нумерация и буквы
        private static string[] numeration = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        
        static int shipCount = 0; // Кол-во кораблей (4й = макс 1, 3й = макс 2, 2й = макс 3, 1 = макс 4)

        // MENU
        public static void Main(string[] args) {
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
                                   System.Threading.Thread.Sleep(500);
                                   break;
            }
        }
        static void GO()
        {
            Console.Title = "Морской бой";
            Console.CursorVisible = false;
            
            SpawnFour();
            while (shipCount<1)
            {
                SpawnThree();
            }
            shipCount = 0;
            while (shipCount<3)
            {
                SpawnTwo();
            }
            shipCount = 0;
            while (shipCount<4)
            {
                SpawnOne();
            }
            generate_field();
            generate_Bot_field();
        }
        
        static void generate_field()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 0);
                Console.Write(alphabet[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i+1);
                Console.Write(numeration[i]);
                Console.SetCursorPosition(2, i+1);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i+1);
                    Part(field[i, j]);
                }
            }
        }
        static void generate_Bot_field()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 26);
                Console.Write(alphabet[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i+16);
                Console.Write(numeration[i]);
                Console.SetCursorPosition(2, i+16);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i+16);
                    Part(botField[i, j]);
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
        private static void SpawnFour()
        {
            Random random = new Random();
            int x = random.Next(10);
            int y = random.Next(10);
            if (x > 5)
            {
                y = random.Next(5);
                for (int i = y; i < y + 4; i++)
                    field[i, x] = 1;
                return;
            }
            if (y > 5)
            {
                x = random.Next(5);
                for (int j = x; j < x + 4; j++)
                    field[y, j] = 1;
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y; i < y + 4; i++)
                    field[i, x] = 1;
            }
            else
            {
                for (int j = x; j < x + 4; j++)
                    field[y, j] = 1;
            }
        }

        private static void SpawnThree()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 6)
            {
                x = random.Next(7);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                        i++;

                    if (i > 9)
                        break;

                    for (int j = x - 1; j < x + 4; j++)
                    {
                        if (j < 0)
                            j++;

                        if (j > 9)
                            break;

                        if (field[i, j] != 0)
                            return;
                    }
                }

                for (int j = x; j < x + 3; j++)
                    field[y, j] = 1;

                shipCount++;
            }

            if (x > 6)
            {
                y = random.Next(7);
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                        i++;

                    if (i > 9)
                        break;

                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                            j++;

                        if (j > 9)
                            break;

                        if (field[i, j] != 0)
                            return;
                    }
                }

                for (int i = y; i < y + 3; i++)
                    field[i, x] = 1;

                shipCount++;
                return;
            }
        }
        private static void SpawnTwo()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 7)
            {
                x = random.Next(8);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                        i++;

                    if (i > 9)
                        break;

                    for (int j = x - 1; j < x + 3; j++)
                    {
                        if (j < 0)
                            j++;

                        if (j > 9)
                            break;

                        if (field[i, j] != 0)
                            return;
                    }
                }

                for (int j = x; j < x + 2; j++)
                    field[y, j] = 1;

                shipCount++;
            }

            if (x > 7)
            {
                y = random.Next(8);
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                        i++;

                    if (i > 9)
                        break;

                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                            j++;

                        if (j > 9)
                            break;

                        if (field[i, j] != 0)
                            return;
                    }
                }

                for (int i = y; i < y + 3; i++)
                    field[i, x] = 1;

                shipCount++;
            }
        }

        private static void SpawnOne()
        {
            Random random = new Random();
            int x = random.Next(10);
            int y = random.Next(10);
            for (int i = y - 1; i < y + 2; i++)
            {
                if (i < 0)
                    i++;
                if (i > 9)
                    break;
                for (int j = x - 1; j < x + 2; j++)
                {
                    if (j < 0)
                        j++;
                    if (j > 9)
                        break;
                    if (field[i, j] != 0)
                        return;
                }
            }
            field[y, x] = 1;
            shipCount++;
        }
    }
}