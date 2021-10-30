using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    class Team
    {
        //СЪЗДАВАМЕ ОТБОР КОЙТО ИМА:
        public string Name { get; set; }
        public string Creator { get; set; }
        //лист от членове
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //четем борй на екипи
            int teamsCount = int.Parse(Console.ReadLine());
            //Създаваме лист от отбори
            List<Team> teams = new List<Team>();
            for (int i = 0; i < teamsCount; i++)
            {   //getting info of command
                string[] info = Console.ReadLine().Split("-");
                string creator = info[0];
                string teamName = info[1];
                //Проверяваме ако в моя отбор има отбор с името значи вече е създаден
                if (teams.Any(team =>team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                //Ако във всички отбори има създател не може да създава друг отбор
                else if(teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                //Създаваме нов отбор
                else
                {    //Създаваме нов отбор
                    var team = new Team();
                    team.Name = teamName;
                    team.Creator = creator;
                    //нов лист от стрингове
                    team.Members = new List<string>();
                    //добавяме към всички до този момент отбори
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
            //четем команда до получаване на командата
            string line = Console.ReadLine();
            while (line != "end of assignment")
            {   //четем user и team to join
                string user = line.Split(new string[] {"->"}, StringSplitOptions.None)[0];
                string teamToJoin = line.Split(new string[] {"->"}, StringSplitOptions.None)[1];
                //
                if (!teams.Any(team => team.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                //има член който иска да се присъедини или usera = creator не може да се добави в  този отбор
                else if (teams.Any(team => team.Members.Contains(user) || teams.Any(team => team.Creator == user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                }
                
                else
                {
                    var currTeam = teams.First(team => team.Name == teamToJoin);
                    currTeam.Members.Add(user);
                }
                line = Console.ReadLine();
            }
            var finalTeam = teams.Where(team => team.Members.Count > 0);
            var disbandedTeams = teams.Where(team => team.Members.Count == 0);
            //1.Подреждаме по тобори и колко членове има във всеки един от отборите
            //След това по имената в текущия екип
            foreach (Team team in finalTeam.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (string member in team.Members.OrderBy(memebr => memebr ))
                {
                    Console.WriteLine($"-- {member}");
                }
                

                
            }
            Console.WriteLine($"Teams to disban:");
          
                if (disbandedTeams != null)
                {
                foreach (Team disbandedTeam in disbandedTeams.OrderBy(team => team.Name))
                {
                    Console.WriteLine($"{disbandedTeam.Name}");
                }
                }
            
        }
    }
}
