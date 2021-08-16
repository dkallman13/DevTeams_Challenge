using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private List<Developer> _devDirectory = new List<Developer>();

        // C
        public bool AddContentToDirectory(Developer dev)
        {
            int startingCount = _devDirectory.Count();
            _devDirectory.Add(dev);

            bool wasAdded = _devDirectory.Count > startingCount;

            return wasAdded;

        }
        // R
        public List<Developer> GetContents()
        {
            return _devDirectory;
        }
        // U
        public bool UpdateDeveloper(int id, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByID(id);
            if (oldDeveloper is null)
            {
                return false;
            }
            else
            {
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.CanAccessPluralsight = newDeveloper.CanAccessPluralsight;
                oldDeveloper.Team = newDeveloper.Team;
                return true;
            }
        }

        // D
        public bool RemoveDeveloper(int id)
        {
            Developer oldDeveloper = GetDeveloperByID(id);
            if (oldDeveloper is null)
            {
                return false;
            }
            else
            {
                int count = _devDirectory.Count();

                _devDirectory.Remove(oldDeveloper);
                if (count > _devDirectory.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public Developer GetDeveloperByID(int id)
        {
            foreach (var dev in _devDirectory)
            {
                if (dev.ID == id)
                {
                    return dev;
                }
            }
            return null;
        }
        public List<Developer> GetDevelopersByTeam(TeamAssignment team)
        {
            List<Developer> memberList = new List<Developer>();
            foreach (var member in _devDirectory)
            {
                if (member.Team == team)
                {
                    memberList.Add(member);
                }
            }

            return memberList;

        }
    }
}
