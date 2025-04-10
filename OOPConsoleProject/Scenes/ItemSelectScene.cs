using OOPConsoleProject.Item;
using OOPConsoleProject.Managers;
using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class ItemSelectScene : Scene
    {
        private ItemBase[] items;
        

        public override void Enter()
        {
            StageManager.StageItemCount();

            items = new ItemBase[Game.itemCount];

            List<int> allItems          = PokeManager.Instance.items.Keys.ToList();
            List<int> allSkillMachines  = PokeManager.Instance.skillMachines.Keys.ToList();
            List<int> allRareItems = PokeManager.Instance.rareItems.Keys.ToList();
            List<int> allBattleItems = PokeManager.Instance.battleItems.Keys.ToList();

            HashSet<int> selectedItems          = new HashSet<int>();        
            HashSet<int> selectedSkillMachines  = new HashSet<int>();
            HashSet<int> selectedRareItems      = new HashSet<int>();
            HashSet<int> selectedBattleItems    = new HashSet<int>();

            while (selectedItems.Count + selectedSkillMachines.Count + selectedBattleItems.Count + selectedRareItems.Count
                    < Game.itemCount)
            {
                int id;
                int randomNum = random.Next(1,100);
                bool isSkillMachine = false;                                // 기술머신 확률 20%, 황금몬스터볼 확률 3퍼, 배틀아이템 6퍼 
                bool isBattleItem = false;
                bool isRareItem = false;

                if (randomNum <= 1)
                    isRareItem = true;
                else if (randomNum <= 4)
                    isBattleItem = true;
                else if (randomNum <= 20)
                    isSkillMachine = true;

                if (isSkillMachine && allSkillMachines.Count > 0)       // 기술머신
                {
                    id = allSkillMachines[random.Next(allSkillMachines.Count)];
                    selectedSkillMachines.Add(id);
                }
                else if (isBattleItem && allBattleItems.Count > 0)           // 배틀아이템
                {
                    id = allBattleItems[random.Next(allBattleItems.Count)];
                    selectedBattleItems.Add(id);
                }
                else if (isRareItem && allRareItems.Count > 0)       // 레어아이템
                {
                    id = allRareItems[random.Next(allRareItems.Count)];
                    selectedRareItems.Add(id);
                }
                else if (allItems.Count > 0)                            // 일반 아이템
                {
                    do
                    {
                        id = allItems[random.Next(allItems.Count)];
                    }
                    while ((Game.stageCount < 30 && (id == 6 || id == 7)) ||
                           (Game.stageCount < 60 && id == 7));

                    selectedItems.Add(id);
                }
            }

            int index = 0;
            foreach (int id in selectedItems)
            {
                items[index++] = PokeManager.Instance.items[id];
            }
            foreach (int id in selectedSkillMachines)
            {
                items[index++] = PokeManager.Instance.skillMachines[id];
            }
            foreach (int id in selectedBattleItems)
            {
                items[index++] = PokeManager.Instance.battleItems[id];
            }
            foreach (int id in selectedRareItems)
            {
                items[index++] = PokeManager.Instance.rareItems[id];
            }
        }

        public override void RenderScene()
        {
            Console.WriteLine("===================================아이템을 고르세요!===================================\n");
            foreach (var item in items)
            {
                item.PrintData();
            }
            Console.WriteLine("======================================================================================");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n{playerPokemon.name}의 현재 체력 {playerPokemon.stat.curHP} / {playerPokemon.stat.HP()}\n");
            Console.ResetColor();
            playerPokemon.PrintSkillData();
        }

        public override void Input()
        {
            Console.WriteLine("==================================\n");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(StringUtil.KoreanParticle($"{i + 1}. {items[i].name}을/를 고른다.\n"));
            }

            Console.WriteLine("==================================\n");
            do
            {
                base.Input();
            }
            while (!InputBool(input,ConsoleKey.D1, ConsoleKey.D0 + Game.itemCount));        
        }

        public override void Update()
        {
            ItemBase selectItem = items[(int)input - 49];

            selectItem.Use();    
        }

        public override void Result()
        {
            Console.WriteLine("==================================\n");
            Console.WriteLine("계속 진행을 원하시면 아무키나 클릭하세요\n");
            Console.WriteLine("==================================\n");

            Console.ReadKey(true);
         
            SceneManager.Instance.ChangeScene("배틀");
        }
    }
}
