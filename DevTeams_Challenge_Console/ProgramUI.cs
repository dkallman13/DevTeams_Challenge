using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            //SeedContent();
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here
            //Menu options we'll need and the methods you'll need to make

            //CreateNewDeveloper();
            //DisplayAllDevelopers();
            //DisplayDevelopersByTeam();
            //DisplayDeveloperById();
            //UpdateExistingDeveloper();
            //DeleteExistingDeveloper();
        }

        // Helpermethods you should write
        // A method to print a developer's first and last name, useful in display all
        // private void DisplayDevBasicInfo(Developer dev) {}

        // A method to print a developers full information, useful when showing one developer
        // private void DisplayDevFullInfo(Developer dev) {}


        //private void SeedContent(){}
    }
}
