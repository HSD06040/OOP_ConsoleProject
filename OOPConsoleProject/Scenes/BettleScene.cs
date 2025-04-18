﻿using OOPConsoleProject.Managers;
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
            if (!isBattle)
                Setup();
            DrawUI();

            PixelDrawer.DrawPokemon(enemyPokemon.pixelData, 55, 5);
            PixelDrawer.DrawPokemon(PixelDrawer.FlipPokemonHorizontal(playerPokemon.pixelData), 3, 15);
            Console.WriteLine("\n============================================================================================================================================");
        }

        private void DrawUI()
        {
            Console.WriteLine("============================================================================================================================================\n");

            DrawStat(playerPokemon);
            Console.Write($"                            ");
            DrawStat(enemyPokemon);

            Console.WriteLine($"                                현재 스테이지 : {Game.stageCount}\n");
            Console.Write($"경험치 : {playerPokemon.stat.curEXP} / {PokeManager.Instance.exp[playerPokemon.stat.level]}");
        }

        private void DrawStat(Pokemon pokemon)
        {
            Console.Write($"Lv.{StringUtil.ColorText(pokemon.stat.level.ToString(), ConsoleColor.White)} ");
            Console.Write($"{StringUtil.ColorText(pokemon.name, StringUtil.TypeColor(pokemon.stat.type))} ");
            Console.Write($"HP : {StringUtil.ColorText(pokemon.stat.curHP.ToString(), ConsoleColor.Red)} / ");
            Console.Write($"{StringUtil.ColorText(pokemon.stat.HP().ToString(), ConsoleColor.Red)}");
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
                    if(firstPoke == playerPokemon)
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
            Thread.Sleep(500);

            if (!enemyPokemon.stat.isAlive)
            {
                Console.WriteLine("======================================================================================================\n");
                Console.WriteLine("계속 진행을 원하시면 아무키나 클릭하세요\n");
                Console.WriteLine("======================================================================================================\n");

                Console.ReadKey(true);

                isBattle = false;
                SceneManager.Instance.ChangeScene("아이템");
            }
            else if (!playerPokemon.stat.isAlive)
            {
                SceneManager.Instance.ChangeScene("끝");   
            }
        }
    }
}
