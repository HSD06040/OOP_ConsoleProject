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
            float itemDamage = GetItemStat(myStat,skill.type);

            if (CanCrit())
            {
                crit = true;
                critDamage = 1.5f;
            }

            if (itemDamage < 1)
                itemDamage = 1;

            if (STAB)
                STABValue = 1.5f;

            totalDamage = (((((myStat.level * 2 / 5 + 2) * skill.skillPower * myStat.Damage() / 50)
                / enemyStat.Defense()) + 2) * critDamage * itemDamage)* random.Next(217, 256) / 255 * STABValue * TypeMultifly(skill.type, enemyStat.type);

            if (totalDamage == 0)
                totalDamage = 1;

            enemyStat.DecreaseHealth((int)totalDamage,crit);
        }

        private static bool CanCrit()
        {
            return random.Next(1, 100) < 6.25f ? true : false;
        }

        private static float GetItemStat(Stat myStat, Type skillType)
        {
            switch (skillType)
            {
                case Type.Normal:
                    return myStat.itemStat.normalDamage;
                case Type.Fire:
                    return myStat.itemStat.waterDamage;
                case Type.Grass:
                    return myStat.itemStat.grassDamage;
                case Type.Water:
                    return myStat.itemStat.normalDamage;
            }
            return 1;
        }

        public static float TypeMultifly(Type skillType, Type enemyType)
        {
            if (skillType == Type.Fire)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        Console.WriteLine("효과가 굉장했다!\n");
                        return 2;
                    case Type.Water:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                    case Type.Fire:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                }
            }

            if (skillType == Type.Water)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                    case Type.Water:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                    case Type.Fire:
                        Console.WriteLine("효과가 굉장했다!\n");
                        return 2;
                }
            }

            if (skillType == Type.Grass)
            {
                switch (enemyType)
                {
                    case Type.Grass:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                    case Type.Water:
                        Console.WriteLine("효과가 굉장했다!\n");
                        return 2;
                    case Type.Fire:
                        Console.WriteLine("효과가 별로인 것 같다...\n");
                        return .5f;
                }
            }

            return 1;
        }
    }
}
