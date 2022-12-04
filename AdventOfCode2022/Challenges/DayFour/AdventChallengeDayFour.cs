#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayFour.cs
// Last Modified: 2022/12/04 4:34 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Linq;
using AdventOfCode2022.Challenges.DayTwo;

namespace AdventOfCode2022.Challenges.DayThree
{
    public class AdventChallengeDayFour : AdventChallengeBase
    {
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 4;
        protected override string GetChallengeOneText() => "In how many assignment pairs does one range fully contain the other?";
        protected override void ExecuteChallengeOneInternal()
        {
            FileExtensions.ProcessStream("day4_input_challenge1", r =>
                                                                  {
                                                                      var totalOverlapPairs = 0;

                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          var elfPairAssignments = RetrieveAssignments(line);
                                                                          if(ElfAssignmentFullContainsTheOther(elfPairAssignments)) totalOverlapPairs++;
                                                                      }
                                                                      Console.WriteLine($"The total number of pairs where one member completely overlaps another is {totalOverlapPairs}.");
                                                                  });
        }

        private bool ElfAssignmentFullContainsTheOther(IElfAssignment[] elfPairAssignments)
        {
            var elf1CompletelyInElf2Sections = elfPairAssignments[0].AssignedSections.All(s => elfPairAssignments[1].AssignedSections.Contains(s));
            var elf2CompletelyInElf1Sections = elfPairAssignments[1].AssignedSections.All(s => elfPairAssignments[0].AssignedSections.Contains(s));
            return elf1CompletelyInElf2Sections || elf2CompletelyInElf1Sections;
        }

        private IElfAssignment[] RetrieveAssignments(string line)
        {
            var elfNo = 1;
            var elfAssignments = line.Split(',').Select(e => new ElfAssignment(elfNo++, e)).ToArray();
            return elfAssignments;
        }

        #endregion
    }
}