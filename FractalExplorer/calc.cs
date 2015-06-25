using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace FractalExplorer
{

    delegate Complex my_bin(Complex o1, Complex o2);
    delegate Complex my_f(Complex o);

    struct binop
    {

        public char op { get; set; }/*operation symbol*/
        public my_bin operation_del { get; set; }

        public Complex operation(Complex lefto, Complex righto)
        {
            return operation_del(lefto, righto);
        }
    }

    struct func
    {
        public String name { get; set; }/*function name*/
        public my_f function_del { get; set; }

        public Complex operation(Complex o)
        {
            return function_del(o);
        }
    }

    static class calc
    {

        public static binop[] binary_operations = {
                                                    new binop{op = '+', operation_del = add},
                                                    new binop{op = '-', operation_del = sub},
                                                    new binop{op = '*', operation_del = mul},
                                                    new binop{op = '/', operation_del = dv},
                                                    new binop{op = '^', operation_del = pow},
                                                };
        public static func[] functions = {
                                             new func{name = "-", function_del = u_minus},
                                             new func{name = "exp" , function_del = Complex.Exp},
                                             new func{name = "log", function_del = Complex.Log},
                                             new func{name = "abs", function_del = my_Abs },
                                             new func{name = "sdr", function_del = Complex.Conjugate},
                                             new func{name = "sin" , function_del=Complex.Sin},
                                             new func{name = "sinh", function_del = Complex.Sinh},
                                             new func{name = "arcsin", function_del = Complex.Asin},
                                             new func{name = "tg", function_del = Complex.Tan},
                                             new func{name = "atg", function_del = Complex.Atan},
                                             new func{name = "tgh", function_del = Complex.Tanh}
                                         };

        /// <summary>
        /// Returns square of euclidean norm of input complex number z
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
        internal static int get_binop_num(char c)
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
        /// Returns function number in the table of binary operations
        /// Returns -1 if function isn't in the table
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static int get_func_num(string p)
        {
            for (int i = 0; i < functions.Length; i++)
            {
                if (p.Equals(functions[i].name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static Complex my_Abs(Complex z)
        {
            return new Complex(Complex.Abs(z), 0);
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

        /// <summary>
        /// Returns -o i.e. if o = a + bi -o= -a -bi
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Complex u_minus(Complex o)
        {
            return -o;
        }

        
    }
}
