using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Game
    {
        bool _continues;

        public Game()
        {
            this.SetContinues(true);        // Game continues as long this is true
        }

        public void handler(Game game, User user, Hole hole)
        {
            Console.Write("Welcome to Awesome Golf Game!\nThis course has only one hole.\nPlease register by entering your name: ");
            user.GetNameFromConsole(user);
            hole.GetDifficultyFromConsole();
            hole.GenerateHole();
            Console.WriteLine("Welcome " + user.Name + "!\nYour hole has length " + hole.Length + " and par " + hole.Par);
            Console.WriteLine("You have " + hole.SwingsAllowed + " swings to try to get the ball in the cup.");
            hole.StartSwinging();
            Console.WriteLine("Thank you for playing Awesome Golf Game. Have a nice day!");
            Console.ReadKey();
            this.SetContinues(false);       // exits game
        }

        // GETTERS & SETTERS
        public bool Continues()
        {
            return _continues;
        }
        public void SetContinues(bool Continues)
        {
            this._continues = Continues;
        }

    }
}
