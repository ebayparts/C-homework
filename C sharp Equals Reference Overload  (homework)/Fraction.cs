using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_Equals_Reference_Overload___homework_
{
    public class Fraction
    {
        int num, denom;
        public int Denom
        {
            get => denom;
            set => denom = value != 0 ? value : throw new Exception("Wrong denominator");
        }
        public int Num
        {
            get => num;
            set => num = value;
        }
        public Fraction(int num = 0, int denom = 1)
        {
            try
            {
                Denom = denom;
            }
            catch (Exception)
            {
                Denom = 1;
            }
            Num = num;
        }
        public override string ToString()
        {
            return $"{Num} / {Denom}";
        }
    }
}
