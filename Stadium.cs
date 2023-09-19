using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Stadium : Figure
    {
        public int Width { get; } //ширина с параметром получения
        public int Height { get; } //высота с параметром получения

        public Stadium(int width, int height) //конструктор который учитывает лишь ширину и высоту
        {
            Width = width;
            Height = height;
            Walls walls = new Walls(width, height);
            walls.Draw();
        }

        public bool IsIn(double x, double y) //возвращает правду или ложь в зависимости от того находится мяч на поле или вне поля
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
