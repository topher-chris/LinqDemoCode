using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemoCode
{
    class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalId { get; set; }
        public Animal(string name = "no name", double wt = 0, double ht = 0)
        {
            Name = name;
            Weight = wt;
            Height = ht;
        }
        public override string ToString()
        {
            return string.Format($"{Name} weighs {Weight} lbs and is {Height} inches tall");
        }
    }
}
