using OOPConsoleProject.Item;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Util;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;

namespace OOPConsoleProject.Managers
{
    public class PokeManager
    {
        public Random random = new Random();

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
            InitializePokemon();
            InitializePixelData();
            InitializeEXP();
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
        public Dictionary<int, RareItem> rareItems;
        public Dictionary<int, BattleItem> battleItems;

#endregion
        private void InitializeSkills()
        {
            skills = new Dictionary<int, Skill>
            {
                // 불꽃 타입
                {0, new Skill("플레어드라이브", Type.Fire, 120, 100)},
                {1, new Skill("불대문자", Type.Fire, 110, 85)},
                {2, new Skill("화염방사", Type.Fire, 90, 100)},
                {3, new Skill("열풍", Type.Fire, 95, 90)},
                {4, new Skill("불꽃엄니", Type.Fire, 65, 95)},
                {5, new Skill("불꽃세례", Type.Fire, 40, 100)},
                {6, new Skill("화염자동차", Type.Fire, 60, 100)},
                {7, new Skill("니트로차지", Type.Fire, 50, 100)},
                {8, new Skill("분화", Type.Fire, 150, 50)},
                {9, new Skill("블레이즈킥", Type.Fire, 85, 90)},
                {10, new Skill("불꽃펀치", Type.Fire, 75, 100)},
                {11, new Skill("불태우기", Type.Fire, 130, 100)},
                {12, new Skill("매지컬플레임", Type.Fire, 75, 100)},

                // 풀 타입
                {13, new Skill("솔라빔", Type.Grass, 120, 80)},
                {14, new Skill("리프스톰", Type.Grass, 100, 85)},
                {15, new Skill("에너지볼", Type.Grass, 90, 100)},
                {16, new Skill("리프블레이드", Type.Grass, 90, 100)},
                {17, new Skill("씨폭탄", Type.Grass, 80, 100)},
                {18, new Skill("덩굴채찍", Type.Grass, 45, 100)},
                {19, new Skill("바늘팔", Type.Grass, 60, 100)},
                {20, new Skill("매지컬리프", Type.Grass, 60, 100)},
                {21, new Skill("잎날가르기", Type.Grass, 55, 95)},
                {22, new Skill("개척하기", Type.Grass, 50, 100)},
                {23, new Skill("우드해머", Type.Grass, 120, 100)},
                {24, new Skill("하드플랜트", Type.Grass, 150, 90)},
                {25, new Skill("나뭇잎", Type.Grass, 40, 100)},
                {26, new Skill("트로피컬킥", Type.Grass, 70, 100)},

                // 물 타입
                {27, new Skill("하이드로펌프", Type.Water, 110, 80)},
                {28, new Skill("파도타기", Type.Water, 90, 100)},
                {29, new Skill("폭포오르기", Type.Water, 80, 100)},
                {30, new Skill("열탕", Type.Water, 80, 100)},
                {31, new Skill("거품광선", Type.Water, 65, 100)},
                {32, new Skill("물대포", Type.Water, 40, 100)},
                {33, new Skill("거품", Type.Water, 40, 100)},
                {34, new Skill("아쿠아제트", Type.Water, 40, 100)},
                {35, new Skill("물의파동", Type.Water, 60, 100)},
                {36, new Skill("소금물", Type.Water, 65, 100)},
                {37, new Skill("껍질끼우기", Type.Water, 35, 95)},
                {38, new Skill("셸블레이드", Type.Water, 75, 95)},

                // 노말 타입
                {39, new Skill("파괴광선", Type.Normal, 150, 90)},
                {40, new Skill("기가임팩트", Type.Normal, 150, 90)},
                {41, new Skill("몸통박치기", Type.Normal, 40, 100)},
                {42, new Skill("베어가르기", Type.Normal, 70, 100)},
                {43, new Skill("박치기", Type.Normal, 70, 100)},
                {44, new Skill("할퀴기", Type.Normal, 40, 100)},
                {45, new Skill("전광석화", Type.Normal, 40, 100)},
                {46, new Skill("풀베기", Type.Normal, 50, 95)},
                {47, new Skill("메가톤펀치", Type.Normal, 80, 85)},
                {48, new Skill("찝기", Type.Normal, 55, 100)},
                {49, new Skill("짓밟기", Type.Normal, 65, 100)},
                {50, new Skill("신속", Type.Normal, 80, 100)},
                {51, new Skill("칼등치기", Type.Normal, 40, 100)},

                {52, new Skill("하이퍼보이스",Type.Normal, 90,100)},
                {53, new Skill("성스러운불꽃", Type.Fire, 100, 95)},
                {54, new Skill("불꽃의맹세", Type.Fire, 80, 100)},
                {55, new Skill("풀의맹세", Type.Grass, 80, 100)},
                {56, new Skill("물의맹세", Type.Water, 80, 100)},
                {57, new Skill("꽃보라", Type.Grass, 90, 100)},
                {58, new Skill("아쿠아테일", Type.Water, 90, 90)},
                {59, new Skill("불꽃튀기기", Type.Fire, 70, 100)},
                {60, new Skill("V제너레이트", Type.Fire, 180, 60)},
                {61, new Skill("폭음파", Type.Normal, 140, 100)},
                {62, new Skill("근원의파동", Type.Water, 110, 85)},
                {63, new Skill("물거품아리아", Type.Water, 90, 100)},
                {64, new Skill("불꽃채찍", Type.Fire, 80, 100)},
                {65, new Skill("아쿠아브레이크", Type.Water, 85, 100)},
                {66, new Skill("파워휩", Type.Grass, 120, 85)},
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

                // 포니타
                {10, new PokemonBaseStat("포니타"  ,Type.Fire,10 ,50, 70, 55, 90) },
                {11, new PokemonBaseStat("날쌩마"  ,Type.Fire,11 ,65, 85, 80, 105) },

                // 식스테일
                {12, new PokemonBaseStat("식스테일" ,Type.Fire,12 ,38, 45, 55, 65) },
                {13, new PokemonBaseStat("나인테일" ,Type.Fire,13 ,73, 80, 90, 100) },

                // 가디
                {14, new PokemonBaseStat("가디"  ,Type.Fire,14 ,55, 70, 45, 60) },
                {15, new PokemonBaseStat("윈디"  ,Type.Fire,15 ,90, 110, 80, 95) },

                // 콘치
                {16, new PokemonBaseStat("콘치"   ,Type.Water,16 ,45, 50, 55, 63) },
                {17, new PokemonBaseStat("왕콘치"  ,Type.Water,17 ,80, 83, 74, 68) },

                // 고라파덕
                {18, new PokemonBaseStat("고라파덕",Type.Water,18 ,50, 60, 49, 55) },
                {19, new PokemonBaseStat("골덕"    ,Type.Water,19 ,80, 90, 80, 85) },

                // 크랩
                {20, new PokemonBaseStat("크랩"   ,Type.Water,20 ,30, 90, 80, 50) },
                {21, new PokemonBaseStat("킹크랩"  ,Type.Water,21 ,55, 130, 100, 75) },

                // 달콤아
                {22, new PokemonBaseStat("달콤아"   ,Type.Grass,22 ,42, 30, 38, 32) },
                {23, new PokemonBaseStat("달무리나"  ,Type.Grass,23 ,52, 40, 48, 62) },
                {24, new PokemonBaseStat("달코퀸"   ,Type.Grass,24 ,72, 120, 98, 72) },

                // 치릴리
                {25, new PokemonBaseStat("치릴리"   ,Type.Grass,25 ,45, 65, 50, 30) },
                {26, new PokemonBaseStat("드레디어" ,Type.Grass,26 ,70, 110, 75, 90) },

                // 무스틈니
                {27, new PokemonBaseStat("무스틈니"   ,Type.Grass,27 ,74, 100, 72, 46) },

                // 꼬렛
                {28, new PokemonBaseStat("꼬렛"     ,Type.Normal,28 ,30, 53, 35, 72) },
                {29, new PokemonBaseStat("레트라"   ,Type.Normal,29 ,55, 81, 65, 97) },

                // 이브이
                {30, new PokemonBaseStat("이브이"   ,Type.Normal,30 ,55, 55, 63, 55) },

                // 폴리곤
                {31, new PokemonBaseStat("폴리곤"   ,Type.Normal,31 ,65, 85, 72, 40) },

                // 잠만보
                {32, new PokemonBaseStat("잠만보"   ,Type.Normal,32 ,160, 110, 80, 30) },

                // 파이어
                {33, new PokemonBaseStat("파이어"   ,Type.Fire  ,32 ,90, 125, 90, 90) },
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
            pixels = new Dictionary<int, string[,]>();

            foreach (var kvp in pokePedia)
            {
                int id = kvp.Key;
                string name = kvp.Value.name;
                pixels[id] = PixelDrawer.PixelLoader(name);
            }
        }
        private void InitializeItems()
        {
            items = new Dictionary<int, ItemBase>
            {
                // 종족값 Up Item
                {1, new Taurine ("타우린","포켓몬의 공격 종족값을 10% 늘려준다.") },
                {2, new Saponin ("사포닌","포켓몬의 방어 종족값를 10% 늘려준다.") },
                {3, new MaxUp   ("맥스업","포켓몬의 체력 종족값를 10% 늘려준다.") },
                {4, new Alkaloid("알칼로이드","포켓몬의 스피드 종족값를 10% 늘려준다.") },

                // 힐 아이템
                {5, new Potion("상처약","포켓몬의 HP를 20 만큼 회복한다.",20) },
                {6, new Potion("좋은 상처약","포켓몬의 HP를 50 만큼 회복한다.",50) },
                {7, new Potion("고급 상처약","포켓몬의 HP를 120만큼 회복한다.",120) },

                // 레벨업 아이템
                {8, new Candy("이상한사탕","포켓몬의 레벨을 1 상승시킨다.", 1) },
            };

            rareItems = new Dictionary<int, RareItem>
            {
                {1, new GoldenPokeBall("황금 몬스터볼","획득 시 스테이지 후 얻을 수 있는 아이템의 갯수가 증가한다.") }
            };

            battleItems = new Dictionary<int, BattleItem>
            {
                {1, new SilkScarf("실크스카프","획득 시 노말타입 기술의 위력이 20% 증가한다.",20)},
                {2, new MysticWater("신비의물방울","획득 시 물타입 기술의 위력이 20% 증가한다.",20)},
                {3, new Charcoal("목탄","획득 시 불꽃타입 기술의 위력이 20% 증가한다.",20)},
                {4, new MiracleSeed("기적의씨","획득 시 풀타입 기술의 위력이 20% 증가한다.",20)},
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
            if (Game.stageCount == 24)
                return BossSetting(32);

            if (Game.stageCount == 69)
                return BossSetting(33);

            int[] pokemons;

            pokemons = StageManager.GetDifficultyByStage();

            if (pokePedia.TryGetValue(pokemons[random.Next(pokemons.Length)], out PokemonBaseStat data))
            {
                return CreatePokemon(data);
            }
            return null;
        }

        private Pokemon BossSetting(int id)
        {
            PokemonBaseStat bossData;
            bossData = pokePedia[id];
            return CreatePokemon(bossData);
        }

        private Pokemon CreatePokemon(PokemonBaseStat data)
        {
            int randomLevel = random.Next(Game.stageCount - 3, Game.stageCount + 3);

            if (randomLevel < 1)
                randomLevel = 1;

            return new Pokemon(data.name, data.type, data.id, data.hp, data.damage, data.defense, data.speed)
            .SetupPixelData(pixels[data.id]).SetupSkills().SetRandomIV().SetLevel(randomLevel);
        }

        public Pokemon SetupPokemon(int id)
        {
            PokemonBaseStat data = pokePedia[id];

            return new Pokemon(data.name, data.type, data.id, data.hp, data.damage, data.defense, data.speed)
                .SetupPixelData(pixels[data.id]).SetupSkills();
        }
    }
}
