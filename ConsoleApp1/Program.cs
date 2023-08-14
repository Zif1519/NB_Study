namespace ConsoleApp1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Week2 week2 = new Week2();
            week2.NumberBaseBall();
        }
        public static void Process1()
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Age : ");
            string age = Console.ReadLine();

            Console.WriteLine($"Name : {name} , Age : {age}");
        }


        public static void Process2() 
        {
            Console.Write("Please input two numbers (ex \"20 30\") : ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);

            int sum = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {sum}");
        }


        public static void Process3() 
        {
            Console.WriteLine("Input Celsius Temperature : ");
            String input = Console.ReadLine();
            float celsius = float.Parse(input);
            float fahrenheit = celsius * 1.8f + 32f;

            Console.WriteLine($"Celsius Temperature : {celsius} is");
            Console.WriteLine($"Fahrenheit Temperature : {fahrenheit}");
        }


        public static void BMI()
        {
            Console.WriteLine("Input your height : ");
            string input1 = Console.ReadLine();
            Console.WriteLine("Input your weight : ");
            string input2 = Console.ReadLine();

            float height = float.Parse(input1);
            float weight = float.Parse(input2);

            float bmi = (weight * 10000f) / (height * height);

            Console.WriteLine($"Your BMI : {bmi} ");
        }
    }
}
