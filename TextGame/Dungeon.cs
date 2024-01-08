using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    enum DungoenType
    {
        EASY = 1, NORMAL = 2, HARD = 3 
    }
    internal class Dungeon
    {
        private Random random = new Random();
        private int difficulty;

        private int[] defend = new int[] {0, 5, 11, 17};

        public void GoDungeon(Character character, int difficulty)
        {
            if(character.RealDefend < defend[difficulty])
            {
                int dice = random.Next(0, 100);
                if(dice <= 40)
                {
                    Defeat(character, difficulty);
                }
                else
                {
                    Clear(character, difficulty);
                }
            }
            else
            {
                Clear(character, difficulty);
            }

        }

        private void Defeat(Character character, int difficulty)
        {
            int health = character.Health;

            character.Health -= character.Health / 2;

            Console.Clear();
            Console.WriteLine("던전 실패");
            Console.WriteLine($"권장 방어력이 맞지 않아 {Difficulty(difficulty)}탐험을 실패하였습니다.");
            Console.WriteLine("보상을 획득하실 수 없습니다.");
            Console.WriteLine();

            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {health} -> {character.Health}");
        }

        private void Clear(Character character, int difficulty)
        {
            int health = character.Health;
            int gold = character.Gold;

            int damage = random.Next(20 - (character.RealDefend - defend[difficulty]), 36 - (character.RealDefend - defend[difficulty]));
            character.Health -= damage;

            Console.Clear();
            if (character.Health <= 0)
            {
                Console.WriteLine("던전 실패");
                Console.WriteLine($"체력이 부족하여 {Difficulty(difficulty)}탐험을 실패하였습니다.");
                Console.WriteLine("보상을 획득하실 수 없습니다.");
                Console.WriteLine();

                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {health} -> {character.Health}");

                character.Health = 1;
            }
            else
            {
                int parsent = random.Next(1 * character.ReaLAttack, 2 * character.ReaLAttack + 1);
                int reward = 1000 + (((defend[difficulty] - 5) * 125));
                int extraGold = (reward * parsent / 100);
                int fiReward = reward + extraGold;
                character.Gold += fiReward;

                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"{Difficulty(difficulty)}을 클리어 하였습니다.");
                Console.WriteLine();

                Console.WriteLine($"보상 {reward} , 추가 {extraGold}(+{parsent}%)");
                Console.WriteLine();

                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {health} -> {character.Health}");
                Console.WriteLine($"Gold {gold} G -> {character.Gold} G");

                character.expUP();
            }
        }

        public int RecoDef(int difficulty)
        {
            return defend[difficulty];
        }

        public string Difficulty(int difficulty)
        {
                switch (difficulty)
                {
                    case 1: return "쉬운 던전";
                    case 2: return "일반 던전";
                    case 3: return "어려운 던전";
                }

                return "";
        }
    }
}
