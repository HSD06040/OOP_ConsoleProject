using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Scenes;
using OOPConsoleProject.Util;

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
            { "시작"  ,new StartScene() },
            { "배틀"  ,new BettleScene() },
            { "아이템" , new ItemSelectScene() },
            { "끝"   , new EndScene()}
        };

        public void ChangeScene(string sceneName)
        {
            Game.curScene = sceneDictionary[sceneName];
            Game.curScene.Enter();
        }

        public void SkillLearning(Skill skill)
        {
            ConsoleKey input;
            Skill removeSkill;

            Console.Clear();
            Game.playerPokemon.PrintSkillData();
            Console.WriteLine("어떤 기술을 잊겠습니까?\n");
            Console.Write("배우려는 기술 : "); skill.PrintSkillData();

            do
            {
                if (Console.KeyAvailable)
                    Console.ReadKey(true);

                input = Console.ReadKey(true).Key;
            }
            while (input < ConsoleKey.D1 || input > ConsoleKey.D4);

            switch(input)
            {
                case ConsoleKey.D1:
                    removeSkill = Game.playerPokemon.skills[0];
                    Game.playerPokemon.skills[0] = skill;
                    break;
                case ConsoleKey.D2:
                    removeSkill = Game.playerPokemon.skills[1];
                    Game.playerPokemon.skills[1] = skill;
                    break;
                case ConsoleKey.D3:
                    removeSkill = Game.playerPokemon.skills[2];
                    Game.playerPokemon.skills[2] = skill;
                    break;
                case ConsoleKey.D4:
                    removeSkill = Game.playerPokemon.skills[3];
                    Game.playerPokemon.skills[3] = skill;
                    break;
                default:
                    removeSkill = skill;
                    break;
            }
            Console.WriteLine(StringUtil.KoreanParticle($"\n{Game.playerPokemon.name}은/는 {removeSkill.name}을 잊어버리고"));
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".\n");
            Thread.Sleep(200);
            Console.WriteLine(StringUtil.KoreanParticle($"{skill.name}을/를 새롭게 배웠다!\n"));
        }
    }
}
