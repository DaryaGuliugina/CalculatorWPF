using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private bool isNumber;
        private bool isChange;
        public MainWindow()
        {
            InitializeComponent();
            inputBox.Text = "0";
            isNumber = true;
            isChange = false;
        }
        private void inputNumber(char number)
        {
            isChange = true;
            if (isNumber)
                inputBox.Clear();
            inputBox.Text += number;
            isNumber = false;
        }
        private void oneBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('1');
        }
        private void twoBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('2');
        }
        private void threeBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('3');
        }
        private void fourBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('4');
        }
        private void fiveBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('5');
        }
        private void sixBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('6');
        }
        private void sevenBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('7');
        }
        private void eightBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('8');
        }
        private void nineBtn_Click(object sender, RoutedEventArgs e)
        {
            inputNumber('9');
        }
        private void zeroBtn_Click(object sender, RoutedEventArgs e)
        {
            if (inputBox.Text != "0")
            {
                inputNumber('0');
            }
        }
        private void Check()
        {
            if (showBox.Text.IndexOf('+') != -1 ||
                showBox.Text.IndexOf('-') != -1 ||
                showBox.Text.IndexOf('*') != -1 ||
                showBox.Text.IndexOf('/') != -1)
            {
                Calculate();
            }
        }
        private void Calculate()
        {
            if (showBox.Text.IndexOf('+') != -1)
            {
                inputBox.Text = (double.Parse(showBox.Text.Substring(0, showBox.Text.IndexOf('+'))) + double.Parse(inputBox.Text)).ToString();
            }
            else if (showBox.Text.IndexOf('-') != -1)
            {
                inputBox.Text = (double.Parse(showBox.Text.Substring(0, showBox.Text.LastIndexOf('-'))) - double.Parse(inputBox.Text)).ToString();
            }
            else if (showBox.Text.IndexOf('*') != -1)
            {
                inputBox.Text = (double.Parse(showBox.Text.Substring(0, showBox.Text.IndexOf('*'))) * double.Parse(inputBox.Text)).ToString();
            }
            else if (showBox.Text.IndexOf('/') != -1)
            {
                inputBox.Text = (double.Parse(showBox.Text.Substring(0, showBox.Text.IndexOf('/'))) / double.Parse(inputBox.Text)).ToString();
            }
        }
        private void Operation(char op)
        {
            if (isChange)
            {
                if (inputBox.Text[inputBox.Text.Length - 1] == ',')
                    inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 1);
                if (showBox.Text.LastIndexOf('=') == -1)
                {
                    Check();
                }
                showBox.Text = inputBox.Text;
                showBox.Text += op;
                isNumber = true;
                isChange = false;
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Operation('+');
        }
        private void subBtn_Click(object sender, RoutedEventArgs e)
        {
            Operation('-');
        }
        private void multBtn_Click(object sender, RoutedEventArgs e)
        {
            Operation('*');
        }
        private void divBtn_Click(object sender, RoutedEventArgs e)
        {
            Operation('/');
        }
        private void resultBtn_Click(object sender, RoutedEventArgs e)
        {
            if (showBox.Text.LastIndexOf('=') == -1)
            {
                if (inputBox.Text[inputBox.Text.Length - 1] == ',')
                    inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 1);
                showBox.Text += inputBox.Text;
                showBox.Text += "=";
                Calculate();
                isChange = true;
                isNumber = true;
            }
        }
        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (inputBox.Text.IndexOf(',') == -1)
            {
                inputBox.Text += ',';
                isNumber = false;
            }
        }
        private void clearSymbolBtn_Click(object sender, RoutedEventArgs e)
        {
            if (inputBox.Text.Length > 1)
            {
                inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 1);
            }
            else if (inputBox.Text.Length <= 1)
            {
                inputBox.Text = "0";
                isNumber = true;
            }
        }
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (showBox.Text.IndexOf('=') != -1)
                showBox.Clear();
            inputBox.Text = "0";
            isNumber = true;
        }
        private void clearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            showBox.Clear();
            inputBox.Text = "0";
            isNumber = true;
        }
    }
}
