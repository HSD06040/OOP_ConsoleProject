using OOPConsoleProject.Item;
using OOPConsoleProject.Managers;
using System;
using System.Collections.Generic;
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
            HashSet<int> selectedItem = new HashSet<int>();
            int id;

            while (selectedItem.Count < Game.itemCount)
            {
                do
                {
                    id = allItems[random.Next(allItems.Count)];
                }
                while (Game.stageCount < 30 && (id == 6 || id == 7)
                       || Game.stageCount < 60 && (id == 7));

                selectedItem.Add(id);
            }

            int index = 0;
            foreach (int num in selectedItem)
            {
                items[index++] = PokeManager.Instance.items[num];
            }

        }

        public override void RenderScene()
        {
            Console.WriteLine("========================아이템을 고르세요!==============================\n");
            foreach (var item in items)
            {
                item.PrintData();
            }
            Console.WriteLine("=============================================================================");
        }

        public override void Input()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"{i+1}. {items[i].name,6} 을 고른다.\n");
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
