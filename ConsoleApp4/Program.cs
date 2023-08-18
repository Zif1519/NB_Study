namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //           Jindo jindo = new Jindo();
            //           Dog dog = jindo;
            //           Animal animal = jindo;

            //           Console.WriteLine($"\n" 
            //               + $"{jindo.a}, " 
            //               + $"{jindo.b}, "
            //               + $"{jindo.c}" 
            //               + $"\n" 
            //               + $"{(dog).a}, " 
            //               + $"{(dog).b}, " 
            ////               + $"{(dog).c}" 
            //               + $"\n" 
            //               + $"{(animal).a}, " 
            ////               + $"{(animal).b}, " 
            ////               + $"{(animal).c}"
            //               );

            //            string[] a = new string[] { "hi" };
            //            string[] b = new string[] { "" };
            //            Console.Write(a[0]);
            //            Console.WriteLine(b[0]);
            //            b = a;
            //            Console.Write(a[0]);
            //            Console.WriteLine(b[0]);
            //            b[0] = "bye";
            //            Console.Write(a[0]);
            //            Console.WriteLine(b[0]);


            //            int a1 = 10;
            //            int b1 = a1;
            //            b1 = 20;

            //            Console.Write(a1);
            //            Console.WriteLine(b1);

            //            object obj = a1;
            //            Console.Write(a1);
            //            Console.WriteLine(b1);
            ////            Console.WriteLine((int)obj1);
            ////            Console.WriteLine((int)obj2);

            //            object obj2 = obj;
            //            obj2 = 30;


            //            int originalValue = 42;

            //            // Boxing
            //            object boxedValue = originalValue;

            //            // Copy by Value (for boxed value)
            //            object copiedBoxedValue = boxedValue;

            //            // Copy by Reference (for original value)
            //            int copiedOriginalValue = originalValue;

            //            // Change the original value
            //            originalValue = 99;

            //Console.WriteLine("Original Value: " + originalValue);
            //Console.WriteLine("Boxed Value: " + boxedValue);
            //Console.WriteLine("Copied Boxed Value: " + copiedBoxedValue);
            //Console.WriteLine("Copied Original Value: " + copiedOriginalValue);



            //List<object> nums = new List<object>();
            //int test = 10;
            //nums.Add(test);
            //int test2 = 20;
            //object test3 = 30;

            //test2 = (int)nums[0];
            //test3 = nums[0];
            //test3 = 40;

            //Console.Write($"{test} , {test2}, {test3}, {nums[0]}");

            int a = 10;

            object b = a;
            object c = a;
            object d = b;

            object e = new object();
            object f = e;

            Console.WriteLine($" a == b ? : {(int)b == a}");
            Console.WriteLine($" b == c ? : {b == c}");
            Console.WriteLine($" (int)b == (int)c ? : {(int)b == (int)c}");
            Console.WriteLine($" b == d ? : {b == d}");
            Console.WriteLine($" f == e ? : {f == e}");


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