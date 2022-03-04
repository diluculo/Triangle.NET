﻿// -----------------------------------------------------------------------
// <copyright file="Point.cs" company="">
// Triangle.NET code by Christian Woltering, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

namespace TriangleNet.Geometry
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a 2D point.
    /// </summary>
#if USE_Z
    [DebuggerDisplay("ID {ID} [{X}, {Y}, {Z}]")]
#else
    [DebuggerDisplay("ID {ID} [{X}, {Y}]")]
#endif
    public class Point : IComparable<Point>, IEquatable<Point>
    {
        internal int id;
        internal int label;

        internal double x;
        internal double y;
#if USE_Z
        internal double z;
#endif

        public Point()
            : this(0.0, 0.0, 0)
        {
        }

        public Point(double x, double y)
            : this(x, y, 0)
        {
        }

        public Point(double x, double y, int label)
        {
            this.x = x;
            this.y = y;
            this.label = label;
        }

        #region Public properties

        /// <summary>
        /// Gets or sets the vertex id.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the vertex x coordinate.
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the vertex y coordinate.
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

#if USE_Z
        /// <summary>
        /// Gets or sets the vertex z coordinate.
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
#endif

        /// <summary>
        /// Gets or sets a general-purpose label.
        /// </summary>
        /// <remarks>
        /// This is used for the vertex boundary mark.
        /// </remarks>
        public int Label
        {
            get { return label; }
            set { label = value; }
        }

        #endregion

        #region Overriding Equals() and == Operator

        public static bool operator ==(Point a, Point b)
        {
            if (a is null)
            {
                // If one is null, but not both, return false.
                return b is null;
            }

            // If both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj) => Equals(obj as Point);

        public bool Equals(Point p)
        {
            // If object is null return false.
            if (p is null)
            {
                return false;
            }

            // Return true if the fields match.
            return (x == p.x) && (y == p.y);
        }

        #endregion

        public int CompareTo(Point other)
        {
            if (x == other.x && y == other.y)
            {
                return 0;
            }

            return (x < other.x || (x == other.x && y < other.y)) ? -1 : 1;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + x.GetHashCode();
            hash = hash * 31 + y.GetHashCode();

            return hash;
        }
    }
}
