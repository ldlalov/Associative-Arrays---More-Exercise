using System;
using System.Collections.Generic;

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
            Dictionary<string,int> users = new Dictionary<string, int>();
            Dictionary<string, List<string>> userInContests = new Dictionary<string, List<string>>();
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
                       users.Add(username,  points);
                        }
                        else
                        {
                            if (users[username] > points)
                            {
                            users[username]= points;
                            }
                        }
                    }
                }
            }
        }
    }
}
