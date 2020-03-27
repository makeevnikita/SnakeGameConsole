using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;


namespace ConsoleApp6
{
    enum ControlKey
    { 
        UP, DOWN, RIGHT, LEFT, NULL
    };
    class Segments
    {
        public static int x, y;
    }
    class Program
    {

        public static int sizeI = 10, sizeJ = 10, snakeI = sizeI / 2, snakeJ = sizeJ / 2, segments = 2, score = 0, tmp = 0;
        public static string[,] field = new string[sizeI, sizeJ];
        public static Random rnd = new Random();
        public static int fruitI = rnd.Next(1, sizeI - 1), fruitJ = rnd.Next(1, sizeJ - 1);
        static ControlKey key;
        
        static void draw()
        {
            Console.Clear();
            for (int i = 0; i < sizeI - 1; ++i)
            {
                for(int j = 0; j < sizeJ; ++j)
                {
                    if(field[i, j] != "0")
                    {
                        field[i, j] = "#";
                    }
                }
            }

            field[snakeI, snakeJ] = "O";
            for(int i = 0; i < segments; ++i)
            {
                for(int j = 0; j < segments; ++j)
                {
                    field[snakeI, snakeJ] = "O";

                }
            }
            field[fruitI, fruitJ] = "@";

            for (int i = 0; i < sizeI - 1; ++i)
            {
                for (int j = 0; j < sizeJ; ++j)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            if(snakeI == fruitI && snakeJ == fruitJ)
            {
                fruitI = rnd.Next(1, sizeI - 1);
                fruitJ = rnd.Next(1, sizeJ - 1);
                if(key == ControlKey.UP)
                {
                    field[snakeI, snakeJ] = "0";
                    --snakeI;
                    
                }
            }
            
        }
        static void control()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                switch (keyInfo.KeyChar)
                {
                    case 'w':
                        key = ControlKey.UP;
                        break;
                    case 'd':
                        key = ControlKey.RIGHT;
                        break;
                    case 'a':
                        key = ControlKey.LEFT;
                        break;
                    case 's':
                        key = ControlKey.DOWN;
                        break;
                }
            }
        }
        static void snake()
        {
        
            switch (key)
            {
                case ControlKey.LEFT:
                    if(snakeJ == 0)
                    {
                        snakeJ = sizeJ - 1;
                    }
                    else
                    {
                        --snakeJ;
                    }
                    break;
                case ControlKey.RIGHT:
                    if(snakeJ == sizeJ - 1)
                    {
                        snakeJ = 0;
                    }else
                    {
                        snakeJ++;
                    }
                    break;
                case ControlKey.DOWN:
                    if(snakeI == sizeI - 1)
                    {
                        snakeI = 0;
                    }else
                    {
                        snakeI++;
                    }
                    break;
                case ControlKey.UP:
                    if(snakeI == 0)
                    {
                        snakeI = sizeI - 1;
                    }else
                    {
                        snakeI--;
                    }
                    break;

            }       
        }
        static void Main(string[] args)
        {

            do
            {

                draw();
                control();
                snake();
                Thread.Sleep(340);
            } while (true);
        }

    }
}