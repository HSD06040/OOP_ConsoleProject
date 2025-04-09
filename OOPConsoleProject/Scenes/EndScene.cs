using OOPConsoleProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class EndScene : Scene
    {
        public override void Input()
        {
            Console.WriteLine("종료하시려면 esc 다시 플레이 하시려면 아무키나 클릭하세요");
            base.Input();
        }
        public override void RenderScene()
        {
            Console.WriteLine("=============================================\n\n\n");
            Console.WriteLine("                눈앞이 깜깜해졌다...            \n\n\n");
            Console.WriteLine("=============================================\n");
        }

        public override void Result()
        {
            switch(input)
            {
                case ConsoleKey.Escape:
                    Game.gameOver = true;
                    break;
                default: SceneManager.Instance.ChangeScene("타이틀");
                    Game.Start();
                    break;
            }
        }

        public override void Update()
        {
            
        }
    }
}
