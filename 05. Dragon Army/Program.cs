using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _05._Dragon_Army
{
    class Stats
    {
        public Stats(int damage, int health, int armor)
        {
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, Stats>> dragons = new Dictionary<string, SortedDictionary<string, Stats>>();
            int countOfDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfDragons; i++)
            {
                string[] dragon = Console.ReadLine().Split(' ');
                string type = dragon[0];
                string name = dragon[1];

                int damage = int.TryParse(dragon[2], out damage) ? damage : 45;
                int health = int.TryParse(dragon[3], out health) ? health : 250;
                int armor = int.TryParse(dragon[4], out armor) ? armor : 10;
                Stats stat = new Stats(damage, health, armor);
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, Stats>());
                    dragons[type].Add(name, stat);
                }
                else
                {
                    dragons[type][name] = stat;
                }

            }
            foreach (var dragon in dragons)
            {
                Console.WriteLine($"{ dragon.Key}::({ dragon.Value.Select(x => x.Value.Damage).Average():f2}/{ dragon.Value.Select(x => x.Value.Health).Average():f2}/{ dragon.Value.Select(x => x.Value.Armor).Average():f2})");
                foreach (var item in dragon.Value)
                {
                    Console.WriteLine($"-{item.Key} -> damage: {item.Value.Damage}, health: {item.Value.Health}, armor: {item.Value.Armor}");
                }
            }
        }
    }
}
