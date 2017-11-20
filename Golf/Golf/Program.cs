using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            //git test
            Game game = new Game();
            Hole hole = new Hole();
            User user = new User();
            while (game.Continues())
            {
                game.handler(game, user, hole);
            }
        }
    }
}
