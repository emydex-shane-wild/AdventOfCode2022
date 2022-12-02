#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayTwo.cs
// Last Modified: 2022/12/02 4:37 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.IO;
using AdventOfCode2022.Architecture;

namespace AdventOfCode2022.Challenges.DayTwo
{
    public class AdventChallengeDayTwo : AdventChallengeBase
    {
        #region Protected Overrides

        protected override int GetDayNumber() => 2;
        protected override string GetChallengeOneText() => "What would your total score be if everything goes exactly according to your strategy guide?";

        protected override void ExecuteChallengeOneInternal()
        {
            using (var memoryStream = new MemoryStream(FileAccessHelper.GetResourceData("day2_input_challenge1")))
                using (var reader = new StreamReader(memoryStream))
                {
                    var totalScore = 0;

                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLine();
                        var rpsChoices = line.Split(' ');
                        var opponentChoice = rpsChoices[0];
                        var yourChoice = rpsChoices[1];

                        totalScore += CalculateRoundResult(opponentChoice, yourChoice) + CalculateChoiceValue(yourChoice);
                    }

                    Console.WriteLine($"The strategy guide would give you a score of {totalScore}.");
                }
        }

        private int CalculateRoundResult(string opponentChoice, string yourChoice)
        {
            switch (opponentChoice)
            {
                case "A":
                    switch (yourChoice)
                    {
                        case "X": return 3;
                        case "Y": return 6;
                        case "Z": return 0;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                case "B":
                    switch (yourChoice)
                    {
                        case "X": return 0;
                        case "Y": return 3;
                        case "Z": return 6;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                case "C":
                    switch (yourChoice)
                    {
                        case "X": return 6;
                        case "Y": return 0;
                        case "Z": return 3;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                default:
                    throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
            }
        }

        private int CalculateChoiceValue(string rpsChoice)
        {
            switch (rpsChoice)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
            }
        }

        #endregion
    }
}