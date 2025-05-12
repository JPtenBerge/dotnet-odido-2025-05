using Odido.ConsoleApplication;
using static System.Net.Mime.MediaTypeNames;

var repo = new InMemoryGameRepository();
var service = new GameService(repo);
Game? game = null;

Console.WriteLine("Enter your name, Hero:");
string playerName = Console.ReadLine() ?? "Hero";

bool exit = false;
while (!exit)
{
    DisplayMainMenu();
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1": // List games
                DisplayGames();
                break;
            case "2": // Create new game
                CreateGame();
                break;
            case "3": // Select a game
                SelectGame();
                break;
            case "4": // Play the selected game
                PlayTurn();
                break;
            case "5": // Quit
                exit = true;
                Console.WriteLine("Thanks for playing! Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    } catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    if (!exit)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
    
void CreateGame() {
    game = service.CreateNewGame(playerName);
    Console.WriteLine($"New game created with ID: {game.Id}");
}

void PlayTurn()
{
    if(game is null)
    {
        Console.WriteLine("No game selected. Please select a game first.");
        return;
    }
    if (game.IsCompleted)
    {
        Console.WriteLine("Game is over. Please select a new game or create a new one.");
        return;
    }
    DisplayGame();
    Console.WriteLine("What do you want to do next? [1: Attack, 2: Heal]");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out int choice) || (choice != 1 && choice != 2 ) )
    {
        Console.WriteLine("Invalid input. Please enter 1 for attack, 2 for heal.");
        return;
    }
    GameAction action = (GameAction)(choice - 1);
    service.PlayTurn(game.Id, action);
    DisplayGame();
}

void DisplayGame() {
    DisplayCombatLog();
    Console.WriteLine($"{game.Hero.Name}'s health: {game.Hero.Health}");
    Console.WriteLine($"{game.Boss.Name}'s health: {game.Boss.Health}");
}
void DisplayCombatLog()
{
    Console.WriteLine("Combat Log:");
    foreach (var entry in game.CombatLog)
    {
        Console.WriteLine($"{entry.Timestamp}: {entry.Message}");
    }
}

void DisplayGames()
{
    var games = service.GetGamesByPlayer(playerName);
    if (games.Count == 0)
    {
        Console.WriteLine("No active games found.");
        return;
    }
    Console.WriteLine("Active Games:");
    foreach (var g in games)
    {
        Console.WriteLine($"Game ID: {g.Id}, Created on: {g.CreationDate} - Hero: {g.Hero.Health} - Boss: {g.Boss.Health}");
    }
}

void SelectGame() {
    Console.Clear();
    DisplayGames();
    Console.WriteLine("Enter the Game ID to select:");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out int gameId))
    {
        Console.WriteLine("Invalid Game ID.");
        return;
    }
    game = service.GetGameById(gameId);
    if (game is null)
    {
        Console.WriteLine("Game not found.");
        return;
    }
}

void DisplayMainMenu() {
    Console.WriteLine("1. List Active Games");
    Console.WriteLine("2. Create New Game");
    Console.WriteLine("3. Select Game");
    Console.WriteLine("4. Play Game");
    Console.WriteLine("5. Quit");
}

//Lab 13
void Lab13() {
    //Create a list with multiple characters (both Hero and Boss).
    //Try using the helper method to:
    // -Print the character's type, name, and health
    // - Apply 10 damage to each character
    // -Print a motivational message using an inline lambda

    var characters = new List<Character>
    {
        new Hero("Hero1"),
        new Boss("Boss1"),
        new Hero("Hero2"),
        new Boss("Boss2")
    };

    // Print character details
    Utilities.ForEachCharacter(characters, character => Console.WriteLine($"Type: {character.GetType().Name}, Name: {character.Name}, Health: {character.Health}"));

    // Apply 10 damage to each character
    Utilities.ForEachCharacter(characters, character =>
    {
        character.TakeDamage(10);
        Console.WriteLine($"{character.Name} took 10 damage. Remaining Health: {character.Health}");
    });

    // Print motivational message
    Utilities.ForEachCharacter(characters, character => Console.WriteLine($"{character.Name} with thealt {character.Health} is doing great!"));
}