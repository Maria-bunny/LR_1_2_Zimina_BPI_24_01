using System;

namespace LR_1_2_Zimina_BPI_24_01
{
    public class Triangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC) : base("Треугольник")
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            // Формула Герона: S = √(p * (p - a) * (p - b) * (p - c))
            double p = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}
