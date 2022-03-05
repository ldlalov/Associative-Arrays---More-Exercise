using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestAndUsers = new Dictionary<string, Dictionary<string,int>>();
            Dictionary<string, int> users = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] cmd = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string username = cmd[0];
                string contest = cmd[1];
                int points = int.Parse(cmd[2]);
                if (!contestAndUsers.ContainsKey(contest))
                {
                    contestAndUsers.Add(contest, new Dictionary<string, int>());
                    if (!contestAndUsers[contest].ContainsKey(username))
                    {
                    contestAndUsers[contest].Add(username, points);
                    }
                    else
                    {
                        if (contestAndUsers[contest][username]<points)
                        {
                        contestAndUsers[contest][username] = points;
                        }
                    }
                }
                else
                {
                    if (!contestAndUsers[contest].ContainsKey(username))
                    {
                        contestAndUsers[contest].Add(username, points);
                    }
                    else
                    {
                        if (contestAndUsers[contest][username]<points)
                        {
                        contestAndUsers[contest][username] = points;
                        }
                    }
                }
            }
            foreach (var key in contestAndUsers)
            {
                Console.WriteLine($"{key.Key}: {key.Value.Count} participants");
                var orderByGrades = key.Value.OrderByDescending(key => key.Value).ThenBy(key => key.Key);
                int counter = 0;
                foreach (var item in orderByGrades)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                }
            }
            Console.WriteLine("Individual standings:");
            foreach (var item in contestAndUsers)
            {
                foreach (var key in item.Value)
                {
                    if (!users.ContainsKey(key.Key))
                    {
                        users.Add(key.Key, key.Value);
                    }
                    else
                    {
                        users[key.Key] += key.Value; 
                    }
                    
                }
            }
                var temp = users.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            int count = 0;
            foreach (var item in temp)
            {
                count++;
                Console.WriteLine($"{count}. {item.Key} -> {item.Value}");
            }
        }
    }
}
