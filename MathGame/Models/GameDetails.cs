using MathGame.Controller;

namespace MathGame.Models;

internal record GameInfo(GameMode Mode, Difficulty Difficulty, int Score, string Name, double Time);

internal record GameDetails(GameMode Mode, Difficulty Difficulty);

public record QuestionData(int FirstNumber, int SecondNumber, Operation Operator);

public record QuestionResult(int QuestionNumber, bool Correct);

public enum GameMode
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random,
    Records,
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
}

public enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}