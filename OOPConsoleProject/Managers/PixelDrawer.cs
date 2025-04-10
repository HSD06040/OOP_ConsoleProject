using System.Drawing;
using System.Text;

namespace OOPConsoleProject.Managers
{
    public class PixelDrawer
    {
        private static string[,] effects =
        {
            {"","","","","a","a","a","a","","","","", },
            {"","","a","a","","","","","a","a","","", },
            {"","a","","","b","b","b","b","","","a","", },
            {"","a","","b","","","","","b","","a","", },
            {"a","","b","","","b","b","","","b","","a", },
            {"a","","b","","b","a","a","b","","b","","a", },
            {"a","","b","","b","a","a","b","","b","","a", },
            {"a","","b","","","b","b","","","b","","a", },
            {"","a","","b","","","","","b","","a","", },
            {"","a","","","b","b","b","b","","","a","", },
            {"","","a","a","","","","","a","a","","", },
            {"","","","","a","a","a","a","","","","", }, 
        };

        //static void Main()
        //{
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;

        //    //AttckEffect(Type.Fire);

        //    string name = "몬스터볼";
        //    string[,] matrix = ConvertImageToSymbolMatrix(name);

        //    //SaveMatrixToText(matrix, name);

        //    DrawPokemon(PixelLoader(name), 1, 1);
        //}
        public static string[,] PixelLoader(string fileName)
        {
            string filePath = $"PixelData/txt/{fileName}.txt";
            var lines = File.ReadAllLines(filePath);

            int rows = lines.Length;            // 행
            int cols = lines[0].Length;         // 열

            string[,] pixel = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    pixel[y, x] = lines[y][x].ToString();
                }
            }

            return pixel;
        }
        
        static string[,] ConvertImageToSymbolMatrix(string name)
        {
            string path = $"PixelData/png/{name}.png";
            Bitmap bmp = new Bitmap(path);
            int width = bmp.Width;
            int height = bmp.Height;

            string[,] matrix = new string[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    if (IsWhite(pixel))
                        matrix[y, x] = "e"; // empty
                    else if (IsDarkCyan(pixel))
                        matrix[y, x] = "v"; // darkCyan
                    else if (IsMagenta(pixel))
                        matrix[y, x] = "m"; // darkRed 
                    else if (IsRed(pixel))
                        matrix[y, x] = "r"; // red
                    else if (IsDarkRed(pixel))
                        matrix[y, x] = "k"; // darkRed 
                    else if (IsBlack(pixel))
                        matrix[y, x] = "w"; // w = white <- 테두리
                    else if (IsDarkYellow(pixel))
                        matrix[y, x] = "h"; // DarkYellow
                    else if (IsYellow(pixel))
                        matrix[y, x] = "y"; // yellow
                    else if (IsGreen(pixel))
                        matrix[y, x] = "g"; // green
                    else if (IsDarkGray(pixel))
                        matrix[y, x] = "a"; // darkGray
                    else if (IsDarkGreen(pixel))
                        matrix[y, x] = "z"; // darkGreen             
                    else if (IsBlue(pixel))
                        matrix[y, x] = "b"; // blue
                    else if (IsCyan(pixel))
                        matrix[y, x] = "c"; // cyan
                    
                    else if (IsGray(pixel))
                        matrix[y, x] = "j"; // DarkYellow
                    else
                        matrix[y, x] = "x"; // unknown
                }
            }

            return matrix;
        }
        
        private static void DrawText(string text)
        {
            switch (text)
            {
                case "k":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "r":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "g":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "b":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "w":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "y":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "j":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;     
                case "a":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "z":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "h":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "c":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "v":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "m":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "n":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "e":
                    Console.Write("  ");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            Console.Write("██");
            Console.ResetColor();
        }

        static void SaveMatrixToText(string[,] matrix, string name)
        {
            string path = $"PixelData/txt/{name}.txt";
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    sb.Append(matrix[y, x]);
                }
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString());
        }

        public static void DrawPokemon(string[,] pokemon, int xDistance, int yDistance)
        {
            int rows = pokemon.GetLength(0);
            int cols = pokemon.GetLength(1);

            string[,] pokePixel = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    pokePixel[y, x] = pokemon[y, x];
                }
            }

            for (int y = 0; y < rows; y++)
            {
                Console.SetCursorPosition(xDistance, yDistance + y);
                for (int x = 0; x < cols; x++)
                {
                    DrawText(pokePixel[y, x]);
                }
                Console.WriteLine();
            }
        }
        public static string[,] FlipPokemonHorizontal(string[,] pokemon)
        {
            int rows = pokemon.GetLength(0);
            int cols = pokemon.GetLength(1);
            string[,] flipped = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    flipped[y, x] = pokemon[y, cols - 1 - x];
                }
            }

            return flipped;
        }

        public static void PrintEffect(Type type, int xDis, int yDis)
        {
            ConsoleColor color1, color2;

            switch(type)
            {
                case Type.Normal:
                    color1 = ConsoleColor.DarkGray;
                    color2 = ConsoleColor.White;
                    break;
                case Type.Grass:
                    color1 = ConsoleColor.DarkGreen;
                    color2 = ConsoleColor.Green;
                    break;
                case Type.Fire:
                    color1 = ConsoleColor.DarkRed;
                    color2 = ConsoleColor.Red;
                    break;
                case Type.Water:
                    color1 = ConsoleColor.DarkCyan;
                    color2 = ConsoleColor.Cyan;
                    break;
                default:
                    color1 = ConsoleColor.Gray;
                    color2 = ConsoleColor.White;
                    break;
            }

            for (int y = 0; y < effects.GetLength(0); y++)
            {
                Console.SetCursorPosition(xDis, y+ yDis);
                for (int x = 0; x < effects.GetLength(1); x++)
                {            
                    switch(effects[y, x])
                    {
                        case "a":
                            Console.ForegroundColor = color1;
                            Console.Write("██");
                            break;
                        case "b":
                            Console.ForegroundColor = color2;
                            Console.Write("██");
                            break;
                        default:
                            Console.Write("  ");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();

            Thread.Sleep(1);

            for (int y = 0; y < effects.GetLength(0); y++)
            {
                Console.SetCursorPosition(xDis, y + yDis);
                for (int x = 0; x < effects.GetLength(1); x++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }

        public static void AttckEffect(Type type)
        {
            for (int i = 0; i < 50; i++)
            {
                PrintEffect(type,15+i,7);
            }
        }

        #region IsColor
        static bool IsWhite(Color c)        => c.R > 240 && c.G > 240 && c.B > 240;
        static bool IsRed(Color c)          => c.R > 150 && c.G > 50 && c.B < 160 && c.G < 145; 
        static bool IsDarkRed(Color c)      => c.R > 170 && c.G > 50 && c.B < 90 && c.G < 120;
        static bool IsYellow(Color c)       => c.R > 200 && c.G > 125 && c.B < 200;
        static bool IsDarkYellow(Color c)   => c.R > 170 && c.G > 120 && c.B < 133 && c.R < 220;
        static bool IsGreen(Color c)        => c.R < 120 && c.G > 150 && c.B < 120;
        static bool IsDarkGreen(Color c)    => c.R < 120 && c.G > 80 && c.B < 120;
        static bool IsBlue(Color c)         => c.B > 180 && c.R < 100 && c.G < 100;
        static bool IsCyan(Color c)         => c.R < 150 && c.G > 160 && c.B > 164;
        static bool IsDarkCyan(Color c)     => (c.R > 50 && c.G > 89 && c.B > 105 && c.R < 100 && c.G < 160 && c.B < 207);
        static bool IsBlack(Color c)        => c.R < 50 && c.G < 50 && c.B < 50;
        static bool IsDarkGray(Color c)     => c.R < 90 && c.G < 90 && c.B < 90;
        static bool IsGray(Color c)         => c.R < 190 && c.G < 190 && c.B < 190;
        static bool IsMagenta(Color c)      => c.R < 190 && c.G < 150 && c.B > 190;

        #endregion
    }
}
