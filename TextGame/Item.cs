using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public enum ItemType
    {
        WEAPON, ARMOR
    }

    internal class Item
    {
        private string name;
        private string detail;
        private string number;

        private int price;

        private ItemSpec spec;
        private ItemType itemType;

        private bool isSale = true;
        private bool isEquiped = false;

        public Item(string number, ItemType itemType, string name, string detail, int price, ItemSpec spec)
        {
            this.number = number;
            this.itemType = itemType;
            this.name = name;
            this.detail = detail;
            this.price = price;
            this.spec = spec;
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

        public string SalePrice
        {
            get {
                if (isSale)
                {
                    string _saleprice = price.ToString() + " G";
                    return _saleprice;
                }
                else
                {
                    return "구매완료";
                }
            }
        }

        public void SetSale()
        {
            if (this.isSale)
            {
                this.isSale = false;
            }
            else
            {
                this.isSale = true;
            }
            
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
            get { return spec.getSpec(); }
        }

        public string GetSpecName
        {
            get { return spec.getSpecName(); }
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
