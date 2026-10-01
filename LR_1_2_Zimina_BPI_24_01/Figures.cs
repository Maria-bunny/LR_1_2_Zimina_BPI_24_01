using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_2_Zimina_BPI_24_01
{
    public class Figure : IFugure
    {
        public string Name { get; protected set; }
        public Figure(string name)
        {
            Name = name;
        }
        public virtual double GetArea()
        {
            return 0.0;
        }

        public virtual double GetPerimeter()
        {
            return 0.0;
        }
    }
}
