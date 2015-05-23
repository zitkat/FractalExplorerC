using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FractalExplorer
{
    class calc
    {
        /*
         * expression
         */


        public Complex nextIteration(Complex z, Complex c)
        {
            //TODO calculate from expression
            double re = z.Real*z.Real - z.Imaginary * z.Imaginary + c.Real;
            double im = 2 * z.Imaginary * z.Real + c.Imaginary;
            Complex res = new Complex(re, im);
            return res;
        }

        public void setExpression(String s)
        {

        }

        private void/*expression*/ parseExp(String s)
        {

        }

        public static double fsq(Complex z)
        {
            return z.Real * z.Real + z.Imaginary * z.Imaginary;
        }




    }
}
