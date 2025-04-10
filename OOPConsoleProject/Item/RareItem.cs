using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public class RareItem : ItemBase
    {
        public RareItem(string name, string description) : base(name, description)
        {
            this.name = StringUtil.ColorText(name, ConsoleColor.Magenta);
        }

        public override void Use()
        {
        }
    }
    public class GoldenPokeBall : RareItem
    {
        public GoldenPokeBall(string name, string description) : base(name, description)
        {
        }

        public override void Use()
        {
            Game.AddItemCount();
        }
    }
}
