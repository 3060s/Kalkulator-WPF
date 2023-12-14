namespace Kalkulator_WPF;

public class Obliczenia
{
    public static double CalculateString(string input)
    {
        var numbersStr = new string[2];
        var currentNumber = 0;
        char op = '\0';

        foreach (var c in input)
        {
            if (char.IsDigit(c) || c == ',')
            {
                numbersStr[currentNumber] += c;
            }
            else
            {
                op = c;
                currentNumber++;
            }
        }

        var number1 = double.Parse(numbersStr[0]);
        var number2 = double.Parse(numbersStr[1]);

        switch (op)
        {
            case '+':
                return number1 + number2;

            case '-':
                return number1 - number2;

            case 'x':
                return number1 * number2;

            case '÷':
                return number1 / number2;
        }

        return 0;
    }
}
