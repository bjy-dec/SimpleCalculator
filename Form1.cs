using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{

    public partial class Form1 : Form
    {
        private string currentOperand = string.Empty;
        private List<string> tokens = new List<string>();

        public Form1()
        {
            InitializeComponent();
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
            // Clear current entry
            currentOperand = string.Empty;
            // remove trailing operand from expression
            // simple approach: remove text after last operator
            var expr = textBoxExpression.Text;
            int idx = expr.Length - 1;
            while (idx >= 0 && !IsOperator(expr[idx].ToString())) idx--;
            textBoxExpression.Text = idx >= 0 ? expr.Substring(0, idx + 1) : string.Empty;
            textBoxResult.Clear();
        }

        private void BtnDel_Click(object? sender, EventArgs e)
        {
            var expr = textBoxExpression.Text;
            if (expr.Length == 0) return;
            // remove last char
            expr = expr.Substring(0, expr.Length - 1);
            textBoxExpression.Text = expr;

            // update currentOperand by scanning back from end until operator
            int idx = expr.Length - 1;
            var operand = string.Empty;
            while (idx >= 0 && !IsOperator(expr[idx].ToString()))
            {
                operand = expr[idx] + operand;
                idx--;
            }
            currentOperand = operand;
            textBoxResult.Text = currentOperand;
        }

        private void BtnPM_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperand)) return;
            if (currentOperand.StartsWith("-"))
                currentOperand = currentOperand.Substring(1);
            else
                currentOperand = "-" + currentOperand;

            // rebuild expression: replace last operand in expression
            var expr = textBoxExpression.Text;
            int idx = expr.Length - 1;
            while (idx >= 0 && !IsOperator(expr[idx].ToString())) idx--;
            textBoxExpression.Text = (idx >= 0 ? expr.Substring(0, idx + 1) : string.Empty) + currentOperand;
            textBoxResult.Text = currentOperand;
        }

        private void BtnResult_Click(object? sender, EventArgs e)
        {
            // push last operand
            if (!string.IsNullOrEmpty(currentOperand))
            {
                tokens.Add(currentOperand);
            }

            // build evaluable expression
            var expr = textBoxExpression.Text.Replace("X", "*").Replace("x", "*").Replace("÷", "/");
            try
            {
                var dt = new DataTable();
                var value = dt.Compute(expr, null);
                textBoxResult.Text = value.ToString();
                // clear tokens and set currentOperand to result so further calculations can continue
                tokens.Clear();
                currentOperand = value.ToString();
                textBoxExpression.Text = expr; // keep expression as entered (mapped operators)
            }
            catch
            {
                textBoxResult.Text = "Error";
            }
        }

        private static bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "X" || s == "x" || s == "*" || s == "÷" || s == "/";
        }

        private void textBoxExpression_TextChanged(object sender, EventArgs e)
        {
            // keep behavior minimal: when user types directly in expression, update current operand and result preview
            var expr = textBoxExpression.Text;
            int idx = expr.Length - 1;
            var operand = string.Empty;
            while (idx >= 0 && !IsOperator(expr[idx].ToString()))
            {
                operand = expr[idx] + operand;
                idx--;
            }
            currentOperand = operand;
            textBoxResult.Text = currentOperand;
        }
    }
}
