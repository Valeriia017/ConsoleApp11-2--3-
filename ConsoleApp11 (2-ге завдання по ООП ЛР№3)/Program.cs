using System;

class Parent
{
    protected double Pole1; // довжина першої півосі
    protected double Pole2; // довжина другої півосі

    public Parent()
    {
    }

    public Parent(double semiAxis1, double semiAxis2)
    {
        Pole1 = semiAxis1;
        Pole2 = semiAxis2;
    }

    public void Print()
    {
        Console.WriteLine($"Півосі: a={Pole1} b={Pole2}");
    }

    public double Metod1()
    {
        return Math.Round(Math.PI * Pole1 * Pole2, 2);
    }

    public double Metod2()
    {
        return Math.Round(2 * Math.PI * Math.Sqrt((Pole1 * Pole1 + Pole2 * Pole2) / 2),2);
    }
}

class Child : Parent
{
    public Child(double radius) : base(radius, radius)
    {
    }

    public double Metod3()
    {
        // Площа вписаного квадрата в коло дорівнює (діаметр кола / √2)²
        double diameter = 2 * Pole1; // Діаметр кола - двічі радіус
        double sideOfSquare = diameter / Math.Sqrt(2);
        return Math.Round(sideOfSquare * sideOfSquare, 2);
    }

    public double Metod4()
    {
        // Периметр вписаного квадрата в коло дорівнює 4 * сторона квадрата
        double diameter = 2 * Pole1; // Діаметр кола - двічі радіус
        double sideOfSquare = diameter / Math.Sqrt(2);
        return Math.Round(4 * sideOfSquare, 3);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            double semiAxis1 = random.Next(1, 7); // Випадкова довжина першої півосі
            double semiAxis2 = random.Next(1, 7); // Випадкова довжина другої півосі

            if (semiAxis1 != semiAxis2)
            {
                // Це еліпс
                Parent ellipse = new Parent(semiAxis1, semiAxis2); 
                ellipse.Print();
                Console.WriteLine($"Еліпс: Площа = {ellipse.Metod1()}, Довжина лінії = {ellipse.Metod2()}") ;
            }
            else
            {
                // Це коло
                Child circle = new Child(semiAxis1);
                circle.Print();
                Console.WriteLine($"Коло: Площа = {circle.Metod1()}, Довжина кола = {circle.Metod2()}");
                Console.WriteLine($"Вписаний квадрат. Площа = {circle.Metod3()}, Периметр = {circle.Metod4()}");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}