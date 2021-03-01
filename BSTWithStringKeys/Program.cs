using static System.Console;
using System.Collections.Generic;

namespace BSTWithStringKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            BST binaryTreeTeam = new BST();

            string[] teamNames = LoadTeamTable();
            string[] teamLocations = LoadTeamLocation();

            string teamName;
            string teamLocation;
            string input;

            for (int i = 0; i < teamLocations.Length; i++)
            {
                binaryTreeTeam.Insert(teamNames[i], teamLocations[i]);
                WriteLine($"{teamLocations[i]} {teamNames[i]} inserted.");
            }

            do
            {
                
                Write("\n(I)nsert, (F)ind, (D)elete team, (T)raverse or (Q)uit? => ");

                input = ReadLine().ToUpper().Substring(0, 1);

                switch (input)
                {
                    case "I":
                        WriteLine("INSERT A NEW TEAM");
                        WriteLine("------------------d" +
                            "");
                        Write("Enter new team name: ");
                        teamName = ReadLine();
                        Write("Enter team location: ");
                        teamLocation = ReadLine();
                        binaryTreeTeam.Insert(teamName, teamLocation);
                        WriteLine($"\n{teamName} successfully added!");

                        break;
                    case "F":
                        WriteLine("FIND A TEAM");
                        WriteLine("------------");
                        Write("Enter team name to retrieve its location: ");
                        teamName = ReadLine();
                        //binaryTreeTeam.Find(teamName);
                        if (binaryTreeTeam.Find(teamName) != null)
                        {

                            WriteLine($"\n{teamName} are from {binaryTreeTeam.Find(teamName)}.");
                        }
                        else
                        {
                            WriteLine($"{teamName} doesn't exist.");
                        }
                        break;
                   
                    case "D":
                        WriteLine("DELETE A TEAM");
                        WriteLine("--------------");
                        Write("Enter team to delete: ");
                        teamName = ReadLine();

                        
                        if (binaryTreeTeam.Find(teamName) != null)
                        {
                            WriteLine($"\nThe {teamName} from {binaryTreeTeam.Find(teamName)} are no more.");
                            binaryTreeTeam.Delete(teamName);
                        }
                        else
                        {
                            WriteLine($"{teamName} doesn't exist.");
                        }
                        break;
                    case "T":
                        WriteLine("\nTEAM NAMES IN ASCENDING SEQUENCE: ");
                        WriteLine("-----------------------------------");
                        binaryTreeTeam.Traverse();
                        break;
                    case "Q":
                        WriteLine("\nOkey Dokey.  All done. ");
                        break;
                    default:
                        WriteLine("Invalid command.");
                        break;
                }


            } while (input != "Q");


            WriteLine();
        }

        private static string[] LoadTeamTable()
        {
            return new string[32] {"Cardinals","Falcons","Ravens","Bills",
                "Panthers","Bears","Bengals","Browns",
                "Cowboys","Broncos","Lions","Packers",
                "Texans","Colts","Jaguars","Chiefs",
                "Chargers","Rams","Dolphins","Vikings",
                "Patriots","Saints","Giants","Jets",
                "Raiders","Eagles","Steelers","49ers",
                "Seahawks","Buccaneers","Titans","Football Team"};
        }

        private static string[] LoadTeamLocation()
        {
            return new string[32] {"Arizona","Atlanta","Baltimore","Buffalo",
            "Carolina","Chicago","Cincinnati","Cleveland",
            "Dallas","Denver","Detroit","Green Bay",
            "Houston","Indianapolis","Jacksonville","Kansas City",
            "Los Angeles","Los Angeles", "Miami","Minnesota",
            "New England","New Orleans","New York","New York",
            "Oakland","Philadelphia","Pittsburgh","San Francisco",
            "Seattle","Tampa Bay","Tennessee", "Washington"};
        }
    }
}

