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
                Console.WriteLine($"{i+1} : {skills[i].name,6} / 타입 : {StringUtil.TypeKorean(skills[i].type),2}, 위력 : {skills[i].skillPower,3}, 명중률 : {skills[i].chance,3}\n");
            }
            Console.WriteLine("=============================================================\n");
        }
    }
}
