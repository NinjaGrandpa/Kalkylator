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
        public int sqaureRoot = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            NumpadText.Text = String.Empty;
            symbolCount = 0;
            sqaureRoot = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!NumpadText.Text.Contains("^√"))
            {
                if (e.Source is Button button)
                {
                    NumpadText.Text += button.Content;
                }
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
            String[] numbers = NumpadText.Text.Split('+', '-', '*', '/', '^', '√');

            char[] opArray = { '+', '-', '*', '/', '^', '√' };
            char[] textArray = NumpadText.Text.ToCharArray();

           // for (int i = 0; i < opArray.Length; i++)
           // {
           //     if (textArray[0] == opArray[])
           //     {
           //
           //     }
           // }
           //
           //if (textArray[0] == )
           //{



                var answer = 0.00;
                var number1 = Convert.ToDouble(numbers[0]);
                var number2 = Convert.ToDouble(numbers[1]);


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

                else if (NumpadText.Text.Contains('^'))
                {
                    answer = Math.Pow(number1, number2);
                }

                else if (NumpadText.Text.Contains('√'))
                {
                    answer = Math.Pow(number1, 1 / number2);
                }


                NumpadText.Text = Convert.ToString(answer);

                symbolCount = 0;
            //}
            //
            //else
            //{
            //    NumpadText.Text = NumpadText.Text;
            //}

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (NumpadText.Text.Length > 0)
            {
                NumpadText.Text = NumpadText.Text.Substring(0, NumpadText.Text.Length - 1);

                if (!NumpadText.Text.Contains("^√+-*/"))
                {
                    symbolCount = 0;
                }
            }
        }
    }
}
