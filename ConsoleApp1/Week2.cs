using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Week2
    {
        public void Process1()
        {
            int score = 55;
            string playerRank = "";
            switch (score / 10)
            {
                case 10:
                case 9:
                    playerRank = "Diamond";
                    break;
                case 8:
                    playerRank = "Platinum";
                    break;
                case 7:
                    playerRank = "Gold";
                    break;
                case 6:
                    playerRank = "Silver";
                    break;
                default:
                    playerRank = "Bronze";
                    break;
            }
            Console.WriteLine(playerRank);
        }


        public void NumberBaseBall()
        {
            int[] hidenNumbers = new int[3];
            int[] guessNumbers = new int[3];
            Console.WriteLine("Start to create Hidden Numbers");
            while (hidenNumbers[0] == hidenNumbers[1] || hidenNumbers[1] == hidenNumbers[2] || hidenNumbers[0] == hidenNumbers[2])
            {
                for (int i = 0; i < hidenNumbers.Length; i++)
                {
                    hidenNumbers[i] = new Random().Next(0, 10);
                }
            }
            Console.WriteLine("Success to create Hidden Numbers");
            // Console.WriteLine($"{hidenNumbers[0]} , {hidenNumbers[1]} , {hidenNumbers[2]}");


            Console.Write("Do you want to read Rules of NumberBaseBall? ( Y / N )");
            string rule = Console.ReadLine();
            if (rule[0] == 'Y')
            {
                Console.WriteLine("\n\n\nGuess the Hidden Numbers. numbers position is also important.");
                Console.WriteLine("If your guessed number matches both Hidden Number and its position, You get 1 strike.");
                Console.WriteLine("If your guessed number matches Hidden Number but wrong position, You get 1 ball.");
                Console.WriteLine("Example  HiddenNumbers [5],[3],[7]   and   you guessed [3], [4], [7]");
                Console.WriteLine("[3] is matched but its position is wrong so you get 1ball");
                Console.WriteLine("and [7] is matched also its position is matched so you get 1strike");
                Console.WriteLine("You have 10times of chance. GoodLuck!\n\n\n");
            } else 
            {
                Console.WriteLine("\n\n\nYou skipped the game rules\n\n\n");
            }

            Console.WriteLine("Game is Started, Guess the Hidden Numbers. \nex) \"3 5 2\" , \"8 2 5\"\n\n");
            int tryCount = 0;
            while (tryCount != 10)
            {
                tryCount++;
                Console.Write($"{tryCount} try, New Guess numbers : ");
                string answer = Console.ReadLine();
                string[] numbers = answer.Split(' ');
                guessNumbers[0] = int.Parse(numbers[0]);
                guessNumbers[1] = int.Parse(numbers[1]);
                guessNumbers[2] = int.Parse(numbers[2]);

                int strikeCount = 0;
                int ballCount = 0;
                for (int i=0; i < 3; i++) 
                { 
                    for (int j=0; j < 3; j++) 
                    {
                        if (guessNumbers[i] == hidenNumbers[j] && i == j) strikeCount++;
                        if (guessNumbers[i] == hidenNumbers[j] && i != j) ballCount++;
                    }
                }
                if (strikeCount == 3)
                {
                    Console.WriteLine("\n\nCongratulations! You have won the game.\n\n");
                    break;
                }
                Console.WriteLine($"{tryCount} try, result : {strikeCount} strike , {ballCount} ball\n");
            }
            if (tryCount == 10) Console.WriteLine("\n You lose the game. \n");
        }
    }
}
