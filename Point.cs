using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Point
    {
        public int x;
        public int y;
        public string sym;

        public Point(int _x, int _y, string _sym) //конструктор класса Точка, который учитывает значения по горизонтали, вертикали и символа
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void Draw() //Метод для рисования Точек
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }

        public void Clear() //Очищение точки
        {
            sym = " ";
            Draw();
        }

        public virtual void DrawList(List<Point> pList) //метод для рисования списка обьектов класса Точка
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

    }
}
