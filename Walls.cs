using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorLine upLine = new HorLine(0, mapWidth-2, 2, "+");
            HorLine downLine = new HorLine(0, mapWidth-2, mapHeight-1, "+");
            VerLine leftLine = new VerLine(2, mapHeight-1, 0, "+");
            VerLine rightLine = new VerLine(2, mapHeight-1, mapWidth-2, "+");
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
