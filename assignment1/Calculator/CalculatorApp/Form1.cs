using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        // 初始化计算器
        private void InitializeCalculator()
        {
            cmbOperator.Items.Add("+");
            cmbOperator.Items.Add("-");
            cmbOperator.Items.Add("*");
            cmbOperator.Items.Add("/");
            cmbOperator.SelectedIndex = 0;
        }

        // 按钮点击事件，执行计算
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!IsValidNumber(txtNumber1.Text) || !IsValidNumber(txtNumber2.Text))
            {
                MessageBox.Show("请输入有效的数字！");
                return;
            }

            double number1 = double.Parse(txtNumber1.Text);
            double number2 = double.Parse(txtNumber2.Text);

            double result = 0;
            switch (cmbOperator.SelectedItem.ToString())
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        MessageBox.Show("除数不能为零！");
                        return;
                    }
                    result = number1 / number2;
                    break;
            }

            lblResult.Text = result.ToString();
        }

        // 检查输入的数字是否有效
        private bool IsValidNumber(string text)
        {
            double number;
            return double.TryParse(text, out number);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
