using System;
using System.IO;
using System.Threading;

class Program {
    
  
  
  /*
  public static void bestTeamHang(){
    int tempNum = 0;
    int time = 1000;
    string timeTeam = "";
    
    for(int i = 0; i < 20000; i++){
      if(File.Exists(i+".txt")){
        int j = 1;
        while(GetLine(i+".txt", j) != GetLine("blank.txt", 1)){
          //Console.WriteLine(GetLine(team+".txt",i));
          j++;
          if(GetLine(i+".txt", j).Contains("Total Climb Time")){
            string num1 = GetLine(i+".txt", j)[18].ToString();
            string num2 = GetLine(i+".txt", j)[19].ToString();
            tempNum = Int32.Parse(num1+num2);
            if(tempNum < time ){
              timeTeam = i.ToString();
              time = tempNum;
            }
            
          }
        }
      }
    }
    Console.WriteLine("Team " + timeTeam + " Climb Time " + time);
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Press Enter to go back to menu");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadLine();
    Console.Clear();
    menu();
  }
*/
  ///<summary>
  ///Basically looks at the best stats for something specific. This can be cargo, or hang, or even defense
  ///</summary>
  
  ///<summary>
  ///Looks at the best scores for a specified team
  ///</summary>
  

  ///<summary>
  ///Finds the average cargo for team selected
  ///</summary>
  

  

  //Here's some overused methods
    
  
  public static void Main (string[] args) {
    Menu menu = new Menu();
    menu.menu();
  }
}