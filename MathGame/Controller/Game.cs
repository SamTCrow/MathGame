using MathGame.Localization;
using MathGame.Models;
using MathGame.Views;
using Spectre.Console;

namespace MathGame.Controller;

internal class Game(IView view)
{
    public IView View { get; } = view;
    public int Score { get; private set; } = 0;
    public int TotalQuestions { get; private set; } = 0;
    public List<QuestionResult> Results { get; } = new();
    public bool End { get; private set; } = false;
    public List<GameInfo> GameList { get; private set; } = new();

    public void Run()
    {
        string name = View.Welcome();
        while (!End)
        {
            GameMode menuChoice = View.DisplayMenu();
            if (menuChoice == GameMode.Records)
            {
                View.DisplayRecord(GameList);
                continue;
            }
            Difficulty difficulty = View.DisplayDifficultyMenu();
            Question questionGenerator = new(new GameDetails(menuChoice, difficulty));
            DateTime start = DateTime.Now;
            TotalQuestions = difficulty switch
            {
                Difficulty.Easy => 5,
                Difficulty.Medium => 10,
                Difficulty.Hard => 15,
                _ => 5,
            };

            for (int i = 0; i < TotalQuestions; i++)
            {
                var question = questionGenerator.GetQuestion();
                int answer = View.DisplayQuestion(question);
                bool result = View.DisplayResult(answer, question);
                if (result)
                {
                    Score++;
                }
                Results.Add(new QuestionResult(i + 1, result));
                View.DisplayStatus(Results);
            }
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            GameList.Add(new GameInfo(menuChoice, difficulty, Score, name, time.TotalSeconds));
            bool keepPlaying = View.DisplayEnd(Score, name, time.TotalSeconds);
            Results.Clear();
            Score = 0;
            AnsiConsole.Clear();
            End = !keepPlaying;
        }
    }
}