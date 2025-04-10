using OOPConsoleProject.Item;
using OOPConsoleProject.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Managers
{
    public class Inventory
    {
        private static List<BattleItem> battleItemList = new List<BattleItem>();

        public static void AddItem(BattleItem item)
        {
            battleItemList.Add(item);

            Game.playerPokemon.stat.itemStat.ClearStat();

            Update();
        }

        public static void Update()
        {
            foreach (BattleItem battleItem in battleItemList)
            {
                battleItem.AddItemStat();
            }
        }

        public static void Clear()
        {
            battleItemList = new List<BattleItem>();
            Game.playerPokemon.stat.itemStat.ClearStat();
        }
    }
}
