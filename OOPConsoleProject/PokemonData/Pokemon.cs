using OOPConsoleProject.Managers;
using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPConsoleProject.PokemonData
{
    public class Pokemon
    {
        private Random random => PokeManager.Instance.random;

        public string name { get; private set; }
        public int id { get; private set; }
        public string[,] pixelData { get; private set; }

        public Stat stat { get; private set; }
        public Skill[] skills { get; private set; } = new Skill[4];
        public Skill selectSkill;

        public Pokemon(string name, Type type, int id, int hp, int damage, int defense, int speed)
        {
            stat = new Stat(name, type, hp, damage, defense, speed);
            this.name = name;
            this.id = id;
            stat.OnLevelUp += Evolution;
        }

        public Pokemon SetLevel(int level)
        {
            stat.SetLevel(level);
            return this;
        }

        public Pokemon SetupSkills()
        {
            var allSkillIds = StageManager.GetDifficultyByStageSkill();
            var selectedSkillIds = new HashSet<int>();

            while (selectedSkillIds.Count < 4)
            {
                int id = allSkillIds[random.Next(allSkillIds.Count)];
                selectedSkillIds.Add(id);
            }

            int index = 0;
            foreach (int id in selectedSkillIds)
            {
                skills[index++] = PokeManager.Instance.skills[id];
            }
            return this;
        }

        public Pokemon SetupPixelData(string[,] pixels)
        {
            pixelData = pixels;
            return this;
        }

        public Pokemon SetIV(int value)
        {
            stat.SetIV(value); 
            return this;
        }
        public Pokemon SetRandomIV()
        {
            stat.SetIV(random.Next(32));
            return this;
        }

        public void PrintSkillData()
        {
            Console.WriteLine("=============================================================\n");

            for (int i = 0; i < skills.Length; i++)
            {
                Skill skill = skills[i];

                string namePadded = StringUtil.PadRightDisplay(skill.name, 12);

                string typeText = StringUtil.TypeKorean(skill.type).PadRight(2);

                Console.Write($"{i + 1,2} : {namePadded} / 타입 : ");

                Console.ForegroundColor = StringUtil.TypeColor(skill.type);
                Console.Write($"{typeText}");
                Console.ResetColor();

                Console.WriteLine($", 위력 : {skill.skillPower,3}, 명중률 : {skill.chance,3}\n");
            }

            Console.WriteLine("=============================================================\n");
        }

        public void Evolution()
        {
            if(EvolutionManager.TryGetEvolution(id, out EvolutionData data))
            {
                if(stat.level >= data.requiredLevel)
                {
                    int delay = 500;
                    Pokemon evolved = PokeManager.Instance.SetupPokemon(data.evolvedDexNumber);
                    evolved.SetLevel(stat.level);
                    evolved.SetIV(stat.IV);
                    evolved.skills = skills;

                    Console.Clear();

                    PixelDrawer.DrawPokemon(pixelData,3,3);

                    Console.WriteLine($"\n어랏? {name}의 모습이?\n");
                    Console.Write("."); Thread.Sleep(delay); Console.Write("."); Thread.Sleep(delay); Console.Write("."); Thread.Sleep(delay);

                    PixelDrawer.DrawPokemon(evolved.pixelData, 3, 30);

                    Console.WriteLine($"\n{name}이(가) {evolved.name}(으)로 진화했다!\n");


                    Game.SetupPlayerPokemon(evolved);
                }
            }
        }
    }
}
