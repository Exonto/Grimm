using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    /// <summary>
    /// This defines a 3D mathematical vector.
    /// </summary>
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public int IntX { get { return (int)this.X; } }
        public int IntY { get { return (int)this.Y; } }
        public int IntZ { get { return (int)this.Z; } }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) +
                                 Math.Pow(Y, 2) +
                                 Math.Pow(Z, 2));
            }

            set
            {
                double magRatio = value / this.Magnitude;

                this.X *= magRatio;
                this.Y *= magRatio;
                this.Z *= magRatio;
            }
        }

        public double Radians
        {
            get
            {
                return FixAngle(Math.Atan2(this.Y, this.X));
            }
        }

        public double Degrees
        {
            get
            {
                return this.Radians * (180 / Math.PI);
            }
        }


        #region Constructors

        public Vector()
        {
            this.X = 0.0;
            this.Y = 0.0;
            this.Z = 0.0;
        }

        public Vector(Vector v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Fixes an angle to between 0 and 360 or 2pi.
        /// </summary>
        /// <param name="val">Input angle</param>
        /// <returns>The angle, fixed to between 0 and 360 or 0 and 2pi</returns>
        public static double FixAngle(double val)
        {
            //-2pi to 0 to between 0 and 2pi
            if (val < 0)
            {
                return 2 * Math.PI - (Math.Abs(val) % (2 * Math.PI));
            }
            //over 2pi to between 0 and 2pi
            else if (val > 2 * Math.PI)
            {
                return val % (2 * Math.PI);
            }
            //else it's fine, return it back
            else
            {
                return val;
            }
        }

        #endregion

        #region Comparisons

        public bool IsEqualTo(Vector other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z;
        }
        
        #endregion

        #region Simple Operations

        public Vector Add(double x, double y)
        {
            return new Vector(this.X + x, this.Y + y);
        }

        public Vector Add(double x, double y, double z)
        {
            return new Vector(this.X + x, this.Y + y, this.Z + z);
        }

        public Vector Add(Vector p)
        {
            return new Vector(this.X + p.X, this.Y + p.Y, this.Z + p.Z);
        }

        public Vector Subtract(double x, double y)
        {
            return new Vector(this.X - x, this.Y - y);
        }

        public Vector Subtract(double x, double y, double z)
        {
            return new Vector(this.X - x, this.Y - y, this.Z - z);
        }

        public Vector Subtract(Vector p)
        {
            return new Vector(this.X - p.X, this.Y - p.Y, this.Z - p.Z);
        }

        public Vector Multiply(double x, double y)
        {
            return new Vector(this.X * x, this.Y * y);
        }

        public Vector Multiply(double x, double y, double z)
        {
            return new Vector(this.X * x, this.Y * y, this.Z * z);
        }

        public Vector Multiply(Vector p)
        {
            return new Vector(this.X * p.X, this.Y * p.Y, this.Z * p.Z);
        }

        public Vector Divide(double x, double y)
        {
            return new Vector(this.X / x, this.Y / y);
        }

        public Vector Divide(double x, double y, double z)
        {
            return new Vector(this.X / x, this.Y / y, this.Z / z);
        }

        public Vector Divide(Vector p)
        {
            return new Vector(this.X / p.X, this.Y / p.Y, this.Z / p.Z);
        }

        public Vector SetX(double x)
        {
            return new Vector(x, this.Y, this.Z);
        }

        public Vector SetY(double y)
        {
            return new Vector(this.X, y, this.Z);
        }

        public Vector SetZ(double z)
        {
            return new Vector(this.X, this.Y, z);
        }

        public Vector InDirection(Direction dir)
        {
            return Direction.GetVectorAt(this, dir);
        }

        #endregion

        #region Vector Operations

        /// <summary>
        /// Returns a normalized vector whose hypotenuse has been set to 1
        /// while retaining its direction.
        /// </summary>
        /// <returns>The normalized vector.</returns>
        public Vector Normalize()
        {
            return new Vector(this.X / this.Magnitude,
                              this.Y / this.Magnitude,
                              this.Z / this.Magnitude);
        }

        public double DistanceTo(double x, double y)
        {
            double xDif = Math.Abs(this.X - x);
            double yDif = Math.Abs(this.Y - y);

            return Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
        }

        public double DistanceTo(double x, double y, double z)
        {
            double xDif = Math.Abs(this.X - x);
            double yDif = Math.Abs(this.Y - y);
            double zDif = Math.Abs(this.Z - z);

            return Math.Sqrt(Math.Pow(xDif, 2) +
                             Math.Pow(yDif, 2) +
                             Math.Pow(zDif, 2));
        }

        public double DistanceTo(Vector v)
        {
            double xDif = Math.Abs(this.X - v.X);
            double yDif = Math.Abs(this.Y - v.Y);
            double zDif = Math.Abs(this.Z - v.Z);

            return Math.Sqrt(Math.Pow(xDif, 2) +
                             Math.Pow(yDif, 2) +
                             Math.Pow(zDif, 2));
        }

        public double DotProduct(double x, double y)
        {
            return (this.X * x) + (this.Y * y);
        }

        public double DotProduct(double x, double y, double z)
        {
            return (this.X * x) + (this.Y * y) + (this.Z * z);
        }

        public double DotProduct(Vector v)
        {
            return (this.X * v.X) + (this.Y * v.Y);
        }

        public Vector CrossProduct(double x, double y)
        {
            return new Vector(0, 0, (this.X * y) - (this.Y * x));
        }

        public Vector CrossProduct(double x, double y, double z)
        {
            return new Vector((this.Y * z) - (this.Z * y),
                              (this.Z * x) - (this.X * z),
                              (this.X * y) - (this.Y * x));
        }

        public Vector CrossProduct(Vector v)
        {
            return new Vector((this.Y * v.Z) - (this.Z * v.Y),
                              (this.Z * v.X) - (this.X * v.Z),
                              (this.X * v.Y) - (this.Y * v.X));
        }

        #endregion

        public override string ToString()
        {
            return $"[{X},{Y},{Z}]";
        }
    }
}