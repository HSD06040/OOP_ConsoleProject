using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Skill
    {
        public string name { get; private set; }
        public Type type { get; private set; }
        public int chance { get; private set; }
        public int skillPower { get; private set; }

        public Skill(string name, Type type, int skillPower, int chance)
        {
            this.name = name;
            this.type = type;
            this.skillPower = skillPower;
            this.chance = chance;
        }
    }
}
