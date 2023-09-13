namespace FootballAppNew;

public class FootballTeams
{
    
    // Properties
    public string FullClubName { get; set; }
    public string Abbreviation { get; set; }
    public char SpecialRanking { get; set; }
    
    public int Defense { get; set; }
    public int Offense { get; set; }

    // Constructor
    public FootballTeams(string fullClubName, string abbreviation, char specialRanking)
    {
        FullClubName = fullClubName;
        Abbreviation = abbreviation;
        SpecialRanking = specialRanking;
        Defense = RollRandomStat();
        Offense = RollRandomStat();
    }
    public FootballTeams(string fullClubName, string abbreviation, char specialRanking, int defence, int offense)
    {
        FullClubName = fullClubName;
        Abbreviation = abbreviation;
        SpecialRanking = specialRanking;
        Defense = LimitStat(defence);
        Offense = LimitStat(offense);
    }

    public FootballTeams(string[] teamValues)
    {
        FullClubName = teamValues[0];
        Abbreviation = teamValues[1];
        SpecialRanking = teamValues[2][0];
        Defense = Convert.ToInt32(teamValues[3]);
        Offense = Convert.ToInt32(teamValues[4]);
    }

    public string ConvertTOCSVFormat()
    {
        return $"{FullClubName},{Abbreviation},{SpecialRanking},{Defense},{Offense}";
    }
    
    private int LimitStat(int stat)
    {
        if (stat > 10) { return 10; }
         if (stat < 1) { return 1; } 
         return stat;
    }

    private int RollRandomStat()
    {
        int maxStat = 10;
        Random random = new Random();
        int randomStat = random.Next(maxStat) + 1;
        return randomStat;
    }
    
}