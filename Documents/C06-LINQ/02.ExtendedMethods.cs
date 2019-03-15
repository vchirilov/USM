//*******************************************************************************************
//The form [from .. in .. select ] is called query form or standard form.
//There is one more shorter form for wrtting LINQ queries. It uses exnded methods.
//Extended methods are extended methods of IEnumerable
	//Select
	//Where
	//OrderBy
	//OrderByDescending
	//ThenBy
	//ThenByDescending
	//Join:GroupBy
	//ToLookup
	//GroupJoin
	//Reverse
	//All
	//Any
	//Contains
	//Distinct
	//Except
	//Union
	//Intersect
	//Count
	//Sum
	//Average
	//Min
	//Max
	//Take
	//Skip
	//TakeWhile
	//SkipWhile
	//Concat
	//Zip
	//First
	//FirstOrDefault
	//Single
	//SingleOrDefault
	//ElementAt
	//ElementAtOrDefault
	//Last
	//LastOrDefault
//*******************************************************************************************

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
