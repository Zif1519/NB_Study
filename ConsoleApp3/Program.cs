namespace ConsoleApp3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int mapHeight = 15;
            int mapWidth = 15;
            Snake Snake = new Snake();

            bool isFoodOn = false;
            Position food = new Position(0,0);
            int foodCount = 2;

            DrawMap(mapWidth, mapHeight);

            while (true)
            {
                if (!isFoodOn)
                {
                    MakeApple(mapWidth, mapHeight, Snake.Head, Snake.Body, ref isFoodOn, ref food);
                }

                DrawSnake(Snake);
                Thread.Sleep(300);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            Snake.direction = Snake.DIRECTION.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            Snake.direction = Snake.DIRECTION.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            Snake.direction = Snake.DIRECTION.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            Snake.direction = Snake.DIRECTION.Down;
                            break;
                        default:
                            break;
                    }
                }

                if (Snake.Head.x == food.x && Snake.Head.y == food.y)
                {
                    isFoodOn = false;
                    foodCount++;
                    food.x = -1;
                    food.y = -1;
                }

                if (foodCount >= 1)
                {
                    Snake.Lengthen();
                    foodCount--;
                }else
                {
                    Snake.Move();
                }
                
                if (Snake.Body.Any(item => item.x == Snake.Head.x && item.y == Snake.Head.y))
                {
                    break;
                }
                if (Snake.Head.x > 15 ||  Snake.Head.x < 0 || Snake.Head.y > 15 || Snake.Head.y < 0)
                {
                    break;
                }
            }
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("\n\n\n 게임이 종료되었습니다. \n\n\n");
        }
        public static void DrawMap(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("\u00B7");
                }
                Console.WriteLine();
            }
        }
        public static void MakeApple(int mapWidth, int mapHeight, Position head, Queue<Position> body, ref bool foodOn, ref Position food)
        {
            foodOn = true;
            Position position = new Position(0, 0);
            bool isContain = true;
            while (isContain || (position.x == head.x && position.y == head.y))
            {
                Random random = new Random();
                position.x = random.Next(0, mapWidth);
                position.y = random.Next(0, mapHeight);

                isContain = body.Any(item => item.x == position.x && item.y == position.y);
            }

            food.x = position.x;
            food.y = position.y;

            Console.SetCursorPosition(position.x*2, position.y);
            Console.Write("\u2605");
            
        }

        public static void DrawSnake(Snake snake)
        {
            if (snake == null) return;
            Console.SetCursorPosition(snake.Head.x*2, snake.Head.y);
            Console.Write('\u25A1');
            foreach(Position position in snake.Body)
            {
                Console.SetCursorPosition(position.x * 2, position.y);
                Console.Write('\u25A1');
            }
        }
    }

    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Snake
    {
        public enum DIRECTION { Left = 0, Right, Up, Down }

        public DIRECTION direction = DIRECTION.Left;
        public Position Head { get; set; } = new Position(10, 10);
        public Queue<Position> Body { get; set; } = new Queue<Position>();

        Position dummy = new Position(0, 0);

        public void Lengthen()
        {
            Position add = new Position(0,0);
            add.x = Head.x;
            add.y = Head.y;

            Body.Enqueue(add);
            Head = MoveHead(Head);
        }
        public void Shorten(int length)
        {
            for (int i = 0; i < length; i++)
            {
                dummy = Body.Dequeue();
                Console.SetCursorPosition(dummy.x * 2, dummy.y);
                Console.Write('\u00B7');
            }
            Head = MoveHead(Head);
        }
        public void Move()
        {
            Body.Enqueue(Head);
            dummy = Body.Dequeue();
            Console.SetCursorPosition(dummy.x * 2, dummy.y);
            Console.Write('\u00B7');
            Head = MoveHead(Head);
        }
        public Position MoveHead(Position head)
        {
            switch (direction)
            {
                case DIRECTION.Left:
                    head.x -= 1;
                    break;
                case DIRECTION.Right:
                    head.x += 1;
                    break;
                case DIRECTION.Up:
                    head.y -= 1;
                    break;
                case DIRECTION.Down:
                    head.y += 1;
                    break;
            }
            return head;
        }
    }
}
