using System;
using System.IO;
using System.Threading;

class MatchMake{
  public void addTeam(string team){
    File.Create(team+".txt").Close();
    
  }
  public void addLines(string team){
    for(int i = 0; i<5000; i++){
      File.AppendAllText(team+".txt", "0" + Environment.NewLine);
    }
    Console.WriteLine("Added team!");
  }
  ///<summary>
  ///Makes match, is found in MatchMake folder
  ///</summary
  public void makeMatch(){
    Menu menu = new Menu();
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
    
    string autoAccuracy;
    string teleAccuracy;
    int team1;
    string prompt;
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    Console.WriteLine("Enter Scouting Data (Type q or quit to go back to menu)");
    Console.Write("Team #: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    team = Console.ReadLine();
    if(!int.TryParse(team, out team1)){
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("This is not a team. Going back to menu. Press enter to continue");
      Console.ForegroundColor = ConsoleColor.White;
      Console.ReadLine();
      menu.menu();
    }
    Console.ForegroundColor = ConsoleColor.White;
    if(!File.Exists(team+".txt")){
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("This team doesn't exist. Would you like to add this team? (Type 'y' for yes or 'n' for no and you will go back to the menu.)");
      prompt = Console.ReadLine();
      if(prompt == "y"){
        addTeam(team);
        addLines(team);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("CREATED TEAM");
        Console.WriteLine("If you want to go back to menu, press 'y', if you want to continue, press enter");
        prompt = Console.ReadLine();
        if (prompt == "y"){
          Console.Clear();
          menu.menu();
        }
      }
      else{
        Console.Clear();
        menu.menu();
      }
    }
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Match: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    match = Console.ReadLine();
    if(match == "quit" || match == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Taxi (y or n): ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    taxi = Console.ReadLine();
    if(taxi == "quit" || taxi == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Auto Lower: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    autoLower = Console.ReadLine();
    if(autoLower.Length == 1){
      autoLower = "0" + autoLower;
    }
    if(autoLower == "quit" || autoLower == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Auto Upper: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    autoUpper = Console.ReadLine();
    if(autoUpper.Length == 1){
      autoUpper = "0" + autoUpper;
    }
    if(autoUpper == "quit" || autoUpper == "q"){
      menu.menu();
    }
    
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Auto Missed: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    autoMissed = Console.ReadLine();
    if(autoMissed.Length == 1){
      autoMissed = "0" + autoMissed;
    }
    if(autoMissed == "quit" || autoMissed == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Position (n,l,t,c): ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    position = Console.ReadLine();
    if(position == "quit" || position == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Tele Lower: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    teleLower = Console.ReadLine();
    if(teleLower.Length == 1){
      teleLower = "0" + teleLower;
    }
    if(teleLower == "quit" || teleLower == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Tele Upper: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    teleUpper = Console.ReadLine();
    if(teleUpper.Length == 1){
      teleUpper = "0" + teleUpper;
    }
    if(teleUpper == "quit" || teleUpper == "q"){
      menu.menu();
    }
    
    
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Tele Missed: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    teleMissed = Console.ReadLine();
    if(teleMissed.Length == 1){
      teleMissed = "0" + teleMissed;
    }
    if(teleMissed == "quit" || teleMissed == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Defense (0-2): ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    defense = Console.ReadLine();
    if(defense == "quit" || defense == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Climb Type (l,m,h,t,n): ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    climbType = Console.ReadLine();
    if(climbType == "quit" || climbType == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Climb Start: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    climbStart = Console.ReadLine();
    if(climbStart == "quit" || climbStart == "q"){
      menu.menu();
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Climb Finish: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    climbEnd = Console.ReadLine();
    if(climbEnd == "quit" || climbEnd == "q"){
      menu.menu();
    }
    

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Climb Entry (f, s): ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    climbEnter = Console.ReadLine();
    if(match == "quit" || match == "q"){
      menu.menu();
    }

    
    string data;
    Console.WriteLine("Press enter to continue, or q or quit to ditch the data");
    data = Console.ReadLine();
    if(data == "q" || data == "quit"){
      menu.menu();
    }

    climbTime = (Int32.Parse(climbStart) - Int32.Parse(climbEnd));
    
    double autoUpperInt = Double.Parse(autoUpper);
    double autoLowerInt = Double.Parse(autoLower);
    double autoMissedInt = Double.Parse(autoMissed);
    autoAccuracy = (autoUpperInt+autoLowerInt)/(autoUpperInt + autoLowerInt + autoMissedInt)*100 + "%";

    double teleUpperInt = Double.Parse(teleUpper);
    double teleLowerInt = Double.Parse(teleLower);
    double teleMissedInt = Double.Parse(teleMissed);
    teleAccuracy = (teleUpperInt+teleLowerInt)/(teleUpperInt + teleLowerInt + teleMissedInt)*100 + "%";
    

    
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
    writeToFile(team, "Entry: "+ climbEnter);

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
    if((autoCargo).ToString().Length == 1){
      writeToFile(team, "Auto Cargo Score: 0" + autoCargo);
    }
    else{
      writeToFile(team, "Auto Cargo Score: " + autoCargo);
    }
    
    writeToFile(team, "Auto Accuracy: " + autoAccuracy);
    writeToFile(team, "Tele Accuracy: " + teleAccuracy);

    
    writeToFile(team, "------------------------");
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("***********************");
    Console.ForegroundColor = ConsoleColor.Green;
    //Console.WriteLine(autoAccuracy);
    Console.WriteLine("Success!");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("***********************");
    
    
    Thread.Sleep(2500);
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    menu.menu();
  }
  public string GetLine(string fileName, int line)
  {
    using (var sr = new StreamReader(fileName)) {
    for (int i = 1; i < line; i++)
    sr.ReadLine();
    return sr.ReadLine();
    }
  }
  
  public void WriteLine(string fileName, int line)
  {
    using (var sr = new StreamWriter(fileName)) {
    for (int i = 1; i < line; i++)
    sr.WriteLine();
    }
  }
  
  public void lineChanger(string newText, string fileName, int line_to_edit)
  {
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit - 1] = newText;
     File.WriteAllLines(fileName, arrLine);
    
  }
  public void writeToFile(string team, string text){
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
}