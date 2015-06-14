using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FractalExplorer
{
    class expression
    {
        //TODO array of functions and binary operations

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
			          x - variable
			          e - error
			      */
            public String msg { get; private set; }  /* error message for error tokens */
        
            public tok(int index, int op_num, Complex value, char tag, String msg): this()
            {
                this.index = index;
                this.op_num = op_num;
                this.value = value;
                this.tag = tag;
                this.msg = msg;
            }
        }

        tok[] expr;
        int len;

        int position = 0;//position in parsed string

        public Complex nextIteration(Complex z, Complex c)
        {
            //TODO calculate from expression
            //double re = z.Real*z.Real - z.Imaginary * z.Imaginary + c.Real;
            //double im = 2 * z.Imaginary * z.Real + c.Imaginary;
            //Complex res = new Complex(re, im);
            //return res;

            tok  work_tok;
	        Complex work_num;
	        Complex lefto;
	        Complex righto;

            Stack<Complex> s = new Stack<Complex>();

            int i = 0;
	        while(i < len){
                work_tok = expr[i];
                i++;
		        /*print_tok(work_tok);*/
		        switch (work_tok.tag){
			        case 'n':
				        s.Push(work_tok.value);
				        break;
			        case 'z':
				        s.Push(z);
				        break;
                    case 'c':
                        s.Push(c);
                        break;
                    //case 'f':
                    //      if(!pop(s, &work_num)){
                    //        /*printf("No arguments for function.\n");*/
                    //        free_stack(&s);
                    //        return 0;
                    //      }
                    //      work_num = (functions[work_tok->op_num]).my_f(work_num);
                    //      push(s,&work_num);
                    //    break;
			        case 'b':
				          if(s.Count < 2){
					         /*printf("Missing operand for bin op.\n");*/
                              //TODO throw exception
					          return 0;
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

        public void setExpression(String s)
        {
            parseExp(s);
        }

        /// <summary>
        /// Parses mathematical expression s in infix notation, fills array expr
        /// with tokens representing parsed expression in reverse polish notation.
        /// TODO throws exception if parsing goes wrong
        /// </summary>
        /// <param name="s"></param>
        private void parseExp(String s)
        {
            expr = new tok[s.Length];
            int i=0;
            position = 0;
            tok curr_tok, work_tok;
            Stack<tok> stack = new Stack<tok>();
            String expecting = "(fnzce";/* expression shouldn't start with left parenthesis or binary operator,
							            * error is always expected */
            //TODO parse expression

            while(position < s.Length){
                curr_tok = get_next_tok(s);
                if (is_expected(curr_tok.tag, expecting))
                {
                    switch (curr_tok.tag)
                    {
                        case 'c':
                        case 'z':
                        case 'n': /*if token is a number or variable it is added to the output queue*/
                            expr[i]=curr_tok;//appends curr_tok at end of expression
                            i++;
                            expecting = ")be";
                            break;
                        case 'f':
                            stack.Push(curr_tok);
                            expecting = "(e";
                            if (curr_tok.op_num == calc.get_func_num("-"))
                            {
                                expecting = "(fnzce";
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
                                        expr[i] = curr_tok;
                                        i++;
                                    }
                                    else break;
                                }
                                else break;
                            }
                            stack.Push(curr_tok);
                            expecting = "(fnzce";
                            break;
                        case '(':
                            stack.Push(curr_tok);
                            expecting = "(fnzce";
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
                                new tok(curr_tok.index, -1, new Complex(), 'e', "Unmatched right parenthesis");
                                //TODO throw exception
                                return;
                            }
                            else
                            {
                                work_tok = stack.Peek();
                                if (work_tok.tag == 'f')
                                {
                                    work_tok = stack.Pop();
                                    expr[i] = curr_tok;
                                    i++;
                                }
                            }
                            expecting = ")be";
                            break;
                        case 'e':
                            //TODO throw exception
                            return;
                    }
                }
                else
                {
                    new tok(curr_tok.index,-1, new Complex(),'e',"Unexpected token");
                    //TODO throw exception
                    return;
                }
            }
            if (is_expected('(', expecting) || is_expected('n', expecting) || is_expected('z', expecting) || is_expected('c', expecting))
            {
		        new tok(position,-1, new Complex(),'e',"Expected more tokens after token");
                //TODO throw exception
		        return;
	        }
            /*
             * Dump rest of the operators to the queue
             */
	        while(stack.Count>0){
		        work_tok = stack.Pop();
		        if(work_tok.tag == '('){/*all parenthesis should've been popped by their counterparts*/
		            new tok(work_tok.index,-1, new Complex(),'e', "Unmatched left parenthesis '('");
			        return;
                }
		        expr[i] = work_tok;
                i++;
            }
            len = i;
	}


        /// <summary>
        /// Finds lexical token in *retezec starting at *position, moves *position at the start of next token
        /// and fills tok struct *next with found data or error report if symbols in retezec
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

            //if(!(next && expr && position)){
            //    return;
            //}

	        switch(expr[t_pos]){
		        case '(':
		        case ')':
			        position++; 
			        return new tok (position, -1, new Complex(0,0), expr[t_pos], "(,)");
		        case '^':
		        case '+':
		        case '*':
		        case '/':
			        position++; 
			        return new tok (position, calc.get_binop_num(expr[t_pos]), new Complex(0,0),'b', "+,*,/,^");;
		        case 'z':
			        position++; 
			        return new tok (position, -1, new Complex(0,0), 'z', "z");
                case 'c':
                    position++; 
			        return new tok (position, -1, new Complex(0,0), 'c', "c");
		        case '-':
			          if(t_pos-1 < 0){/*'-' is at the star of the string => it's unary*/
				          position++; 
				          return new tok (position, calc.get_func_num("-"), new Complex(0,0), 'f', "-");
			          }else if( is_bin_op(expr[t_pos-1]) || expr[t_pos-1]=='(' ){
				          /* '-' is inside of the string then it's unary if there is binary operation or left parentheses preceding it*/
				          position++; 
				          return new tok (position, calc.get_func_num("-"), new Complex(0,0), 'f', "-");
			          }
			          position++; 
			          return new tok (position, calc.get_binop_num(expr[t_pos]), new Complex(0,0), 'b', "-");
		        default:
			        if(is_func_id(expr[t_pos])){
				        func_name="";
				        while(is_func_id(expr[t_pos]) && t_pos < expr.Length){
					        func_name += expr[t_pos];
					        t_pos++;
				        }
				        //func_name="";
				        func_num = calc.get_func_num(func_name);
				        if(func_num < 0){
                            return new tok(position, -1, new Complex(0, 0), 'e', "Unknown function");
				        }else{
					        position = t_pos; 
					        return new tok(position, func_num, new Complex(0, 0),'f',"");
				        }
			        }

			        if(is_digit(expr, t_pos)){
				         num="";
				         while(t_pos < expr.Length && is_digit(expr, t_pos)){
					         num +=expr[t_pos];
					         t_pos++;
				         }
				        
				         //k = sscanf(num,"%lf", &val);
                         //TODO parse complex number from obtained string
                         try
                         {
                             val = new Complex(Double.Parse(num), 0);
                         }catch(Exception e){
                             return new tok(position, -1, new Complex(0, 0), 'e', "Error parsing number");
                         }
					    position = t_pos; 
					    return new tok(position, -1, val, 'n', "");
			        }
			        position++; 
			        return new tok(position, -1, new Complex(0, 0), 'e',"Invalid character");

	        }

        }

          
        /// <summary>
        /// Returns 1 i.e. true, if character in s at pos could be part of representation of a complex number i.e.
        /// c is digit: '0..9','E' or 'e' or '-' preceded by 'E'/'e' or '.'. Or 'i' preceded by '0..9' or alone.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        bool is_digit(String s, int pos)
        {

            //TODO proper identification of complex numbers
            bool res = Char.IsDigit(s, pos) || s[pos] == 'E' || s[pos] == 'e' || s[pos] == '.';
            res = res || ((s[pos] == '-') && (s[pos - 1] == 'E' || s[pos - 1] == 'e'));
            return res;

        }

        /// <summary>
        /// Returns 1 i.e. id c is binary operator i.e.: '+, -, *, /, ^'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool is_bin_op(char c)
        {

            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        /// <summary>
        /// Returns 1 i.e. true if c could be part of function name i.e. c is a letter.
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
}