using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace FractalExplorer
{

    delegate Complex my_bin(Complex o1, Complex o2);/*operation reference*/

    static class calc
    {
        
         public struct binop{

	        public char op { get; set; }/*operation symbol*/
            public my_bin operation_del { get; set; }


            public Complex operation(Complex lefto, Complex righto)
            {
                return operation_del(lefto, righto);
            }
         }

        public static binop[] binary_operations = {new binop{op = '+', operation_del = add},
                                            new binop{op = '-', operation_del = sub},
                                            new binop{op = '*', operation_del = mul},
                                            new binop{op = '/', operation_del = dv},
                                            new binop{op = '^', operation_del = pow},
                                           };

        /// <summary>
        /// Returns square of euklidean norm of input complex number z
        /// </summary>
        /// <param name="z">complex number</param>
        /// <returns></returns>
        public static double fsq(Complex z)
        {
            return z.Real * z.Real + z.Imaginary * z.Imaginary;
        }

        /// <summary>
        /// Returns binary operation number in the table of binary operations
        /// Returns -1 if operation isn't in the table
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int get_binop_num(char c)
        {
            int i = 0;
            for (i = 0; i < binary_operations.Length; ++i)
            {
                if (c == binary_operations[i].op)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns a+b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex add(Complex a, Complex b)
        {
            return a + b;
        }

        /// <summary>
        /// Returns a-b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex sub(Complex a, Complex b)
        {
            return a - b;
        }

        /// <summary>
        /// Returns a/b,
        /// sets errno to EDOM if b==0 and returns inf if able.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex dv(Complex a, Complex b)
        {
            return a / b;
        }

        /// <summary>
        /// Returns a*b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex mul(Complex a, Complex b)
        {
            return a * b;
        }
        
        /// <summary>
        /// Returns a^b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex pow(Complex a, Complex b)
        {
            return Complex.Pow(a,b);
        }

        internal static int get_func_num(string p)
        {
            throw new NotImplementedException();
        }
    }
}
