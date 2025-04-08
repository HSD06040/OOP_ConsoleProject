using System.Drawing;
using System.Text;

namespace OOPConsoleProject.Managers
{
    public class PixelDrawer
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[,] matrix = ConvertImageToSymbolMatrix("PixelData/파이리.png");

            SaveMatrixToText(matrix, "파이리.txt");
            Console.WriteLine("텍스트 파일 저장 완료!");

            DrawPokemon(matrix,1,1);
        }

        static string[,] ConvertImageToSymbolMatrix(string imagePath)
        {
            Bitmap bmp = new Bitmap(imagePath);
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
                    else if (IsBlack(pixel))
                        matrix[y, x] = "w"; // w = white <- 테두리
                    else if (IsRed(pixel))
                        matrix[y, x] = "r"; // red
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
                    else
                        matrix[y, x] = "x"; // unknown
                }
            }

            return matrix;
        }
        
        private void DrawText(string text)
        {
            switch (text)
            {
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
                case "a":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "z":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

        static void SaveMatrixToText(string[,] matrix, string filePath)
        {
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

            File.WriteAllText(filePath, sb.ToString());
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

        static bool IsWhite(Color c) => c.R > 240 && c.G > 240 && c.B > 240;
        static bool IsRed(Color c) => c.R > 170 && c.G > 50 && c.G < 180 && c.B < 150;
        static bool IsYellow(Color c) => c.R > 200 && c.G > 185 && c.B < 160;
        static bool IsGreen(Color c) => c.R < 120 && c.G > 150 && c.B < 120;
        static bool IsDarkGreen(Color c) => c.R < 120 && c.G > 80 && c.B < 120;
        static bool IsBlue(Color c) => c.B > 180 && c.R < 100 && c.G < 100;
        static bool IsBlack(Color c) => c.R < 50 && c.G < 50 && c.B < 50;
        static bool IsDarkGray(Color c) => c.R < 90 && c.G < 90 && c.B < 90;
    }
}
