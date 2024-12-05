using System;

namespace Discriminant
{
    public class DiscriminantCalculator
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double DiscriminantResult { get; private set; }
        public string Message { get; private set; }

        // Конструктор, принимающий коэффициенты A, B, C и вызывающий расчет дискриминанта
        public DiscriminantCalculator(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            CalculateDiscriminant();
        }

        // Метод для вычисления дискриминанта
        public void CalculateDiscriminant()
        {
            DiscriminantResult = B * B - 4 * A * C;
            Message = "Успешно рассчитано.";
        }

        // Перегруженный метод для вычисления дискриминанта с передачей коэффициентов
        public virtual double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        // Перегруженный метод для вычисления дискриминанта с параметром verbose
        public double CalculateDiscriminant(double a, double b, double c, bool verbose)
        {
            if (verbose)
            {
                Console.WriteLine($"Calculating discriminant for A={a}, B={b}, C={c}...");
            }
            return CalculateDiscriminant(a, b, c);
        }
    }
}