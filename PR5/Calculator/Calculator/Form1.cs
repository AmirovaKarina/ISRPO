using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private double result = 0;
        private string operation = "";
        private bool isNewInput = true;
        private bool isDegreeMode = true;
        private CultureInfo culture = CultureInfo.InvariantCulture;
        private bool decimalPointAdded = false;
        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            btn0.Click += (s, e) => AppendNumber("0");
            btn1.Click += (s, e) => AppendNumber("1");
            btn2.Click += (s, e) => AppendNumber("2");
            btn3.Click += (s, e) => AppendNumber("3");
            btn4.Click += (s, e) => AppendNumber("4");
            btn5.Click += (s, e) => AppendNumber("5");
            btn6.Click += (s, e) => AppendNumber("6");
            btn7.Click += (s, e) => AppendNumber("7");
            btn8.Click += (s, e) => AppendNumber("8");
            btn9.Click += (s, e) => AppendNumber("9");

            btnPlus.Click += (s, e) => SetOperation("+");
            btnMinus.Click += (s, e) => SetOperation("-");
            btnMultiply.Click += (s, e) => SetOperation("*");
            btnDivide.Click += (s, e) => SetOperation("/");
            btnPower.Click += (s, e) => SetOperation("^");
            btnEquals.Click += (s, e) => PerformCalculation();

            btnSqrt.Click += (s, e) => ApplyFunction(x => Math.Sqrt(x), "sqrt");
            btnSin.Click += (s, e) => ApplyTrigonometricFunction(x => Math.Sin(x), "sin");
            btnCos.Click += (s, e) => ApplyTrigonometricFunction(x => Math.Cos(x), "cos");
            btnTan.Click += (s, e) => ApplyTrigonometricFunction(x => Math.Tan(x), "tan");
            btnLn.Click += (s, e) => ApplyFunction(x => Math.Log(x), "ln");
            btnLog.Click += (s, e) => ApplyFunction(x => Math.Log10(x), "log");
            btnAbs.Click += (s, e) => ApplyFunction(x => Math.Abs(x), "abs");

            btnChangeSign.Click += (s, e) => ChangeSign();
            btnDecimal.Click += (s, e) => AddDecimalPoint();
            btnComma.Click += (s, e) => AddDecimalPoint();

            btnPi.Click += (s, e) => AppendConstant(Math.PI.ToString(), "Pi");
            btnE.Click += (s, e) => AppendConstant(Math.E.ToString(), "e");
            btnAns.Click += (s, e) => AppendConstant(result.ToString(), "Ans");

            btnOpenParenthesis.Click += (s, e) => AppendNumber("(");
            btnCloseParenthesis.Click += (s, e) => AppendNumber(")");

            btnClear.Click += (s, e) => Clear();
            btnDelete.Click += (s, e) => DeleteLastCharacter();

            btnSum.Click += (s, e) => CalculateSumOfDigits();

            UpdateDisplay();
        }

        private void AppendNumber(string number)
        {
            if (isNewInput)
            {
                currentInput = number;
                isNewInput = false;
            }
            else
            {
                currentInput += number;
            }
            UpdateDisplay();
        }

        private void AddDecimalPoint()
        {
            if (isNewInput)
            {
                currentInput = "0.";
                isNewInput = false;
                decimalPointAdded = true;
            }
            else if (!decimalPointAdded)
            {
                if (currentInput == "" || currentInput == "-")
                {
                    currentInput += "0";
                }
                currentInput += ".";
                decimalPointAdded = true;
            }
            UpdateDisplay();
        }
        private void AddComma()
        {
            AddDecimalPoint();
        }

        private void AppendConstant(string value, string displayName)
        {
            currentInput = value;
            isNewInput = true;
            decimalPointAdded = value.Contains(".");
            UpdateDisplay();
        }

        private void SetOperation(string op)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    PerformCalculation();
                }

                try
                {
                    result = double.Parse(currentInput, culture);
                    operation = op;
                    isNewInput = true;
                    decimalPointAdded = false;
                }
                catch (FormatException)
                {
                    ShowError("Некорректный формат числа");
                }
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                operation = op;
            }
        }

        private void PerformCalculation()
        {
            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    double secondNumber = double.Parse(currentInput, culture);

                    switch (operation)
                    {
                        case "+":
                            result += secondNumber;
                            break;
                        case "-":
                            result -= secondNumber;
                            break;
                        case "*":
                            result *= secondNumber;
                            break;
                        case "/":
                            if (Math.Abs(secondNumber) > double.Epsilon)
                                result /= secondNumber;
                            else
                            {
                                ShowError("Деление на ноль!");
                                return;
                            }
                            break;
                        case "^":
                            result = Math.Pow(result, secondNumber);
                            break;
                    }

                    currentInput = result.ToString(culture);
                    operation = "";
                    isNewInput = true;
                    decimalPointAdded = currentInput.Contains(".");
                    UpdateDisplay();
                }
                catch (FormatException)
                {
                    ShowError("Некорректный формат числа");
                }
                catch (OverflowException)
                {
                    ShowError("Результат слишком большой или слишком малый");
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void ApplyFunction(Func<double, double> func, string funcName)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    double num = double.Parse(currentInput, culture);

                    if (funcName == "√" && num < 0)
                    {
                        ShowError("Квадратный корень из отрицательного числа!");
                        return;
                    }

                    if ((funcName == "ln" || funcName == "log") && num <= 0)
                    {
                        ShowError("Логарифм определен только для положительных чисел!");
                        return;
                    }

                    double result = func(num);
                    currentInput = result.ToString(culture);
                    decimalPointAdded = currentInput.Contains(".");
                    UpdateDisplay();
                }
                catch (FormatException)
                {
                    ShowError("Некорректный формат числа");
                }
                catch (OverflowException)
                {
                    ShowError("Результат слишком большой или слишком малый");
                }
            }
        }


        private void ApplyTrigonometricFunction(Func<double, double> func, string funcName)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    double angle = double.Parse(currentInput, culture);

                    if (isDegreeMode)
                    {
                        angle = angle * Math.PI / 180.0;
                    }

                    double result = func(angle);

                    if (funcName == "tan" && Math.Abs(Math.Cos(angle)) < 1e-10)
                    {
                        ShowError("Тангенс не определен для данного угла");
                        return;
                    }

                    currentInput = result.ToString(culture);
                    decimalPointAdded = currentInput.Contains(".");
                    UpdateDisplay();
                }
                catch (FormatException)
                {
                    ShowError("Некорректный формат числа");
                }
            }
        }

        private void ChangeSign()
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    double num = double.Parse(currentInput, culture);
                    currentInput = (-num).ToString(culture);
                    UpdateDisplay();
                }
                catch (FormatException)
                {
                    if (currentInput.StartsWith("-"))
                    {
                        currentInput = currentInput.Substring(1);
                    }
                    else
                    {
                        currentInput = "-" + currentInput;
                    }
                    UpdateDisplay();
                }
            }
            else
            {
                currentInput = "-";
                isNewInput = false;
                UpdateDisplay();
            }
        }


        private void CalculateSumOfDigits()
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    string input = currentInput.TrimEnd('.');

                    double sum = 0;
                    foreach (char c in input)
                    {
                        if (char.IsDigit(c))
                        {
                            sum += char.GetNumericValue(c);
                        }
                    }

                    currentInput = sum.ToString(culture);
                    decimalPointAdded = false;
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка вычисления суммы цифр: {ex.Message}");
                }
            }
        }

        private void DeleteLastCharacter()
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);

                decimalPointAdded = currentInput.Contains(".");

                if (string.IsNullOrEmpty(currentInput))
                {
                    currentInput = "0";
                    isNewInput = true;
                    decimalPointAdded = false;
                }

                UpdateDisplay();
            }
        }

        private void Clear()
        {
            currentInput = "";
            result = 0;
            operation = "";
            isNewInput = true;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                txtboxDisplay.Text = "0";
            }
            else
            {
                if (currentInput.Length > 30)
                {
                    txtboxDisplay.Text = currentInput.Substring(currentInput.Length - 30);
                }
                else
                {
                    txtboxDisplay.Text = currentInput;
                }
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Clear();
        }
    }
}
