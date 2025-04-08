using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public class Potion : ItemBase
    {
        protected int healAmount;
        public Potion(string name, string description, int healAmount) : base(name, description)
        {
            this.healAmount = healAmount;
        }

        public override void Use()
        {
            Game.playerPokemon.stat.IncreaseHealth(healAmount);
        }
    }
}
