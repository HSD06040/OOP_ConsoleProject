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

        public static void PrintSlow(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static string TypeKorean(Type type)
        {
            switch (type)
            {
                case Type.Normal:
                    return "노말";
                case Type.Fire:
                    return "불";
                case Type.Grass:
                    return "풀";
                case Type.Water:
                    return "물";
                default:
                    return "노말";
            }
        }
        public static ConsoleColor TypeColor(Type type)
        {
            return type switch
            {
                Type.Normal => ConsoleColor.White,
                Type.Fire => ConsoleColor.Red,
                Type.Grass => ConsoleColor.Green,
                Type.Water => ConsoleColor.Blue,
                _ => ConsoleColor.White
            };
        }
        public static int GetDisplayWidth(string text)
        {
            int width = 0;
            foreach (char c in text)
            {
                // 한글 유니코드 블록: 0xAC00 ~ 0xD7A3
                width += (c >= 0xAC00 && c <= 0xD7A3) ? 2 : 1;
            }
            return width;
        }

        public static string PadRightDisplay(string text, int totalDisplayWidth)
        {
            int currentWidth = GetDisplayWidth(text);
            int paddingNeeded = totalDisplayWidth - currentWidth;
            return text + new string(' ', Math.Max(0, paddingNeeded));
        }

        public static string GetConsoleColorCodeByType(Type type)
        {
            return type switch
            {
                Type.Fire => "\x1b[91m",    
                Type.Water => "\x1b[94m",   
                Type.Grass => "\x1b[92m",   
                //Type.Electric => "\x1b[33m",
                //Type.Ice => "\x1b[36m",     
                //Type.Fighting => "\x1b[91m",
                //Type.Psychic => "\x1b[35m", 
                //Type.Dragon => "\x1b[95m",  
                //Type.Fairy => "\x1b[95m",   
                _ => "\x1b[37m",            
            };
        }
        public static string ColorText(string text, ConsoleColor color)
        {
            string ansiCode = color switch
            {
                ConsoleColor.Black => "\x1b[30m",
                ConsoleColor.DarkBlue => "\x1b[34m",
                ConsoleColor.DarkGreen => "\x1b[32m",
                ConsoleColor.DarkCyan => "\x1b[36m",
                ConsoleColor.DarkRed => "\x1b[31m",
                ConsoleColor.DarkMagenta => "\x1b[35m",
                ConsoleColor.DarkYellow => "\x1b[33m",
                ConsoleColor.Gray => "\x1b[37m",
                ConsoleColor.DarkGray => "\x1b[90m",
                ConsoleColor.Blue => "\x1b[94m",
                ConsoleColor.Green => "\x1b[92m",
                ConsoleColor.Cyan => "\x1b[96m",
                ConsoleColor.Red => "\x1b[91m",
                ConsoleColor.Magenta => "\x1b[95m",
                ConsoleColor.Yellow => "\x1b[93m",
                ConsoleColor.White => "\x1b[97m",
                _ => "\x1b[0m"
            };

            return $"{ansiCode}{text}\x1b[0m";
        }
    }
}
