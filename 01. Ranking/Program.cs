using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class User
    {
        public string Username { get; set; }
        public int points { get; set; }
        public List<string> contests { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            //Dictionary<string, int> contestsPoints = new Dictionary<string, int>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string contest;
            while ((contest = Console.ReadLine()) != "end of contests")
            {
                string[] cmd = contest.Split(":");
                string contestName = cmd[0];
                string contestPass = cmd[1];
                contests.Add(contestName, contestPass);

            }

            string submition;
            while ((submition = Console.ReadLine()) != "end of submissions")
            {
                string[] submitions = submition.Split("=>");
                string contestName = submitions[0];
                string contestPass = submitions[1];
                string username = submitions[2];
                int points = int.Parse(submitions[3]);
                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName] == contestPass)
                    {
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new Dictionary<string, int>());
                            if (!users[username].ContainsKey(contestName))
                            {
                                users[username].Add(contestName, points);
                            }
                            else
                            {
                                if (users[username][contestName] < points)
                                {
                                    users[username][contestName] = points;
                                }
                            }
                        }
                        else
                        {
                            if (!users[username].ContainsKey(contestName))
                            {
                                users[username].Add(contestName, points);
                            }
                            else
                            {
                                if (users[username][contestName] < points)
                                {
                                    users[username][contestName] = points;
                                }
                            }
                        }
                    }
                }
            }
            string winner = "";
            int totalPoints = 0;
            foreach (var user in users)
            {
                int userPoints = user.Value.Values.ToArray().Sum();
                if (totalPoints < userPoints)
                {
                    totalPoints = userPoints;
                    winner = user.Key;
                }
            }
            Console.WriteLine($"Best candidate is {winner} with total {totalPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in users)
            {
                    var temp = user.Value.OrderByDescending(user => user.Value);

                Console.WriteLine(user.Key);
                foreach (var item in temp)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }

            }
        }
    }
}
