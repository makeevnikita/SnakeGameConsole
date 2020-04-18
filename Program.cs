using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Program
    {
        public static int width = 40, height = 50;
        public static int headX, headY, fruitX, fruitY, size = 1;
        public static ConsoleKeyInfo f;
        public static string move = "";
        bool eat = false;
        public static string[,] map = new string[width, height];
        public static int[] masX = new int[size];
        public static int[] maxY = new int[size];
        public static bool game = true;
        
        
        static void Main(string[] args)
        {
            Game.Move(width, height, ref headX, ref headY, move, ref map);
        }
        public static void Control()
        {
            while (game == true)
            {
                Console.WriteLine();
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
                        if (headY - 1 >= 0) headY -= 1;
                        break;
                    case "Down":
                        if (headY + 1 < width) headY += 1;
                        break;
                    case "Left":
                        if (headX - 1 >= 0) headX -= 1;
                        break;
                    case "Right":
                        if (headX + 1 < height) headX += 1;
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
                for (int j = 0; i < height; ++j)
                {
                    if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                    {
                        map[i, j] = "=";
                    }
                }
            }
            headX = width - 2; headY = 1;
            map[headX, headY] = "X";
            while (true)
            {
                fruitX = rnd.Next(1, width - 2); fruitY = rnd.Next(1, height - 2);
                if (fruitX == headX && fruitY == headY || fruitX != headX && fruitY == headY || fruitX != headX && fruitY != headY)
                {
                    break;
                }
            }
            map[fruitX, fruitY] = "*";
        }
    }

}
