namespace FootballAppNew;

public class FootballTeams
{
    
    // Properties
    public string FullClubName { get; set; }
    public string Abbreviation { get; set; }
    public char SpecialRanking { get; set; }

    // Constructor
    public FootballTeams(string fullClubName, string abbreviation, char specialRanking)
    {
        FullClubName = fullClubName;
        Abbreviation = abbreviation;
        SpecialRanking = specialRanking;
        
    }

    public FootballTeams(string[] teamValues)
    {
        FullClubName = teamValues[0];
        Abbreviation = teamValues[1];
        SpecialRanking = teamValues[2][0];
    }

    public string ConvertTOCSVFormat()
    {
        return $"{FullClubName},{Abbreviation},{SpecialRanking}";
    }
    
}