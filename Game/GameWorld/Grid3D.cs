using Grimm.Game.Exceptions;
using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    public class Grid3D
    {
        private OffsetList<OffsetList<OffsetList<Location>>> Grid { get; set; } = new OffsetList<OffsetList<OffsetList<Location>>>();

        public Grid3D()
        {
        }

        public Grid3D AddLocation(Location loc)
        {
            if (HasLocationAt(loc.Pos))
                throw new GridAlreadyHasLocationException();

            var absX = Math.Abs(loc.X);
            var absY = Math.Abs(loc.Y);
            var absZ = Math.Abs(loc.Z);
            var indexX = 0;
            var indexY = 0;
            var indexZ = 0;

            if (loc.X < 0)
            {
                var willUpdate = this.Grid.WillUpdateOffset(loc.X);

                var difX = willUpdate
                    ? absX - this.Grid.Offset
                    : 0;

                this.Grid.AttemptUpdateOffset(loc.X);

                indexX = this.Grid.Offset + loc.X;

                for (var x = 0; x < difX; x++)
                    this.Grid.Insert(0, new OffsetList<OffsetList<Location>>());
            }
            else
            {
                indexX = loc.X + this.Grid.Offset;
            }

            if (loc.Y < 0)
            {
                var willUpdate = this.Grid[indexX].WillUpdateOffset(loc.Y);

                var difY = willUpdate
                    ? absY - this.Grid[indexX].Offset
                    : 0;

                this.Grid[indexX].AttemptUpdateOffset(loc.Y);

                indexY = this.Grid[indexX].Offset + loc.Y;

                for (var y = 0; y < difY; y++)
                    this.Grid[indexX].Insert(0, new OffsetList<Location>());
            }
            else
            {
                try
                {
                    indexY = loc.Y + this.Grid[indexX].Offset;
                }
                catch (ArgumentOutOfRangeException)
                {
                    indexY = loc.Y;
                }
            }

            if (loc.Z < 0)
            {
                var grid = this.Grid[indexX][indexY];
                var willUpdate = grid.WillUpdateOffset(loc.Z);

                var difZ = willUpdate
                    ? absZ - grid.Offset
                    : 0;

                grid.AttemptUpdateOffset(loc.Z);

                indexZ = grid.Offset + loc.Z;

                for (var z = 0; z < difZ; z++)
                    grid.Insert(0, null);
            }
            else
            {
                try
                {
                    indexZ = loc.Z + this.Grid[indexX][indexY].Offset;
                }
                catch (ArgumentOutOfRangeException)
                {
                    indexZ = loc.Z;
                }
            }

            EnsureCapacity(new Vector(indexX, indexY, indexZ));

            this.Grid[indexX][indexY][indexZ] = loc;

            return this;
        }

        public bool HasLocationAt(Vector pos)
        {
            try
            {
                var indexPos = GetIndexPos(pos);
                return this.IsInBounds(pos) &&
                       this.Grid[indexPos.IntX]
                                [indexPos.IntY]
                                [indexPos.IntZ] != null;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsInBounds(Vector pos)
        {
            try
            {
                var indexPos = GetIndexPos(pos);
                return this.Grid.Count - 1 >= indexPos.IntX &&
                       this.Grid[indexPos.IntX].Count - 1 >= indexPos.IntY &&
                       this.Grid[indexPos.IntX][indexPos.IntY].Count - 1 >= indexPos.IntZ;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public Location GetLocationAt(Vector pos)
        {
            if (!HasLocationAt(pos))
                return null;

            var indexPos = GetIndexPos(pos);
            return this.Grid[indexPos.IntX][indexPos.IntY][indexPos.IntZ];
        }
        public Location GetLocationAt(int x, int y, int z)
        {
            return GetLocationAt(new Vector(x, y, z));
        }

        public List<Location> GetLinear()
        {
            var linear = new List<Location>();
            for (var x = 0; x < this.Grid.Count; x++)
            {
                for (var y = 0; y < this.Grid.Count; y++)
                {
                    for (var z = 0; z < this.Grid.Count; z++)
                    {
                        linear.Add(this.Grid[x][y][z]);
                    }
                }
            }

            return linear;
        }

        public void ForEach(Action<Location> action)
        {
            for (var x = 0; x < this.Grid.Count; x++)
            {
                for (var y = 0; y < this.Grid.Count; y++)
                {
                    this.Grid[x][y].ForEach(action);
                }
            }
        }

        private int GetIndexX(int x)
        {
            return x + GetOffsetX();
        }
        private int GetOffsetX()
        {
            return this.Grid.Offset;
        }

        private int GetIndexY(int x, int y)
        {
            return y + GetOffsetY(x);
        }
        private int GetOffsetY(int x)
        {
            return this.Grid[GetIndexX(x)].Offset;
        }

        private int GetIndexZ(int x, int y, int z)
        {
            return z + GetOffsetZ(x, y);
        }
        private int GetOffsetZ(int x, int y)
        {
            return this.Grid[GetIndexX(x)][GetIndexY(x, y)].Offset;
        }

        private Vector GetIndexPos(Vector pos)
        {
            return new Vector(
                GetIndexX(pos.IntX),
                GetIndexY(pos.IntX, pos.IntY),
                GetIndexZ(pos.IntX, pos.IntY, pos.IntZ));
        }

        /// <summary>
        /// Expands the grid until it is large enough to fully contain the given position
        /// on the x, y, and z axes.
        /// </summary>
        /// <param name="pos"></param>
        private void EnsureCapacity(Vector pos)
        {
            for (int x = 0; x < pos.X + 1; x++)
            {
                if (this.Grid.Count - 1 < x)
                    this.Grid.Add(new OffsetList<OffsetList<Location>>());
                for (int y = 0; y < pos.Y + 1; y++)
                {
                    if (this.Grid.ElementAt(x).Count - 1 < y)
                        this.Grid.ElementAt(x).Add(new OffsetList<Location>());
                    for (int z = 0; z < pos.Z + 1; z++)
                    {
                        if (this.Grid.ElementAt(x).ElementAt(y).Count - 1 < z)
                            this.Grid.ElementAt(x).ElementAt(y).Add(null);
                    }
                }
            }
        }
    }
}
