using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Scenes;

namespace OOPConsoleProject.Managers
{
    public class SceneManager
    {
        private static SceneManager instance;
        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }
                return instance;
            }
        }

        public Dictionary<string, Scene> sceneDictionary = new Dictionary<string, Scene>
        {
            { "타이틀", new TitleScene() },
            { "시작" ,new StartScene() },
            { "배틀" ,new BettleScene() }
        };

        public Scene GetScene(string sceneName)
        {
            return sceneDictionary[sceneName];
        }
    }
}
