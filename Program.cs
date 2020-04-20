using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Program
    {
        public static int width = 10, height = 10;
        public static int headX, headY, fruitX, fruitY, size = 1;
        public static ConsoleKeyInfo f;
        public static string move = "";
        public static bool eat = false;
        public static string[,] map = new string[width, height];
        public static int[] masX = new int[size];
        public static int[] masY = new int[size];
        public static bool game = true;
        
        
        static void Main(string[] args)
        {
            while(true)
            {
                Random rnd = new Random();
                headX = width - 2; headY = 1;
                while (true)
                {
                    fruitX = rnd.Next(1, width - 2); fruitY = rnd.Next(1, height - 2);
                    if (fruitX == headX && fruitY == headY || fruitX != headX && fruitY == headY || fruitX != headX && fruitY != headY)
                    {
                        break;
                    }
                }
                while (game == true)
                {
                    Console.Clear();
                    Game.Draw(width, height, ref headX, ref headY, ref fruitX, ref fruitY, ref map);
                    Game.Move(width, height, ref headX, ref headY, move, ref map);
                    
                    if (fruitX == headX && headX == headY)
                    {
                        Game.Fruit(width, height, ref fruitX, ref fruitY, ref map); //TO DO Еда генерируется, но не отрисовывается
                    }
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            Console.Write(map[i, j]);
                        }
                        Console.WriteLine();
                    }

                    if (Console.KeyAvailable == true)
                    {
                        f = Console.ReadKey();
                        if (f.Key == ConsoleKey.UpArrow)
                            if (move != "Down")
                                move = "Up";
                        if (f.Key == ConsoleKey.DownArrow)
                            if (move != "Up")
                                move = "Down";
                        if (f.Key == ConsoleKey.RightArrow)
                            if (move != "Left")
                                move = "Right";
                        if (f.Key == ConsoleKey.LeftArrow)
                            if (move != "Right")
                                move = "Left";
                    }
                    System.Threading.Thread.Sleep(400);
                }
            }
        } 
    }
    class Game
    {
        public static void Move(int width, int height, ref int headX, ref int headY, string move, ref string[,] map)
        {
            {
                map[headX, headY] = " ";
                switch (move)
                {
                    case "Up":
                        if (headX - 1 >= 0) headX -= 1;
                        break;
                    case "Down":
                        if (headX + 1 < width) headX += 1;
                        break;
                    case "Left":
                        if (headY - 1 >= 0) headY -= 1;
                        break;
                    case "Right":
                        if (headY + 1 < height) headY += 1;
                        break;
                }
                map[headX, headY] = "X";
            }

        }
        public static void Draw(int width, int height, ref int headX, ref int headY, ref int fruitX, ref int fruitY, ref string[,] map)
        {
            Random rnd = new Random();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    map[i, j] = " ";
                    if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                    {
                        map[i, j] = "=";
                    }
                }
            }

            map[headX, headY] = "X";

            map[fruitX, fruitY] = "*";
        }
        public static void Fruit(int width, int height, ref int fruitX, ref int fruitY, ref string[,] map)
        {
            Random rnd = new Random();
            fruitX = rnd.Next(1, width - 1); fruitY = rnd.Next(1, height - 1);
            
        }
        public static void EatGenerate(int width, int height, ref string[,] map, ref int fruitX, ref int fruitY, int headX, int headY, ref bool eat, int[] masX, int[] masY)
        {
            if (fruitX == headX && headX == headY)
            {
                eat = true;
                Random rnd = new Random();
                bool s = true;
                while (s == true)
                {
                    fruitX = rnd.Next(1, width - 2);
                    fruitY = rnd.Next(1, height - 2);
                    while (s == true)
                    {
                        fruitX = rnd.Next(1, width - 2);
                        fruitY = rnd.Next(1, height - 2);
                        int p = 0;
                        if (fruitX != headX && fruitY == headY || fruitY != headY && fruitX == headX || fruitX != headX && fruitY != headY)
                        {
                            for (int i = 0; i < masX.Length; i++)
                            {
                                if (fruitX != masX[i] && fruitY == masY[i] || fruitY != masY[i] && fruitX == masX[i] || fruitX != masX[i] && fruitY != masY[i])
                                    p++;
                                if (p == masX.Length)
                                    s = false;
                            }
                        }

                    }
                    map[fruitX, fruitY] = "*";
                }
            }
        }
    }

}
