#region License Information

// **********************************************************************************************************************************
// AdventChallengeDaySix.cs
// Last Modified: 2022/12/06 3:18 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.IO;
using System.Linq;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day06
{
    public class AdventChallengeDay06 : AdventChallengeBase
    {
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 6;
        protected override string GetChallengeOneText() => "How many characters need to be processed before the first start-of-packet marker is detected?";
        protected override string GetChallengeTwoText() => "How many characters need to be processed before the first start-of-message marker is detected?";

        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day6_input_challenge1", r =>
                                                                  {
                                                                      Console.WriteLine($"The number of processed characters before marker are {CalculateProcessedCharacters(r, 4)}.");
                                                                  });
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            FileExtensions.ProcessStream("day6_input_challenge1", r =>
                                                                  {
                                                                      Console.WriteLine($"The number of processed characters before marker are {CalculateProcessedCharacters(r, 14)}.");
                                                                  });
        }

        private int CalculateProcessedCharacters(StreamReader reader, int uniqueCharacterCount)
        {
            var processedCharCount = 0;
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLine();
                var lineLength = line.Length;

                for (var i = 0; i < lineLength; i++)
                {
                    var checkString = line.Substring(i, uniqueCharacterCount);
                    if(AreCharsUnique(checkString))
                    {
                        processedCharCount = i+uniqueCharacterCount;
                        break;
                    }
                }
            }

            return processedCharCount;
        }

        private bool AreCharsUnique(string checkString)
        {
            return checkString.Distinct().Count() == checkString.Length;
        }

        #endregion
    }
}