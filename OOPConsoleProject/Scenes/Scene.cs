using OOPConsoleProject.PokemonData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public abstract class Scene
    {
        protected ConsoleKey input;
        protected Pokemon playerPokemon => Game.playerPokemon;
        protected Pokemon enemyPokemon  => Game.enemyPokemon;
        protected Random random = new Random();
        public abstract void RenderScene();
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        protected bool InputBool(ConsoleKey inputKey,ConsoleKey startKey, ConsoleKey endKey)
        {
            return inputKey >= startKey && inputKey <= endKey;
        }
        public abstract void Update();

        public abstract void Result();
    }
}
