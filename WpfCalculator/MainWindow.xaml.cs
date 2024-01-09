using System.Diagnostics;
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
        private string Value { get; set; } = "0";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumpadClick(object sender, RoutedEventArgs e)
        {
            string ButtonNumber = ((Button)sender).Content.ToString();

            Value += ButtonNumber;
            if (Value[0] == '0' && (Value.Length > 1))
            {
               Value = Value.TrimStart('0');
                Debug.WriteLine(Value);
            }
            ResultLabel.Content = Value;


        }
        private void UtilityClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Backspace")
            {
                Value = Value.Remove(Value.Length - 1);
            }
            if(Value.Length == 0)
            {
                Value = "0";
            }
            ResultLabel.Content = Value;
        }   
    }

}