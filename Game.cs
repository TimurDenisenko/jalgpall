using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Game
    {
        public Team HomeTeam { get; private set; } //Первая команда, представитель класса Team, с параметром получения значения 
        public Team AwayTeam { get; private set;  } //Вторая аналогичная команда
        public Stadium Stadium { get; private set; } //Стадион, представитель класса Stadium, с параметром получения значения
        public Ball Ball { get; private set; } //Мяч, представитель класса Ball, с параметром публичного получения и приватной установки

        public Game(Team homeTeam, Team awayTeam, Stadium stadium) //конструктор игры при обьектах команды и стадион
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }
        public Game() {}

        public void Start() //Запуск игры 
        {
            Stadium.StadiumDraw();
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this); //создаем мяч в центре поля
            HomeTeam.StartGame((Stadium.Width) / 2, Stadium.Height,1); //создаем 1 команду 
            AwayTeam.StartGame(Stadium.Width, Stadium.Height,2); //создаем 2 команду
        }
        private (double, double) GetPositionForAwayTeam(double x, double y)  //получаем позицию второй команды
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        public (double, double) GetPositionForTeam(Team team, double x, double y)  //получаем позицию для команд
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        public void SetBallSpeedForTeam(Team team, double vx, double vy) //устанавливаем скорость мяча для команд
        {
            if (HomeTeam==team)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }

        public void Move() //осуществляем передвижение команд и мяча
        {
            HomeTeam.Move();
            AwayTeam.Move();
            Ball.Move();
            CheckWin();
            Console.SetCursorPosition(0, 0);
            Console.Write("{0}: {1}\n{2}: {3}", HomeTeam.Name, HomeTeam.Win, AwayTeam.Name, AwayTeam.Win);
        }

        public void CheckWin() //проверяем находится ли мяч в зоне победы
        {
            if (Convert.ToInt32(Ball.X) <= 1)
            {
                AwayTeam.Win += 1;
                new Point(Convert.ToInt32(Ball.X), Convert.ToInt32(Ball.Y),"").Clear();
                Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
                Console.Clear();
                new Walls(Stadium.Width, Stadium.Height).Draw();
                Start();
            }
            else if (Convert.ToInt32(Ball.X) >= Stadium.Width-2)
            {
                HomeTeam.Win += 1;
                new Point(Convert.ToInt32(Ball.X), Convert.ToInt32(Ball.Y), "").Clear();
                Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
                Console.Clear();
                new Walls(Stadium.Width, Stadium.Height).Draw();
                Start();
            }
        }

        public Game Setting()
        {
            int width;
            int height;
            while (true)
            {
                try
                {
                    Console.Write("Mänguvälja mõõtmed (Laius): ");
                    width = Int32.Parse(Console.ReadLine());
                    if (width>200 || width<80)
                    {
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Mänguvälja mõõtmed (Kõrgus): ");
                    height = Int32.Parse(Console.ReadLine());
                    if (height>200 || height<20)
                    {
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            Console.SetWindowSize(width, height);
            string t1name="";
            string t2name="";  
            do
            {
                Console.Write("Esimese meeskonna nimi: ");
                t1name = Console.ReadLine();
            } while (t1name.Length==0 || t1name.Length>20);
            do
            {
                Console.Write("Teise meeskonna nimi: ");
                t2name = Console.ReadLine();
            } while (t2name.Length==0 || t2name.Length>20 || t2name==t1name);
            Team t1 = new Team(t1name);
            Team t2 = new Team(t2name);
            int count;
            while (true)
            {
                try
                {
                    Console.WriteLine("Mitu inimest on meeskonnas?");
                    count = Int32.Parse(Console.ReadLine());
                    if (count<1 || count>12)
                    {
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            for (int i = 0; i < count; i++)
            {
                t1.AddPlayer(new Player("", 1));
                t2.AddPlayer(new Player("", 2));
            }
            Stadium stadium = new Stadium(width, height);
            Game game = new Game(t1, t2, stadium);
            HomeTeam = t1;
            AwayTeam = t2;
            Stadium = stadium;
            Console.Clear();
            return game;
        }

        public int Menu()
        {
            Console.Clear();
            int n;
            Console.WriteLine("[1] Taaskäivitage praeguste seadetega\n"
                                  +"[2] Taaskäivitage uute seadetega\n"
                                  +"[3] Lõpetama");
            while (true)
            {
                try
                {
                    n = Int32.Parse(Console.ReadLine());
                    if (n<=0 && n>=4)
                    {
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return n;
        }
    }
}
