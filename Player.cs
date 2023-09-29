using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Player
    {
        //поля
        public string Name { get; } //имя игрока 
        public double X { get; private set; } //х координата
        public double Y { get; private set; } //у координата
        private double _vx, _vy; //расстояние игрока и мяча
        public Team? Team { get; set; } = null; //команда где играет игрок

        private const double MaxSpeed = 1; //максимальная скрость игрока
        private const double MaxKickSpeed = 5; //максимальная скорость удара
        private const double BallKickDistance = 2; //дистанция удара меча

        private Random _random = new Random(); //рандомное число
        private int TeamInt;

        //конструкторы
        public Player(string name, int teamInt)   //конструктор создания игрока используя только имя
        {
            Name = name;
            TeamInt = teamInt;
        }

        public Player(string name, int x, int y, Team team, int teamInt) // конструктор создания игрока используя имя, координаты и команду
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
            TeamInt = teamInt;  
        }

        public void SetPosition(int x, int y)  //установка координатов игрока
        {
            X = x;
            Y = y;
            new Point(x, y, "I").Draw();
        }

        public (double, double) GetAbsolutePosition()  //получение абсолютной позиции
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        public double GetDistanceToBall() //получение дистанции до мяча
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void MoveTowardsBall() //передвижение игрока к мячу
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        public void Move() //передвижение игрока
        {
            if (Team.GetClosestPlayerToBall() != this) //если не определенно
            {
                _vx = 0;
                _vy = 0;
            }

            if (GetDistanceToBall() < BallKickDistance) //если дистанция мяча меньше дистанции удара мяча
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                    ); //устанавливаем скорость мяча
            }

            var newX = X + _vx; //установка  новых координат и абсолютной позиции
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2)) //проверяем находится ли мяч на поле или нет и устанавливаем координаты
            {
                
                if (newX != X || newY != Y)
                {
                    new Point(Convert.ToInt32(X), Convert.ToInt32(Y), "").Clear();
                }
                X = newX;
                Y = newY;
                switch (TeamInt)
                {
                    case 1:
                        Console.ForegroundColor = Team.Color;
                        SetPosition(Convert.ToInt32(X), Convert.ToInt32(Y));
                        break;
                    case 2:
                        Console.ForegroundColor = Team.Color;
                        SetPosition(Convert.ToInt32(X), Convert.ToInt32(Y));
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                _vx = _vy = 0;
            }
        }
    }
}
