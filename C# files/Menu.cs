using System;
using System.IO;
using System.Threading;

class Menu{
  public void menu(){
    Average average = new Average();
    BestTeam bestTeams = new BestTeam();
    MatchMake makeMatch = new MatchMake();
    DriverSheet driverSheet = new DriverSheet();
    
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine();
    Console.WriteLine("---Bot Tracker: RAPID REACT---");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Enter Data/Create Team");
    Console.WriteLine("2. Specific Team Average Scores");
    Console.WriteLine("3. Driver Sheet");
    Console.WriteLine("4. Overall Best Scores");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("For ideas and concepts: https://docs.google.com/document/d/1lcDnq1DKAksiUKyjLZiNfk-rsdiIlfKHMmPCIlj3ZKc/edit#");
    Console.ForegroundColor = ConsoleColor.White;
    
    string prompt = Console.ReadLine();
    Console.Clear();
    if(prompt=="1"){
      //Checks to make sure the code will actually run
      try{
        makeMatch.makeMatch();
      }
      catch(Exception e){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Oops, something went wrong, check the code and please try again.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please press enter to go to menu");
        Console.ReadLine();
        Console.Clear();
        menu();
      }
    }
    else if (prompt ==  "2"){
      average.averageCargo();
    }
    else if (prompt ==  "3"){
      driverSheet.driveData();
    }
    else if (prompt == "4"){
      bestTeams.bestTeamMenu();
    }
    else{
      Console.Clear();
      menu();
    }
    
  }
}