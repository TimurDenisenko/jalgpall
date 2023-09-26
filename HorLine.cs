using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    class HorLine : Figure
    {
        public HorLine(int xLeft, int xRight, int y, string sym) //Конструктор для рисования горизонтальной линии
        {
            pList = new List<Point>();
            for (int i = xLeft; i <= xRight; i++)
            {
                Point p = new Point(i, y, sym);
                pList.Add(p);
            }
        }
    }
}
