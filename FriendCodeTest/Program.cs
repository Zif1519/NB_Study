namespace SnakeGame
{

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
       //     dog.Bark(str);
        }
    }

    public class Dog
    {
        public int str = 10;
        public void Bark(int _str)
        {
            Console.WriteLine(str);
        }
    }
}