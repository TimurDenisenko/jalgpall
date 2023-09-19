﻿using System;
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
                Console.SetWindowSize(80, 20);
                Console.SetBufferSize(600, 400);
                Team t1 = new Team("1T");
                Team t2 = new Team("2T");
                for (int i = 0; i < 1; i++)
                {
                    t1.AddPlayer(new Player(""+i));
                }
                for (int i = 0; i < 1; i++)
                {
                    t2.AddPlayer(new Player(""+(i+10)));
                }
                Stadium stadium = new Stadium(80, 20);
                Game game = new Game(t1, t2, stadium);
                game.Start();
                game.Move();
                Console.ReadLine();
            }
        }
    }
}