using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal abstract class Hero
    {
        public abstract string Name { get; set; }
        public abstract string SaveTheWorld();

        public virtual string SaveTheUniverse() { return $"{Name} has saved the universe!"; }
    }
}
