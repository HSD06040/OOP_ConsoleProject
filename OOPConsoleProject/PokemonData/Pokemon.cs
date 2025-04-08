using OOPConsoleProject.Managers;
using OOPConsoleProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPConsoleProject.PokemonData
{
    public class Pokemon
    {
        Random random = new Random();
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

        public void SetLevel(int level) => stat.SetLevel(level);

        public void SetupSkills()
        {
            var allSkillIds = PokeManager.Instance.skills.Keys.ToList();
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
        }

        public void SetupPixelData(string[,] pixels)
        {
            pixelData = pixels;
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

                    Console.Clear();

                    Console.Write($"\n어랏? {name}의 모습이?\n");
                    Console.Write("."); Thread.Sleep(delay); Console.Write("."); Thread.Sleep(delay); Console.Write(".\n"); Thread.Sleep(delay);
                    Console.WriteLine($"{name}이(가) {evolved.name}(으)로 진화했다!\n");

                    Game.SetupPlayerPokemon(evolved);
                }
            }
        }
    }
}
