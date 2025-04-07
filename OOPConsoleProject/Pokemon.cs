using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPConsoleProject
{
    public class Pokemon
    {
        Random random = new Random();
        public string name { get; private set; }  
        public int id { get; private set; }
        public string[,] pixelData { get; private set; }

        public Stat stat { get; private set; }
        public Skill[] skills { get; private set; } = new Skill[4];

        public Pokemon(string name,int id,int hp, int damage, int defense, int speed) 
        {
            stat = new Stat(hp, damage, defense, speed);
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

        public void SetupPixelData()
        {
            pixelData = PokeManager.Instance.pixels[id];
        }
    }
}
