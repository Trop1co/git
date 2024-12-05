using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPosition = textBox1.SelectionStart;

            // Блокировка кириллических символов
            if ((e.KeyChar >= 'А' && e.KeyChar <= 'я') || (e.KeyChar >= 'Ё' && e.KeyChar <= 'ё'))
            {
                e.Handled = true;
                return;
            }

            // Разрешённые символы: цифры, знаки, управляющие символы
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                !char.IsLower(e.KeyChar) && e.KeyChar != '.' &&
                e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != '/' && e.KeyChar != '*')
            {
                e.Handled = true;
            }

            // Логика для знака минус
            if (e.KeyChar == '-')
            {
                // Проверка позиции курсора и длины строки перед обращением к предыдущему символу
                bool prevCharIsOperator = cursorPosition == 0 ||
                                          (cursorPosition > 0 && "+-*/".Contains(textBox1.Text[cursorPosition - 1]));

                if (prevCharIsOperator && cursorPosition > 0 && textBox1.Text[cursorPosition - 1] == '-')
                    e.Handled = true;
                else if (!prevCharIsOperator || (cursorPosition > 0 && char.IsDigit(textBox1.Text[cursorPosition - 1])))
                    e.Handled = false;
                else
                    e.Handled = true;
            }

            // Логика для точки
            if (e.KeyChar == '.')
            {
                bool foundDigit = false;
                for (int i = cursorPosition - 1; i >= 0; i--)
                {
                    if (char.IsDigit(textBox1.Text[i]))
                    {
                        foundDigit = true;
                        break;
                    }
                    if ("+-*/".Contains(textBox1.Text[i])) break;
                }
                e.Handled = !foundDigit ||
                            cursorPosition > 0 && (textBox1.Text[cursorPosition - 1] == '.' ||
                                                   (!char.IsDigit(textBox1.Text[cursorPosition - 1]) && textBox1.Text[cursorPosition - 1] != '-'));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void PerformArithmeticOperation()
        {
            string input = textBox1.Text;
            string pattern = @"([-]?\d+(\.\d+)?)[\s]*([+\-*/])[\s]*([-]?\d+(\.\d+)?)";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                try
                {
                    double num1 = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    string operation = match.Groups[3].Value;
                    double num2 = double.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);

                    double result = operation switch
                    {
                        "+" => num1 + num2,
                        "-" => num1 - num2,
                        "*" => num1 * num2,
                        "/" when num2 != 0 => num1 / num2,
                        "/" => throw new DivideByZeroException(),
                        _ => 0
                    };

                    textBox2.Text = Math.Round(result, 5).ToString(CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    textBox2.Text = "Ошибка ввода!";
                }
                catch (DivideByZeroException)
                {
                    textBox2.Text = "Ошибка: деление на 0!";
                }
            }
            else
            {
                textBox2.Text = "Неверный формат!";
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformArithmeticOperation();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Калькулятор";
            MaximizeBox = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int controlWidth = this.Width / 3;
            int controlHeight = this.Height / 3;

            textBox1.Width = controlWidth;
            textBox2.Width = controlWidth;
            button1.Width = controlWidth;
            button1.Height = controlHeight;
        }
    }
}
