using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class AntiHero : SuperHero
    {
        public string AntiHeroAction(string action) {
            return $"{Name} is {action}";
        }
    }
}
