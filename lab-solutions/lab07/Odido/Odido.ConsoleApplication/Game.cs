namespace Odido.ConsoleApplication;

internal class Game
{
    public string PlayerName { get; }
    public DateTime CreationDate { get; }
    public bool IsCompleted { get; private set; }
    public string? WinnerType { get; private set; }
    private List<Character> Characters { get; }
    public List<CombatLogEntry> CombatLog { get; }

    public Character Hero => Characters.OfType<Character>().First(c => c.Name == "Hero");
    public Character Boss => Characters.OfType<Character>().First(c => c.Name == "Boss");

    public Game(string playerName)
    {
        PlayerName = playerName;
        CreationDate = DateTime.Now;
        IsCompleted = false;
        WinnerType = null;
        Characters = [
            new Character("Hero"),
            new Character("Boss")
        ];
        CombatLog = [ new CombatLogEntry("Game started") ];
    }

    public bool PlayTurn(GameAction action)
    {
        if (IsCompleted) return true;

        // Hero's turn
        if (action == GameAction.Attack)
        {
            int damage = Hero.Attack(Boss);
            CombatLog.Add(new CombatLogEntry($"Hero attacks Boss for {damage} damage."));
        }
        else
        {
            int healed = Hero.Heal();
            CombatLog.Add(new CombatLogEntry($"Hero heals for {healed} health."));
        }

        if (!Boss.IsAlive)
        {
            IsCompleted = true;
            WinnerType = "Hero";
            CombatLog.Add(new CombatLogEntry("Boss has been defeated! Hero wins."));
            return true;
        }

        // Boss's turn
        int bossDamage = Boss.Attack(Hero);
        CombatLog.Add(new CombatLogEntry($"Boss attacks Hero for {bossDamage} damage."));

        if (!Hero.IsAlive)
        {
            IsCompleted = true;
            WinnerType = "Boss";
            CombatLog.Add(new CombatLogEntry("Hero has been defeated! Boss wins."));
            return true;
        }

        return false;
    }

    public string GetLastLogEntry()
    {
        return CombatLog.Last().Message;
    }
}
