using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Game
    {
        public Team HomeTeam { get; } //Первая команда, представитель класса Team, с параметром получения значения 
        public Team AwayTeam { get; } //Вторая аналогичная команда
        public Stadium Stadium { get; } //Стадион, представитель класса Stadium, с параметром получения значения
        public Ball Ball { get; private set; } //Мяч, представитель класса Ball, с параметром публичного получения и приватной установки

        public Game(Team homeTeam, Team awayTeam, Stadium stadium) //конструктор игры при обьектах команды и стадион
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }

        public void Start() //Запуск игры 
        {
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

        public (double, double) GetBallPositionForTeam(Team team) //получаем позицию мяча для команд
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        public void SetBallSpeedForTeam(Team team, double vx, double vy) //устанавливаем скорость мяча для команд
        {
            if (team == HomeTeam)
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
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(HomeTeam.GetBallPosition());
            AwayTeam.Move();
            Console.SetCursorPosition(0, 21);
            Console.WriteLine(AwayTeam.GetBallPosition());
            Ball.Move();
        }
    }
}
