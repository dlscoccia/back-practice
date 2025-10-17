using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class SuperHero : Hero, ISuperHero
    {
        private string _Name;
        public int Id { get; set; } = 1;
        public override string Name { 
            get { return _Name; } 
            set { 
            _Name = value.Trim();
            } 
        }

        public string NameAndAlterEgo { get { return $"{Name} ({AlterEgo})"; } }

        public string AlterEgo { get; set; }
        public string City;
        public List<SuperPower> Powers;
        public bool CanFly;

        public SuperHero()
        {
            Id = 1;
            Powers = new List<SuperPower>();
            CanFly = false;

        }

        public string UsePowers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var power in Powers)
            {
                sb.AppendLine($"{NameAndAlterEgo} is using {power.Name}!");
            }
            return sb.ToString();
        }

        public override string SaveTheWorld()
        {
            return $"{NameAndAlterEgo} has saved the world again!";
        }

        public override string SaveTheUniverse()
        {
            return base.SaveTheUniverse() + " two times today!";
        }
    }
}
