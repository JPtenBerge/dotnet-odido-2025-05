namespace Odido.ConsoleApplication;

internal delegate void CharacterAction(Character character);

internal delegate void Action<T>(T item);

internal static class Utilities
{
    /// <summary>
    /// Executes the specified action for each character in the list.
    /// </summary>
    /// <param name="characters">The list of characters.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when characters or action is null.</exception>
    public static void ForEachCharacter(List<Character> characters, CharacterAction action)
    {
        if (characters is null) throw new ArgumentNullException(nameof(characters));
        if (action is null) throw new ArgumentNullException(nameof(action));
        foreach (var character in characters)
        {
            action(character);
        }
    }

    /// <summary>
    /// Executes the specified action for each item in the list.
    /// </summary>
    /// <param name="items">The list of items.</param>
    /// <param name="action">The action to execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when items or action is null.</exception>
    public static void ForEach<T>(List<T> items, Action<T> action)
    {
        if (items is null) throw new ArgumentNullException(nameof(items));
        if (action is null) throw new ArgumentNullException(nameof(action));
        foreach (var item in items)
        {
            action(item);
        }
    }
}
