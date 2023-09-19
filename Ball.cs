using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Ball
    {
        public double X { get; private set; } //координата х, с публичным параметром получения и приватный параметр установки
        public double Y { get; private set; } //координата у с аналогичным описанием

        private double _vx, _vy; //приватная переменная координат мяча

        private Game _game; //создаем приватный обьект игра класса Game

        public Ball(int x, int y, Game game) //конструктор который учитывает параметры координат и обьекта игры
        {
            _game = game;
            X = x;
            Y = y;
            new Point(x, y,"*").Draw();
        }

        public void SetSpeed(double vx, double vy) //устанавливаем скорость мяча
        {
            _vx = vx;
            _vy = vy;
        }

        public void Move() //передвижение мяча
        {
            double newX = X + _vx;
            double newY = Y + _vy;
            if (_game.Stadium.IsIn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = 0;
                _vy = 0;
            }
        }

    }
}
