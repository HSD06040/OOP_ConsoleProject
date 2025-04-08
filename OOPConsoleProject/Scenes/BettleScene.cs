using OOPConsoleProject.Managers;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class BettleScene : Scene
    {
        Battle battle = new Battle();
        bool isBattle = false;
        public override void RenderScene()
        {
            if(!isBattle)
                Setup();

            Console.Write($"Lv.{playerPokemon.stat.level} {playerPokemon.name} HP : {playerPokemon.stat.HP()} / {playerPokemon.stat.curHP}");
            Console.Write($"                            ");
            Console.Write($"Lv.{enemyPokemon.stat.level} {enemyPokemon.name} HP : {enemyPokemon.stat.HP()} / {enemyPokemon.stat.curHP}\n");
            Console.Write($"현재 스테이지 : {Game.stageCount}");

            PokeManager.Instance.DrawPokemon(playerPokemon.pixelData, 3, 3);
            PokeManager.Instance.DrawPokemon(enemyPokemon.pixelData, 10, 3);
        }

        private void Setup()
        {
            Game.SetupEnemyPokemon(PokeManager.Instance.SetupRandomPokemon());
            Game.stageCount++;
        }

        public override void Input()
        {
            Console.WriteLine("\n");
            Console.WriteLine(StringUtil.KoreanParticle($"{playerPokemon.name} 은/는 무엇을 할까?\n"));

            playerPokemon.PrintSkillData();

            do
            {
                base.Input();
            }
            while (!InputBool(input,ConsoleKey.D1,ConsoleKey.D4));  
        }

        public override void Update()
        {
            isBattle = false;
            while(playerPokemon.stat.isAlive && enemyPokemon.stat.isAlive)
            {
                if(isBattle)
                {
                    Console.Clear();
                    RenderScene();
                    Input();
                }

                BattleSetup();

                Pokemon firstPoke = battle.turn.Dequeue();
                Pokemon secondPoke = battle.turn.Dequeue();

                Console.WriteLine($"{StringUtil.KoreanParticle($"{firstPoke.name}의 {firstPoke.selectSkill.name}!!!")}\n");
                Thread.Sleep(500);

                if (random.Next(100) < firstPoke.selectSkill.chance)
                    firstPoke.stat.DoDamage(secondPoke.stat, firstPoke.selectSkill);
                else
                    Console.WriteLine($"{firstPoke.name}의 공격은 빗나갔다!\n");

                Thread.Sleep(500);

                if (secondPoke.stat.isAlive)
                {
                    Console.WriteLine($"{StringUtil.KoreanParticle($"{secondPoke.name}의 {secondPoke.selectSkill.name}!!!")}\n");
                    Thread.Sleep(500);

                    if (random.Next(100) < secondPoke.selectSkill.chance)
                        secondPoke.stat.DoDamage(firstPoke.stat, secondPoke.selectSkill);
                    else                    
                        Console.WriteLine($"{firstPoke.name}의 공격은 빗나갔다!\n");

                    Thread.Sleep(500);
                }
                else
                {
                    firstPoke.stat.GetEXP(secondPoke.stat.DropEXP());
                }

                if(!isBattle)
                    isBattle = true;
            }
        }

        private void BattleSetup()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    playerPokemon.selectSkill = playerPokemon.skills[0];
                    break;
                case ConsoleKey.D2:
                    playerPokemon.selectSkill = playerPokemon.skills[1];
                    break;
                case ConsoleKey.D3:
                    playerPokemon.selectSkill = playerPokemon.skills[2];
                    break;
                case ConsoleKey.D4:
                    playerPokemon.selectSkill = playerPokemon.skills[3];
                    break;
            }

            enemyPokemon.selectSkill = enemyPokemon.skills[random.Next(0, 4)];

            if (playerPokemon.stat.Speed() > enemyPokemon.stat.Speed())
            {
                battle.turn.Enqueue(playerPokemon);
                battle.turn.Enqueue(enemyPokemon);
            }
            else
            {
                battle.turn.Enqueue(enemyPokemon);
                battle.turn.Enqueue(playerPokemon);
            }
        }

        public override void Result()
        {
            if (!enemyPokemon.stat.isAlive)
            {
                Console.WriteLine("==================================\n");
                Console.WriteLine("계속 진행을 원하시면 아무키나 클릭하세요\n");
                Console.WriteLine("==================================\n");

                Console.ReadKey(true);

                isBattle = false;
                SceneManager.Instance.ChangeScene("아이템");
            }
            else if (!playerPokemon.stat.isAlive)
            {
                SceneManager.Instance.ChangeScene("끝");
                Game.gameOver = true;
            }
        }
    }
}
