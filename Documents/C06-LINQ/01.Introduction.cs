//*******************************************************************************************
//C# 3.0(.NET 3.5) introduced the lambda expression along with LINQ. 
//LINQ is a structured language for querying data-sets (IEnumerable) using lambda expressions.
//The lambda expression is a shorter way of representing anonymous method using some special syntax.
//There are many forms for LINQ: LINQ to Objects,LINQ to Entities,LINQ to Sql,LINQ to XML,LINQ to DataSet,Parallel LINQ (PLINQ)
//*******************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Introduction
    {
        public static void Start1()
        {
            string[] teams = { "ATeam", "BTeam1", "BTeam2", "CTeam", "DTeam", "ETeam" };

            var selectedTeams = new List<string>();
            foreach (string s in teams)
            {
                if (s.ToUpper().StartsWith("B"))
                    selectedTeams.Add(s);
            }
            selectedTeams.Sort();

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
        }

        public static void Start2()
        {
            string[] teams = { "ATeam", "BTeam1", "BTeam2", "CTeam", "DTeam", "ETeam" };

            var selectedTeams = from t in teams 
                                where t.ToUpper().StartsWith("B") 
                                orderby t 
                                select t; 

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
        }
    }
}




