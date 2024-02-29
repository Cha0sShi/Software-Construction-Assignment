namespace CalculatorApp
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
            txtNumber1 = new TextBox();
            txtNumber2 = new TextBox();
            lblResult = new TextBox();
            label1 = new Label();
            cmbOperator = new ComboBox();
            calculate = new Button();
            SuspendLayout();
            // 
            // txtNumber1
            // 
            txtNumber1.Location = new Point(70, 21);
            txtNumber1.Name = "txtNumber1";
            txtNumber1.Size = new Size(96, 23);
            txtNumber1.TabIndex = 0;
            // 
            // txtNumber2
            // 
            txtNumber2.Location = new Point(218, 21);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(96, 23);
            txtNumber2.TabIndex = 0;
            // 
            // lblResult
            // 
            lblResult.Location = new Point(372, 21);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(96, 23);
            lblResult.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 25);
            label1.Name = "label1";
            label1.Size = new Size(17, 17);
            label1.TabIndex = 2;
            label1.Text = "=";
            label1.Click += label1_Click;
            // 
            // cmbOperator
            // 
            cmbOperator.FormattingEnabled = true;
            cmbOperator.Location = new Point(172, 22);
            cmbOperator.Name = "cmbOperator";
            cmbOperator.Size = new Size(40, 25);
            cmbOperator.TabIndex = 3;
            // 
            // calculate
            // 
            calculate.Location = new Point(506, 19);
            calculate.Name = "calculate";
            calculate.Size = new Size(75, 23);
            calculate.TabIndex = 4;
            calculate.Text = "计算";
            calculate.UseVisualStyleBackColor = true;
            calculate.Click += btnCalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(calculate);
            Controls.Add(cmbOperator);
            Controls.Add(label1);
            Controls.Add(lblResult);
            Controls.Add(txtNumber2);
            Controls.Add(txtNumber1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumber1;
        private TextBox txtNumber2;
        private TextBox lblResult;
        private Label label1;
        private ComboBox cmbOperator;
        private Button calculate;
    }
}
