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
        private ItemBase[] items = new ItemBase[Game.itemCount];
        private ItemBase selectItem;

        public override void Enter()
        {
            List<int> allItems = PokeManager.Instance.items.Keys.ToList();
            List<int> allSkillMachines = PokeManager.Instance.skillMachines.Keys.ToList();
            HashSet<int> selectedItems = new HashSet<int>();
            HashSet<int> selectedSkillMachines = new HashSet<int>();

            while (selectedItems.Count + selectedSkillMachines.Count < Game.itemCount)
            {
                int id;
                bool isSkillMachine = random.Next(100) < 20;            // 기술머신 확률 20%

                if (isSkillMachine && allSkillMachines.Count > 0)       // 기술머신
                {
                    id = allSkillMachines[random.Next(allSkillMachines.Count)];
                    selectedSkillMachines.Add(id);
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
        }

        public override void RenderScene()
        {
            Console.WriteLine("========================아이템을 고르세요!==============================\n");
            foreach (var item in items)
            {
                item.PrintData();
            }
            Console.WriteLine("=================================================================================");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n{playerPokemon.name}의 현재 체력 {playerPokemon.stat.curHP} / {playerPokemon.stat.HP()}\n");
            Console.ResetColor();
        }

        public override void Input()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(StringUtil.KoreanParticle($"{i + 1}. {items[i].name}을/를 고른다.\n"));
            }

            do
            {
                base.Input();
            }
            while (!InputBool(input,ConsoleKey.D1, ConsoleKey.D0 + Game.itemCount));        
        }

        public override void Update()
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    selectItem = items[0];
                    break;
                case ConsoleKey.D2:
                    selectItem = items[1];
                    break;
                case ConsoleKey.D3:
                    selectItem = items[2];
                    break;
                case ConsoleKey.D4:
                    selectItem = items[3];
                    break;
                case ConsoleKey.D5:
                    selectItem = items[4];
                    break;
                case ConsoleKey.D6:
                    selectItem = items[5];
                    break;
            }

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
