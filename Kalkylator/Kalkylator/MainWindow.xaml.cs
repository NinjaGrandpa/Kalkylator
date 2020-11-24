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

namespace Kalkylator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int symbolCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            NumpadText.Text = String.Empty;
            symbolCount = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (e.Source is Button button)
            {
                NumpadText.Text += button.Content;
            }
        }

        private void ButtonOp_Click(object sender, RoutedEventArgs e)
        {
            if (symbolCount == 0)
            {
                if (e.Source is Button button)
                {
                    NumpadText.Text += button.Content;
                }
            }

            symbolCount++;

        }

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            String[] numbers = NumpadText.Text.Split('+', '-', '*', '/');

            var number1 = Convert.ToDouble(numbers[0]);
            var number2 = Convert.ToDouble(numbers[1]);
            var answer = 0.00;

            if (NumpadText.Text.Contains('+'))
            {
                answer = number1 + number2;
            }

            else if (NumpadText.Text.Contains('-'))
            {
                answer = number1 - number2;
            }

            else if (NumpadText.Text.Contains('*'))
            {
                answer = number1 * number2;   
            }

            else if (NumpadText.Text.Contains('/'))
            {
                answer = number1 / number2;
            }

            NumpadText.Text = Convert.ToString(answer);

            symbolCount = 0;

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (NumpadText.Text.Length > 0)
            {
                NumpadText.Text = NumpadText.Text.Substring(0, NumpadText.Text.Length - 1);
            }
        }
    }
}
