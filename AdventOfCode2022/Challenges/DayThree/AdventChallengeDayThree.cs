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
using AdventOfCode2022.Challenges.DayTwo;

namespace AdventOfCode2022.Challenges.DayThree
{
    public class AdventChallengeDayThree : AdventChallengeBase
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

    public interface ISackGroup
    {
        #region Public Properties

        bool IsGroupFull { get; }

        #endregion

        #region Public Methods

        void AddItemSack(string sack);
        char GetBadge();

        #endregion
    }

    public class SackGroup : ISackGroup
    {
        #region Private Members

        private readonly IList<string> _sacks = new List<string>();

        #endregion

        #region Public Methods

        public void AddItemSack(string sack)
        {
            if (_sacks.Count == 3)
            {
                throw new Exception("Sack Group Full. Cannot have more than 3 sacks.");
            }

            _sacks.Add(sack);
        }

        public char GetBadge()
        {
            char? c = null;
            var orderedSacks = _sacks.OrderBy(s => s.Length)
                                     .ToArray();
            var smallestSack = orderedSacks.FirstOrDefault();

            for (var i = 0; i < (smallestSack?.Length ?? 0); i++)
            {
                var foundInSack1 = orderedSacks[1]
                                           .IndexOf(smallestSack[i]
                                                            .ToString(), StringComparison.InvariantCulture) > -1;
                var foundInSack2 = orderedSacks[2]
                                           .IndexOf(smallestSack[i]
                                                            .ToString(), StringComparison.InvariantCulture) > -1;
                if (foundInSack1 && foundInSack2)
                {
                    return smallestSack[i];
                }
            }

            return '+';
        }

        #endregion

        #region ISackGroup

        public bool IsGroupFull => _sacks.Count == 3;

        #endregion
    }
}