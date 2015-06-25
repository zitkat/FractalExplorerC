using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace FractalExplorer
{
    class expression
    {
        struct tok{
            public int index { get; private set; }  /* index of token start in parsed expression, for error reporting */
            public int op_num { get; private set; }  /* number of operation in array of unary (math. functions) or
				        binary operations
				        -1 if token represents number or parenthesis
				      */
            public Complex value { get; private set; }/* value of a real number, if token represents number*/
            public char tag { get; private set; }/* tag of token meaning
			  	      f - function i.e. unary operator:
			          b - binary operator
			          (,) - for left or right parenthesis respectively
			          n - number
			          z or c - variable
			      */        
            public tok(int index, int op_num, Complex value, char tag): this()
            {
                this.index = index;
                this.op_num = op_num;
                this.value = value;
                this.tag = tag;
            }
            public tok(int index, int op_num, char tag)
                : this()
            {
                this.index = index;
                this.op_num = op_num;
                this.value = new Complex();
                this.tag = tag;
            }
        }

        tok[] expr;
        int len;

        int position = 0;//position in parsed string

        public Complex value_at(Complex z, Complex c)
        {
           
            tok  work_tok;
	        Complex work_num;
	        Complex lefto;
	        Complex righto;
            Stack<Complex> s = new Stack<Complex>();

            for (int i = 0; i < len; i++)
            {
                //TODO optimize?
                work_tok = expr[i];             
                switch (work_tok.tag)
                {
                    case 'n':
                        s.Push(work_tok.value);
                        break;
                    case 'z':
                        s.Push(z);
                        break;
                    case 'c':
                        s.Push(c);
                        break;
                    case 'f':
                        if (s.Count < 1)
                        {
                            throw new parsingException("Chybí argument funkce", work_tok.index);//probably can't happen
                        }
                        else
                        {
                            work_num = s.Pop();
                        }
                        work_num = (calc.functions[work_tok.op_num]).operation(work_num);
                        s.Push(work_num);
                        break;
                    case 'b':
                        if (s.Count < 2)
                        {         
                            throw new parsingException("Chybí operand binární operace", work_tok.index);//probably can't happen
                        }
                        else
                        {
                            righto = s.Pop();
                            lefto = s.Pop();
                        }
                        work_num = (calc.binary_operations[work_tok.op_num]).operation(lefto, righto);
                        s.Push(work_num);
                        break;
                }
            }
            if (s.Count <= 0)
            {
                work_num = 0;
            }
            else
            {
                work_num = s.Pop();
            }
	        return work_num;
        }


        public void set_expression(String s)
        {
            parse(s);
        }

        /// <summary>
        /// Parses mathematical expression s in infix notation, fills array this.expr
        /// with tokens representing parsed expression in reverse polish notation.
        /// </summary>
        /// <param name="s"></param>
        private void parse(String s)  
        {
            expr = new tok[s.Length];
            int i=0;
            position = 0;
            tok curr_tok, work_tok;
            Stack<tok> stack = new Stack<tok>();
            String expecting = "(fnzc";/* expression shouldn't start with left parenthesis or binary operator*/

            while(position < s.Length){
                try
                {
                    curr_tok = get_next_tok(s);
                }
                catch(parsingException e)
                {
                    throw e;
                }
                if (is_expected(curr_tok.tag, expecting))
                {
                    switch (curr_tok.tag)
                    {
                        case 'c':
                        case 'z':
                        case 'n': /*if token is a number or variable it is added to the output array*/
                            expr[i]=curr_tok;//appends curr_tok at end of expression
                            i++;
                            expecting = ")b";
                            break;
                        case 'f':
                            stack.Push(curr_tok);
                            expecting = "(";
                            if (curr_tok.op_num == calc.get_func_num("-"))
                            {
                                expecting = "(fnzc";
                            }
                            break;
                        case 'b':
                            while (stack.Count > 0)
                            {
                                work_tok = stack.Peek();
                                if (work_tok.tag == 'b')
                                {
                                    if ((curr_tok.op_num != calc.get_binop_num('^') && priority_dif(work_tok, curr_tok) >= 0) ||
                                        (curr_tok.op_num == calc.get_binop_num('^') && priority_dif(work_tok, curr_tok) > 0))
                                    {
                                        /*
                                         * '^' is right associative so it requires special treatment
                                         */
                                        work_tok = stack.Pop();
                                        expr[i] = work_tok;
                                        i++;
                                    }
                                    else break;
                                }
                                /*
                                 * unary '-' has lower priority then other functions
                                 * priority_dif takes care of that
                                 */
                                if (work_tok.tag == 'f')
                                {
                                    if (priority_dif(work_tok, curr_tok) >= 0)
                                    {
                                        work_tok = stack.Pop();
                                        expr[i] = work_tok;
                                        i++;
                                    }
                                    else break;
                                }
                                else break;
                            }
                            stack.Push(curr_tok);
                            expecting = "(fnzc";
                            break;
                        case '(':
                            stack.Push(curr_tok);
                            expecting = "(fnzc";
                            break;
                        case ')':
                            work_tok = stack.Peek();
                            while (stack.Count>0)
                            { /*ends when reaches end of the stack and doesn't find '('*/
                                work_tok = stack.Pop();
                                if (work_tok.tag == '(')
                                {/*ends when left parenthesis is found*/
                                    break;
                                }
                                expr[i] = work_tok;
                                i++;
                            }
                            if (work_tok.tag != '(')
                            {/*left parenthesis not found*/
                                throw new parsingException("Nadbytečná pravá závorka", curr_tok.index);
                            }
                            else
                            {
                                if (stack.Count > 0)
                                {
                                    work_tok = stack.Peek();
                                    if (work_tok.tag == 'f')
                                    {
                                        work_tok = stack.Pop();
                                        expr[i] = work_tok;
                                        i++;
                                    }
                                }
                            }
                            expecting = ")b";
                            break;
                    }
                }
                else
                {
                    throw new parsingException("Neočekávaný symbol", curr_tok.index);
                }
            }
            if (is_expected('(', expecting) || is_expected('n', expecting) || is_expected('z', expecting) || is_expected('c', expecting))
            {
                throw new parsingException("Očekávány další symboly", position);
	        }
            /*
             * Dump rest of the operators to the array
             */
	        while(stack.Count>0){
		        work_tok = stack.Pop();
		        if(work_tok.tag == '('){
                    /*all parenthesis should've been popped by their counterparts*/
                    throw new parsingException("Neuzavřená levá závorka '('", work_tok.index);
                }
		        expr[i] = work_tok;
                i++;
            }
            len = i;
	}


        /// <summary>
        /// Finds lexical token in expr starting at curent postion, moves position at the start of next token
        /// and returns found token. Throws parsingExresiion if symbols in expr don't matc any known lexical token
        /// don't match any known lexical token.
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        tok get_next_tok(String expr)
        {
	        String num;
	        String func_name;
	        int func_num=-1;

	        int t_pos = position;
	        Complex val;

	        switch(expr[t_pos]){
		        case '(':
		        case ')':
			        position++; 
			        return new tok (position, -1, expr[t_pos]);
		        case '^':
		        case '+':
		        case '*':
		        case '/':
			        position++; 
			        return new tok (position, calc.get_binop_num(expr[t_pos]), 'b');;
		        case 'z':
			        position++; 
			        return new tok (position, -1, 'z');
                case 'c':
                    position++; 
			        return new tok (position, -1, 'c');
                case 'i':
                    position++;
                    return new tok(position, -1, new Complex(0, 1),'n');
		        case '-':
			          if(t_pos-1 < 0){/*'-' is at the star of the string => it's unary*/
				          position++; 
				          return new tok (position, calc.get_func_num("-"), new Complex(0,0), 'f');
			          }else if( is_bin_op(expr[t_pos-1]) || expr[t_pos-1]=='(' ){
				          /* '-' is inside of the string then it's unary if there is binary operation or left parentheses preceding it*/
				          position++; 
				          return new tok (position, calc.get_func_num("-"), 'f');
			          }
			          position++; 
			          return new tok (position, calc.get_binop_num(expr[t_pos]),'b');
		        default:
			        if(is_func_id(expr[t_pos])){
				        func_name="";
				        while(t_pos < expr.Length && is_func_id(expr[t_pos])){
					        func_name += expr[t_pos];
					        t_pos++;
				        }
				        func_num = calc.get_func_num(func_name);
				        if(func_num < 0){  
                            throw new parsingException("Neznámá funkce", position);
				        }else{
					        position = t_pos; 
					        return new tok(position, func_num,'f');
				        }
			        }

			        if(is_digit(expr, t_pos)){
				         num="";
                         while (t_pos < expr.Length && is_digit(expr, t_pos))
                         {
                             num += expr[t_pos];
                             t_pos++;
                         }
                         try
                         {
                             if (t_pos < expr.Length && expr[t_pos] == 'i')
                             {
                                 val = new Complex(0, Double.Parse(num));
                                 t_pos++;
                             }
                             else
                             {
                                 val = new Complex(Double.Parse(num), 0);
                             }
                         }
                         catch(Exception e)
                         {
                             throw new parsingException("Chyba v čísle", position);
                         }
					    position = t_pos; 
					    return new tok(position, -1, val, 'n');
			        }
			        position++;
                    throw new parsingException("Nepovolený znak", position);
	        }

        }

          
        /// <summary>
        /// Returns True, if character in s at pos could be part of representation of a complex number i.e.
        /// c is digit: '0..9','E' or 'e' or '-' preceded by 'E'/'e' or '.'. Or 'i' preceded by '0..9' or alone.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        bool is_digit(String s, int pos)
        {
            bool res = Char.IsDigit(s, pos) || s[pos] == 'E' || s[pos] == 'e' || s[pos] == ',';
            res = res || ((s[pos] == '-') && (s[pos - 1] == 'E' || s[pos - 1] == 'e'));
            return res;
        }

        /// <summary>
        /// Returns true if c is binary operator i.e.: '+, -, *, /, ^'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool is_bin_op(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        /// <summary>
        /// Returns true if c could be part of function name i.e. c is a letter.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool is_func_id(char c)
        {
            return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
        }

        /// <summary>
        /// Returns true if char tag is found in string expecting
        /// </summary>
        /// <param name="tag">tag of the token</param>
        /// <param name="expecting">list of expected tags</param>
        /// <returns></returns>
        bool is_expected(char tag, String expecting)
        {
            return expecting.Contains(tag);
        }

        /// <summary>
        /// Returns negative value if o2 has greater priority than o1
  		///	        zero if they have same priority
  		///	        positive value otherwise
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        int priority_dif(tok o1, tok o2)
        {
            if (o1.tag == 'b' && o2.tag == 'b')
            {
                return o1.op_num - o2.op_num;
                /*
                 * Binary operations are sorted by priority.
                 */
            }
            if (o1.tag == 'f' && o2.tag == 'b')
            {
                if (o1.op_num == calc.get_func_num("-"))
                {
                    /*
                     * Unary minus has the same priority as '*'.
                     */
                    return calc.get_binop_num('*') - o2.op_num;

                }
                /*
                 * Other functions have greater priority then bin. operations.
                 */
                return 1;

            }
            return 0;

        }

    }

    
    public class parsingException : Exception
    { 
        /// <summary>
        /// Position where the parsing error was encountered
        /// </summary>
        public int index;

        public parsingException( string message, int index ) : base( message )
        {
            this.index = index;
        }
        public parsingException( string message, Exception inner, int index ) : base( message, inner) 
        {
            this.index = index;
        }

        protected parsingException( 
        System.Runtime.Serialization.SerializationInfo info, 
        System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
    }
}