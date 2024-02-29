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

        // ��ʼ��������
        private void InitializeCalculator()
        {
            cmbOperator.Items.Add("+");
            cmbOperator.Items.Add("-");
            cmbOperator.Items.Add("*");
            cmbOperator.Items.Add("/");
            cmbOperator.SelectedIndex = 0;
        }

        // ��ť����¼���ִ�м���
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!IsValidNumber(txtNumber1.Text) || !IsValidNumber(txtNumber2.Text))
            {
                MessageBox.Show("��������Ч�����֣�");
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
                        MessageBox.Show("��������Ϊ�㣡");
                        return;
                    }
                    result = number1 / number2;
                    break;
            }

            lblResult.Text = result.ToString();
        }

        // �������������Ƿ���Ч
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
