using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.PokemonData
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

        public void PrintSkillData()
        {
            string namePadded = StringUtil.PadRightDisplay(name, 12);

            string typeText = StringUtil.TypeKorean(type).PadRight(2);

            Console.Write($"{namePadded} / 타입 : ");

            Console.ForegroundColor = StringUtil.TypeColor(type);
            Console.Write($"{typeText}");
            Console.ResetColor();

            Console.Write($", 위력 : {skillPower,3}, 명중률 : {chance,3}\n");
        }
    }
}
