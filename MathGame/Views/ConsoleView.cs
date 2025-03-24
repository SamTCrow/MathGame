using MathGame.Controller;
using MathGame.Localization;
using MathGame.Models;
using Spectre.Console;

namespace MathGame.Views;

internal class ConsoleView(Language lang = Language.Italiano) : IView
{
    public Language Lang { get; set; } = lang;

    public string Welcome()
    {
        string name = AnsiConsole.Ask<string>(Messages.AskName(Lang));
        AnsiConsole.MarkupLine($"[bold green on black]{Messages.Welcome(Lang, name)}[/]");
        return name;
    }

    public GameMode DisplayMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<GameMode>()
                .Title(Messages.MenuHeader(Lang))
                .AddChoices(Enum.GetValues<GameMode>())
                .UseConverter(mode =>
                    mode switch
                    {
                        GameMode.Addition => Messages.Addition(Lang),
                        GameMode.Subtraction => Messages.Subtraction(Lang),
                        GameMode.Multiplication => Messages.Multiplication(Lang),
                        GameMode.Division => Messages.Divide(Lang),
                        GameMode.Random => Messages.Random(Lang),
                        GameMode.Records => Messages.Record(Lang),
                        _ => throw new ArgumentOutOfRangeException(
                            nameof(mode),
                            mode,
                            "Invalid game mode"
                        ),
                    }
                )
        );
    }

    public int DisplayQuestion(QuestionData question)
    {
        string symbol = question.Operator switch
        {
            Operation.Subtraction => "-",
            Operation.Multiplication => "*",
            Operation.Division => "/",
            Operation.Addition => "+",
            _ => "Invalid operator.",
        };

        var answer = AnsiConsole.Ask<int>(
            $"[bold green on black]{question.FirstNumber}[/]  {symbol}  [bold green on black]{question.SecondNumber}[/]  [rapidblink]=[/]  "
        );
        return answer;
    }

    public bool DisplayResult(int answer, QuestionData question)
    {
        if (Question.CheckAnswer(answer, question))
        {
            AnsiConsole.MarkupLine($"[bold green on black]{Messages.Success(Lang)}[/]");
            Console.Beep();
            Console.WriteLine();
            return true;
        }
        else
        {
            AnsiConsole.MarkupLine($"[bold red on black]{Messages.Failure(Lang)}[/]");
            Console.WriteLine();
            return false;
        }
    }

    public void DisplayStatus(List<QuestionResult> result)
    {
        var table = new Table();
        table.AddColumn("");
        table.AddColumn("");
        table.HideHeaders();

        foreach (var questionResult in result)
        {
            table.AddRow(
                questionResult.QuestionNumber.ToString(),
                questionResult.Correct ? "[bold green on black]V[/]" : "[bold red on black]X[/]"
            );
        }
        AnsiConsole.Write(table);
    }

    public bool DisplayEnd(int score, string name, double time)
    {
        var keepPlaying = AnsiConsole.Ask<string>(Messages.End(Lang, score, name, time));
        return keepPlaying == "si" || keepPlaying == "yes";
    }

    public Difficulty DisplayDifficultyMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<Difficulty>()
                .Title(Messages.DifficultyHeader(Lang))
                .AddChoices(Enum.GetValues<Difficulty>())
                .UseConverter(mode =>
                    mode switch
                    {
                        Difficulty.Easy => Messages.Easy(Lang),
                        Difficulty.Medium => Messages.Medium(Lang),
                        Difficulty.Hard => Messages.Hard(Lang),
                        _ => throw new ArgumentOutOfRangeException(
                            nameof(mode),
                            mode,
                            "Invalid difficulty"
                        ),
                    }
                )
        );
    }

    public void DisplayRecord(List<GameInfo> gameList)
    {
        var table = new Table();
        table.AddColumn("Nome");
        table.AddColumn("Mode");
        table.AddColumn("Difficulty");
        table.AddColumn("Score");
        table.AddColumn("Time");
        table.HideHeaders();
        foreach (GameInfo game in gameList)
        {
            table.AddRow(
                game.Name,
                game.Mode.ToString(),
                game.Difficulty.ToString(),
                game.Score.ToString(),
                game.Time.ToString("F2")
            );
            ;
        }
        AnsiConsole.Write(table);
        Console.ReadLine();
        AnsiConsole.Clear();
    }
}