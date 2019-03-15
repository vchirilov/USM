using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class ExtendedMethods
    {
        public static void Start()
        {
            string[] teams = { "ATeam", "BTeam1", "BTeam2", "CTeam", "DTeam", "ETeam" };

            var selectedTeams = teams.Where(t => t.ToUpper().StartsWith("B")).OrderBy(t => t);

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
        }
    }
}
