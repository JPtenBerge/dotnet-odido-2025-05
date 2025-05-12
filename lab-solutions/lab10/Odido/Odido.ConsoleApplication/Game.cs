namespace Odido.ConsoleApplication;

internal class Game
{
    public string PlayerName { get; }
    public DateTime CreationDate { get; }
    public bool IsCompleted { get; private set; }
    public string? WinnerType { get; private set; }
    private List<Character> Characters { get; }
    public List<CombatLogEntry> CombatLog { get; }

    public Hero Hero => Characters.OfType<Hero>().First();
    public Boss Boss => Characters.OfType<Boss>().First();

    public Game(string playerName)
    {
        PlayerName = playerName;
        CreationDate = DateTime.Now;
        IsCompleted = false;
        WinnerType = null;
        Characters = [
            new Hero(),
            new Boss()
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
            CombatLog.Add(new CombatLogEntry($"{Hero.Name} attacks {Boss.Name} for {damage} damage."));
        }
        else
        {
            int healed = Hero.Heal();
            CombatLog.Add(new CombatLogEntry($"{Hero.Name} heals for {healed} health."));
        }

        if (!Boss.IsAlive)
        {
            IsCompleted = true;
            WinnerType = "Hero";
            CombatLog.Add(new CombatLogEntry($"{Boss.Name} has been defeated! {Hero.Name} wins."));
            return true;
        }

        // Boss's turn
        int bossDamage = Boss.Attack(Hero);
        CombatLog.Add(new CombatLogEntry($"{Boss.Name} attacks {Hero.Name} for {bossDamage} damage."));

        if (!Hero.IsAlive)
        {
            IsCompleted = true;
            WinnerType = "Boss";
            CombatLog.Add(new CombatLogEntry($"{Hero.Name} has been defeated! {Boss.Name} wins."));
            return true;
        }

        return false;
    }

    public string GetLastLogEntry()
    {
        return CombatLog.Last().Message;
    }
}
