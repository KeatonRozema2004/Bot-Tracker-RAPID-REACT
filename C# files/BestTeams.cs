using System;
using System.IO;
using System.Threading;
class BestTeam{
  public void bestTeamMenu(){
    Menu menu = new Menu();
    MatchMake match = new MatchMake();
    string prompt;
    Console.WriteLine("Best Team Menu");
    Console.WriteLine("---------------------");
    Console.WriteLine("1. Top 10 Tele Upper Cargo Amount");
    Console.WriteLine("2. Top 10 Tele Lower Cargo Amount");
    Console.WriteLine("3. Top 10 Tele Overall Cargo Points");
    Console.WriteLine("4. Top 10 Climb Type/Time");
    Console.WriteLine("5. Top 10 Defense Bot");
    prompt = Console.ReadLine();
    if(prompt == "1"){
      Console.Clear();
      bestTeamsStats("Tele Upper", 12, 13, 0, 0, false);
    }
    else if(prompt == "2"){
      Console.Clear();
      bestTeamsStats("Tele Lower", 12, 13, 0, 0, false);
    }
    else if(prompt == "3"){
      Console.Clear();
      bestTeamsStats("Tele Cargo Score", 18, 19, 0, 0, false);
    }
    else if(prompt == "4"){
      Console.Clear();
      bestTeamsStats("Total Climb Time", 18, 19, 0, 10000, true);
    }
    else{
      Console.Clear();
      menu.menu();
    }
    
  }







  
  public void bestScore(string team){
    MatchMake match = new MatchMake();
    int autoHigh = 0;
    int autoLow = 0;
    int teleHigh = 0;
    int teleLow = 0;
    int time = 500;
    //int leastAutoMissed = 500;
    //int leastTeleMissed = 500;
    int defense = 0;
    int tempNum = 0;
    //string tempString;
    string climbType = "n";
    int i = 1; 
    //Console.WriteLine("Getting team data...");
    while(match.GetLine(team+".txt", i) != match.GetLine("blank.txt", 1)){
      //Console.WriteLine(match.GetLine(team+".txt",i));
      i++;
      if(match.GetLine(team+".txt", i).Contains("Auto Upper")){
        string num1 = match.GetLine(team+".txt", i)[12].ToString();
        string num2 = match.GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > autoHigh){
          autoHigh = tempNum;
        }
      }
      if(match.GetLine(team+".txt", i).Contains("Auto Lower")){
        string num1 = match.GetLine(team+".txt", i)[12].ToString();
        string num2 = match.GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > autoLow){
          autoLow = tempNum;
        }
      }
      if(match.GetLine(team+".txt", i).Contains("Tele Lower")){
        string num1 = match.GetLine(team+".txt", i)[12].ToString();
        string num2 = match.GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > teleLow){
          teleLow = tempNum;
        }
      }
      if(match.GetLine(team+".txt", i).Contains("Tele Upper")){
        string num1 = match.GetLine(team+".txt", i)[12].ToString();
        string num2 = match.GetLine(team+".txt", i)[13].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum > teleHigh){
          teleHigh = tempNum;
        }
      }

      if(match.GetLine(team+".txt", i).Contains("Defense")){
        string num1 = match.GetLine(team+".txt", i)[9].ToString();
        tempNum = Int32.Parse(num1);
        if(tempNum > defense){
          defense = tempNum;
        }
      }
      /*
      if(match.GetLine(team+".txt", i).Contains("Total Climb Time")){
        string num1 = match.GetLine(team+".txt", i)[18].ToString();
        string num2 = match.GetLine(team+".txt", i)[19].ToString();
        tempNum = Int32.Parse(num1+num2);
        if(tempNum < time){
          time = tempNum;
        }
      }
*/
      if(match.GetLine(team+".txt", i).Contains("Climb Type")){
        string climb = match.GetLine(team+".txt", i)[12].ToString();
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





    i=0;
    while(match.GetLine(team+".txt", i) != match.GetLine("blank.txt", 1)){
      //Console.WriteLine(match.GetLine(team+".txt",i));
      i++;

      if(match.GetLine(team+".txt", i).Contains("Total Climb Time")){
        string num1 = match.GetLine(team+".txt", i)[18].ToString();
        string num2 = match.GetLine(team+".txt", i)[19].ToString();
        tempNum = Int32.Parse(num1+num2);
        
        if(tempNum < time && match.GetLine(team+".txt", i-4)[12].ToString() == climbType){
          time = tempNum;
          
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
    Console.WriteLine("Best Defense: " + defense);
    Console.WriteLine();
    
    
  }
  public static void bestTeamsStats(string contains, int numb1, int numb2, int tempNumb, int startNum, bool hang){
    MatchMake match = new MatchMake();
    Menu menu = new Menu();
    int tempNum = tempNumb;
    int numTeams = 10000;
    int teleHigh1 = startNum;
    int teleHigh2 = startNum;
    int teleHigh3 = startNum;
    int teleHigh4 = startNum;
    int teleHigh5 = startNum;
    int teleHigh6 = startNum;
    int teleHigh7 = startNum;
    int teleHigh8 = startNum;
    int teleHigh9 = startNum;
    int teleHigh10 = startNum;
    
    string teleHighTeam1 = "";
    string teleHighTeam2 = "";
    string teleHighTeam3 = "";
    string teleHighTeam4 = "";
    string teleHighTeam5 = "";
    string teleHighTeam6 = "";
    string teleHighTeam7 = "";
    string teleHighTeam8 = "";
    string teleHighTeam9 = "";
    string teleHighTeam10 = "";
    
    
    for(int i = 0; i < numTeams; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(match.GetLine(i+".txt", j) != match.GetLine("blank.txt", 1)){
          //Console.WriteLine(match.GetLine(team+".txt",i));
          j++;
          if(match.GetLine(i+".txt", j).Contains(contains)){
            string num1 = match.GetLine(i+".txt", j)[numb1].ToString();
            string num2 = match.GetLine(i+".txt", j)[numb2].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh1 && hang == false){
              teleHighTeam1 = i.ToString();
              teleHigh1 = tempNum;
            }
            else if(tempNum < teleHigh1 && hang){
              teleHighTeam1 = i.ToString();
              teleHigh1 = tempNum;
            }
          }
        }
      }
    }
    tempNum = tempNumb;
    for(int i = 0; i < numTeams; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(match.GetLine(i+".txt", j) != match.GetLine("blank.txt", 1)){
          //Console.WriteLine(match.GetLine(team+".txt",i));
          j++;
          if(match.GetLine(i+".txt", j).Contains(contains) && i+".txt" != teleHighTeam1 + ".txt"){
            string num1 = match.GetLine(i+".txt", j)[numb1].ToString();
            string num2 = match.GetLine(i+".txt", j)[numb2].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh2 && hang == false){
              teleHighTeam2 = i.ToString();
              teleHigh2 = tempNum;
            }
            else if(tempNum < teleHigh2 && hang){
              teleHighTeam2 = i.ToString();
              teleHigh2 = tempNum;
            }
          }
        }
      }
    }
    tempNum = tempNumb;
    for(int i = 0; i < numTeams; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(match.GetLine(i+".txt", j) != match.GetLine("blank.txt", 1)){
          //Console.WriteLine(match.GetLine(team+".txt",i));
          j++;
          if(match.GetLine(i+".txt", j).Contains(contains) && i+".txt" != teleHighTeam1 + ".txt" && i+".txt" != teleHighTeam2 + ".txt" ){
            string num1 = match.GetLine(i+".txt", j)[numb1].ToString();
            string num2 = match.GetLine(i+".txt", j)[numb2].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh3 && hang == false){
              teleHighTeam3 = i.ToString();
              teleHigh3 = tempNum;
            }
            else if(tempNum < teleHigh3 && hang){
              teleHighTeam3 = i.ToString();
              teleHigh3 = tempNum;
            }
          }
        }
      }
    }
    tempNum = tempNumb;
    for(int i = 0; i < numTeams; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(match.GetLine(i+".txt", j) != match.GetLine("blank.txt", 1)){
          //Console.WriteLine(match.GetLine(team+".txt",i));
          j++;
          if(match.GetLine(i+".txt", j).Contains(contains) && i+".txt" != teleHighTeam1 + ".txt" && i+".txt" != teleHighTeam2 + ".txt"&& i+".txt" != teleHighTeam3 + ".txt"){
            string num1 = match.GetLine(i+".txt", j)[numb1].ToString();
            string num2 = match.GetLine(i+".txt", j)[numb2].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh4 && hang == false){
              teleHighTeam4 = i.ToString();
              teleHigh4 = tempNum;
            }
            else if(tempNum < teleHigh4 && hang){
              teleHighTeam4 = i.ToString();
              teleHigh4 = tempNum;
            }
          }
        }
      }
    }
    tempNum = tempNumb;
    for(int i = 0; i < numTeams; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(match.GetLine(i+".txt", j) != match.GetLine("blank.txt", 1)){
          //Console.WriteLine(match.GetLine(team+".txt",i));
          j++;
          if(match.GetLine(i+".txt", j).Contains(contains) && i+".txt" != teleHighTeam1 + ".txt" && i+".txt" != teleHighTeam2 + ".txt"&& i+".txt" != teleHighTeam3 + ".txt"&& i+".txt" != teleHighTeam4 + ".txt"){
            string num1 = match.GetLine(i+".txt", j)[numb1].ToString();
            string num2 = match.GetLine(i+".txt", j)[numb2].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum > teleHigh5 && hang == false){
              teleHighTeam5 = i.ToString();
              teleHigh5 = tempNum;
            }
            else if(tempNum < teleHigh5 && hang){
              teleHighTeam5 = i.ToString();
              teleHigh5 = tempNum;
            }
          }
        }
      }
    }

    Console.WriteLine("1. Team " + teleHighTeam1 + " Upper Tele: " + teleHigh1);
    Console.WriteLine("2. Team " + teleHighTeam2 + " Upper Tele: " + teleHigh2);
    Console.WriteLine("3. Team " + teleHighTeam3 + " Upper Tele: " + teleHigh3);
    Console.WriteLine("4. Team " + teleHighTeam4 + " Upper Tele: " + teleHigh4);
    Console.WriteLine("5. Team " + teleHighTeam5 + " Upper Tele: " + teleHigh5);
    Console.WriteLine("6. Team " + teleHighTeam6 + " Upper Tele: " + teleHigh6);
    Console.WriteLine("7. Team " + teleHighTeam7 + " Upper Tele: " + teleHigh7);
    Console.WriteLine("8. Team " + teleHighTeam8 + " Upper Tele: " + teleHigh8);
    Console.WriteLine("9. Team " + teleHighTeam9 + " Upper Tele: " + teleHigh9);
    Console.WriteLine("10. Team " + teleHighTeam10 + " Upper Tele: " + teleHigh10);
    
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Press Enter to go back to menu");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadLine();
    Console.Clear();
    menu.menu();
  }
}