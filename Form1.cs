<<<<<<< HEAD
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

=======
>>>>>>> parent of 1e41e7a (과제1 코딩과 테스트 완료)
namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
<<<<<<< HEAD
            AttachHandlers();
        }

        private void AttachHandlers()
        {
            // Digit buttons
            btn0.Click += Digit_Click;
            btn1.Click += Digit_Click;
            btn2.Click += Digit_Click;
            btn3.Click += Digit_Click;
            btn4.Click += Digit_Click;
            btn5.Click += Digit_Click;
            btn6.Click += Digit_Click;
            btn7.Click += Digit_Click;
            btn8.Click += Digit_Click;
            btn9.Click += Digit_Click;

            // Dot
            btnDot.Click += Dot_Click;

            // Operators
            btnPlus.Click += Operator_Click;
            btnMinus.Click += Operator_Click;
            btnMultiply.Click += Operator_Click;
            btnDivide.Click += Operator_Click;

            // Controls
            btnC.Click += BtnC_Click;
            btnCE.Click += BtnCE_Click;
            btnDel.Click += BtnDel_Click;
            btnPM.Click += BtnPM_Click;
            btnResult.Click += BtnResult_Click;

            // Attach handlers for any parentheses buttons that may exist on the form (Text = "(" or ")")
            AttachParenHandlers(this);
            // cube button handler (square button is wired in Designer to button1_Click)
            btnNumCube.Click += BtnCube_Click;
        }

        private void AttachParenHandlers(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button b)
                {
                    if (b.Text == "(") b.Click += (s, e) => textBoxExpression.AppendText("(");
                    else if (b.Text == ")") b.Click += (s, e) => textBoxExpression.AppendText(")");
                }

                // recurse
                if (c.HasChildren)
                    AttachParenHandlers(c);
            }
        }

        private void Digit_Click(object? sender, EventArgs e)
        {
            if (sender is Button b)
            {
                // Append to expression only; textBoxExpression_TextChanged will update currentOperand and textBoxResult
                textBoxExpression.AppendText(b.Text);
            }
        }

        private void Dot_Click(object? sender, EventArgs e)
        {
            if (!currentOperand.Contains('.'))
            {
                // Only append to the expression; TextChanged handler will update currentOperand/result
                if (string.IsNullOrEmpty(currentOperand))
                {
                    textBoxExpression.AppendText("0.");
                }
                else
                {
                    textBoxExpression.AppendText(".");
                }
            }
        }

        private void Operator_Click(object? sender, EventArgs e)
        {
            if (sender is Button b)
            {
                // If there is a current operand, push it first
                if (!string.IsNullOrEmpty(currentOperand))
                {
                    tokens.Add(currentOperand);
                    // show the completed operand in result (operand by operand)
                    textBoxResult.Text = currentOperand;
                    currentOperand = string.Empty;
                }

                // If last token is an operator, replace it
                if (tokens.Any() && IsOperator(tokens.Last()))
                {
                    tokens[tokens.Count - 1] = b.Text;
                }
                else
                {
                    tokens.Add(b.Text);
                }

                textBoxExpression.AppendText(b.Text);
            }
        }

        private void BtnC_Click(object? sender, EventArgs e)
        {
            // Clear all
            currentOperand = string.Empty;
            tokens.Clear();
            textBoxExpression.Clear();
            textBoxResult.Clear();
        }

        private void BtnCE_Click(object? sender, EventArgs e)
        {
            // Clear current entry (remove last token or result). Make it repeatable.
            currentOperand = string.Empty;
            var expr = textBoxExpression.Text ?? string.Empty;
            if (string.IsNullOrEmpty(expr))
            {
                textBoxResult.Clear();
                return;
            }

            // If there is a computed result appended with '=', remove the result part first
            var eqPos = expr.IndexOf('=');
            if (eqPos >= 0)
            {
                // remove '=' and everything after it
                textBoxExpression.Text = expr.Substring(0, eqPos);
                textBoxResult.Clear();
                return;
            }

            // If last char is an operator, remove that operator
            if (expr.Length > 0 && IsOperator(expr.Last().ToString()))
            {
                textBoxExpression.Text = expr.Substring(0, expr.Length - 1);
                textBoxResult.Clear();
                return;
            }

            // otherwise remove trailing operand (all digits/decimal/sign until previous operator or parenthesis)
            int start = FindLastOperandStart(expr);
            textBoxExpression.Text = start > 0 ? expr.Substring(0, start) : string.Empty;
            textBoxResult.Clear();
        }

        private void BtnDel_Click(object? sender, EventArgs e)
        {
            var expr = textBoxExpression.Text ?? string.Empty;
            if (expr.Length == 0) return;

            // If expression contains '=', allow deleting the result chars one by one, then '=' itself
            var eqPos = expr.IndexOf('=');
            if (eqPos >= 0)
            {
                // If there are chars after '=', remove last char of result
                if (eqPos < expr.Length - 1)
                {
                    expr = expr.Substring(0, expr.Length - 1);
                    textBoxExpression.Text = expr;
                    // show remaining part after '=' as current result preview
                    var rem = expr.Substring(eqPos + 1);
                    currentOperand = rem;
                    textBoxResult.Text = currentOperand;
                    return;
                }

                // If '=' is the last char, remove it
                expr = expr.Substring(0, expr.Length - 1);
                textBoxExpression.Text = expr;
                currentOperand = string.Empty;
                textBoxResult.Clear();
                return;
            }

            // Normal behavior: remove last char
            expr = expr.Substring(0, expr.Length - 1);
            textBoxExpression.Text = expr;

            // update currentOperand by finding start index (include possible leading sign)
            int start = FindLastOperandStart(expr);
            currentOperand = start < expr.Length ? expr.Substring(start) : string.Empty;
            textBoxResult.Text = currentOperand;
        }

        private void BtnPM_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperand)) return;
            if (currentOperand.StartsWith("-"))
                currentOperand = currentOperand.Substring(1);
            else
                currentOperand = "-" + currentOperand;

            // rebuild expression: replace last operand in expression (respect signed operands)
            var expr = textBoxExpression.Text ?? string.Empty;
            int start = FindLastOperandStart(expr);
            textBoxExpression.Text = (start > 0 ? expr.Substring(0, start) : string.Empty) + currentOperand;
            textBoxResult.Text = currentOperand;
        }

        private void BtnResult_Click(object? sender, EventArgs e)
        {
            // push last operand
            if (!string.IsNullOrEmpty(currentOperand))
            {
                tokens.Add(currentOperand);
            }
            // build evaluable expression from displayed expression
            var original = textBoxExpression.Text ?? string.Empty;
            // if user already has '=' in the expression, evaluate only the part before '='
            var beforeEq = original;
            var eqIndex = original.IndexOf('=');
            if (eqIndex >= 0)
                beforeEq = original.Substring(0, eqIndex);

            var expr = PrepareExpressionForCompute(beforeEq);

            // remove trailing operator if any
            while (expr.Length > 0 && IsOperator(expr.Last().ToString()))
                expr = expr.Substring(0, expr.Length - 1);

            if (string.IsNullOrWhiteSpace(expr))
            {
                textBoxResult.Text = string.Empty;
                return;
            }

            try
            {
                var value = EvaluateExpression(beforeEq);
                textBoxResult.Text = value;
                // clear tokens and set currentOperand to result so further calculations can continue
                tokens.Clear();
                currentOperand = value;
                // show expression with result appended
                textBoxExpression.Text = beforeEq + "=" + value;
            }
            catch
            {
                textBoxResult.Text = "Error";
            }
        }

        private static bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "X" || s == "x" || s == "×" || s == "*" || s == "÷" || s == "/";
        }

        // Treat parentheses as separators when scanning operands
        private static bool IsSeparator(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s == "(" || s == ")") return true;
            return IsOperator(s);
        }

        // Prepare expression for evaluation:
        // - map displayed operators to compute-friendly ones
        // - remove spaces
        // - insert '*' for implicit multiplication, e.g. "2(3+4)" -> "2*(3+4)", "(2)(3)" -> "(2)*(3)", "2)3" -> "2)*3"
        private static string PrepareExpressionForCompute(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            // Map display operators and superscripts to compute-friendly ones
            var src = s.Replace("X", "*").Replace("x", "*").Replace("×", "*")
                       .Replace("÷", "/").Replace("\u00B2", "^2").Replace("\u00B3", "^3").Replace(" ", string.Empty);
            var sb = new StringBuilder();
            for (int i = 0; i < src.Length; i++)
            {
                char c = src[i];
                sb.Append(c);
                if (i < src.Length - 1)
                {
                    char n = src[i + 1];
                    // insert '*' when: digit or '.' or ')' is followed by '(', or ')' followed by digit or '.'
                    if ((char.IsDigit(c) || c == '.' || c == ')') && n == '(')
                    {
                        sb.Append('*');
                    }
                    else if (c == ')' && (char.IsDigit(n) || n == '.'))
                    {
                        sb.Append('*');
                    }
                }
            }
            return sb.ToString();
        }

        // Evaluate arithmetic expression supporting + - * / ^ and parentheses.
        // Uses shunting-yard to handle precedence and associativity, then evaluates RPN.
        private static string EvaluateExpression(string expr)
        {
            var src = PrepareExpressionForCompute(expr);
            if (string.IsNullOrWhiteSpace(src)) return string.Empty;

            // Tokenize
            var tokens = new List<string>();
            for (int i = 0; i < src.Length; i++)
            {
                char c = src[i];
                if (char.IsWhiteSpace(c)) continue;

                // number (may include leading '-')
                if (char.IsDigit(c) || c == '.' || (c == '-' && (i == 0 || src[i - 1] == '(' || IsOperator(src[i - 1].ToString())) && i + 1 < src.Length && (char.IsDigit(src[i + 1]) || src[i + 1] == '.')))
                {
                    int j = i;
                    if (src[j] == '-') j++;
                    while (j < src.Length && (char.IsDigit(src[j]) || src[j] == '.')) j++;
                    tokens.Add(src.Substring(i, j - i));
                    i = j - 1;
                    continue;
                }

                // unary minus before '(', convert to 0 - (...)
                if (c == '-' && (i == 0 || src[i - 1] == '(' || IsOperator(src[i - 1].ToString())) && i + 1 < src.Length && src[i + 1] == '(')
                {
                    tokens.Add("0");
                    tokens.Add("-");
                    continue;
                }

                // operators and parentheses
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '(' || c == ')')
                {
                    tokens.Add(c.ToString());
                    continue;
                }

                // unknown char
                throw new ArgumentException($"Invalid character in expression: {c}");
            }

            // Shunting-yard to RPN
            var output = new List<string>();
            var ops = new Stack<string>();

            int Prec(string op) => op == "+" || op == "-" ? 2 : (op == "*" || op == "/" ? 3 : (op == "^" ? 4 : 0));
            bool IsRightAssoc(string op) => op == "^";

            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    output.Add(token);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/" || token == "^")
                {
                    while (ops.Count > 0)
                    {
                        var top = ops.Peek();
                        if (top == "(") break;
                        int p1 = Prec(token);
                        int p2 = Prec(top);
                        if ((IsRightAssoc(token) && p1 < p2) || (!IsRightAssoc(token) && p1 <= p2))
                        {
                            output.Add(ops.Pop());
                            continue;
                        }
                        break;
                    }
                    ops.Push(token);
                }
                else if (token == "(")
                {
                    ops.Push(token);
                }
                else if (token == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                        output.Add(ops.Pop());
                    if (ops.Count == 0 || ops.Pop() != "(")
                        throw new ArgumentException("Mismatched parentheses");
                }
                else
                {
                    throw new ArgumentException($"Unknown token: {token}");
                }
            }

            while (ops.Count > 0)
            {
                var t = ops.Pop();
                if (t == "(" || t == ")") throw new ArgumentException("Mismatched parentheses");
                output.Add(t);
            }

            // Evaluate RPN
            var st = new Stack<double>();
            foreach (var tk in output)
            {
                if (double.TryParse(tk, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    st.Push(num);
                }
                else
                {
                    if (st.Count < 2) throw new ArgumentException("Invalid expression");
                    var b = st.Pop();
                    var a = st.Pop();
                    double r = tk switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        "^" => Math.Pow(a, b),
                        _ => throw new ArgumentException($"Unsupported operator: {tk}")
                    };
                    st.Push(r);
                }
            }

            if (st.Count != 1) throw new ArgumentException("Invalid expression");
            return st.Pop().ToString(CultureInfo.InvariantCulture);
        }

        // Find the start index of the last operand in the expression string.
        // This treats a leading '-' as part of the operand when it represents a sign
        // (i.e. at the beginning of the expression or following another operator or '(' ).
        private static int FindLastOperandStart(string expr)
        {
            if (string.IsNullOrEmpty(expr)) return 0;
            int idx = expr.Length - 1;
            while (idx >= 0 && !IsSeparator(expr[idx].ToString())) idx--;

            // If the character at idx is '-' it might be a sign for the operand.
            if (idx >= 0 && expr[idx] == '-')
            {
                // treat '-' as sign when it's at the start or preceded by an operator or '('
                if (idx == 0 || IsOperator(expr[idx - 1].ToString()) || expr[idx - 1] == '(')
                {
                    return idx; // include the '-' as part of operand
                }
            }

            return idx + 1;
        }

        private void textBoxExpression_TextChanged(object sender, EventArgs e)
        {
            // Handle manual '=' typing: if expression ends with '=' compute and append result
            var expr = textBoxExpression.Text ?? string.Empty;
            var eqIndex = expr.IndexOf('=');
            if (eqIndex >= 0)
            {
                // If there's already something after '=', treat it as the current operand/result and do nothing
                if (eqIndex < expr.Length - 1)
                {
                    currentOperand = expr.Substring(eqIndex + 1);
                    textBoxResult.Text = currentOperand;
                    return;
                }

                // Expression ends with '=' -> evaluate the part before '=' and append the result
                var beforeEq = expr.Substring(0, eqIndex);
                var eval = beforeEq.Replace("X", "*").Replace("x", "*").Replace("×", "*").Replace("÷", "/");
                while (eval.Length > 0 && IsOperator(eval.Last().ToString()))
                    eval = eval.Substring(0, eval.Length - 1);
                if (string.IsNullOrWhiteSpace(eval))
                {
                    textBoxResult.Text = string.Empty;
                    return;
                }

                try
                {
                    var value = EvaluateExpression(beforeEq);
                    // append result after '='; this will re-enter TextChanged but the guard above prevents recomputation
                    textBoxExpression.Text = beforeEq + "=" + value;
                    textBoxResult.Text = value;
                    tokens.Clear();
                    currentOperand = value;
                }
                catch
                {
                    textBoxResult.Text = "Error";
                }

                return;
            }

            // keep behavior minimal: when user types directly in expression, update current operand and result preview
            int start = FindLastOperandStart(expr);
            currentOperand = start < expr.Length ? expr.Substring(start) : string.Empty;
            textBoxResult.Text = currentOperand;
=======
>>>>>>> parent of 1e41e7a (과제1 코딩과 테스트 완료)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show exponent form for square: append ^2 to the last operand
            if (string.IsNullOrEmpty(currentOperand)) return;

            var expr = textBoxExpression.Text ?? string.Empty;
            int start = FindLastOperandStart(expr);
            var prefix = start > 0 ? expr.Substring(0, start) : string.Empty;
            textBoxExpression.Text = prefix + currentOperand + "\u00B2";
            currentOperand = currentOperand + "\u00B2";
            textBoxResult.Clear();
        }

        private void BtnCube_Click(object? sender, EventArgs e)
        {
            // Show exponent form for cube: append ^3 to the last operand
            if (string.IsNullOrEmpty(currentOperand)) return;

            var expr = textBoxExpression.Text ?? string.Empty;
            int start = FindLastOperandStart(expr);
            var prefix = start > 0 ? expr.Substring(0, start) : string.Empty;
            textBoxExpression.Text = prefix + currentOperand + "\u00B3";
            currentOperand = currentOperand + "\u00B3";
            textBoxResult.Clear();
        }
    }
}
