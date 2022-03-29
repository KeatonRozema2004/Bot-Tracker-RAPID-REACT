using System;
using System.IO;
using System.Threading;

class Program {

  public static void menu(){
    Console.WriteLine("---Bot Tracker: RAPID REACT---");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Enter match data/Create new team file");
    Console.WriteLine("2. Get team best scores");
    Console.WriteLine("3. Get team average tele cargo scores");
    Console.WriteLine("4. Get team matches (cargo, and climb)");
    Console.WriteLine("5. Check if team has data");
    Console.WriteLine("6. Get best scores for teams");
    Console.WriteLine("7. Drive Team Data (IN PROGRESS)");
    
    string prompt = Console.ReadLine();
    Console.Clear();
    if(prompt=="1"){
      //Checks to make sure the code will actually run
      try{
        makeMatch();
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
      bestScore();
      Console.WriteLine("Press Enter to go back to menu");
      Console.ReadLine();
      Console.Clear();
      menu();
    }
    else if (prompt ==  "3"){
      averageCargo();
    }
    else if (prompt ==  "4"){
      lastMatches();
      Console.WriteLine("Press enter to continue");
      Console.ReadLine();
      Console.Clear();
      menu();
    }
    else if (prompt ==  "5"){
      checkData();
    }
    else if (prompt == "6"){
      bestTeamCargo();
    }
    else if (prompt == "7"){
      driveData();
    }
    else{
      menu();
    }
    
  }


  public static void driveData(){
    lastMatches();
    bestScore();
    Console.WriteLine("Press enter to go back to menu");
    Console.ReadLine();
    Console.Clear();
    menu();
  }
    
  public static void addTeam(string team){
    File.Create(team+".txt").Close();
    
  }
  public static void addLines(string team){
    for(int i = 0; i<5000; i++){
      File.AppendAllText(team+".txt", "0" + Environment.NewLine);
    }
    Console.WriteLine("Added team!");
  }
  public static void lastMatches(){
    int i = 1;
    Console.Write("Team #: ");
    string team = Console.ReadLine();
    Console.WriteLine("Getting team data...");
    Console.WriteLine("--------------------");
    while(GetLine(team+".txt", i) != GetLine("blank.txt", 1)){
      i++;
      if(GetLine(team+".txt", i).Contains("Tele Upper")){
        Console.WriteLine(GetLine(team+".txt", i));
      }
      if(GetLine(team+".txt", i).Contains("Tele Lower")){
        Console.WriteLine(GetLine(team+".txt", i));
      }
      if(GetLine(team+".txt", i).Contains("Climb Type")){
        Console.WriteLine(GetLine(team+".txt", i));
      }
      if(GetLine(team+".txt", i).Contains("Climb Time")){
        Console.WriteLine(GetLine(team+".txt", i));
      }
      if(GetLine(team+".txt", i).Contains("-----")){
        Console.WriteLine("--------------------");
      }
    }
    
  }
  public static void bestTeamCargo(){
    
    int tempNum = 0;
    
    int teleHigh = 0;
    string teleHighTeam = "";
    int teleLow = 0;
    string teleLowTeam = "";
    int time = 1000;
    string timeTeam = "";
    
    for(int i = 0; i < 20000; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(GetLine(i+".txt", j) != GetLine("blank.txt", 1)){
          //Console.WriteLine(GetLine(team+".txt",i));
          j++;
          if(GetLine(i+".txt", j).Contains("Tele Upper")){
            string num1 = GetLine(i+".txt", j)[12].ToString();
            string num2 = GetLine(i+".txt", j)[13].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh){
              teleHighTeam = i.ToString();
              teleHigh = tempNum;
            }
          }
          if(GetLine(i+".txt", j).Contains("Tele Lower")){
            string num1 = GetLine(i+".txt", j)[12].ToString();
            string num2 = GetLine(i+".txt", j)[13].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleLow){
              teleLowTeam = i.ToString();
              teleLow = tempNum;
            }
          }
          if(GetLine(i+".txt", j).Contains("Total Climb Time")){
            string num1 = GetLine(i+".txt", j)[18].ToString();
            string num2 = GetLine(i+".txt", j)[19].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum < time){
              timeTeam = i.ToString();
              time = tempNum;
            }
          }
        }
      }
    }
    Console.WriteLine("Team " + teleHighTeam + " Upper Tele: " + teleHigh);
    Console.WriteLine("Team " + teleLowTeam + " Upper Tele: " + teleLow);
    Console.WriteLine("Team " + timeTeam + " Climb Time " + time);
    Console.WriteLine("Press Enter to go back to menu");
    Console.ReadLine();
    Console.Clear();
    menu();
  }
  ///<summary>
  ///Looks at the best scores for a specified team
  ///</summary>
  public static void bestScore(){
    string team;
    int autoHigh = 0;
    int autoLow = 0;
    int teleHigh = 0;
    int teleLow = 0;
    int time = 500;
    int leastAutoMissed = 500;
    int leastTeleMissed = 500;
    int tempNum = 0;
    string tempString;
    string climbType = "n";
    int i = 1; 
    Console.Write("Team #: ");
    team = Console.ReadLine();
    Console.WriteLine("Getting team data...");
    while(GetLine(team+".txt", i) != GetLine("blank.txt", 1)){
      //Console.WriteLine(GetLine(team+".txt",i));
      i++;
      if(GetLine(team+".txt", i).Contains("Auto Upper")){
        string num1 = GetLine(team+".txt", i)[12].ToString();
        string num2 = GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > autoHigh){
          autoHigh = tempNum;
        }
      }
      if(GetLine(team+".txt", i).Contains("Auto Lower")){
        string num1 = GetLine(team+".txt", i)[12].ToString();
        string num2 = GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > autoLow){
          autoLow = tempNum;
        }
      }
      if(GetLine(team+".txt", i).Contains("Tele Lower")){
        string num1 = GetLine(team+".txt", i)[12].ToString();
        string num2 = GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > teleLow){
          teleLow = tempNum;
        }
      }
      if(GetLine(team+".txt", i).Contains("Tele Upper")){
        string num1 = GetLine(team+".txt", i)[12].ToString();
        string num2 = GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > teleHigh){
          teleHigh = tempNum;
        }
      }
      if(GetLine(team+".txt", i).Contains("Total Climb Time")){
        string num1 = GetLine(team+".txt", i)[18].ToString();
        string num2 = GetLine(team+".txt", i)[19].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum < time){
          time = tempNum;
        }
      }
      if(GetLine(team+".txt", i).Contains("Climb Type")){
        string climb = GetLine(team+".txt", i)[12].ToString();
        if(climb == "l" && climbType == "n"){
          climbType = climb;
        }
        else if(climb == "m"){
          if(climbType == "l" || climbType == "n"){
            climbType = climb;
          }
        }
        
        else if(climb == "h"){
          if(climbType == "m" || climbType == "l" || climbType == "n"){
            climbType = climb;
          }
        }

        else if(climb == "t"){
          if(climbType == "h" || climbType == "m" ||climbType == "l" || climbType == "n"){
            climbType = climb;
          }
        }
        
      }
    }
    Console.WriteLine("Best High Goal Auto: " + autoHigh);
    Console.WriteLine("Best Low Goal Auto: " + autoLow);
    Console.WriteLine();
    Console.WriteLine("Best High Goal Tele: " + teleHigh);
    Console.WriteLine("Best Low Goal Tele: " + teleLow);
    Console.WriteLine();
    Console.WriteLine("Best Climb Time: " + time);
    Console.WriteLine("Best Climb Type: " + climbType);
    Console.WriteLine();
    
    
  }

  ///<summary>
  ///Finds the average cargo for team selected
  ///</summary>
  public static int averageCargo(){
    //String stringy = new String();
    string team;
    int averageScore = 0;
    int i = 1;
    int j = 0;
    Console.Write("Team #: ");
    team = Console.ReadLine();
    while(GetLine(team+".txt", i) != GetLine("blank.txt", 1)){
      //Console.WriteLine(GetLine(team+".txt",i));
      i++;
      if(GetLine(team+".txt", i).Contains("Tele Cargo Score")){
        string num1 = GetLine(team+".txt", i)[18].ToString();
        string num2 = GetLine(team+".txt", i)[19].ToString();
        averageScore += Int32.Parse(num1+num2);
        j++;
      }
    }
    
    Console.WriteLine("Average Tele Cargo Score: " + averageScore/j);
    Console.WriteLine();
    
    Console.WriteLine("Please press Enter to go back to menu");
    Console.ReadLine();
    Console.Clear();
    menu();
    return 1;
  }

  
  /// <summary> 
  /// Will get match data for team selected
  /// </summary>
  public static void makeMatch(){
    string team;
    string match;

    string taxi;
    string autoUpper;
    string autoLower;
    string autoMissed;
    int autoCargo;

    string teleUpper;
    string teleLower;
    string teleMissed;
    string defense;
    string position;
    int teleCargo;
    
    string climbStart;
    string climbEnd;
    int climbTime;
    string climbType;
    string climbEnter;
    
    string prompt;
    
    
    Console.Write("Team #: ");
    team = Console.ReadLine();
    if(!File.Exists(team+".txt")){
      Console.WriteLine("This team doesn't exist. Would you like to add this team? (Type 'y' for yes or 'n' for no and you will go back to the menu.)");
      prompt = Console.ReadLine();
      if(prompt == "y"){
        addTeam(team);
        addLines(team);
        Console.WriteLine("If you want to go back to menu, press 'y', if you want to continue, press enter");
        prompt = Console.ReadLine();
        if (prompt == "y"){
          Console.Clear();
          menu();
        }
      }
      else{
        menu();
      }
    }
    
    Console.Write("Match: ");
    match = Console.ReadLine();

    Console.Write("Taxi (y or n): ");
    taxi = Console.ReadLine();

    Console.Write("Auto Lower: ");
    autoLower = Console.ReadLine();
    if(autoLower.Length == 1){
      autoLower = "0" + autoLower;
    }

    Console.Write("Auto Upper: ");
    autoUpper = Console.ReadLine();
    if(autoUpper.Length == 1){
      autoUpper = "0" + autoUpper;
    }
    
    
    Console.Write("Auto Missed: ");
    autoMissed = Console.ReadLine();
    if(autoMissed.Length == 1){
      autoMissed = "0" + autoMissed;
    }

    Console.Write("Position (n,l,t,c): ");
    position = Console.ReadLine();

    Console.Write("Tele Lower: ");
    teleLower = Console.ReadLine();
    if(teleLower.Length == 1){
      teleLower = "0" + teleLower;
    }
    
    Console.Write("Tele Upper: ");
    teleUpper = Console.ReadLine();
    if(teleUpper.Length == 1){
      teleUpper = "0" + teleUpper;
    }
    
    
    
    Console.Write("Tele Missed: ");
    teleMissed = Console.ReadLine();
    if(teleMissed.Length == 1){
      teleMissed = "0" + teleMissed;
    }
    
    Console.Write("Defense (0-2): ");
    defense = Console.ReadLine();
    
    Console.Write("Climb Type (l,m,h,t,n): ");
    climbType = Console.ReadLine();
    
    Console.Write("Climb Start: ");
    climbStart = Console.ReadLine();
    
    Console.Write("Climb Finish: ");
    climbEnd = Console.ReadLine();
    Console.Write("Climb Entry (f, s): ");
    climbEnter = Console.ReadLine();

    climbTime = (Int32.Parse(climbStart) - Int32.Parse(climbEnd));

    
    //User match data
    writeToFile(team, "Match Number: " + match);
    writeToFile(team, "Taxi: " + taxi);
    writeToFile(team, "Auto Upper: " + autoUpper);
    writeToFile(team, "Auto Lower: "+ autoLower);
    writeToFile(team, "Auto Missed: "+ autoMissed);
    writeToFile(team, "Tele Upper: " + teleUpper);
    writeToFile(team, "Tele Lower: "+ teleLower);
    writeToFile(team, "Tele Missed: "+ teleMissed);
    writeToFile(team, "Position: " + position);
    writeToFile(team, "Defense: " + defense);
    writeToFile(team, "Climb Type: "+ climbType);
    writeToFile(team, "Start: "+ climbStart);
    writeToFile(team, "End: "+ climbEnd);

    teleCargo = (Int32.Parse(teleUpper)*2)+(Int32.Parse(teleLower)*1);
    autoCargo = (Int32.Parse(autoUpper)*4)+(Int32.Parse(autoLower)*2);
    //Calculated match data

    if((climbTime).ToString().Length == 1){
      writeToFile(team, "Total Climb Time: 0"+ climbTime);
    }
    else{
      writeToFile(team, "Total Climb Time: "+ climbTime);
    }
    if((teleCargo).ToString().Length == 1){
      writeToFile(team, "Tele Cargo Score: 0" + teleCargo);
    }
    else{
      writeToFile(team, "Tele Cargo Score: " + teleCargo);
    }
    
    writeToFile(team, "Auto Cargo Score: " + autoCargo);

    
    writeToFile(team, "------------------------");
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("***********************");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Success!");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("***********************");
    
    
    Thread.Sleep(2000);
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    menu();
  }



  public static void checkData(){
    Console.Write("Team #: ");
    string team = Console.ReadLine();
    if(GetLine(team+".txt", 1) == GetLine("blank.txt",1)){
      Console.WriteLine("No data is here");
    }
    else{
      Console.WriteLine("Data exists for this team");
    }
    Console.WriteLine("Press Enter to go to menu");
    Console.ReadLine();
    menu();
  }
  /*
  public static void teamExists(){
    string team;
    Console.Write("Team #: ");
    team = Console.ReadLine();
    if(File.Exists(team+".txt")){
      Console.WriteLine("This team exists");
    }
    else{
      Console.WriteLine("Does not exist");
    }
    Console.WriteLine("Press enter to go to menu");
    Console.ReadLine();
    Console.Clear();
    menu();
  }
*/

  //Here's some overused methods
    public static string GetLine(string fileName, int line)
  {
    using (var sr = new StreamReader(fileName)) {
    for (int i = 1; i < line; i++)
    sr.ReadLine();
    return sr.ReadLine();
    }
  }
  
  public static void WriteLine(string fileName, int line)
  {
    using (var sr = new StreamWriter(fileName)) {
    for (int i = 1; i < line; i++)
    sr.WriteLine();
    }
  }
  
  static void lineChanger(string newText, string fileName, int line_to_edit)
  {
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit - 1] = newText;
     File.WriteAllLines(fileName, arrLine);
    
  }
  public static void writeToFile(string team, string text){
    int i = 1;
    bool emptyLine = false;
    while(emptyLine == false){
      //Thread.Sleep(10);
      if(GetLine(team+".txt", i) != GetLine("blank.txt", 1)){
        //Console.WriteLine(GetLine(team+".txt", i));
      }
      else{
        //Console.WriteLine("Wrote to line "+ i);
        lineChanger(text , team+".txt" , i);
        emptyLine = true;
      }
      i++;
    }
  }
  
  public static void Main (string[] args) {
    
    menu();
  }
}