using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const string inputPattern = @"^\d*,?\d*[+\-x÷]?(\d*.?\d*)?$";
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
        if (display.Length == 1 || display.Length == 2 && display.Contains('-'))
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
        string num = (sender as Button).Content.ToString();

        if (display[0] == '0' && num == "0") { return; }
        if (ClearScreen) { display = ""; }

        var nextDisplay = display + num;

        if (!InputPattern().Match(nextDisplay).Success)
        {
            return;
        }

        display = nextDisplay;
        ClearScreen = false;
        Update();
    }

    private void Arytmetyka(object sender, RoutedEventArgs e)
    {
        string art = (sender as Button).Content.ToString();
        var nextDisplay = display + art;

        if (!InputPattern().Match(nextDisplay).Success)
        {
            return;
        }

        display = nextDisplay;
        ClearScreen = false;
        Update();
    }

    private void Przecinek(object sender, RoutedEventArgs e)
    {
        var nextDisplay = display + ',';

        if (!InputPattern().Match(nextDisplay).Success)
        {
            return;
        }

        display = nextDisplay;
        ClearScreen = false;
        Update();
    }

    public void Rownanie(object sender, RoutedEventArgs e)
    {
        ClearScreen = true;
        display = Obliczenia.CalculateString(display).ToString();
        Update();
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }

    private void Update()
    {
        WynikEkran.Text = display;
    }

    [GeneratedRegex(inputPattern)]
    private static partial Regex InputPattern();
}