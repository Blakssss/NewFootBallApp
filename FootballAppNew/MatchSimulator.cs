namespace FootballAppNew;
// This is a class that can be made an object of and simulate a match between two teams and get an outcome
public class MatchSimulator
{
    // Change the number to decide the amount of times each team gets a chance to score one another
    private readonly int _opportunitiesForGoal = 6;
    // Change the number to decide the highest amount a dice can be
    private readonly int _diceSize = 10;
    // Change the number to alter how many extra dice a defending team gets
    private readonly int _defendingDiceHandicap = 2;

    // Methode you call, to get an outcome between two teams.
    // You can think the firstTeam as the home and the second as out team or opposite as long as you do the same for all other teams
    public MatchOutcome SimulateOutcome(FootballTeams firstTeam, FootballTeams secondTeam)
    {
        int firstTeamScore = 0;
        int secondTeamScore = 0;
        int opportunityCounter = 0;
        while (opportunityCounter < _opportunitiesForGoal)
        {
            firstTeamScore += SimulateGoalOpportunity(firstTeam, secondTeam);
            secondTeamScore += SimulateGoalOpportunity(secondTeam, firstTeam);
            opportunityCounter++;
        }
        
        
        return new MatchOutcome(firstTeam, firstTeamScore, secondTeam, secondTeamScore);
    }

    // a method the class uses to figure out if an attackingTeam either, scored a goal '1' or didn't '0'
    // It does this by rolling a certain number of dice for each team, then the highest valued dice is taken from each team
    // and if the attackingTeam has lower or the same as the defendingTeam, then they did not score.
    private int SimulateGoalOpportunity(FootballTeams attackingTeam, FootballTeams defendingTeam)
    {
        List<int> attackingTeamDiceRolls = SimulateAttackRoll(attackingTeam);
        List<int> defendingTeamDiceRolls = SimulateDefendingRoll(defendingTeam);

        int highestAttackRoll = FindHighestRoll(attackingTeamDiceRolls);
        int highestDefendingRoll = FindHighestRoll(defendingTeamDiceRolls);

        if (highestAttackRoll > highestDefendingRoll)
        {
            return 1;
        }

        return 0;
    }

    // a method the class uses to find the highest number in a list of diceRolls
    private int FindHighestRoll(List<int> diceRolls)
    {
        int highestRoll = 1;
        foreach (var diceRoll in diceRolls)
        {
            if (diceRoll > highestRoll) { highestRoll = diceRoll; }
        }

        return highestRoll;
    }

    // a method the class uses to get a list of dice rolls for an attackingTeam
    private List<int> SimulateAttackRoll(FootballTeams attackingTeam)
    {
        List<int> attackDiceRolls = new List<int>();
        int amountOfOffenseDice = attackingTeam.Offense;
        for (int i = 0; i < amountOfOffenseDice; i++)
        {
            int diceRollValue = RollDice();
            attackDiceRolls.Add(diceRollValue);
        }

        return attackDiceRolls;
    }

    // a method the class uses to get a list of dice rolls for a defendingTeam
    private List<int> SimulateDefendingRoll(FootballTeams defendingTeam)
    {
        List<int> defendingDiceRolls = new List<int>();
        int amountOfDefenseDice = defendingTeam.Defense + _defendingDiceHandicap; 
        for (int i = 0; i < amountOfDefenseDice; i++)
        {
            int diceRollValue = RollDice();
            defendingDiceRolls.Add(diceRollValue);
        }

        return defendingDiceRolls;
    }

    // a method the class uses to get the value of a dice roll between 1 and the amount the _dicesSize is set to
    private int RollDice()
    {
        Random random = new Random();
        return random.Next(_diceSize) + 1;
    }
}