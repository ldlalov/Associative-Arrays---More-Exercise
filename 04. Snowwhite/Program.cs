using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Dwarf
    {
        public Dwarf(string name, string color, int physics)
        {
            this.Name = name;
            this.Color = color;
            this.Physics = physics;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Physics { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Dwarf> dwarfs = new List<Dwarf>();
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] cmd = input.Split(" <:> ");
                string name = cmd[0];
                string color = cmd[1];
                int physics = int.Parse(cmd[2]);
                Dwarf dwarf = new Dwarf(name, color, physics);
                bool dwarfExist = false;
                foreach (var item in dwarfs)
                {
                    if (item.Name == name && item.Color == color)
                    {
                        dwarfExist = true;
                        if (item.Physics < physics)
                        {
                            item.Physics = physics;
                            break;
                        }
                        break;
                    }
                }
                if (!dwarfExist)
                {
                dwarfs.Add(dwarf);
                }
            }
            var orderedHats = dwarfs.GroupBy(dwarfs => dwarfs.Name).SelectMany(dwarfs => dwarfs);
            var ordered = dwarfs.OrderByDescending(x => x.Physics);
            foreach (var dwarf in ordered.GroupBy(x => x.Color).SelectMany(x => x))
            {
                Console.WriteLine(String.Join(' ',$"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}"));
            }
        }
    }
}

