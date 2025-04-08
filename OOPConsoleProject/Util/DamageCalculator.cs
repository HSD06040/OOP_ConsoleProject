using OOPConsoleProject.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Util
{
    public static class DamageCalculator
    {
        static Random random = new Random();

        public static void TotalDamageCalculator(Stat myStat, Skill skill, Stat enemyStat)
        {
            bool crit = false;
            float critDamage = 1;
            bool STAB = myStat.type == skill.type;
            float STABValue = 1;
            float totalDamage = 0;

            if (CanCrit())
            {
                crit = true;
                critDamage = 1.5f;
            }

            if (STAB)
                STABValue = 1.5f;

            totalDamage = ((myStat.level * 2 / 5 + 2) * skill.skillPower * myStat.Damage() / 50
                / enemyStat.Defense() + 2) * critDamage * random.Next(217, 255) / 100 * STABValue * TypeMultifly(skill.type, enemyStat.type);

            enemyStat.DecreaseHealth((int)totalDamage,crit);
        }

        public static bool CanCrit()
        {
            return random.Next(1, 100) < 6.25f ? true : false;
        }

        public static float TypeMultifly(Type skillType, Type enemyType)
        {
            if (skillType == Type.Fire)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        return 2;
                    case Type.Water:
                        return .5f;
                    case Type.Fire:
                        return .5f;
                }
            }

            if (skillType == Type.Water)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        return .5f;
                    case Type.Water:
                        return .5f;
                    case Type.Fire:
                        return 2;
                }
            }

            if (skillType == Type.Grass)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        return .5f;
                    case Type.Water:
                        return 2;
                    case Type.Fire:
                        return .5f;
                }
            }

            return 1;
        }
    }
}
