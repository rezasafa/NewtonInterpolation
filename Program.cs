using System;

class newtoninterpolation
{
    public static double[] divideddifference(double[] x, double[] y)
    {
        int n = x.Length;
        double[,] coeff = new double[n, n];

        for (int i = 0; i < n; i++)
            coeff[i, 0] = y[i];

        for (int j = 1; j < n; j++)
        {
            for (int i = 0; i < n - j; i++)
            {
                coeff[i, j] = (coeff[i + 1, j - 1] - coeff[i, j - 1]) / (x[i + j] - x[i]);
            }
        }

        double[] result = new double[n];
        for (int i = 0; i < n; i++)
            result[i] = coeff[0, i];

        return result;
    }

    public static double newtoninterpolationvalue(double[] x, double[] coeff, double value)
    {
        int n = coeff.Length;
        double result = coeff[0];
        double term = 1;

        for (int i = 1; i < n; i++)
        {
            term *= (value - x[i - 1]);
            result += coeff[i] * term;
        }

        return result;
    }

    static void Main()
    {
        double[] x = { 2, 3, 4, 5, 6, 7, 8, 9 };
        double[] y = { 4, 9, 16, 25, 36, 49, 64, 81 };

        double[] coeff = divideddifference(x, y);

        double inputvalue = 500; // مقدار ورودی که می‌خواهید خروجی‌اش را تخمین بزنید
        double outputvalue = newtoninterpolationvalue(x, coeff, inputvalue);

        Console.WriteLine($"predicted output for input {inputvalue}: {outputvalue}");
    }
}