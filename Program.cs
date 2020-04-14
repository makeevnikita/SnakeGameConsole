using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class coord
    {
        public int X, Y;
        public coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }



    class Program
    {
        public static Random rnd = new Random();
        public static int W = 20, H = 20;
        public static string[,] field = new string[W,H];
        public static List<coord> snake = new List<coord>();
        public static coord fruit;
        public static int move = 10;

        static void Control()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    if (move != 1)
                        move = 0;
                    break;
                case ConsoleKey.D:
                    if (move != 0)
                        move = 1;
                    break;
                case ConsoleKey.W:
                    if (move != 3)
                        move = 2;
                    break;
                case ConsoleKey.S:
                    if (move != 2)
                        move = 3;
                    break;
            }
            Console.Clear();
            Logic();
        }
        static void Logic()
        {
            int x = snake[0].X, y = snake[0].Y;

            switch (move)
            {
                case 0:
                    --y;
                    snake[snake.Count - 1].X = snake[snake.Count - 2].X;
                    snake[snake.Count - 1].Y = snake[snake.Count - 2].Y;
                    snake[0].Y -= 1;
                    for(int i = 1; i < snake.Count - 1; ++i)
                    {

                    }
                    break;
                case 1:
                    ++y;
                    break;
                case 2:
                    --x;
                    break;
                case 3:
                    ++x;
                    break;

            }

            
            coord newSegment = new coord(x, y);
            if (snake[0].X == fruit.X && snake[0].Y == fruit.Y)
            {
                fruit.X = rnd.Next(0, W - 1);
                fruit.Y = rnd.Next(0, H - 1);
                
                snake.Insert(0, newSegment);
            }
            Draw();
        }
        static void Draw()
        {
            for(int i = 0; i < W; ++i)
            {
                for(int j = 0; j < H; ++j)
                {
                    field[i, j] = "=";
                }
            }
            for(int i = 0; i < snake.Count; ++i)
            {
                field[snake[i].X, snake[i].Y] = "#";
            }
            for(int i = 0; i < W; ++i)
            {
                for(int j = 0; j < H; ++j)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            for(int i = 0; i < snake.Count; ++i)
            {
                Console.WriteLine(snake[i].X + " " + snake[i].Y);
            }
            Console.WriteLine("move= " + move);
            Console.WriteLine(snake.Count);
            Control();
        }
        static void Main(string[] args)
        {
            snake.Add(new coord(W / 2, (W/2) - 1));
            snake.Add(new coord(W / 2, (W/2) - 2));
            snake.Add(new coord(W / 2, (W/2) - 3));
            fruit = new coord(rnd.Next(0, W - 1), rnd.Next(0, H - 1));
            Draw();
        }
    }
}
