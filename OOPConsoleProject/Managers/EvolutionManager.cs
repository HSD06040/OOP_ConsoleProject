using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Managers
{
    public static class EvolutionManager
    {
        private static readonly Dictionary<int, EvolutionData> evolutionTable = new Dictionary<int, EvolutionData>
        {
            {1, new EvolutionData(2,6) }, {2, new EvolutionData(3,32) }, // 이상해씨 라인
            {4, new EvolutionData(5,16) }, {5, new EvolutionData(6,36) }, // 파이리 라인
            {7, new EvolutionData(8,16) }, {8, new EvolutionData(9,36) }, // 거북왕 라인
        };

        public static bool TryGetEvolution(int fromDex, out EvolutionData data)
        {
            return evolutionTable.TryGetValue(fromDex, out data);
        }
    }
}
