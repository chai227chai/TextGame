using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace TextGame
{

    internal class GameManager
    {
        Character character = new Character();
        ItemList itemList = new ItemList();
        Inventroy inventory = new Inventroy();
        Dungeon dungeon = new Dungeon();

        public GameManager()
        {
            MainTown();
        }

        //---------------------------------------------------------------------------------------------------------------
        void MainTown()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Console.WriteLine();

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");

            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while(int.Parse(act) > 5 || int.Parse(act) <= 0)
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if(act == "1")
            {
                Console.Clear();
                CharacterStat();
            }
            else if(act == "2")
            {
                Console.Clear();
                InventoryBag();
            }
            else if(act == "3")
            {
                Console.Clear();
                Shop();
            }
            else if (act == "4")
            {
                Console.Clear();
                DungeonEnter();
            }
            else if (act == "5")
            {
                Console.Clear();
                Rest();
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        void CharacterStat()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            Console.WriteLine();

            character.SetTemAttack(inventory.ExAttack());
            character.SetTemDefend(inventory.ExDefend());

            Console.WriteLine($"LV. {character.Level}");
            Console.WriteLine($"Chad ({character.Name})");
            Console.WriteLine($"공격력 : {character.Attack} {character.TemAttack}");
            Console.WriteLine($"방어력 : {character.Defend} {character.TemDefend}");
            Console.WriteLine($"체 력 : {character.Health}");
            Console.WriteLine($"Gold : {character.GoldStr}");

            Console.WriteLine();

            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while (act != "0")
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                MainTown();
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        void Shop()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine(character.Gold);

            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            foreach(Item item in itemList)
            {
                Console.WriteLine($"- {item.Name} | {item.GetTypeName} | {item.GetSpecName} | {item.Detail} | {item.SalePrice}");
            }

            Console.WriteLine();

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while (act != "1" && act != "2" && act != "0")
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if(act == "1")
            {
                Console.Clear();
                PurchaceTem();
            }
            else if (act == "2")
            {
                Console.Clear();
                SaleTem();
            }
            else if (act == "0")
            {
                Console.Clear();
                MainTown();
            }

        }

        //---------------------------------------------------------------------------------------------------------------
        void PurchaceTem()
        {
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine(character.GoldStr);

            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            int index = 1;
            foreach (Item item in itemList)
            {
                Console.WriteLine($"- {index} {item.Name} | {item.GetTypeName} | {item.GetSpecName} | {item.Detail} | {item.SalePrice}");
                index++;
            }

            Console.WriteLine();

            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            bool loop = true;
            while (loop)
            {
                int cursor = int.Parse(act);
                if (act == "0")
                {
                    break;
                }
                else if(cursor < index && cursor > 0)
                {
                    if (character.Gold >= itemList.GetItem(cursor).Price && itemList.GetItem(cursor).GetSale())
                    {
                        itemList.GetItem(cursor).SetSale();
                        inventory.addInventroy(itemList.GetItem(cursor));
                        character.TemPurchase(itemList.GetItem(cursor).Price);

                        loop = false;

                        Console.Clear();
                        PurchaceTem();
                    }
                    else if (!itemList.GetItem(cursor).GetSale())
                    {
                        Console.WriteLine("재고가 없습니다.");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                }
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                Shop();
            }

        }

        //---------------------------------------------------------------------------------------------------------------
        void SaleTem()
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine(character.GoldStr);

            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            int index = 1;
            foreach (Item item in inventory)
            {
                Console.WriteLine($"- {index} {item.NowEquip}{item.Name} | {item.GetTypeName} | {item.GetSpecName} | {item.Detail} | {item.Price * 85 / 100} G");
                index++;
            }

            Console.WriteLine();

            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            bool loop = true;
            while (loop)
            {
                int cursor = int.Parse(act);
                if (act == "0")
                {
                    break;
                }
                else if (cursor < index && cursor > 0)
                {
                    itemList.GetItemList().Find(itemnumber => itemnumber.Number == inventory.GetItem(cursor).Number).SetSale();
                    character.TemSale(inventory.GetItem(cursor).Price);
                    inventory.RemoveItem(cursor);

                    loop = false;

                    Console.Clear();
                    SaleTem();
                }
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                Shop();
            }

        }

        //---------------------------------------------------------------------------------------------------------------
        void InventoryBag()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            foreach (Item item in inventory)
            {
                Console.WriteLine($"- {item.NowEquip}{item.Name} | {item.GetTypeName} | {item.GetSpecName} | {item.Detail}");
            }

            Console.WriteLine();

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while (act != "1" && act != "0")
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "1")
            {
                Console.Clear();
                CharacterEquip();
            }
            else if (act == "0")
            {
                Console.Clear();
                MainTown();
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        void CharacterEquip()
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            int index = 1;
            foreach (Item item in inventory)
            {
                Console.WriteLine($"- {index} {item.NowEquip}{item.Name} | {item.GetTypeName} | {item.GetSpecName} | {item.Detail}");
                index++;
            }

            Console.WriteLine();

            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            bool loop = true;
            while (loop)
            {
                int cursor = int.Parse(act);
                if (act == "0")
                {
                    break;
                }
                else if (cursor < index && cursor > 0)
                {
                    //inventory.GetItem(cursor).SetEquip();
                    inventory.AddEquipedTem(inventory.GetItem(cursor).Type, inventory.GetItem(cursor));

                    loop = false;

                    Console.Clear();
                    CharacterEquip();
                }
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                InventoryBag();
            }
        }

        //---------------------------------------------------------------------------------------------------------------

        void DungeonEnter()
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[상태]");
            Console.WriteLine($"LV. {character.Level}");
            Console.WriteLine($"Chad ({character.Name})");
            Console.WriteLine($"공격력 : {character.ReaLAttack}");
            Console.WriteLine($"방어력 : {character.RealDefend}");
            Console.WriteLine($"체 력 : {character.Health}");
            Console.WriteLine();

            Console.WriteLine($"1. {dungeon.Difficulty(1)} | 방어력 {dungeon.RecoDef(1)} 이상 권장");
            Console.WriteLine($"2. {dungeon.Difficulty(2)} | 방어력 {dungeon.RecoDef(2)} 이상 권장");
            Console.WriteLine($"3. {dungeon.Difficulty(3)} | 방어력 {dungeon.RecoDef(3)} 이상 권장");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while (int.Parse(act) > 4 || int.Parse(act) < 0)
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                MainTown();
            }
            else
            {
                Console.Clear();
                DungeonPlay(int.Parse(act));
            }
        }

        void DungeonPlay(int action)
        {
            dungeon.GoDungeon(character, action);

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            while (act != "0")
            {
                Console.WriteLine("다시 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                DungeonEnter();
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        void Rest()
        {
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.GoldStr})");

            Console.WriteLine();

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            string act = Console.ReadLine();

            bool loop = true;
            while (loop)
            {
                int cursor = int.Parse(act);
                if (act == "0")
                {
                    break;
                }
                else if (act == "1")
                {
                    if(character.Gold < 500)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    else
                    {
                        character.Gold -= 500;
                        character.Health = 100;
                        Console.Clear();
                        Rest();
                    }
                }
                Console.WriteLine("원하시는 행동을 입력해 주세요.");
                Console.Write(">>");
                act = Console.ReadLine();
            }

            if (act == "0")
            {
                Console.Clear();
                MainTown();
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        
        
    }

}
