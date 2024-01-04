using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public enum SpecType
    {
        ATTACK, DEFEND
    }
    public class ItemSpec
    {
        private SpecType specType;
        private int spec;

        public ItemSpec(SpecType specType, int spec)
        {
            this.specType = specType;
            this.spec = spec;
        }

        public int getSpec()
        {
            return spec;
        }

        public SpecType getSpecType()
        {
            return this.specType;
        }

        public string getSpecName()
        {
            switch (this.specType)
            {
                case SpecType.ATTACK:
                    return "공격력 +" + spec.ToString();
                case SpecType.DEFEND:
                    return "방어력 +" + spec.ToString();
            }

            return "";
        }

    }
}
