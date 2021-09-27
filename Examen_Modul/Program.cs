using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Modul
{
    class Program
    {
        static void Main(string[] args)
        {
            var pf = new PathFinder("Zadacha.csv", "CritPut.txt"); //Здесь происходит запуск программы
            pf.CalculateCriticalPath();
        }
    }
}
