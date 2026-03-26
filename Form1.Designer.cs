namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxExpression = new TextBox();
            textBoxResult = new TextBox();
            label1 = new Label();
            btnCE = new Button();
            btnC = new Button();
            btnDel = new Button();
            btnDivide = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnMultiply = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMinus = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnPlus = new Button();
            btnPM = new Button();
            btn0 = new Button();
            btnDot = new Button();
            btnResult = new Button();
            SuspendLayout();
            // 
            // textBoxExpression
            // 
            textBoxExpression.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textBoxExpression.Location = new Point(139, 99);
            textBoxExpression.Name = "textBoxExpression";
            textBoxExpression.Size = new Size(391, 29);
            textBoxExpression.TabIndex = 0;
            textBoxExpression.TextChanged += textBoxExpression_TextChanged;
            // 
            // textBoxResult
            // 
            textBoxResult.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textBoxResult.Location = new Point(139, 134);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(391, 29);
            textBoxResult.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 36F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(123, 20);
            label1.Name = "label1";
            label1.Size = new Size(426, 65);
            label1.TabIndex = 2;
            label1.Text = "Simple Calculator";
            // 
            // btnCE
            // 
            btnCE.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnCE.Location = new Point(139, 188);
            btnCE.Name = "btnCE";
            btnCE.Size = new Size(75, 40);
            btnCE.TabIndex = 3;
            btnCE.Text = "CE";
            btnCE.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            btnC.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnC.Location = new Point(241, 191);
            btnC.Name = "btnC";
            btnC.Size = new Size(75, 39);
            btnC.TabIndex = 4;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            btnDel.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnDel.Location = new Point(344, 189);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 37);
            btnDel.TabIndex = 5;
            btnDel.Text = "del";
            btnDel.UseVisualStyleBackColor = true;
            // 
            // btnDivide
            // 
            btnDivide.BackColor = SystemColors.ControlLightLight;
            btnDivide.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnDivide.ForeColor = Color.Red;
            btnDivide.Location = new Point(453, 189);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(77, 37);
            btnDivide.TabIndex = 6;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            btn7.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn7.ForeColor = Color.FromArgb(0, 0, 192);
            btn7.Location = new Point(140, 242);
            btn7.Name = "btn7";
            btn7.Size = new Size(74, 36);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn8.ForeColor = Color.Blue;
            btn8.Location = new Point(241, 242);
            btn8.Name = "btn8";
            btn8.Size = new Size(75, 36);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn9.ForeColor = Color.FromArgb(0, 0, 192);
            btn9.Location = new Point(344, 242);
            btn9.Name = "btn9";
            btn9.Size = new Size(75, 36);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            // 
            // btnMultiply
            // 
            btnMultiply.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnMultiply.ForeColor = Color.Red;
            btnMultiply.Location = new Point(453, 242);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(77, 36);
            btnMultiply.TabIndex = 10;
            btnMultiply.Text = "X";
            btnMultiply.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn4.ForeColor = Color.FromArgb(0, 0, 192);
            btn4.Location = new Point(139, 292);
            btn4.Name = "btn4";
            btn4.Size = new Size(75, 39);
            btn4.TabIndex = 11;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn5.ForeColor = Color.FromArgb(0, 0, 192);
            btn5.Location = new Point(241, 292);
            btn5.Name = "btn5";
            btn5.Size = new Size(75, 39);
            btn5.TabIndex = 12;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn6.ForeColor = Color.FromArgb(0, 0, 192);
            btn6.Location = new Point(344, 292);
            btn6.Name = "btn6";
            btn6.Size = new Size(75, 39);
            btn6.TabIndex = 13;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            // 
            // btnMinus
            // 
            btnMinus.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnMinus.ForeColor = Color.Red;
            btnMinus.Location = new Point(453, 292);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(77, 39);
            btnMinus.TabIndex = 14;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn1.ForeColor = Color.FromArgb(0, 0, 192);
            btn1.Location = new Point(140, 348);
            btn1.Name = "btn1";
            btn1.Size = new Size(74, 38);
            btn1.TabIndex = 15;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn2.ForeColor = Color.FromArgb(0, 0, 192);
            btn2.Location = new Point(241, 348);
            btn2.Name = "btn2";
            btn2.Size = new Size(75, 38);
            btn2.TabIndex = 16;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn3.ForeColor = Color.FromArgb(0, 0, 192);
            btn3.Location = new Point(344, 348);
            btn3.Name = "btn3";
            btn3.Size = new Size(75, 38);
            btn3.TabIndex = 17;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnPlus.ForeColor = Color.Red;
            btnPlus.Location = new Point(453, 348);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(77, 38);
            btnPlus.TabIndex = 18;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            // 
            // btnPM
            // 
            btnPM.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnPM.ForeColor = Color.Black;
            btnPM.Location = new Point(140, 400);
            btnPM.Name = "btnPM";
            btnPM.Size = new Size(74, 38);
            btnPM.TabIndex = 19;
            btnPM.Text = "+/-";
            btnPM.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btn0.ForeColor = Color.FromArgb(0, 0, 192);
            btn0.Location = new Point(241, 400);
            btn0.Name = "btn0";
            btn0.Size = new Size(74, 38);
            btn0.TabIndex = 20;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            // 
            // btnDot
            // 
            btnDot.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnDot.ForeColor = Color.Black;
            btnDot.Location = new Point(345, 400);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(74, 38);
            btnDot.TabIndex = 21;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            // 
            // btnResult
            // 
            btnResult.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnResult.ForeColor = Color.Black;
            btnResult.Location = new Point(456, 400);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(74, 38);
            btnResult.TabIndex = 22;
            btnResult.Text = "=";
            btnResult.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnResult);
            Controls.Add(btnDot);
            Controls.Add(btn0);
            Controls.Add(btnPM);
            Controls.Add(btnPlus);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btnMinus);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btnMultiply);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btnDivide);
            Controls.Add(btnDel);
            Controls.Add(btnC);
            Controls.Add(btnCE);
            Controls.Add(label1);
            Controls.Add(textBoxResult);
            Controls.Add(textBoxExpression);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxExpression;
        private TextBox textBoxResult;
        private Label label1;
        private Button btnCE;
        private Button btnC;
        private Button btnDel;
        private Button btnDivide;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnMultiply;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMinus;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnPlus;
        private Button btnPM;
        private Button btn0;
        private Button btnDot;
        private Button btnResult;
    }
}
