#region License Information

// **********************************************************************************************************************************
// AdventChallengeDay1.cs
// Last Modified: 2022/12/01 11:31 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Challenges.DayOne
{
    public class AdventChallengeDayOne : AdventChallengeBase
    {
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 1;

        protected override void ExecuteChallengeOneInternal()
        {
            var elves = new List<IElf>();

            using(var memoryStream = new MemoryStream(FileAccessHelper.GetResourceData("day1_input_challenge1")))
            using(var reader = new StreamReader(memoryStream))
            {
                var id = 1;
                var elf = new Elf(id++);
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();
                    
                    if(line == Environment.NewLine || line.IsNullOrEmpty())
                    {
                        elves.Add(elf);
                        elf = new Elf(id++);
                    }
                    else if(int.TryParse(line, out var calories))
                    {
                        elf.AddNewSnackCalories(calories);
                    }
                }

                Console.WriteLine($"Found {elves.Count} elves with {elves.Sum(e => e.SnackCount)} collective snacks.");
                var mostCaloriesElf = elves.OrderByDescending(e => e.SnackCaloriesTotal).FirstOrDefault();
                Console.WriteLine($"The elf with the most snacks is Elf #{(mostCaloriesElf?.ElfId ?? 0)} carrying {(mostCaloriesElf?.SnackCaloriesTotal ?? 0)} calories");
            }
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            
        }

        #endregion
    }
}