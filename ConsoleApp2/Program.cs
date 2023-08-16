using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] deckCards = new Card[52];
            int cardCount = 0;
            Player dealer = new Player();
            Player player = new Player();
            
            NewCards(deckCards, ref cardCount);
            
            Console.Write("블랙젝 게임이 시작되었습니다.");
            Console.Write("게임 설명을 원하십니까? ( Y / N )");
            string rule = Console.ReadLine();
            if (rule[0] == 'Y')
            {
                Console.WriteLine("\n\n\n블랙젝은 카드의 합이 21에 가까운 사람이 승리하는 게임입니다.");
                Console.WriteLine("1. 플레이어와 딜러는 2장의 카드를 받습니다. 플레이어의 2장의 카드는 오픈되며, 딜러의 카드는 1장만 오픈됩니다.");
                Console.WriteLine("  (딜러의 첫 2장의 카드가 블랙젝(합이 21)인 경우에는 플레이어는 추가행동을 할 수 없습니다.)\n");
                Console.WriteLine("2. 플레이어턴 : 플레이어는 카드를 받거나(Hit), 멈추는(Stand) 추가행동을 할 수 있습니다.");
                Console.WriteLine("   플레이어의 카드합이 22를 초과하면(Burst),딜러의 카드를 오픈하지 않고 플레이어의 패배가 됩니다.\n");
                Console.WriteLine("3. 딜러턴 : 딜러는 카드합이 16이하면 Hit, 17이상이면 Stand를 합니다.\n");
                Console.WriteLine("4. 종료 : 카드의 합이 21에 가까운 쪽이 승리하고, 같으면 무승부가 됩니다. \n\n\n");
            }
            else
            {
                Console.WriteLine("\n\n\n게임 설명을 생략합니다.\n\n\n");
            }

            // 딜러가 카드 두장을 뽑는다.
            Console.Write("딜러의 카드 : ");
            CardDraw(deckCards, dealer, ref cardCount, true);
            CardDraw(deckCards, dealer, ref cardCount);
            Console.WriteLine();

            // 플레이어는 2장의 카드를 뽑는다.
            Console.Write("당신의 카드 : ");
            CardDraw(deckCards, player, ref cardCount, true);
            CardDraw(deckCards, player, ref cardCount, true);
            Console.WriteLine();

            while (true)
            {
                Console.Write($"플레이어의 차례입니다. 현재 카드합 {player.Value} 한장 더 받으시겠습니까? (Y/N)");
                string hit = Console.ReadLine();
                if (hit[0] == 'Y')
                {
                    Hit(deckCards, player, ref cardCount);
                    if (player.IsBurst)
                    {
                        Console.WriteLine("\n 플레이어의 카드합이 21을 넘겼습니다. 플레이어의 패배입니다. 배팅금은 회수됩니다.");
                        break;
                    }
                }
                if (hit[0] == 'N')
                {
                    Stand(deckCards, player, dealer, ref cardCount);
                    break;
                }
            }

            // }



        }
        public static void NewCards(Card[] deck, ref int cardCount)
        {
            for (int i = 0; i < 52; i++)
            {
                deck[i] = new Card((i+1) / 13, (i+1) % 13);
            }
            cardCount = 52;
        }

        public static void CardDraw(Card[] deck, Player player, ref int cardCount, bool isOpen)
        {
            if (cardCount == 0)
            {
                Console.WriteLine("Deck이 비어있으므로 새로운 카드를 세팅합니다.");
                NewCards(deck, ref cardCount);
            }

            int pick = new Random().Next(0, deck.Length);
            while (deck[pick] == null)
            {
                pick = new Random().Next(0, deck.Length);
            }

            if (deck[pick] != null)
            {
                player.DrawCard(deck[pick]);
                if (isOpen == true) ShowCard(deck[pick]);
                if (isOpen == false) Console.Write(" ??  ");
                cardCount -= 1;
            }

        }
        public static void CardDraw(Card[] deck, Player player, ref int cardCount)
        {
            CardDraw(deck, player, ref cardCount, false);
        }

        public static void Hit(Card[] deck, Player player, ref int cardCount)
        {
            if (cardCount == 0)
            {
                Console.WriteLine("Deck이 비어있으므로 새로운 카드를 세팅합니다.");
                NewCards(deck, ref cardCount);
            }

            int pick = new Random().Next(0, deck.Length);
            while (deck[pick] == null)
            {
                pick = new Random().Next(0, deck.Length);
            }

            if (deck[pick] != null)
            {
                player.DrawCard(deck[pick]);
                for (int i = 0; i < player.Count; i++)
                {
                    ShowCard(player.Cards[i]);
                }
                cardCount -= 1;
            }
        }
        public static void Stand(Card[] deck, Player player, Player dealer, ref int cardCount)
        {
            Console.WriteLine($"딜러의 카드를 오픈합니다. 딜러의 카드합 {dealer.Value}");
            ShowCard(dealer.Cards[0]);
            ShowCard(dealer.Cards[1]);
            Console.ReadKey();

            while (dealer.Value <= 16)
            {
                Console.WriteLine($"딜러의 카드합 : {dealer.Value} , 카드합이 16이하이므로 한장 더 받습니다.");
                Console.ReadKey();
                Hit(deck, dealer, ref cardCount);
                Console.ReadKey();
                if (dealer.IsBurst)
                {
                    Console.WriteLine("딜러의 카드합이 21를 초과하였습니다. 플레이어의 승리입니다.");
                    break;
                }
            }
            if (!dealer.IsBurst && !player.IsBurst)
            {
                Console.WriteLine("\n게임이 종료되었습니다. ");
                Console.WriteLine($"플레이어 합 : {player.Value} , 딜러의 합 : {dealer.Value}.");
                if (player.Value == dealer.Value) { Console.WriteLine("무승부 입니다."); }
                if (player.Value > dealer.Value) { Console.WriteLine("플레이어 승리입니다."); }
                if (player.Value < dealer.Value) { Console.WriteLine("딜러의 승리입니다."); }
            }
        }
        static void ShowCard(Card card)
        {
            switch (card.Shape)
            {
                case 0:
                    // 클로버
                    Console.Write("\u2663");
                    break;
                case 1:
                    // 하트
                    Console.Write("\u2665");
                    break;
                case 2:
                    // 다이아몬드
                    Console.Write("\u25C6");
                    break;
                case 3:
                    // 스페이드
                    Console.Write("\u2660");
                    break;
            }
            switch (card.Num)
            {
                case 1:
                    Console.Write("A");
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Console.Write(card.Num);
                    break;
                case 11:
                    Console.Write("J");
                    break;
                case 12:
                    Console.Write("Q");
                    break;
                case 13:
                    Console.Write("K");
                    break;
                default:
                    break;
            }
            Console.Write("  ");
        }
    }

    public class Card
    {
        public int Shape { get; set; }
        public int Num { get; set; }
        public Card(int shape, int num)
        {
            Shape = shape;
            Num = num;
        }
    }

    public class Player
    {
        public Card[] Cards { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
        public bool IsBurst { get; set; }
        public void DrawCard(Card card)
        {
            Cards[Count] = card;
            Count++;
            ResetValue();
        }
        public void ResetValue()
        {
            Value = 0;
            int AceCount = 0;

            for (int i = 0; i < Count; i++)
            {
                if (Cards[i].Num == 1)
                {
                    AceCount++;
                    Value += 11;
                }
                else if (Cards[i].Num >= 10)
                {
                    Value += 10;
                }
                else
                {
                    Value += Cards[i].Num;
                }
            }

            while (Value >= 22 && AceCount > 0)
            {
                Value -= 10;
                AceCount--;
            }

            if (Value >= 22)
            {
                IsBurst = true;
            }
        }

        public Player()
        {
            Cards = new Card[10];
            Value = 0;
            Count = 0;
            IsBurst = false;
        }
    }
}