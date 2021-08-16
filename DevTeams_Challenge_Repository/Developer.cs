using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd = 1, BackEnd, Testing }
    public class Developer
    {

        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
        //ID (int)
        //FirstName
        //LastName
        //a bool that shows whether they have access to the online learning tool Pluralsight.
        //TeamAssignment - use the enum declared above this class
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool CanAccessPluralsight { get; set; }
        public TeamAssignment Team { get; set; }

        public Developer(int id, string first, string last, bool hasPluralsightAccess, TeamAssignment team)
        {
            ID = id;
            FirstName = first;
            LastName = last;
            CanAccessPluralsight = hasPluralsightAccess;
            Team = team;
        }


    }
}
