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
        public Walls(int mapWidth, int mapHeight) //конструктор класса Стены, который учитывает ширину и высоту и на основе этих данных рисует стены
        {
            wallList = new List<Figure>();
            HorLine upLine = new HorLine(0, mapWidth-2, 3, "+");
            HorLine downLine = new HorLine(0, mapWidth-2, mapHeight-1, "+");
            VerLine leftLine = new VerLine(3, mapHeight-1, 0, "+");
            VerLine rightLine = new VerLine(3, mapHeight-1, mapWidth-2, "+");
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        public void Draw() //метод для рисования стен
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
