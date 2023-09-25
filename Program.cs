using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(80, 20);
                Console.SetBufferSize(600, 400);
                Team t1 = new Team("1T");
                Team t2 = new Team("2T");
                for (int i = 0; i < 11; i++)
                {
                    t1.AddPlayer(new Player("" + i, 1));
                }
                for (int i = 0; i < 11; i++)
                {
                    t2.AddPlayer(new Player("" + (i + 10), 2));
                }
                Stadium stadium = new Stadium(80, 20);
                Game game = new Game(t1, t2, stadium);
                t1.Game = game;
                t2.Game = game;
                game.Start();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                while (keyInfo.Key != ConsoleKey.R)
                {
                    keyInfo = Console.ReadKey();
                    game.Move();
                }
            }
        }
    }
}