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
            Console.WriteLine("타이틀로 돌아가려면 아무키나 클릭하시오");
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
            SceneManager.Instance.ChangeScene("타이틀");
        }

        public override void Update()
        {
            
        }
    }
}
