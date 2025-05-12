namespace Odido.ConsoleApplication;

internal interface IGameRepository
{
    List<Game> GetActiveGamesForPlayer(string playerName);
    Game? GetById(int gameId);
    void Create(Game game);
    void Update(Game game);
}
