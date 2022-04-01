using System;
using System.IO;
using System.Threading;

class Average
{
    public int averageCargo()
    {
        MatchMake match = new MatchMake();
        Menu menu = new Menu();
        //String stringy = new String();
        string team;
        int averageScoreTele = 0;
        int averageScoreAccTele = 0;
        int teleUpper = 0;
        int i = 1;
        int j = 0;
        Console.Write("Team #: ");
        team = Console.ReadLine();
        while (match.GetLine(team + ".txt", i) != match.GetLine("blank.txt", 1))
        {
            //Console.WriteLine(GetLine(team+".txt",i));
            i++;
            if (match.GetLine(team + ".txt", i).Contains("Tele Upper"))
            {
                string num1 = match.GetLine(team + ".txt", i)[12].ToString();
                string num2 = match.GetLine(team + ".txt", i)[13].ToString();
                teleUpper += Int32.Parse(num1 + num2);
                j++;
            }
        }
        teleUpper = teleUpper / j;
        i = 0;
        j = 0;
        while (match.GetLine(team + ".txt", i) != match.GetLine("blank.txt", 1))
        {
            //Console.WriteLine(GetLine(team+".txt",i));
            i++;
            if (match.GetLine(team + ".txt", i).Contains("Tele Cargo Score"))
            {
                string num1 = match.GetLine(team + ".txt", i)[18].ToString();
                string num2 = match.GetLine(team + ".txt", i)[19].ToString();
                averageScoreTele += Int32.Parse(num1 + num2);
                j++;
            }
        }
        averageScoreTele = averageScoreTele / j;
        i = 0;
        j = 0;
        while (match.GetLine(team + ".txt", i) != match.GetLine("blank.txt", 1))
        {
            //Console.WriteLine(GetLine(team+".txt",i));
            i++;
            if (match.GetLine(team + ".txt", i).Contains("Tele Accuracy"))
            {
                string num1 = match.GetLine(team + ".txt", i)[15].ToString();
                string num2 = match.GetLine(team + ".txt", i)[16].ToString();
                averageScoreAccTele += Int32.Parse(num1 + num2);
                j++;
            }
        };

        Console.WriteLine("Average Tele Upper Cargo Score: " + teleUpper);
        Console.WriteLine("Average Tele Cargo Score: " + averageScoreTele);
        Console.WriteLine("Average Accuracy Tele Cargo Score: " + averageScoreAccTele + "%");
        Console.WriteLine();

        Console.WriteLine("Please press Enter to go back to menu");
        Console.ReadLine();
        Console.Clear();
        menu.menu();
        return 1;
    }
}