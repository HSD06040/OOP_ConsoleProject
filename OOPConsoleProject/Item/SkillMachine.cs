using OOPConsoleProject.Managers;
using OOPConsoleProject.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public class SkillMachine : ItemBase
    {
        private Skill skill;
        public SkillMachine(Skill skill,string name, string description) : base(name, description)
        {
            this.skill = skill;
        }

        public override void Use()
        {
            SceneManager.Instance.SkillLearning(skill);
        }
    }
}
