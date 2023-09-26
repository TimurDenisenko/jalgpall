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
        private Walls Walls { get; set; }

        public Stadium(int width, int height) //конструктор который учитывает лишь ширину и высоту
        {
            Width = width;
            Height = height;
            Walls = new Walls(width, height);
        }

        public bool IsIn(double x, double y) //возвращает правду или ложь в зависимости от того находится мяч на поле или вне поля
        {
            return x >= 0 && x < Width && y >= 4 && y < Height-2;
        }

        public void StadiumDraw()
        { 
            Walls.Draw();
        }
    }
}
