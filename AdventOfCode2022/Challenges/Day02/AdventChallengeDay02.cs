#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayTwo.cs
// Last Modified: 2022/12/03 11:30 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day02
{
    public class AdventChallengeDay02 : AdventChallengeBase
    {
        #region Protected Overrides

        protected override int GetDayNumber() => 2;
        protected override string GetChallengeOneText() => "What would your total score be if everything goes exactly according to your strategy guide?";
        protected override string GetChallengeTwoText() => "Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?";

        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day2_input_challenge1", r =>
                                                                  {
                                                                      var totalScore = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var rpsChoices = line.Split(' ');
                                                                          var opponentChoice = rpsChoices[0];
                                                                          var yourChoice = rpsChoices[1];

                                                                          totalScore += CalculateChoiceValue(yourChoice) + CalculateRoundResult(opponentChoice, yourChoice);
                                                                      }

                                                                      Console.WriteLine($"The strategy guide would give you a score of {totalScore}.");
                                                                  });
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            FileExtensions.ProcessStream("day2_input_challenge1", r =>
                                                                  {
                                                                      var totalScore = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var rpsChoices = line.Split(' ');
                                                                          var opponentChoice = rpsChoices[0];
                                                                          var requiredChoice = GetChoiceFromRequiredOutcome(opponentChoice, rpsChoices[1]);
                                                                          totalScore += CalculateChoiceValue(requiredChoice) + CalculateRoundResult(opponentChoice, requiredChoice);
                                                                      }

                                                                      Console.WriteLine($"The updated strategy guide would give you a score of {totalScore}.");
                                                                  });
        }

        #endregion

        #region Private Methods

        private string GetChoiceFromRequiredOutcome(string opponentChoice, string requiredResult)
        {
            switch (requiredResult)
            {
                case "X":
                    switch (opponentChoice)
                    {
                        case "A":
                            return "Z";
                        case "B":
                            return "X";
                        case "C":
                            return "Y";
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be A,B or C.");
                    }
                case "Y":
                    switch (opponentChoice)
                    {
                        case "A":
                            return "X";
                        case "B":
                            return "Y";
                        case "C":
                            return "Z";
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be A,B or C.");
                    }
                case "Z":
                    switch (opponentChoice)
                    {
                        case "A":
                            return "Y";
                        case "B":
                            return "Z";
                        case "C":
                            return "X";
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be A,B or C.");
                    }
                default:
                    throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
            }
        }

        private int CalculateRoundResult(string opponentChoice, string yourChoice)
        {
            switch (opponentChoice)
            {
                case "A":
                    switch (yourChoice)
                    {
                        case "X":
                            return 3;
                        case "Y":
                            return 6;
                        case "Z":
                            return 0;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                case "B":
                    switch (yourChoice)
                    {
                        case "X":
                            return 0;
                        case "Y":
                            return 3;
                        case "Z":
                            return 6;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                case "C":
                    switch (yourChoice)
                    {
                        case "X":
                            return 6;
                        case "Y":
                            return 0;
                        case "Z":
                            return 3;
                        default:
                            throw new ArgumentException("Choice is unexpected. Should be X,Y or Z.");
                    }
                default:
                    throw new ArgumentException("Choice is unexpected. Should be A,B or C.");
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