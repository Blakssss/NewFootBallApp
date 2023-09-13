using FootballAppNew;

// HER LAVER VI VORES TEAMS
FootballTeams team1 = new FootballTeams("Manchester United", "MU", 'W');
FootballTeams team2 = new FootballTeams("Liverpool FC", "LFC", 'C');
FootballTeams team3 = new FootballTeams("Chelsea FC", "CFC", 'C');
FootballTeams team4 = new FootballTeams("Arsenal FC", "AFC", 'P');
FootballTeams team5 = new FootballTeams("Tottenham Hotspur", "THFC", 'P');
FootballTeams team6 = new FootballTeams("Leicester City", "LCFC", 'P');
FootballTeams team7 = new FootballTeams("West Ham United", "WHU", 'R');
FootballTeams team8 = new FootballTeams("Aston Villa", "AVFC", 'R');
FootballTeams team9 = new FootballTeams("Everton FC", "EFC", 'R');
FootballTeams team10 = new FootballTeams("Leeds United", "LUFC", 'R');
FootballTeams team11 = new FootballTeams("Manchester City", "MCFC", 'C');
FootballTeams team12 = new FootballTeams("Wolverhampton Wanderers", "Wolves", 'P');

// Her laver vi en liste af vores teams.
List<FootballTeams> listOfTeams = new List<FootballTeams>() {team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12};

// Her laver vi en ny instans af en filehandler. 
FileHandler fileHandler = new FileHandler("teams.csv", "FullClubName,Abbreviation,Special Ranking");

// vi laver teams om til strings for at kunne write dem.
List<string> teamsAsString = new List<string>();


// Vi tager hvert team objekt i vores listOfTeams og laver om til en string hvor hvert ord/property bliver delt med et komma , vha ConvertToCSVFormat metoden.
foreach (var team in listOfTeams)
{
    teamsAsString.Add(team.ConvertTOCSVFormat());
}

// Her passer vi så vores liste af teams, hvor hvert team nu er formateret som strings i dette format "FCKøbenhavn,FCK,W"
fileHandler.write(teamsAsString);
// Nu ligger vores teams i CSV format i en fil


List<string[]> readTeamsFromCSV = fileHandler.ReadCsvFile();
List<FootballTeams> readListOfTeams = new List<FootballTeams>();

foreach (var team in readTeamsFromCSV)
{
    readListOfTeams.Add(new FootballTeams(team));
}

foreach (var team in readListOfTeams)
{
    Console.WriteLine(team.FullClubName);
}