using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public struct ComplexNum
    {
        public double Real { get; set; }
        public double Img { get; set; }

        public ComplexNum (double r, double i)
        {
            Real = r;
            Img = i;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(ComplexNum))
                return false;
            return (ComplexNum)obj == this;
        }
        public override string ToString()
        {
            return string.Format("real = {0}, imaginary = {1}", this.Real, this.Img);
        }
        public override int GetHashCode()
        {
            int result = 17;
            result = 37 * result + (int)(BitConverter.DoubleToInt64Bits(Real) - (BitConverter.DoubleToInt64Bits(Real) >> 32));
            result = 37 * result + (int)(BitConverter.DoubleToInt64Bits(Img) - (BitConverter.DoubleToInt64Bits(Img) >> 32));
            return result;
        }
        public static ComplexNum operator+ (ComplexNum num1, ComplexNum num2)
        {
            return new ComplexNum(num1.Real + num2.Real, num1.Img + num2.Img);
        }
        public static ComplexNum operator -(ComplexNum num1, ComplexNum num2)
        {
            return new ComplexNum(num1.Real - num2.Real, num1.Img - num2.Img);
        }
        public static ComplexNum operator *(ComplexNum num1, ComplexNum num2)
        {
            return new ComplexNum(num1.Real*num2.Real - num1.Img*num2.Img, num1.Img*num2.Real + num2.Img*num1.Real);
        }
        public static ComplexNum operator /(ComplexNum num1, ComplexNum num2)
        {
            double div = Math.Pow(num2.Real, 2) + Math.Pow(num2.Img, 2);
            return new ComplexNum((num1.Real * num2.Real + num1.Img * num2.Img)/div, (num1.Img * num2.Real - num2.Img * num1.Real)/div);
        }

        public static bool operator ==(ComplexNum num1, ComplexNum num2)
        {
            return num1.Real == num2.Real && num1.Img==num2.Img;
        }
        public static bool operator !=(ComplexNum num1, ComplexNum num2)
        {
            return !(num1==num2);
        }


    }
}
