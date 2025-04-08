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
        }
    }
}
