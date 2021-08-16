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
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu (select one):\n" +
                    "1. Add Developer\n" +
                    "2. Display All Developers \n" +
                    "3. Display Developers By Teams \n" +
                    "4. Display Developers By ID \n" +
                    "5. Update developer \n" +
                    "6. Delete Existing Developer\n" +
                    "7. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        break;
                    case "3":
                        GetDeveloperByTeam();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number(1-7)");
                        Console.ReadKey();
                        break;
                }

            }
            //Start with the main menu here
            //Menu options we'll need and the methods you'll need to make

            //CreateNewDeveloper();
            //DisplayAllDevelopers();
            //DisplayDevelopersByTeam();
            //DisplayDeveloperById();
            //UpdateExistingDeveloper();
            //DeleteExistingDeveloper();
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            bool isRunning = true;
            string firstname;
            int idInt;
            string lastname;
            TeamAssignment team;
            bool canAccessPluralsight;
            while (isRunning)
            {
                Console.WriteLine("What is their ID?");
                string id = Console.ReadLine();

                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("Please input a valid number");
                    break;
                }
                else
                {
                    idInt = int.Parse(id);
                    Console.WriteLine("What is their first name?");
                    firstname = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrEmpty(firstname))
                    {
                        Console.WriteLine("Please input a name.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("What is their last name?");
                        lastname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(lastname) || string.IsNullOrEmpty(lastname))
                        {
                            Console.WriteLine("Please input a name.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Which team are they on?\n" +
                                "1. Front-End\n" +
                                "2. Back-End\n" +
                                "3. Testing");
                            int response = int.Parse(Console.ReadLine());
                            if (response <= 3 && response >= 1)
                            {
                                team = (TeamAssignment)response;
                                Console.WriteLine("Can they access Pluralsight? enter y for yes or n for no");
                                string access = Console.ReadLine().ToLower();
                                if (access == "y")
                                {
                                    canAccessPluralsight = true;
                                    isRunning = false; 

                                }
                                else if (access == "n")
                                {
                                    canAccessPluralsight = false;
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("please enter y or n");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("please input a number from 1-3");
                                break;
                            }


                        }
                    }

                }
                Developer dev = new Developer(idInt, firstname, lastname, canAccessPluralsight, team);

                if (_repo.AddContentToDirectory(dev))
                {
                    Console.WriteLine("successfully added to the dev list");
                }
                else
                {
                    Console.WriteLine("mr programmer screwed up");
                }
                Console.ReadKey();
            }
        }
        private void GetDeveloperByTeam()
        {
            Console.Clear();
            Console.WriteLine("What team do you want to search for?\n" +
                "1. Front-End\n" +
                "2. Back-End\n" +
                "3. Testing\n");
            string serachTerms = Console.ReadLine();
            TeamAssignment teamSearch = 0;
            switch (serachTerms)
            {
                case "1":
                    teamSearch = TeamAssignment.FrontEnd;
                    break;
                case "2":
                    teamSearch = TeamAssignment.BackEnd;
                    break;
                case "3":
                    teamSearch = TeamAssignment.Testing;
                    break;
                default:
                    Console.WriteLine("Please input a number from 1 - 3");
                    break;
            }
            List<Developer> results = _repo.GetDevelopersByTeam(teamSearch);
            if (results != null)
            {
                Console.WriteLine($"{"ID",-5} |{"First Name",-10} |{"Last Name",-10} |{"Team Assignment",-10} |{"Pluralsight access",-5}");
                Console.WriteLine("..............................................................................................");
                foreach (Developer result in results)
                {
                    Console.WriteLine($"{result.ID,-5} {result.FirstName,-10} {result.LastName,-10} {result.Team,-20} {result.CanAccessPluralsight,-25}");
                }

            }
            else
            {
                Console.WriteLine("no results for that team");
            }
            Console.ReadKey();
        }

        // Helpermethods you should write
        // A method to print a developer's first and last name, useful in display all
        // private void DisplayDevBasicInfo(Developer dev) {}

        // A method to print a developers full information, useful when showing one developer
        // private void DisplayDevFullInfo(Developer dev) {}


        private void SeedContent()
        {
            Developer developerOne = new Developer(1, "Bob", "Dave", true, TeamAssignment.BackEnd);
            Developer developerTwo = new Developer(2, "Chad", "Johnson", true, TeamAssignment.FrontEnd);
            Developer developerThree = new Developer(3, "Ricky", "Bobby", false, TeamAssignment.Testing);
            _repo.AddContentToDirectory(developerOne);
            _repo.AddContentToDirectory(developerTwo);
            _repo.AddContentToDirectory(developerThree);
        }
    }
}
