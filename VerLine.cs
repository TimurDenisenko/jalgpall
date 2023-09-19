using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    class VerLine : Figure
    {
        public VerLine(int yLeft, int yRight, int x, string sym)
        {
            pList = new List<Point>();
            for (int i = yLeft; i <= yRight; i++)
            {
                Point p = new Point(x, i, sym);
                pList.Add(p);
            }
        }
    }
}
