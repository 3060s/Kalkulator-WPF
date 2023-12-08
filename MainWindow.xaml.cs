using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string display = "0";
        private bool ClearScreen = true;



        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Pierwiastek(object sender, RoutedEventArgs e)
        {

        }

        private void Potega(object sender, RoutedEventArgs e)
        {

        }

        private void Czyszczenie(object sender, RoutedEventArgs e)
        {
            display = "0";
            ClearScreen = true;
            Update();
        }

        private void Cofanie(object sender, RoutedEventArgs e)
        {
            if (display == "0") { return; }
            if (display.Length == 1 || display.Length == 2 && display.Contains("-"))
            {
                display = "0";
                ClearScreen = true;
            }
            else
            {
                display = display.Remove(display.Length - 1, 1);
            }
            Update();
        }

        private void Input(object sender, RoutedEventArgs e)
        {
            string num = (sender as Button).Name.ToString().Remove(0, 1);

            if (display[0] == '0' && num == "0") { return; }
            if (ClearScreen) { display = ""; }

            display += num;
            ClearScreen = false;
            Update();
        }

        private void Arytmetyka(object sender, RoutedEventArgs e)
        {

        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {

        }

        private void Rownanie(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Update()
        {
            WynikEkran.Text = display;
        }
    }
}