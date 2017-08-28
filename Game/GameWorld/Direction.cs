using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    public class Direction
    {
        private static List<Direction> All { get; } = new List<Direction>();

        public static readonly Direction NORTH = new Direction("north", 0, 1, 0);
        public static readonly Direction SOUTH = new Direction("south", 0, -1, 0);
        public static readonly Direction EAST = new Direction("east", 1, 0, 0);
        public static readonly Direction WEST = new Direction("west", -1, 0, 0);
        public static readonly Direction UP = new Direction("up", 0, 0, 1);
        public static readonly Direction DOWN = new Direction("down", 0, 0, -1);

        public string Name { get; private set; }
        public int DifX { get; private set; }
        public int DifY { get; private set; }
        public int DifZ { get; private set; }
        private Direction(string name, int difX, int difY, int difZ)
        {
            this.Name = name;
            this.DifX = difX;
            this.DifY = difY;
            this.DifZ = difZ;

            All.Add(this);
        }

        public static Vector GetVectorAt(Vector vec, Direction dir)
        {
            return vec.Add(new Vector(dir.DifX, dir.DifY, dir.DifZ));
        }

        public static Direction GetByName(string name)
        {
            switch (name)
            {
                case "north":
                case "n":
                    return NORTH;

                case "south":
                case "s":
                    return SOUTH;

                case "east":
                case "e":
                    return EAST;

                case "west":
                case "w":
                    return WEST;

                case "up":
                    return UP;

                case "down":
                    return DOWN;

                default:
                    return null;
            }
        }

        public static IReadOnlyCollection<Direction> GetAll()
        {
            return All.AsReadOnly();
        }
    }
}
