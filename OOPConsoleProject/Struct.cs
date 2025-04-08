using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public struct PokemonBaseStat
    {
        public string name;
        public int id,hp,damage,defense,speed;
        public Type type;

        public PokemonBaseStat(string name,Type type,int id, int hp, int damage, int defense, int speed)
        {
            this.id = id;
            this.hp = hp;
            this.damage = damage;
            this.defense = defense;
            this.speed = speed;
            this.name = name;
            this.type = type;
        }
    }

}
