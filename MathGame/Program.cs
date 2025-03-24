using MathGame.Controller;
using MathGame.Localization;
using MathGame.Views;

Language lang = Language.English;
IView console = new ConsoleView(lang);
Game newGame = new(console);
newGame.Run();