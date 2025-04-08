using OOPConsoleProject.Managers;
using OOPConsoleProject.PokemonData;
using OOPConsoleProject.Scenes;
using System.Drawing;

namespace OOPConsoleProject
{

    public class Game
    {
        public static Pokemon playerPokemon {  get; private set; }
        public static Pokemon enemyPokemon;
        public static Pokemon[] SP = { PokeManager.Instance.SetupPokemon(1), PokeManager.Instance.SetupPokemon(2), PokeManager.Instance.SetupPokemon(3) };
        public static Scene curScene;
        public static int stageCount = 0;
        public static int itemCount = 3;

        public static bool gameOver = false;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SceneManager.Instance.ChangeScene("타이틀");

            Run();
        }
        public static void Run()
        {
            Start();

            while (gameOver == false)
            {
                Console.Clear();
                curScene.RenderScene();
                curScene.Input();
                Console.WriteLine();
                curScene.Update();
                Console.WriteLine();
                curScene.Result();
            }

            End();
        }

        public static void Start() // 스타팅 포켓몬 레벨 선택
        {
            for (int i = 0; i < SP.Length; i++)
            {
                SP[i].SetLevel(5);
            }
        }

        public static void End()
        {
            stageCount = 0;
            itemCount = 0;
        }

        public static void SetupPlayerPokemon(Pokemon pokemon) => playerPokemon = pokemon;
        public static void SetupEnemyPokemon(Pokemon pokemon) => enemyPokemon = pokemon;
    }
}
