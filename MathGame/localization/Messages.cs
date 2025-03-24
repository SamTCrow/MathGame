namespace MathGame.Localization;

internal static class Messages
{
    internal static string AskName(Language language)
    {
        return language switch
        {
            Language.English => "What's your name?",
            Language.Italiano => "Come ti chiami?",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Welcome(Language language, string name)
    {
        return language switch
        {
            Language.English => $"Welcome, {name}!",
            Language.Italiano => $"Benvenuto, {name}!",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string MenuHeader(Language language)
    {
        return language switch
        {
            Language.English => "Choose a game mode:",
            Language.Italiano => "Scegli una modalità di gioco:",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string DifficultyHeader(Language language)
    {
        return language switch
        {
            Language.English => "Choose a difficulty level:",
            Language.Italiano => "Scegli un livello di difficoltà:",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Easy(Language language)
    {
        return language switch
        {
            Language.English => "Easy",
            Language.Italiano => "Facile",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Medium(Language language)
    {
        return language switch
        {
            Language.English => "Medium",
            Language.Italiano => "Medio",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Hard(Language language)
    {
        return language switch
        {
            Language.English => "Hard",
            Language.Italiano => "Difficile",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Addition(Language language)
    {
        return language switch
        {
            Language.English => "Addition",
            Language.Italiano => "Addizione",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Subtraction(Language language)
    {
        return language switch
        {
            Language.English => "Subtraction",
            Language.Italiano => "Sottrazione",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Multiplication(Language language)
    {
        return language switch
        {
            Language.English => "Multiplication",
            Language.Italiano => "Moltiplicazione",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Divide(Language language)
    {
        return language switch
        {
            Language.English => "Division",
            Language.Italiano => "Divisione",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Random(Language language)
    {
        return language switch
        {
            Language.English => "Random",
            Language.Italiano => "Casuale",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Record(Language language)
    {
        return language switch
        {
            Language.English => "Charts",
            Language.Italiano => "Classifica",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Success(Language language)
    {
        return language switch
        {
            Language.English => "Correct!",
            Language.Italiano => "Corretto!",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string Failure(Language language)
    {
        return language switch
        {
            Language.English => "Incorrect!",
            Language.Italiano => "Sbagliato!",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string End(Language language, int score, string name, double time)
    {
        return language switch
        {
            Language.English =>
                $"Congratulations, {name}! You scored {score} in {time:F2} seconds! Do you want to play again? (yes/no)",
            Language.Italiano =>
                $"Complimenti, {name}! Hai totalizzato {score} in {time:F2} secondi! Vuoi giocare ancora? (si/no)",
            _ => throw new NotImplementedException(),
        };
    }
}

public enum Language
{
    English,
    Italiano,
}