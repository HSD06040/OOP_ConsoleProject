using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Managers
{
    public static class StageManager
    {
        private static Dictionary<string, int[]> stagePokemonByDifficulty = new Dictionary<string, int[]>
        {
            {"쉬움"   , new int[] {1,4,7,12,16,18,22,25,28} },
            {"보통"   , new int[] {2,5,8,10,14,13,20,23,27,29,30,31,17} },
            {"어려움" , new int[] {3,6,9,11,15,17,19,21,24,26,27,31,13,20} }
        };

        public static int[] GetDifficultyByStage()
        {
            if (IsHard()) return stagePokemonByDifficulty["어려움"];
            if (IsNormal()) return stagePokemonByDifficulty["보통"];
            return stagePokemonByDifficulty["쉬움"];
        }
        public static List<int> GetDifficultyByStageSkill()
        {
            List<int> skills = new List<int>();

            foreach(var data in PokeManager.Instance.skills)
            {
                if(data.Value.skillPower <= 70 && IsEasy())
                {
                    skills.Add(data.Key);
                }

                if (data.Value.skillPower <= 90 && IsNormal())
                {
                    skills.Add(data.Key);
                }

                if (IsHard())
                {
                    skills.Add(data.Key);
                }
            }

            return skills;
        }

        public static void StageItemCount()
        {
            if (Game.stageCount != 0 && Game.stageCount % 10 == 0)
                Game.AddItemCount();
        }

        static bool IsHard() => Game.stageCount >= 50;
        static bool IsNormal() => Game.stageCount >= 25;
        static bool IsEasy() => Game.stageCount < 25;
    }
}
