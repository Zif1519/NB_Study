namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jindo jindo = new Jindo();
            Dog dog = jindo;
            Animal animal = jindo;

            Console.WriteLine($"\n" 
                + $"{jindo.a}, " 
                + $"{jindo.b}, "
                + $"{jindo.c}" 
                + $"\n" 
                + $"{(dog).a}, " 
                + $"{(dog).b}, " 
 //               + $"{(dog).c}" 
                + $"\n" 
                + $"{(animal).a}, " 
 //               + $"{(animal).b}, " 
 //               + $"{(animal).c}"
                );
        }
    }


    public class Animal
    {
        public int a = 1;
    }
    public class Dog : Animal
    {
        public int a = 2;
        public int b = 2;
    }
    public class Jindo : Dog
    {
        public int a = 3;
        public int b = 3;
        public int c = 3;
    }

}