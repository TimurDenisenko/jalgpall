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
            int n=0;
            while (n!=3)
            {
                Console.SetBufferSize(600, 400);
                Game game = new Game().Setting();
                while (true)
                {
                    n = game.Menu();
                    if (n==1)
                    { 
                        game.NullWin();
                    }
                    else if (n==2 || n==3)
                    {
                        break;
                    }
                    Console.Clear();
                    game.Start();
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.R)
                    {
                        game.Move();
                        keyInfo = Console.ReadKey();
                    }
                }
            }
        }
    }
}