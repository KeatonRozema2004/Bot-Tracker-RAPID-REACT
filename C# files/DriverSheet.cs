using System;
using System.IO;
using System.Threading;
class DriverSheet
{
    public void driveData()
    {
        MatchMake match = new MatchMake();
        Menu menu = new Menu();
        BestTeam best = new BestTeam();
        int i = 0;
        Console.Write("Team #: ");
        string team = Console.ReadLine();
        Console.WriteLine("Getting team data........");
        Console.WriteLine("--------------------");
        while (match.GetLine(team + ".txt", i) != match.GetLine("blank.txt", 1))
        {
            i++;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (match.GetLine(team + ".txt", i).Contains("Match Number"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (match.GetLine(team + ".txt", i).Contains("Tele Lower"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (match.GetLine(team + ".txt", i).Contains("Tele Upper"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (match.GetLine(team + ".txt", i).Contains("Auto Cargo Total"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (match.GetLine(team + ".txt", i).Contains("Climb Time"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (match.GetLine(team + ".txt", i).Contains("Climb Type"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (match.GetLine(team + ".txt", i).Contains("Defense"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (match.GetLine(team + ".txt", i).Contains("Position"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (match.GetLine(team + ".txt", i).Contains("Entry"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (match.GetLine(team + ".txt", i).Contains("-----"))
            {
                Console.WriteLine("--------------------");
            }
        }
        best.bestScore(team);
        Console.WriteLine("Press enter to go back to menu");
        Console.ReadLine();
        Console.Clear();
        menu.menu();
    }

    /*
    public void lastMatches()
    {
        MatchMake match = new MatchMake();
        int i = 0;
        Console.Write("Team #: ");
        string team = Console.ReadLine();
        Console.WriteLine("Getting team data...");
        Console.WriteLine("--------------------");
        while (match.GetLine(team + ".txt", i) != match.GetLine("blank.txt", 1))
        {
            i++;
            if (match.GetLine(team + ".txt", i).Contains("Match Number"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Tele Lower"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Tele Upper"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            
            if (match.GetLine(team + ".txt", i).Contains("Auto Cargo Scored"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Climb Time"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Climb Type"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }

            if (match.GetLine(team + ".txt", i).Contains("Defense"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Position"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("Entry"))
            {
                Console.WriteLine(match.GetLine(team + ".txt", i));
            }
            if (match.GetLine(team + ".txt", i).Contains("-----"))
            {
                Console.WriteLine("--------------------");
            }
        }

    }*/
}