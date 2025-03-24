using MathGame.Models;

namespace MathGame.Controller;

internal class Question(GameDetails game)
{
    public Difficulty Difficulty
    {
        get => game.Difficulty;
    }

    public GameMode Mode
    {
        get => game.Mode;
    }

    public int Answer { get; }

    public QuestionData GetQuestion()
    {
        Operation symbol = Mode switch
        {
            GameMode.Addition => Operation.Addition,
            GameMode.Subtraction => Operation.Subtraction,
            GameMode.Multiplication => Operation.Multiplication,
            GameMode.Division => Operation.Division,
            GameMode.Random => Enum.GetValues<Operation>()[new Random().Next(0, 4)],
            _ => Enum.GetValues<Operation>()[new Random().Next(0, 4)],
        };

        int max = Difficulty switch
        {
            Difficulty.Easy => 11,
            Difficulty.Medium => 101,
            Difficulty.Hard => 1001,
            _ => 11,
        };
        int firstNumber = new Random().Next(1, max);
        int secondNumber = new Random().Next(1, max);

        if (symbol == Operation.Division)
        {
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = new Random().Next(1, max);
                secondNumber = new Random().Next(1, max);
            }
        }

        return new QuestionData(firstNumber, secondNumber, symbol);
    }

    public static bool CheckAnswer(int answer, QuestionData question)
    {
        return question.Operator switch
        {
            Operation.Addition => answer == question.FirstNumber + question.SecondNumber,
            Operation.Subtraction => answer == question.FirstNumber - question.SecondNumber,
            Operation.Multiplication => answer == question.FirstNumber * question.SecondNumber,
            Operation.Division => answer == question.FirstNumber / question.SecondNumber,
            _ => false,
        };
    }
}