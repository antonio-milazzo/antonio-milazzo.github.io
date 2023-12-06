using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_MilazzoAntonio
{
    internal class NPC
    {
        public string Name { get; set; }    
        public string Description { get; set; }

        public NPC(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    internal class Gimili : NPC 
    {
        public Gimili(string name, string description) : base("Gimili", "Your helpful friend on this adventure")
        { 
          
        }

        public void Greet()
        {
            Console.WriteLine($"My name is Gimili, I'll be helping you on you're adventure today, would you like an overview of the quest?");
        }
    }
}
