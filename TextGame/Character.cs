using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    [Serializable]
    internal class Character
    {
        private string name = "전사";

        private int level = 1;
        private int health = 100;
        private int defend;
        private int attack;
        private int gold = 1500;
        private int temAttack;
        private int temDefend;
        private int realAttack;
        private int realDefend;
        private int exp = 0;
        private int nextLevel = 1;

        public string Name
        {
            get { return name; }
        }

        public string Level
        {
            get { if (this.level < 10)
                {
                    string _level = "0" + level.ToString();
                    return _level;
                }
                else
                {
                    return level.ToString();
                }
                        }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Defend
        {
            get {
                defend = 10 + (level - 1);
                return defend; 
            }
        }

        public int Attack
        {
            get {
                attack = 17 + (int)((float)(level - 1) * 0.5);
                return attack; 
            }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public string GoldStr
        {
            get {
                string _gold = this.gold.ToString() + " G";
                    return _gold; }
        }

        public void TemPurchase(int price)
        {
            this.gold = gold - price;
        }

        public void TemSale(int price)
        {
            this.gold = gold + (price * 85 / 100);
        }

        public void SetTemAttack(int exAttack)
        {
            temAttack = exAttack;
        }

        public string TemAttack
        {
            get 
            { 
                if(temAttack > 0)
                {
                    string exattack = $"(+{temAttack})";
                    return exattack;
                }
                else if (temAttack < 0)
                {
                    string exattack = $"({temAttack})";
                    return exattack;
                }
                else
                {
                    return "";
                }
            }
        }

        public void SetTemDefend(int exDefend)
        {
            temDefend = exDefend;
        }

        public string TemDefend
        {
            get
            {
                if (temDefend > 0)
                {
                    string exdefend = $"(+{temDefend})";
                    return exdefend;
                }
                else if (temDefend > 0)
                {
                    string exdefend = $"({temDefend})";
                    return exdefend;
                }
                else
                {
                    return "";
                }
            }
        }

        public int ReaLAttack
        {
            get 
            {
                this.realAttack = Attack + temAttack;
                return realAttack; 
            }
        }

        public int RealDefend
        {
            get
            {
                this.realDefend = Defend + temDefend;
                return realDefend;
            }
        }

        public void expUP()
        {
            exp++;
            if(exp == nextLevel)
            {
                int nowLevel = this.level;
                this.level++;
                exp = 0;
                nextLevel++;

                Console.WriteLine();
                Console.WriteLine("레벨이 상승하였습니다!");
                Console.WriteLine();
            }
        }
    }
}
