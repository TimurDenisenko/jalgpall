using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>(); //список игроков *представители класса Player* с параметром получения
        public string Name { get; private set; } //Название команды с параметром публичного получения и приватной установки значения
        public Game Game { get; set; } //Назначение игры создавая обьект класса Game
        public int Win { get; set; }

        public Team(string name) //конструктор создания команды используя текстовое значение имени
        {
            Name = name;
        }

        public void StartGame(int width, int height, int team) //Начало игры учитывая параметры высоты и ширины 
        {
            Random rnd = new Random();
            foreach (var player in Players) //задаем позицию каждого игрока
            {
                switch (team)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        player.SetPosition(
                        rnd.Next(1, width-1),
                        rnd.Next(4, height-1)
                        );
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        player.SetPosition(
                        rnd.Next(width/2+1, width-2),
                        rnd.Next(4, height-1)
                        );
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AddPlayer(Player player) //Добавляем игрока, представитель класса Player
        {
            if (player.Team != null) return; //если игрок не равен null
            Players.Add(player);
            player.Team = this; //обнуляем значение
        }

        public (double, double) GetBallPosition() //получаем позицию мяча
        {
            return (Game.Ball.X, Game.Ball.Y);
        }

        public void SetBallSpeed(double vx, double vy) //устанаваливаем скорость мяча
        {
            Game.SetBallSpeedForTeam(this, vx, vy); 
        }

        public Player GetClosestPlayerToBall() //ищем ближайшего игрока к мячу
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance) //ищем этого игрока
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        public void Move() //передвигаем ближайшего игрока к мячу
        {
            GetClosestPlayerToBall().MoveTowardsBall(); 
            Players.ForEach(player => player.Move());
        }

        public void AddWin() //прибавляем победу к команде
        {
            Win+=1;
        }
    }
}
