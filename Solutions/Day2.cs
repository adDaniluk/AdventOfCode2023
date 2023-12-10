using System.Text.RegularExpressions;


namespace AdventOfCode2023.Solutions
{
    internal class Day2
    {
        private readonly IList<string> inputList = InputReader.GetInputList("day2.txt");

        private int _gameId;
        private int _gameSum;
        private bool _gameCheck;

        private Dictionary<string, int> _gameBalls = new Dictionary<string, int>();

        private readonly Regex _regexGameId = new Regex(" [\\d]+");
        private readonly Regex _regexAllGames = new Regex("(?<=\\:|\\;)(.*?)(?=\\;|$)");

        private readonly Regex _regexBallsCount = new Regex("[\\d]+");
        private readonly Regex _regexBallsColour = new Regex("[a-z]+");

        public Day2()
        {
            Console.WriteLine("Result of Task1 from Day2: " + Task1(inputList));
            Console.WriteLine("Result of Task2 from Day2: " + Task2(inputList));
        }

        private int Task1(IList<string> inputList)
        {
            foreach (string input in inputList)
            {
                _gameCheck = true;
                _gameId = Int32.Parse(_regexGameId.Match(input).Value);

                var singleGame = GetGames(input);

                foreach (string game in singleGame)
                {
                    foreach (string splittedGame in game.Split(','))
                    {
                        int ballsCount = Int32.Parse(_regexBallsCount.Match(splittedGame).Value);
                        string colour = (string)_regexBallsColour.Match(splittedGame).Value;

                        if (!((colour == "red" && ballsCount < 13) || (colour == "green" && ballsCount < 14) || (colour == "blue" && ballsCount < 15)))
                        {
                            _gameCheck = false;
                        }
                    }
                }

                if (_gameCheck)
                {
                    _gameSum += _gameId;
                }

            }
            return _gameSum;
        }

        private int Task2(IList<string> inputList)
        {
            _gameSum = 0;

            foreach (string input in inputList)
            {

                var singleGame = GetGames(input);

                foreach (string game in singleGame)
                {
                    foreach (string splittedGame in game.Split(','))
                    {
                        int ballsCount = Int32.Parse(_regexBallsCount.Match(splittedGame).Value);
                        string colour = (string)_regexBallsColour.Match(splittedGame).Value;

                        if (!_gameBalls.ContainsKey(colour))
                        {
                            _gameBalls.Add(colour, ballsCount);
                        }
                        else
                        {
                            if (_gameBalls[colour] < ballsCount)
                            {
                                _gameBalls[colour] = ballsCount;
                            }
                        }
                    }
                }

                _gameSum += _gameBalls.Values.ToList().Aggregate(1, (x, y) => x * y);
                _gameBalls.Clear();
            }

            return _gameSum;
        }

        private IList<string> GetGames(string input)
        {
            var gamesMatch = _regexAllGames.Matches(input);

            List<string> games = new List<string>();

            gamesMatch.ToList().ForEach(game => games.Add(game.Value));

            return games;
        }
    }
}
