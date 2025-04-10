using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.PokemonData
{
    public class ItemStat
    {
        public float normalDamage { get; private set; } = 1;
        public float fireDamage { get; private set; } = 1;
        public float grassDamage { get; private set; } = 1;
        public float waterDamage { get; private set; } = 1;

        public void AddStat(Type type, float value = 10)
        {
            switch(type)
            {
                case Type.Normal:
                    normalDamage += value/100;
                    break;
                case Type.Fire:
                    fireDamage += value/100;
                    break;
                case Type.Grass:
                    grassDamage += value/100;
                    break;
                case Type.Water:
                    waterDamage += value/100;
                    break;
            }
        }

        public void ClearStat()
        {
            normalDamage = 1;
            fireDamage = 1;
            grassDamage = 1;
            waterDamage = 1;
        }
    }
}
