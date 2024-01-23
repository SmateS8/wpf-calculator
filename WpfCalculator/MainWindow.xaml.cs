using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Value1 { get; set; } = "0";
        private string Value2 { get; set; } = "0";
        private Boolean Pushed { get; set; } = false;
        private Boolean Totalled { get; set; } = false;
        private string ChosenOperation { get; set; } = string.Empty;
        private Boolean CleanOnType { get; set; } = false;
        private Boolean ChangedByUtility { get; set; } = false;
        private Boolean ConType { get; set; } = false;
        private string Value1BeforeEquals { get; set; } = "0";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Calculate(string ValueString)
        {
            double Value = double.Parse(ValueString);
            switch (ChosenOperation)
            {
                case "Plus":
                    Value2 = (double.Parse(Value2) + Value).ToString();
                    break;
                case "Minus":
                    Value2 = (double.Parse(Value2) - Value).ToString();
                    break;
                case "Multiplication":
                    Value2 = (double.Parse(Value2) * Value).ToString();
                    break;
                case "Division":
                    Value2 = (double.Parse(Value2) / Value).ToString();
                    break;
            }
        }
        private void DoClean()
        {
            Debug.WriteLine("C");
            Value1 = "0";
            Value2 = "0";
            Pushed = false;
            Totalled = false;
            ChosenOperation = string.Empty;
            CleanOnType = false;
            ChangedByUtility = false;
            ConType = false;
            Value1BeforeEquals = "0";
        }
        private void NumpadClick(object sender, RoutedEventArgs e)
        {
            string? ButtonNumber = ((Button)sender).Content.ToString();
            Totalled = false;
            if (ConType)
            {
                DoClean();
            }
            if (CleanOnType)
            {
                Value1 = "0";
                CleanOnType = false;
            }
            Value1 += ButtonNumber;
            Boolean isDecimal = false;
            for (int i = 0; i < Value1.Length; i++)
            {
                if (Value1[i] == ',')
                {
                    isDecimal = true;
                    break;
                }
            }
            if (!isDecimal)
            {

                if (Value1[0] == '0' && (Value1.Length > 1))
                {
                    Value1 = Value1.TrimStart('0');
                }
                if (Value1 == "")
                {
                    Value1 = "0";
                }
            }
            ResultLabel.Content = Value1;


        }
        private void UtilityClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Backspace" && !CleanOnType)
            {
                Value1 = Value1.Remove(Value1.Length - 1);
            }
            if (Value1.Length == 0)
            {
                Value1 = "0";
            }
            else
            {
                if (button.Name != "Equals" && button.Name != "Point")
                {
                    ConType = false;
                }
                switch (button.Name)
                {
                    case "Plus":
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            ChosenOperation = "Plus";
                            CleanOnType = true;
                            break;
                        }
                        if ((CleanOnType && !ChangedByUtility))
                        {
                            ChosenOperation = "Plus";
                            break;
                        }
                        Totalled = false;
                        ChangedByUtility = false;
                        if (!Pushed)
                        {
                            Value2 = Value1;
                            CleanOnType = true;
                            ChosenOperation = "Plus";
                        }
                        else
                        {
                            Calculate(Value1);
                            Value1 = Value2;
                            CleanOnType = true;
                            ChosenOperation = "Plus";
                        }
                        Pushed = true;

                        break;
                    case "Minus":
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            ChosenOperation = "Minus";
                            CleanOnType = true;
                            break;
                        }
                        if (CleanOnType && !ChangedByUtility)
                        {
                            ChosenOperation = "Minus";
                            break;
                        }
                        ChangedByUtility = false;
                        if (!Pushed)
                        {
                            Value2 = Value1;
                            CleanOnType = true;
                            ChosenOperation = "Minus";
                        }
                        else
                        {
                            Calculate(Value1);
                            Value1 = Value2;
                            CleanOnType = true;
                            ChosenOperation = "Minus";
                        }
                        Pushed = true;

                        break;
                    case "Multiplication":
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            ChosenOperation = "Multiplication";
                            CleanOnType = true;
                            break;
                        }
                        if (CleanOnType && !ChangedByUtility)
                        {
                            ChosenOperation = "Multiplication";
                            break;
                        }
                        ChangedByUtility = false;
                        if (!Pushed)
                        {
                            Value2 = Value1;
                            CleanOnType = true;
                            ChosenOperation = "Multiplication";
                        }
                        else
                        {
                            Calculate(Value1);
                            Value1 = Value2;
                            CleanOnType = true;
                            ChosenOperation = "Multiplication";
                        }
                        Pushed = true;

                        break;
                    case "Division":
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            ChosenOperation = "Division";
                            CleanOnType = true;
                            break;
                        }
                        if (CleanOnType && !ChangedByUtility)
                        {
                            ChosenOperation = "Division";
                            break;
                        }
                        ChangedByUtility = false;
                        if (!Pushed)
                        {
                            Value2 = Value1;
                            CleanOnType = true;
                            ChosenOperation = "Division";
                        }
                        else
                        {
                            Calculate(Value1);
                            Value1 = Value2;
                            CleanOnType = true;
                            ChosenOperation = "Division";
                        }
                        Pushed = true;

                        break;
                    case "Invert":
                        if (Value1 != "0")
                        {
                            Value1 = ((double)1 / int.Parse(Value1)).ToString();
                        }
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            Value2 = Value1;
                        }
                        ChangedByUtility = true;
                        CleanOnType = true;
                        break;
                    case "Square":
                        Value1 = (double.Parse(Value1) * double.Parse(Value1)).ToString();
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            Value2 = Value1;
                        }
                        ChangedByUtility = true;
                        CleanOnType = true;
                        break;
                    case "Root":
                        Value1 = Math.Sqrt(double.Parse(Value1)).ToString();
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            Value2 = Value1;
                        }
                        ChangedByUtility = true;
                        CleanOnType = true;
                        break;
                    case "Point":
                        if (ConType)
                        {
                            DoClean();
                            Value1 = "0,";
                            break;
                        }
                        Boolean Found = false;
                        for (int i = 0; i < Value1.Length; i++)
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
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            Value2 = Value1;
                        }
                        ChangedByUtility = true;
                        CleanOnType = true;
                        break;
                    case "Percent":
                        Debug.WriteLine(ChosenOperation);
                        if(ChosenOperation == "Multiplication" || ChosenOperation == "Division")
                        {
                            Value1 = (double.Parse(Value1) / 100).ToString();
                        }
                        else
                        {
                            Value1 = (double.Parse(Value2) / 100 * double.Parse(Value1)).ToString();
                        }
                        
                        if (Totalled)
                        {
                            Value1BeforeEquals = Value1;
                            Value2 = Value1;
                        }
                        ChangedByUtility = true;
                        CleanOnType = true;
                        break;
                    case "CE":
                        Value1 = "0";
                        CleanOnType = false;
                        break;
                    case "C":
                        DoClean();
                        break;
                    case "Equals":
                        if (!Pushed)
                        {
                            break;
                        }
                        if (!Totalled)
                        {
                            Value1BeforeEquals = Value1;
                        }
                        Totalled = true;
                        Calculate(Value1BeforeEquals);
                        Value1 = Value2;
                        ConType = true;

                        break;
                }
            }

            //Debug.WriteLine(Value1);
            ResultLabel.Content = Value1;




        }
    }

}