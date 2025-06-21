namespace TestingDemo.Core;

public class Kalkulator
{
    public double Dodaj(double a, double b) => a + b;
    public double Odejmij(double a, double b) => a - b;
    public double Pomnoz(double a, double b) => a * b;
    public double Podziel(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Nie można dzielić przez zero.");
        return a / b;
    }
}
