using OOPConsoleProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class TitleScene : Scene
    {
        public override void Input()
        {
            Console.WriteLine("아무키나 누르세요.");
            base.Input();
        }

        public override void RenderScene()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("==================포켓로그=================");
            Console.WriteLine("===========================================");
        }

        public override void Result()
        {
            Game.curScene = SceneManager.Instance.GetScene("시작");
        }

        public override void Update()
        {
            
        }
    }
}
