///
/// Pieter De Bruyne 2013
///
using System;
using System.Drawing;
namespace MMTproject1{

    class LineF
    {
        public PointF p1{get;set;}
        public PointF p2{get;set;}

        public LineF(float p1x,float p1y, float p2x, float p2y){
            this.p1 = new PointF(p1x, p1y);
            this.p2 = new PointF(p2x, p2y);
        }

        public LineF(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public PointF getMidPoint()
        {
                return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            }
        }

        public Vector2D Mid
        {
            get
            {
                return new Vector2D((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }
        }
    }

    class Utils{

        private static readonly Random rand = new Random();

        public static double sign(float x){
            if(x < 0) return -1;
            return 1;
        }

        public static double sign(double x)
        {
            if (x < 0) return -1;
            return 1;
        }

        public static Color randomColor()
        {
            return Color.FromArgb((int)rand.Next(0, 255), (int)rand.Next(0, 255), (int)rand.Next(0, 255));
        }

        public static double randomDoubleInrange(double min, double max)
        {
            return (rand.NextDouble() * (max - min)) + min;
        }
    }

    struct Vector2D
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }
        public Vector2D(Point p)
        {
            x = p.X;
            y = p.Y;
        }
        public Vector2D(PointF p)
        {
            x = p.X;
            y = p.Y;
        }

        public Vector2D(double _x,double _y)
        {
            x = _x;
            y = _y;
        }

        public Point asPoint()
        {
            return new Point((int)x, (int)y);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public double LengthSquared
        {
            get
            {
                return x * x + y * y;
            }
        }

        //
        // Begrenst de vector in X en Y richting (om bijvoorbeeld snelheid te beperken)
        //
        public static Vector2D Minimal(Vector2D vector,Vector2D limit)
        {
            return new Vector2D(Math.Min(vector.X, limit.X), Math.Min(limit.Y, vector.Y));
        }

        public static double AngleBetween(Vector2D v1, Vector2D v2)
        {
            return Math.Atan2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator *(Vector2D v, double s)
        {
            return new Vector2D(v.x * s, v.y * s);
        }

        public static Vector2D operator *(Vector2D v, float s)
        {
            return new Vector2D(v.x * s, v.y * s);
        }

        public static Vector2D operator *(double s,Vector2D v)
        {
            return new Vector2D(v.x * s, v.y * s);
        }

        public static Vector2D operator *( float s ,Vector2D v)
        {
            return new Vector2D(v.x * s, v.y * s);
        }

        public static Vector2D operator /(Vector2D v, double s)
        {
            return new Vector2D(v.x / s, v.y / s);
        }

        public static Vector2D FlipX(Vector2D v)
        {
            return new Vector2D(v.x * -1, v.y);
        }

        public static Vector2D FlipY(Vector2D v)
        {
            return new Vector2D(v.x, v.y * -1);
        }

        public static Vector2D Normalize(Vector2D v)
        {
            double lenght = v.Length;
            if (lenght == 0) lenght = 1.0; //nullvector
            return new Vector2D(v.X / lenght, v.Y / lenght);
        }

        public static double Dot(Vector2D v1,Vector2D v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y);
        }

        public static Vector2D Tangent(Vector2D v)
        {
            return new Vector2D(-v.Y, v.X);
        }

    }
}