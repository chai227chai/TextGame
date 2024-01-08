using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public enum ItemType
    {
        WEAPON, ARMOR, HAT
    }

    [Serializable()]
    internal class Item
    {
        private string name;
        private string detail;
        private string number;

        private int price;
        private int left;

        private ItemSpec spec;
        private ItemType itemType;

        private bool isSale = true;
        private bool isEquiped = false;

        private int inchant = 0;
        private int maxInchant = 3;

        public Item(string number, ItemType itemType, string name, string detail, int price, ItemSpec spec, int left)
        {
            this.number = number;
            this.itemType = itemType;
            this.name = name;
            this.detail = detail;
            this.price = price;
            this.spec = spec;
            this.left = left;
        }

        public Item(Item item)
        {
            this.number = item.number;
            this.itemType = item.itemType;
            this.name = item.name;
            this.detail = item.detail;
            this.price = item.price;
            this.spec = item.spec;
        }

        public string Number
        {
            get{ return this.number; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Detail
        {
            get { return this.detail; }
        }

        public int Price
        {
            get { return this.price; }
        }

        public int Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public string SalePrice
        {
            get {
                if (isSale)
                {
                    string _saleprice = price.ToString() + " G (남은 재고 " + left + "개)";
                    return _saleprice;
                }
                else
                {
                    return "구매완료";
                }
            }
        }

        public void ItemSold()
        {
            if (left > 0)
            {
                left--;
            }
            if(left == 0)
            {
                this.isSale = false;
            }
        }

        public void ItemRefund()
        {
            left++;
            this.isSale = true;
        }

        public bool GetSale()
        {
            return isSale;
        }
        public ItemType Type
        {
            get {return this.itemType; }
        }

        public string GetTypeName
        {
            get
            {
                switch (this.itemType)
                {
                    case ItemType.ARMOR:
                        return "갑옷";
                    case ItemType.WEAPON:
                        return "무기";
                    case ItemType.HAT:
                        return "투구";
                }

                return "";
            }
        }

        public SpecType GetSpecType
        {
            get{ return spec.getSpecType(); }
        }

        public int GetSpec
        {
            get 
            {
                int realSpec = spec.getSpec() + (2 * inchant);
                return realSpec; 
            }
        }

        public void InchantTem()
        {
            if (this.inchant < 3)
            {
                this.inchant++;
            }
        }

        public int MaxInchant
        {
            get { return this.maxInchant; }
        }

        public int Inchant
        {
            get { return inchant; }
        }

        public string NowInchant
        {
            get
            {
                if (inchant > 0)
                {
                    return "(+" + inchant + ")";
                }
                else
                {
                    return "";
                }
            }
        }

        public string GetSpecName
        {
            get 
            { 
                if(inchant > 0)
                {
                    return spec.getSpecName() + "(+" + (2 * inchant) + ")";
                }
                else
                {
                    return spec.getSpecName();
                }
            }
        }

        public bool IsEquip
        {
            get { return isEquiped; }
        }

        public string NowEquip
        {
            get {
                if (isEquiped)
                {
                    return "[E]";
                }
                else
                {
                    return "";
                }
            }
        }

        public void SetEquip()
        {
            if (isEquiped)
            {
                isEquiped = false;
            }
            else
            {
                isEquiped = true;
            }
        }
    }
}
