using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public class Candy : ItemBase
    {
        int levelUpCount;
        public Candy(string name, string description, int levelUpCount = 1) : base(name, description)
        {
            this.levelUpCount = levelUpCount;
        }

        public override void Use()
        {
            for (int i = 0; i < levelUpCount; i++)
            {
                Game.playerPokemon.stat.LevelUp();
            }
        }
    }
}
