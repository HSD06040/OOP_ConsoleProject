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

        public static int[] GetDifficultyByStage(int stageCount)
        {
            if (stageCount >= 50) return stagePokemonByDifficulty["어려움"];
            if (stageCount >= 25) return stagePokemonByDifficulty["보통"];
            return stagePokemonByDifficulty["쉬움"];
        }
    }
}
