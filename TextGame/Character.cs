using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Character
    {
        private string name = "전사";

        private int level = 1;
        private int health = 100;
        private int defend = 10;
        private int attack = 17;
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
            get { return defend + (level - 1); }
        }

        public int Attack
        {
            get { return attack + (int)((float)(level - 1) * 0.5); }
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
            get { if(temAttack > 0)
                {
                    string exattack = $"(+{temAttack.ToString()})";
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
                    string exdefend = $"(+{temDefend.ToString()})";
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
                this.realAttack = attack + temAttack;
                return realAttack; 
            }
        }

        public int RealDefend
        {
            get
            {
                this.realDefend = defend + temDefend;
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
