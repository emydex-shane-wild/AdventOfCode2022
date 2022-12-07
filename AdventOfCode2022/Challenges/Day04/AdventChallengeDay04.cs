#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayFour.cs
// Last Modified: 2022/12/04 4:41 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Linq;
using AdventOfCode2022.Architecture.Extensions;
using AdventOfCode2022.Challenges.Day03;

namespace AdventOfCode2022.Challenges.Day04
{
    public class AdventChallengeDay04 : AdventChallengeBase
    {
        #region Protected Overrides

        protected override int GetDayNumber() => 4;
        protected override string GetChallengeOneText() => "In how many assignment pairs does one range fully contain the other?";
        protected override string GetChallengeTwoText() => "In how many assignment pairs do the ranges overlap?";

        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day4_input_challenge1", r =>
                                                                  {
                                                                      var totalOverlapPairs = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var elfPairAssignments = RetrieveAssignments(line);
                                                                          if (ElfAssignmentFullContainsTheOther(elfPairAssignments))
                                                                          {
                                                                              totalOverlapPairs++;
                                                                          }
                                                                      }

                                                                      Console.WriteLine($"The total number of pairs where one member completely overlaps another is {totalOverlapPairs}.");
                                                                  });
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            FileExtensions.ProcessStream("day4_input_challenge1", r =>
                                                                  {
                                                                      var totalOverlapPairs = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var elfPairAssignments = RetrieveAssignments(line);
                                                                          if (ElfAssignmentPartiallyContainsTheOther(elfPairAssignments))
                                                                          {
                                                                              totalOverlapPairs++;
                                                                          }
                                                                      }

                                                                      Console.WriteLine($"The total number of pairs where one member overlaps another is {totalOverlapPairs}.");
                                                                  });
        }

        #endregion

        #region Private Methods

        private bool ElfAssignmentFullContainsTheOther(IElfAssignment[] elfPairAssignments)
        {
            var elf1CompletelyInElf2Sections = elfPairAssignments[0]
                                               .AssignedSections.All(s => elfPairAssignments[1]
                                                                          .AssignedSections.Contains(s));
            var elf2CompletelyInElf1Sections = elfPairAssignments[1]
                                               .AssignedSections.All(s => elfPairAssignments[0]
                                                                          .AssignedSections.Contains(s));
            return elf1CompletelyInElf2Sections || elf2CompletelyInElf1Sections;
        }

        private bool ElfAssignmentPartiallyContainsTheOther(IElfAssignment[] elfPairAssignments)
        {
            var elf1CompletelyInElf2Sections = elfPairAssignments[0]
                                               .AssignedSections.Any(s => elfPairAssignments[1]
                                                                          .AssignedSections.Contains(s));
            var elf2CompletelyInElf1Sections = elfPairAssignments[1]
                                               .AssignedSections.Any(s => elfPairAssignments[0]
                                                                          .AssignedSections.Contains(s));
            return elf1CompletelyInElf2Sections || elf2CompletelyInElf1Sections;
        }

        private IElfAssignment[] RetrieveAssignments(string line)
        {
            var elfNo = 1;
            var elfAssignments = line.Split(',')
                                     .Select(e => new ElfAssignment(elfNo++, e))
                                     .ToArray();
            return elfAssignments;
        }

        #endregion
    }
}