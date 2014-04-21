using System;

namespace Squish
{
    public class Vector3
    {
        Single _x;
        Single _y;
        Single _z;

        public Single X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Single Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Single Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Vector3(Single n)
        {
            _x = n;
            _y = n;
            _z = n;
        }

        public Vector3(Single X, Single Y, Single Z)
        {
            _x = X;
            _y = Y;
            _z = Z;
        }

        public static Vector3 operator +(Vector3 x, Vector3 y)
        {
            return new Vector3(x._x + y.X, x._y + y.Y, x._z + y.Z);
        }

        public static Vector3 operator -(Vector3 x, Vector3 y)
        {
            return new Vector3(x._x - y.X, x._y - y.Y, x._z - y.Z);
        }

        public static Vector3 operator *(Single y, Vector3 x) { return x * y; }

        public static Vector3 operator *(Vector3 x, Single y)
        {
            return new Vector3(x._x * y, x._y * y, x._z * y);
        }

        public static Vector3 operator *(Vector3 x, Vector3 y)
        {
            return new Vector3(x._x * y.X, x._y * y.Y, x._z * y.Z);
        }

        public static Vector3 operator /(Vector3 x, Single y)
        {
            return new Vector3(x._x / y, x._y / y, x._z / y);
        }

        public static Single Dot(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Single LengthSquared(Vector3 v)
        {
            return Dot(v, v);
        }

        public static Vector3 Min(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                Math.Min(v1.X, v2.X),
                Math.Min(v1.Y, v2.Y),
                Math.Min(v1.Z, v2.Z)
                );
        }

        public static Vector3 Max(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                Math.Max(v1.X, v2.X),
                Math.Max(v1.Y, v2.Y),
                Math.Max(v1.Z, v2.Z)
                );
        }

        public static Vector3 Truncate(Vector3 v)
        {
            return new Vector3(
                (float)(v.X > 0.0f ? Math.Floor(v.X) : Math.Ceiling(v.X)),
                (float)(v.Y > 0.0f ? Math.Floor(v.Y) : Math.Ceiling(v.Y)),
                (float)(v.Z > 0.0f ? Math.Floor(v.Z) : Math.Ceiling(v.Z))
            );
        }
    }
}
