using System;
using System.Collections.Generic;
using System.Linq;


namespace Snowwhite1
{
    class Dwarf
    {
        public Dwarf(string name, int physics)
        {
            this.Name = name;
            this.Physics = physics;
        }
        public string Name { get; set; }
        public int Physics { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] cmd = input.Split(" <:> ");
                string name = cmd[0];
                string color = cmd[1];
                int physics = int.Parse(cmd[2]);
                if (!dwarfs.ContainsKey(color))
                {
                    dwarfs.Add(color, new Dictionary<string, int>());
                    dwarfs[color].Add(name, physics);
                }
                if (!dwarfs[color].ContainsKey(name))
                {
                    dwarfs[color].Add(name, physics);
                }
                if (dwarfs[color][name] < physics)
                {
                    dwarfs[color][name] = physics;
                }
            }
            Dictionary<string, int> ordered = new Dictionary<string, int>();

            foreach (var color in dwarfs.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in color.Value)
                {
                    ordered.Add($"({color.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwar in ordered.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwar.Key}{dwar.Value}");
            }
        }
    }
}