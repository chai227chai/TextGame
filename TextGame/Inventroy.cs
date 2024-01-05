using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    [Serializable]
    internal class Inventroy : IEnumerable
    {
        private List<Item> inventoryList;

        private Dictionary<ItemType, Item> equipedTem;

        private int temAttack;
        private int temDefend;

        public Inventroy()
        {
            this.inventoryList = new List<Item>();
            this.equipedTem = new Dictionary<ItemType, Item>();
        }

        public void addInventroy(Item item)
        {
            Item Inventory_item = new Item(item);
            inventoryList.Add(Inventory_item);
        }

        public void AddEquipedTem(ItemType type, Item item)
        {
            if (equipedTem.ContainsKey(type) && equipedTem[type].Number != item.Number)
            {
                equipedTem[type].SetEquip();
                equipedTem.Remove(type);

                equipedTem.Add(type, item);
                item.SetEquip();
            }
            else if(equipedTem.ContainsKey(type) && equipedTem[type].Number == item.Number)
            {
                item.SetEquip();
                equipedTem.Remove(type);
            }
            else
            {
                equipedTem.Add(type, item);
                item.SetEquip();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.inventoryList.GetEnumerator();
        }

        public Item GetItem(int n)
        {
            return this.inventoryList[n - 1];
        }

        public void RemoveItem(int n)
        {
            inventoryList.RemoveAt(n - 1);
        }

        public int ExAttack()
        {
            int exAttack = 0;
            foreach(Item item in inventoryList.FindAll(isequip => isequip.IsEquip == true && isequip.GetSpecType == SpecType.ATTACK)){
                exAttack += item.GetSpec;
            }

            return exAttack;
        }

        public int ExDefend()
        {
            int exDefend = 0;
            foreach (Item item in inventoryList.FindAll(isequip => isequip.IsEquip == true && isequip.GetSpecType == SpecType.DEFEND)){
                exDefend += item.GetSpec;
            }

            return exDefend;
        }
    }
}
