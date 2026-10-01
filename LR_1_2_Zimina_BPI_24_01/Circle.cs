using System;

namespace LR_1_2_Zimina_BPI_24_01
{
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Круг")
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
