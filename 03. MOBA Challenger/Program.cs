using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Player
    {
        public Player(string name, string position, int skill)
        {
            this.Name = name;
            this.Position = position;
            this.Skill = skill;
        }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Skill { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            //List<Player> players = new List<Player>();
            Dictionary<string, Dictionary<string,int>> players = new Dictionary<string, Dictionary<string,int>>();
            while ((input = Console.ReadLine()) != "Season end")
            {
                string[] cmd;
                if ((cmd = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries)).Length == 3)
                {
                    string name = cmd[0];
                    string position = cmd[1];
                    int skill = int.Parse(cmd[2]);
                    if (!players.ContainsKey(name))
                    {
                        players.Add(name, new Dictionary<string, int>());
                    }
                    if (!players[name].ContainsKey(position))
                    {
                            players[name].Add(position,skill);
                    }
                    if(players[name][position]<skill)
                    {
                            players[name][position] = skill;
                    }
                    
                }

                else if((cmd = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries)).Length == 2)
                {
                    string player1 = cmd[0];
                    string player2 = cmd[1];
                    int player1Skill = 0;
                    int player2Skill = 0;
                    if (players.ContainsKey(player1) && players.ContainsKey(player2))
                    {
                        foreach (var key in players[player1].Keys)
                        {
                            if (players[player1].ContainsKey(key) && players[player2].ContainsKey(key))
                            {
                                    player1Skill += players[player1][key];
                                    player2Skill += players[player2][key];
                            }
                        }
                    }
                    if (player1Skill>player2Skill)
                    {
                        players.Remove(player2);
                    }
                    else if (player2Skill>player1Skill)
                    {
                        players.Remove(player1);
                    }
                }
            }
            foreach (var player in players.OrderByDescending(skill => skill.Value.Values.Sum()).ThenBy(name => name.Key))
            {

                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var kvp in player.Value.OrderByDescending(skill => skill.Value).ThenBy(pos => pos.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}
