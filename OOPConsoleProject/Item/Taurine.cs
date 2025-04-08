using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public class Taurine : ItemBase
    {
        public Taurine(string name, string description) : base(name, description)
        {
        }

        public override void Use()
        {
            Game.playerPokemon.stat.AddBaseStat("damage", 10);
            Console.WriteLine($"{Game.playerPokemon.name}의 공격력이 조금 쌔진 것 같다!");
        }
    }
    public class MaxUp : ItemBase
    {
        public MaxUp(string name, string description) : base(name, description)
        {
        }

        public override void Use()
        {
            Game.playerPokemon.stat.AddBaseStat("hp", 10);
            Console.WriteLine($"{Game.playerPokemon.name}의 체력이 조금 늘어난 것 같다!");
        }
    }
    public class Saponin : ItemBase
    {
        public Saponin(string name, string description) : base(name, description)
        {
        }

        public override void Use()
        {
            Game.playerPokemon.stat.AddBaseStat("defense", 10);
            Console.WriteLine($"{Game.playerPokemon.name}의 방어력이 조금 더 단단해진 것 같다!");
        }
    }
    public class Alkaloid : ItemBase
    {
        public Alkaloid(string name, string description) : base(name, description)
        {
        }

        public override void Use()
        {
            Game.playerPokemon.stat.AddBaseStat("speed", 10);
            Console.WriteLine($"{Game.playerPokemon.name}의 스피드가 조금 빨라진 것 같다!");
        }
    }
}
