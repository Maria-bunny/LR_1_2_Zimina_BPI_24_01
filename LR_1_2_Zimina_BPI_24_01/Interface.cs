using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_2_Zimina_BPI_24_01
{
    public interface IFugure
    {
        double GetArea();
        double GetPerimeter();
        string Name { get; }
    }
}
