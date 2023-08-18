namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 게임 시작
            Console.WriteLine("########################################");
            Console.WriteLine("게임이 시작되었습니다.");
            Console.WriteLine("########################################");

            Stage stage = new Stage();
            stage.Start();

            Warrior warrior = new Warrior();
            Goblin goblin = new Goblin();
            Dragon dragon = new Dragon();
        }
    }
    public interface ICharacter
    {
        public string Name { get; set; }
        public string Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public void TakeDamage(int damage)
        {

        }

    }

    public class Warrior : ICharacter
    {
        public string Name { get; set; }
        public string Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }

        public IItem[] MyItems { get; set; }
        public void TakeDamage(int damage)
        {

        }
    }
    public class Monster : ICharacter
    {
        public string Name { get; set; }
        public string Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public void TakeDamage(int damage)
        {

        }
    }
    public class Goblin : Monster
    {

    }
    public class Dragon : Monster
    {

    }


    public interface IItem
    {
        public string Name { get; set; }
        public void Use(Warrior warrior)
        {

        }
    }
    public class HealthPotion : IItem
    {
        public string Name { get; set; }
        public void Use(Warrior warrior)
        {
            warrior.Health += 100;
        }
    }
    public class StrengthPotion : IItem
    {
        public string Name { get; set; }
        public void Use(Warrior warrior)
        {
            warrior.Attack += 30;
        }
    }

    public class Stage
    {
        
        public void Start()
        {
            // 게임이 스타트
            //-스테이지가 시작되면, 플레이어와 몬스터가 교대로 턴을 진행합니다.
            //-플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
            //-스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
        }
    }

    // 추가적인 요구사항:
    //- 모든 코드는 C# 언어로 작성해주세요.
    //- 코드에는 적절한 주석을 달아주세요.
    //- 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
    //- 각 턴이 진행될 때 천천히 보여지도록 **`Thread.Sleep`**을 사용하여 1초의 대기시간을 추가해주세요.
}