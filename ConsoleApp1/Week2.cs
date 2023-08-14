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
            }
            else
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
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
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

        public void TicTacToe()
        {
            Console.Write("게임 설명을 원하십니까? ( Y / N )");
            string rule = Console.ReadLine();
            if (rule[0] == 'Y')
            {
                Console.WriteLine("\n\n\n틱택토게임은 가로 세로 대각선을 먼저 잇는 사람이 승리하는 게임입니다.");
                Console.WriteLine("2명의 플레이어는 번갈아 가면서 O와 X를 한칸씩 채울수 있습니다.");
                Console.WriteLine("입력은 좌표로서 \"1,2\" , \"2,3\" 과 같이 입력할 수 있습니다.");
                Console.WriteLine("먼저 1줄을 완성시키는 사람이 승리합니다. \n\n\n");
            }
            else
            {
                Console.WriteLine("\n\n\n게임 설명을 생략합니다.\n\n\n");
            }

            int[,] gameStatus = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            bool isOver = false;
            bool isDraw = false;
            int playerNumber = 2;


            while (!isOver && !isDraw)
            {
                playerNumber = (playerNumber) % 2 + 1;
                if (playerNumber == 1) Console.Write("플레이어1의 차례입니다. 원하시는 좌표를 입력하세요 (1~3),(1~3): ");
                if (playerNumber == 2) Console.Write("플레이어2의 차례입니다. 원하시는 좌표를 입력하세요 (1~3),(1~3): ");

                string[] answer = Console.ReadLine().Split(',');
                
                
                if(gameStatus[int.Parse(answer[0])-1, int.Parse(answer[1])-1] == 0)
                {
                    gameStatus[int.Parse(answer[0]) - 1, int.Parse(answer[1]) - 1] = playerNumber;
                }
                else 
                {
                    Console.WriteLine("이미 돌이 놓여진 자리입니다 다시 선택해주세요.");
                    playerNumber = (playerNumber) % 2 + 1;
                    continue;
                }

                ShowGameStatus(gameStatus);
                isOver = IsGameOver(gameStatus);
                isDraw = IsDrawGame(gameStatus);
            }
            if (isDraw) Console.WriteLine("\n\n무승부 입니다.\n\n");
            if (isOver) Console.WriteLine($"\n\n{playerNumber}플레이어가 승리하였습니다.\n\n");
        }

        public void ShowGameStatus(int[,] status)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (status[i, j])
                    {
                        default:
                            Console.Write(' ');
                            break;
                        case 1:
                            Console.Write('X');
                            break;
                        case 2:
                            Console.Write('O');
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        public bool IsGameOver(int[,] status)
        {
            if (status[0, 0] == status[1, 1] && status[0, 0] == status[2, 2] && status[0, 0] != 0) return true;
            if (status[0, 2] == status[1, 1] && status[2, 0] == status[0, 2] && status[0, 2] != 0) return true;
            for (int i = 0; i < 3; i++)
            {
                    if (status[i,0] == status[i,1] && status[i,0] == status[i,2] && status[i,0] != 0) return true;
                    if (status[0,i] == status[1,i] && status[0,i] == status[2,i] && status[0,i] != 0) return true;
            }
            return false;
        }
        public bool IsDrawGame(int[,] status)
        {
            for (int i=0; i <3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    if (status[i, j] == 0) return false;
                }
            }
            return true;
        }
    }
}
