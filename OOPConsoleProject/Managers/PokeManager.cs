﻿using OOPConsoleProject.Item;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Util;
using System;
using System.Runtime.ExceptionServices;

namespace OOPConsoleProject.Managers
{
    public class PokeManager
    {
        Random random = new Random();

        private static PokeManager instance;
        public static PokeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PokeManager();
                }

                return instance;
            }
        }

        private PokeManager()
        {
            InitializeSkills();
            InitializeEXP();
            InitializePokemon();
            InitializePixelData();
            InitializeItems();
        }

#region Data

        public Dictionary<int, Skill> skills;

        public Dictionary<int, PokemonBaseStat> pokePedia;

        public Dictionary<int, int> exp;

        public Dictionary<int, string[,]> pixels;

#endregion

#region Item

        public Dictionary<int, ItemBase> items;
        public Dictionary<int, SkillMachine> skillMachines = new Dictionary<int, SkillMachine>();

#endregion
        private void InitializeSkills()
        {
            skills = new Dictionary<int, Skill>
            {
                {0, new Skill("파괴광선", Type.Normal, 120, 65)},
                {1, new Skill("기가임팩트", Type.Normal, 120, 65)},
                {2, new Skill("몸통박치기", Type.Normal, 40, 100)},
                {3, new Skill("베어가르기", Type.Normal, 70, 100)},
                {4, new Skill("박치기", Type.Normal, 70, 100)},
                {5, new Skill("몸통박치기", Type.Normal, 40, 100)},
                {6, new Skill("할퀴기", Type.Normal, 40, 100)},
                {7, new Skill("전광석화", Type.Normal, 40, 100)},
                {8, new Skill("막치기", Type.Normal, 40, 100)},
                {9, new Skill("풀베기", Type.Normal, 50, 95)},
        
                // 풀 타입 기술
                {10, new Skill("솔라빔", Type.Grass, 120, 70)},
                {11, new Skill("리프스톰", Type.Grass, 130, 70)},
                {12, new Skill("에너지볼", Type.Grass, 90, 100)},
                {13, new Skill("리프블레이드", Type.Grass, 90, 90)},
                {14, new Skill("씨폭탄", Type.Grass, 80, 100)},
                {15, new Skill("덩굴채찍", Type.Grass, 45, 100)},
                {16, new Skill("메가드레인", Type.Grass, 40, 100)},
                {17, new Skill("매지컬리프", Type.Grass, 60, 100)},
                {18, new Skill("잎날가르기", Type.Grass, 55, 95)},
                {19, new Skill("개척하기", Type.Grass, 50, 90)},
        
                // 불 타입 기술
                {20, new Skill("플레어드라이브", Type.Fire, 120, 80)},
                {21, new Skill("불대문자", Type.Fire, 110, 75)},
                {22, new Skill("화염방사", Type.Fire, 90, 95)},
                {23, new Skill("열풍", Type.Fire, 95, 90)},
                {24, new Skill("불꽃엄니", Type.Fire, 65, 95)},
                {25, new Skill("불꽃세례", Type.Fire, 40, 100)},
                {26, new Skill("불꽃놀이", Type.Fire, 35, 85)},
                {27, new Skill("플레임차지", Type.Fire, 50, 100)},
                {28, new Skill("분화", Type.Fire, 100, 50)},
                {29, new Skill("블레이즈킥", Type.Fire, 85, 90)},
        
                // 물 타입 기술
                {30, new Skill("하이드로펌프", Type.Water, 110, 80)},
                {31, new Skill("파도타기", Type.Water, 90, 100)},
                {32, new Skill("폭포오르기", Type.Water, 80, 100)},
                {33, new Skill("열탕", Type.Water, 80, 100)},
                {34, new Skill("거품광선", Type.Water, 65, 100)},
                {35, new Skill("물대포", Type.Water, 40, 100)},
                {36, new Skill("거품", Type.Water, 40, 100)},
                {37, new Skill("아쿠아제트", Type.Water, 40, 100)},
                {38, new Skill("거품광선", Type.Water, 60, 100)},
                {39, new Skill("물의파동", Type.Water, 60, 90)},
            };
        }
        private void InitializePokemon()
        {
            pokePedia = new Dictionary<int, PokemonBaseStat>
            {                                             // id, 체, 공, 방, 스
                // 이상해씨
                {1, new PokemonBaseStat("이상해씨",Type.Grass,1 ,45, 49, 65, 45) },
                {2, new PokemonBaseStat("이상해풀",Type.Grass,2 ,60, 73, 71, 60) },
                {3, new PokemonBaseStat("이상해꽃",Type.Grass,3 ,80, 100, 100, 80) },

                // 파이리
                {4, new PokemonBaseStat("파이리"  ,Type.Fire,4 ,39, 60, 50, 65) },
                {5, new PokemonBaseStat("리자드"  ,Type.Fire,5 ,58, 80, 60, 80) },
                {6, new PokemonBaseStat("리자몽"  ,Type.Fire,6 ,78, 84, 96, 100) },

                // 꼬부기
                {7, new PokemonBaseStat("꼬부기"  ,Type.Water,7 ,44, 48, 70, 43) },
                {8, new PokemonBaseStat("어니부기",Type.Water,8 ,59, 64, 80, 58) },
                {9, new PokemonBaseStat("거북왕"  ,Type.Water,9 ,79, 84, 105, 78) },
            };
        }
        private void InitializeEXP()
        {
            exp = new Dictionary<int, int>
            {
                {1, 8}      , {2, 14}   , {3, 25}   , {4, 38}   , {5, 57},
                {6, 80}     , {7, 106}  , {8, 145}  , {9, 189}  , {10, 236},
                {11, 287}   , {12, 341} , {13, 398} , {14, 459} , {15, 523},
                {16, 590}   , {17, 660} , {18, 733} , {19, 809} , {20, 888},
                {21, 969}   , {22, 1052}, {23, 1137}, {24, 1224}, {25, 1313},
                {26, 1404}  , {27, 1497}, {28, 1592}, {29, 1689}, {30, 1788},
                {31, 1889}  , {32, 1992}, {33, 2097}, {34, 2204}, {35, 2313},
                {36, 2424}  , {37, 2537}, {38, 2652}, {39, 2769}, {40, 2888},
                {41, 3009}  , {42, 3132}, {43, 3257}, {44, 3384}, {45, 3513},
                {46, 3644}  , {47, 3777}, {48, 3912}, {49, 4049}
            };
        }
        private void InitializePixelData()
        {
            pixels = new Dictionary<int, string[,]>
            {
                {1, PixelLoader("이상해씨")},
                {2, PixelLoader("파이리")},
                {3, PixelLoader("꼬부기")}
            };
        }
        private void InitializeItems()
        {
            items = new Dictionary<int, ItemBase>
            {
                // 종족값 Up Item
                {1, new Taurine ("타우린","포켓몬의 공격 노력치를 10% 늘려준다.") },
                {2, new Saponin ("사포닌","포켓몬의 방어 노력치를 10% 늘려준다.") },
                {3, new MaxUp   ("맥스업","포켓몬의 체력 노력치를 10% 늘려준다.") },
                {4, new Alkaloid("알칼로이드","포켓몬의 스피드 노력치를 10% 늘려준다.") },

                // 힐 아이템
                {5, new Potion("상처약","포켓몬의 HP를 20 만큼 회복한다.",20) },
                {6, new Potion("좋은 상처약","포켓몬의 HP를 50 만큼 회복한다.",50) },
                {7, new Potion("고급 상처약","포켓몬의 HP를 120만큼 회복한다.",120) },

                // 레벨업 아이템
                {8, new Candy("이상한사탕","포켓몬의 레벨을 1 상승시킨다.", 1) },
            };

            int i = 1;

            foreach (var skillPair in skills)
            {             
                Skill skill = skillPair.Value;

                string typeName = StringUtil.TypeKorean(skill.type);
                string typeColorCode = StringUtil.GetConsoleColorCodeByType(skill.type);
                string coloredType = $"{typeColorCode}{typeName}\x1b[0m";

                string machineName = $"{skill.name} 기술머신";
                string machineDesc = $"타입 : {coloredType}, 위력 : {skill.skillPower}, 명중률 : {skill.chance}";

                skillMachines.Add(i++, new SkillMachine(skill, machineName, machineDesc));
            }
        }

        public Pokemon SetupRandomPokemon()
        {
            if (pokePedia.TryGetValue(random.Next(1, pokePedia.Count+1), out PokemonBaseStat data))
            {
                Pokemon newPoke = new Pokemon(data.name, data.type, data.id, data.hp, data.damage, data.defense, data.speed);
                newPoke.SetupPixelData(pixels[data.id]);
                newPoke.SetupSkills();
                newPoke.SetLevel(random.Next(Game.stageCount + 1, Game.stageCount + 4));
                return newPoke;
            }
            return null;
        }
        public Pokemon SetupPokemon(int id)
        {
            PokemonBaseStat data = pokePedia[id];
            Pokemon newPoke = new Pokemon(data.name, data.type, data.id, data.hp, data.damage, data.defense, data.speed);
            newPoke.SetupPixelData(pixels[data.id]);
            newPoke.SetupSkills();       
            return newPoke;
        }
        private string[,] PixelLoader(string fileName)
        {
            string filePath = $"PixelData/{fileName}.txt";
            var lines = File.ReadAllLines(filePath);

            int rows = lines.Length;            // 행
            int cols = lines[0].Length;         // 열

            string[,] pixel = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    pixel[y, x] = lines[y][x].ToString();
                }
            }

            return pixel;
        }

        public void DrawPokemon(string[,] pokemon, int xDistance, int yDistance)
        {
            int rows = pokemon.GetLength(0);
            int cols = pokemon.GetLength(1);

            for (int y = 0; y < rows; y++)
            {
                Console.SetCursorPosition(xDistance, yDistance + y);
                for (int x = 0; x < cols; x++)
                {
                    Console.ResetColor();
                    Console.Write(pokemon[y, x]);
                }
            }
        }
    }
}
