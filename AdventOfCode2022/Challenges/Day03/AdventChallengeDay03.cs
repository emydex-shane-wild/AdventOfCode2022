#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayThree.cs
// Last Modified: 2022/12/04 8:32 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day03
{
    public class AdventChallengeDay03 : AdventChallengeBase
    {
        #region Private Members

        private readonly string _validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        #endregion

        #region Protected Overrides

        protected override int GetDayNumber() => 3;
        protected override string GetChallengeOneText() => "Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types?";
        protected override string GetChallengeTwoText() => "Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?";

        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day3_input_challenge1", r =>
                                                                  {
                                                                      var totalScore = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var itemCount = line.Length;
                                                                          var sackItemCount = itemCount / 2;
                                                                          var sacks = new List<string>
                                                                                      {
                                                                                              line.Substring(0, sackItemCount),
                                                                                              line.Substring(sackItemCount)
                                                                                      };

                                                                          foreach (var c in sacks[0]
                                                                                           .Distinct())
                                                                          {
                                                                              var idx = sacks[1]
                                                                                      .IndexOf(c.ToString(), StringComparison.InvariantCulture);
                                                                              if (idx >= 0)
                                                                              {
                                                                                  totalScore += ParseValue(sacks[1][idx]);
                                                                              }
                                                                          }
                                                                      }

                                                                      Console.WriteLine($"The total score is {totalScore}.");
                                                                  });
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            FileExtensions.ProcessStream("day3_input_challenge1", r =>
                                                                  {
                                                                      var totalScore = 0;
                                                                      var groups = new List<ISackGroup>();
                                                                      var group = new SackGroup();
                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();

                                                                          group.AddItemSack(line);
                                                                          if (group.IsGroupFull == false) continue;
                                                                          
                                                                          groups.Add(group);
                                                                          group = new SackGroup();
                                                                      }

                                                                      totalScore = groups.Sum(g => ParseValue(g.GetBadge()));
                                                                      Console.WriteLine($"The sum of the priorities of the badge item types is {totalScore}.");
                                                                  });
        }

        #endregion

        #region Private Methods

        private int ParseValue(char c)
        {
            return _validCharacters.IndexOf(c.ToString(), StringComparison.CurrentCulture) + 1;
        }

        #endregion
    }
}