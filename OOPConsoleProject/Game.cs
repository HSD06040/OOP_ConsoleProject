namespace OOPConsoleProject
{
    public class Game
    {
        static void Main(string[] args)
        {
            Pokemon[] startingPokemon = { PokeManager.Instance.SetupPokemon(1), PokeManager.Instance.SetupPokemon(2), PokeManager.Instance.SetupPokemon(3) };

            Pokemon myPokemon;

            Console.WriteLine($"{startingPokemon[1].name} 은/는 \n" +
                $"{startingPokemon[1].skills[0].name}\n," +
                $"{startingPokemon[1].skills[1].name}\n," +
                $"{startingPokemon[1].skills[2].name}\n," +
                $"{startingPokemon[1].skills[3].name}\n");
            Console.WriteLine($"{startingPokemon[2].name} 은/는 \n" +
                $"{startingPokemon[2].skills[0].name}\n," +
                $"{startingPokemon[2].skills[1].name}\n," +
                $"{startingPokemon[2].skills[2].name}\n," +
                $"{startingPokemon[2].skills[3].name}\n");
            Console.WriteLine($"{startingPokemon[0].name} 은/는 \n" +
                $"{startingPokemon[0].skills[0].name}\n," +
                $"{startingPokemon[0].skills[1].name}\n," +
                $"{startingPokemon[0].skills[2].name}\n," +
                $"{startingPokemon[0].skills[3].name}\n");
        }


    }
}
