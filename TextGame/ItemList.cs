using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    [Serializable]
    internal class ItemList : IEnumerable
    {
        private List<Item> itemList;

        public ItemList()
        {
            this.itemList = new List<Item>();
            initialize();
        }

        public void addItem(string number, ItemType itemType, string name, string detail, int price, ItemSpec spec)
        {
            Item item = new Item(number, itemType, name, detail, price, spec);
            itemList.Add(item);
        }

        public void initialize()
        {
            addItem("0", ItemType.ARMOR, "수련자 갑옷    ", "수련에 도움을 주는 갑옷입니다.                    ", 1000, new ItemSpec(SpecType.DEFEND, 5));
            addItem("1", ItemType.ARMOR, "무쇠 갑옷      ", "무쇠로 만들어져 튼튼한 갑옷입니다.                ", 2000, new ItemSpec(SpecType.DEFEND, 9));
            addItem("2", ItemType.ARMOR, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 3500, new ItemSpec(SpecType.DEFEND, 15));
            addItem("3", ItemType.WEAPON, "낡은 검       ", "쉽게 볼 수 있는 낡은 검 입니다.                   ", 600, new ItemSpec(SpecType.ATTACK, 2));
            addItem("4", ItemType.WEAPON, "청동 도끼     ", "어디선가 사용됐던거 같은 도끼입니다.              ", 1500, new ItemSpec(SpecType.ATTACK, 5));
            addItem("5", ItemType.WEAPON, "스파르타의 창 ", "스파르타의 전사들이 사용했다는 전설의 창입니다.   ", 3000, new ItemSpec(SpecType.ATTACK, 7));
            addItem("6", ItemType.HAT, "외출용 모자      ", "햇빛을 가리기 위한 캡이 달린 모자입니다.          ", 300, new ItemSpec(SpecType.DEFEND, 2));
            addItem("7", ItemType.HAT, "사냥용 모자      ", "사냥꾼들이 주로 쓰는 모자입니다.                  ", 700, new ItemSpec(SpecType.ATTACK, 1));
            addItem("8", ItemType.HAT, "강철 투구      ", "머리를 보호하는데 뛰어난 투구입니다.                ", 1000, new ItemSpec(SpecType.DEFEND, 5));
            addItem("9", ItemType.HAT, "스파르타의 투구  ", "스파르타의 전사들이 사용했다는 전설의 투구입니다. ", 2000, new ItemSpec(SpecType.ATTACK, 5));
        }

        public IEnumerator GetEnumerator()
        {
            return this.itemList.GetEnumerator();
        }

        public Item GetItem(int n)
        {
            return this.itemList[n-1];
        }

        public List<Item> GetItemList()
        {
            return itemList;
        }
    }

}
