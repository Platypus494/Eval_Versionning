using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEditor.FilePathAttribute;

namespace TU_Challenge
{
    public class Pathfinding
    {
        public Pathfinding(string map1)
        {
            int currentLign=0;
            int currentColumn = 0;
            foreach (char c in map1)
            {
                if(c=='_' || c == 'X')
                {
                    currentColumn++;
                }else
                {
                    if (c == '\n')
                    {
                        currentLign++;
                        currentColumn = 0;
                    }
                }
            }
            Grid = new char[currentLign+1,currentColumn];
            currentLign = 0;
            currentColumn = 0;
            foreach (char c in map1)
            {
                if (c == '_' || c == 'X')
                {
                    Grid[currentLign,currentColumn] = c;
                    currentColumn++;
                }
                else
                {
                    if (c == '\n')
                    {
                        currentLign++;
                        currentColumn = 0;
                    }
                }
            }
        }

        public char[,] Grid { get; internal set; }

        internal Path BreadthFirstSearch(Vector2 start, Vector2 destination)
        {
            Vector2 current = start;
            Path path = new Path(start);
            List<Vector2> visited = new List<Vector2>();
            List<Vector2> queue = new List<Vector2>();
            while (current != destination) {
                if (current != start)
                {
                    path = new Path(path, current);
                }
                visited.Add(current);
                foreach (Vector2 v in GetN(current)) {
                    if (!visited.Contains(v))
                    {
                        queue.Add(v);
                    }
                }
                if (queue.Count != 0)
                {
                    current = queue[0];
                }else
                {
                    return path;
                }
                queue.Remove(current);
                queue.RemoveAll(v => visited.Contains(v));
            }
            path = new Path(path, current);
            return path;
        }

        internal char GetCoord(Vector2 el)
        {
            return Grid[el.X, el.Y];
            throw new NotImplementedException();
        }

        internal List<char> GetNeighboors(Vector2 vector2)
        {
            List<char> list= new List<char>();
            List<Vector2> directions = new List<Vector2>();
            directions.Add(new Vector2(-1,-1));
            directions.Add(new Vector2(-1, 1));
            directions.Add(new Vector2(-1, 0));
            directions.Add(new Vector2(1, -1));
            directions.Add(new Vector2(1, 0));
            directions.Add(new Vector2(1, 1));
            directions.Add(new Vector2(0, -1));
            directions.Add(new Vector2(0, 1));

            foreach(Vector2 direction in directions)
            {
                if (!IsOutOfBound(direction + vector2))
                {
                    if (Grid[direction.X + vector2.X, direction.Y + vector2.Y] != 'X')
                    {
                        list.Add(Grid[direction.X + vector2.X, direction.Y + vector2.Y]);
                    }
                }
            }
            return list;

            throw new NotImplementedException();
        }

        internal List<Vector2> GetN(Vector2 vector2)
        {
            List<Vector2> list = new List<Vector2>();
            List<Vector2> directions = new List<Vector2>();
            directions.Add(new Vector2(-1, -1));
            directions.Add(new Vector2(-1, 1));
            directions.Add(new Vector2(-1, 0));
            directions.Add(new Vector2(1, -1));
            directions.Add(new Vector2(1, 0));
            directions.Add(new Vector2(1, 1));
            directions.Add(new Vector2(0, -1));
            directions.Add(new Vector2(0, 1));

            foreach (Vector2 direction in directions)
            {
                if (!IsOutOfBound(direction + vector2))
                {
                    if (Grid[direction.X + vector2.X, direction.Y + vector2.Y] != 'X')
                    {
                        list.Add(vector2+direction);
                    }
                }
            }
            return list;

            throw new NotImplementedException();
        }

        internal List<char> GetNeighboors(Vector2 vector2, List<Vector2> exclude)
        {
            List<char> list = new List<char>();
            List<Vector2> directions = new List<Vector2>();
            directions.Add(new Vector2(-1, -1));
            directions.Add(new Vector2(-1, 1));
            directions.Add(new Vector2(-1, 0));
            directions.Add(new Vector2(1, -1));
            directions.Add(new Vector2(1, 0));
            directions.Add(new Vector2(1, 1));
            directions.Add(new Vector2(0, -1));
            directions.Add(new Vector2(0, 1));

            foreach (Vector2 direction in directions)
            {
                if (!IsOutOfBound(direction + vector2))
                {
                    if (Grid[direction.X + vector2.X, direction.Y + vector2.Y] != 'X' && !exclude.Contains(direction+vector2))
                    {
                        list.Add(Grid[direction.X + vector2.X, direction.Y + vector2.Y]);
                    }
                }
            }
            return list;
        }

        internal bool IsOutOfBound(Vector2 vector2)
        {
            int lenght = Grid.GetLength(0);
            if (vector2.X >= Grid.GetLength(0) || vector2.Y >=Grid.GetLength(1) ||vector2.X <0 || vector2.Y<0)
            {
                return true;
            }
            return false;
            throw new NotImplementedException();
        }
    }

}
