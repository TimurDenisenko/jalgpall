using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Figure
    {
        protected List<Point> pList;
        public void Draw() //функция для рисования точек из списка точек
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Point p in pList)
            {
                p.Draw();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
