using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace C_sharp_Equals_Reference_Overload___homework_
{
    public class Vector
    {
        int x, y;
        public int X
        {
            get => x;
            set => x = value;
        }
        public int Y
        {
            get => y;
            set => y = value;
        }
        public Vector(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public double VectorLength()
        {
            return (Math.Sqrt(Convert.ToDouble(X * X + Y * Y)));
        }
        public override string ToString()
        {
            return ($"X: {X}; Y:{Y}");
        }
        public static Vector operator ++(Vector one)
        {
            return new Vector(one.X+1, one.Y+1);
        }
        public static Vector operator --(Vector one)
        {
            return new Vector(one.Y-1, one.Y-1);
        }
        public static Vector operator +(Vector one, Vector two)
        {
            return new Vector(
                x: one.x + two.x,
                y: one.y + two.y
                );
        }
        public static Vector operator -(Vector one, Vector two)
        {
            return new Vector(
                x: one.x - two.x,
                y: one.y - two.y
                );
        }
        public static Vector operator -(Vector one)
        {
            return new Vector(
                x: one.x*(-1),
                y: one.y*(-1)
                );
        }
        public static int operator *(Vector one, Vector two)
        {
            return one.x * one.y + two.x * two.y;
        }
        public static Vector operator *(Vector vec, Fraction fr) 
        {
            double num = Convert.ToDouble(fr.Num) / Convert.ToDouble(fr.Denom);
            double newX = vec.x * num;
            double newY = vec.y * num;
            return new Vector((int)newX, (int)newY);
        }
        public static bool operator ==(Vector one, Vector two)
        {
            if (ReferenceEquals(one, two))
                return true;
            if ((object)one == null)
                return false;
            return one.Equals(two);
        }
        public static bool operator !=(Vector one, Vector two)
        {
            return !(one == two);
        }
        public static bool operator false(Vector one)
        {
            if (one.X == 0 && one.Y == 0)
                return false;
            return true;
        }
        public static bool operator true(Vector one)
        {
            if (one.X == 0 && one.Y == 0)
                return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            Vector vec = obj as Vector;
            if (vec == null)
                return false;
            return this.x == vec.x && this.y == vec.y;
        }
        public override int GetHashCode()
        {
            return (VectorLength()).ToString().GetHashCode();
        }
        private bool IsValidIndex(int index) => index >= 0 && index <= 1;
        public int this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                    throw new Exception($"Error index{index}");
                if (index == 0)
                    return X;
                return Y;
            }
            set
            {
                if (!IsValidIndex(index))
                    throw new Exception($"Error index{index}");
                if (index == 0)
                    X = value;
                else
                    Y = value;
            }
        }
        public int this[string index]
        {
            get
            {
                if (index.ToLower() == "x")
                    return X;
                else if (index.ToLower() == "y")
                    return Y;
                throw new Exception($"Error index {index ?? "null"}");
            }
        }
        public static implicit operator Vector(double number)
        {
            return new Vector((int)number, 0);
        }
    }
}
