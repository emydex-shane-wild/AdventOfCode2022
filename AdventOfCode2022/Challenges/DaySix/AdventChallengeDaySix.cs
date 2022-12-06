#region License Information

// **********************************************************************************************************************************
// AdventChallengeDaySix.cs
// Last Modified: 2022/12/06 3:18 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Linq;
using AdventOfCode2022.Challenges.DayTwo;

namespace AdventOfCode2022.Challenges.DaySix
{
    public class AdventChallengeDaySix : AdventChallengeBase
    {
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 6;
        protected override string GetChallengeOneText() => "How many characters need to be processed before the first start-of-packet marker is detected?";

        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day6_input_challenge1", r =>
                                                                  {
                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var lineLength = line.Length;

                                                                          for (var i = 0; i < lineLength; i++)
                                                                          {
                                                                              var checkString = line.Substring(i, 4);
                                                                              if(AreCharsUnique(checkString))
                                                                              {
                                                                                  Console.WriteLine($"The number of processed characters before marker are {i+4}.");
                                                                                  break;
                                                                              }
                                                                          }
                                                                      }
                                                                  });
        }

        private bool AreCharsUnique(string checkString)
        {
            return checkString.Distinct().Count() == checkString.Length;
        }

        #endregion
    }
}