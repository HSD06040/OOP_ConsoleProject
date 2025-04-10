using OOPConsoleProject.Managers;
using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public abstract class BattleItem : ItemBase
    {
        protected int value;
        public BattleItem(string name, string description, int value) : base(name, description)
        {
            this.name = $"{StringUtil.ColorText(name, ConsoleColor.Red)}";
            this.value = value ;
        }

        public override void Use()
        {
            Inventory.AddItem(this);
        }

        public abstract void AddItemStat();
    }

    public class SilkScarf : BattleItem
    {
        public SilkScarf(string name, string description, int value) : base(name, description, value)
        {
        }

        public override void AddItemStat()
        {
            Game.playerPokemon.stat.itemStat.AddStat(Type.Normal,value);
        }
    }
    public class MiracleSeed : BattleItem
    {
        public MiracleSeed(string name, string description, int value) : base(name, description, value)
        {
        }

        public override void AddItemStat()
        {
            Game.playerPokemon.stat.itemStat.AddStat(Type.Grass, value);
        }
    }
    public class MysticWater : BattleItem
    {
        public MysticWater(string name, string description, int value) : base(name, description, value)
        {
        }

        public override void AddItemStat()
        {
            Game.playerPokemon.stat.itemStat.AddStat(Type.Water, value);
        }
    }
    public class Charcoal : BattleItem
    {
        public Charcoal(string name, string description, int value) : base(name, description, value)
        {
        }

        public override void AddItemStat()
        {
            Game.playerPokemon.stat.itemStat.AddStat(Type.Fire, value);
        }
    }
}
