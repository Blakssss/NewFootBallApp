namespace FootballAppNew;

public class MatchSimulator
{
    
    private readonly int _opportunitiesForGoal = 6;
   
    private readonly int _diceSize = 10;
  
    private readonly int _defendingDiceHandicap = 2;

    
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

    
    private int FindHighestRoll(List<int> diceRolls)
    {
        int highestRoll = 1;
        foreach (var diceRoll in diceRolls)
        {
            if (diceRoll > highestRoll) { highestRoll = diceRoll; }
        }

        return highestRoll;
    }

    
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

    
    private int RollDice()
    {
        Random random = new Random();
        return random.Next(_diceSize) + 1;
    }
}