using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PrintInfo
    {
        public void Print(ISuperHero superHero) {
            Console.WriteLine(superHero.GetSuperHeroe());

        }
    }
}
