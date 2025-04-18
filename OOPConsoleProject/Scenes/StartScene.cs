﻿using OOPConsoleProject.Managers;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Util;

namespace OOPConsoleProject.Scenes
{
    public class StartScene : Scene
    {
        private Pokemon[] SP = Game.SP;

        public override void RenderScene()
        {
            Console.WriteLine("=========================스타팅 포켓몬 고르기==============================");

            Console.WriteLine("===========================================================================\n");
            Console.WriteLine("===========================================================================\n");

            Console.ForegroundColor = StringUtil.TypeColor(SP[0].stat.type);
            Console.WriteLine($"1 : {SP[0].name,6}의 종족값\n");
            Console.ResetColor();
            SP[0].stat.PrintStat();
            Console.WriteLine("\n");

            PixelDrawer.DrawPokemon(SP[0].pixelData,3,10);

            Console.ForegroundColor = StringUtil.TypeColor(SP[1].stat.type);
            Console.WriteLine($"\n\n2 : {SP[1].name,6}의 종족값\n");
            Console.ResetColor();
            SP[1].stat.PrintStat();
            Console.WriteLine("\n");

            PixelDrawer.DrawPokemon(SP[1].pixelData, 3, 35);

            Console.ForegroundColor = StringUtil.TypeColor(SP[2].stat.type);
            Console.WriteLine($"\n\n3 : {SP[2].name,6}의 종족값\n");
            Console.ResetColor();
            SP[2].stat.PrintStat();
            Console.WriteLine("\n");

            PixelDrawer.DrawPokemon(SP[2].pixelData, 3, 60);

            Console.WriteLine("=========================================================================\n");
        }

        public override void Input()
        {
            Console.WriteLine("당신의 여정을 함께할 포켓몬을 선택하세요!");
            do
            {  
                base.Input();
            }
            while (!InputBool(input, ConsoleKey.D1, ConsoleKey.D3));
        }

        public override void Result()
        {
            SceneManager.Instance.ChangeScene("배틀");
        }

        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Game.SetupPlayerPokemon(SP[0]);
                    Console.WriteLine(StringUtil.KoreanParticle($"{SP[0].name} 을/를 선택하였다!"));
                    break;
                case ConsoleKey.D2:
                    Game.SetupPlayerPokemon(SP[1]);
                    Console.WriteLine(StringUtil.KoreanParticle($"{SP[1].name} 을/를 선택하였다!"));
                    break;
                case ConsoleKey.D3:
                    Game.SetupPlayerPokemon(SP[2]);
                    Console.WriteLine(StringUtil.KoreanParticle($"{SP[2].name} 을/를 선택하였다!"));
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}
