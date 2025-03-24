using MathGame.Controller;
using MathGame.Localization;
using MathGame.Models;

namespace MathGame.Views;

internal interface IView
{
    Language Lang { get; set; }

    int DisplayQuestion(QuestionData question);

    bool DisplayResult(int answer, QuestionData question);

    GameMode DisplayMenu();

    Difficulty DisplayDifficultyMenu();

    string Welcome();

    void DisplayStatus(List<QuestionResult> result);

    bool DisplayEnd(int score, string name, double time);

    void DisplayRecord(List<GameInfo> gameList);
}