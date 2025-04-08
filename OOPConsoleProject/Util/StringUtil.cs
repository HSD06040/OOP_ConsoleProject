using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Util
{
    public static class StringUtil
    {
        private static Dictionary<string, KeyValuePair<string, string>> koreanParticles = new Dictionary<string, KeyValuePair<string, string>>
        {
            { "을/를", new KeyValuePair<string, string>("을", "를") },
            { "이/가", new KeyValuePair<string, string>("이", "가") },
            { "은/는", new KeyValuePair<string, string>("은", "는") },
        };

        public static string KoreanParticle(string text)
        {
            foreach (var particle in koreanParticles)
            {
                var index = text.IndexOf(particle.Key) - 1;
                while (index >= 0)
                {
                    var word = (text[index] - 0xAC00) % 28 > 0 ? particle.Value.Key : particle.Value.Value;
                    text = text.Remove(index + 1, particle.Key.Length).Insert(index + 1, word);
                    index = text.IndexOf(particle.Key) - 1;
                }
            }

            return text;
        }
        public static string TypeKorean(Type type)
        {
            switch (type)
            {
                case Type.Normal:
                    return "노멀";
                case Type.Fire:
                    return "불";
                case Type.Grass:
                    return "풀";
                case Type.Water:
                    return "물";
                default:
                    return "노멀";
            }
        }
    }
}
