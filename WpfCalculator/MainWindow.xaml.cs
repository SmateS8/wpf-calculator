using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Value1 { get; set; } = "0";
        private string Value2 { get; set; } = "0";
        private Boolean OperationChosen { get; set; } = false;
        private string ChosenOperation { get; set; } = string.Empty;
        private Boolean CleanOnType { get; set; } = false;
        private Boolean CEonType { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumpadClick(object sender, RoutedEventArgs e)
        {
            string ButtonNumber = ((Button)sender).Content.ToString();
            if (CleanOnType)
            {
                Value1 = "0";
                CleanOnType = false;
            }
            Value1 += ButtonNumber;
            if (Value1[0] == '0' && (Value1.Length > 1))
            {
               Value1 = Value1.TrimStart('0');
                Debug.WriteLine(Value1);
            }
            ChosenOperation = string.Empty;
            ResultLabel.Content = Value1;


        }
        private void UtilityClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Backspace")
            {
                Value1 = Value1.Remove(Value1.Length - 1);
            }
            if(Value1.Length == 0)
            {
                Value1 = "0";
            }
            else
            {
                switch (button.Name)
                {
                    case "Plus":
                        if(ChosenOperation == "Plus")
                        {
                            Value2 = (double.Parse(Value2) + double.Parse(Value1)).ToString();
                            Value1 = Value2;
                        }
                        ChosenOperation = "Plus";
                        CleanOnType = true;
                        break;
                    case "Minus":
                        ChosenOperation = "Minus";
                        Value1 = (double.Parse(Value2) - double.Parse(Value1)).ToString();
                        Value2 = Value1;
                        CleanOnType = true;
                        break;
                    case "Invert":
                        if (Value1 != "0")
                        {
                            Value1 = ((double)1 / int.Parse(Value1)).ToString();
                            Value2 = Value1;
                        }
                        break;
                    case "Square":
                        Value1 = (double.Parse(Value1)* double.Parse(Value1)).ToString();
                        Value2 = Value1;
                        break;
                    case "Root":
                        Value1 = (Math.Sqrt(double.Parse(Value1))).ToString();
                        Value2 = Value1;
                        break;
                    case "Point":
                        Boolean Found = false;
                        for(int i = 0; i < Value1.Length; i++)
                        {
                            if (Value1[i] == ',')
                            {
                                Found = true;
                            }
                        }
                        if (!Found)
                        {
                            Value1 += ",";
                        }
                       
                        break;
                    case "Negate":
                        Value1 = (double.Parse(Value1) * -1).ToString();
                        break;
                    case "CE":
                        Value1="0";
                        break;
                    case "C":
                        Value1 = "0";
                        Value2 = "0";
                        ChosenOperation = string.Empty;
                        OperationChosen = false;
                        break;
                    default:
                        // code block
                        break;
                }
            }

            //Debug.WriteLine(Value1);
            if (CleanOnType) {
                ResultLabel.Content = Value2;
            }
            else
            {
                ResultLabel.Content = Value1;
            }
            
            


        }   
    }

}