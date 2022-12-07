#region License Information

// **********************************************************************************************************************************
// ElfAssignment.cs
// Last Modified: 2022/12/08 6:49 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Challenges.Day03
{
    public interface IElfAssignment
    {
        int ElfNo { get; }
        int[] AssignedSections { get; }
    }

    public class ElfAssignment : IElfAssignment
    {
        public ElfAssignment(int elfNo, string sectionRange)
        {
            ElfNo = elfNo;
            AssignedSections = GatherSectionsFromRange(sectionRange);
        }

        private int[] GatherSectionsFromRange(string sectionRange)
        {
            var startEndRange = sectionRange.Split('-').Select(n => int.TryParse(n, out var num) ? (int?)num : null).ToArray();
            if(startEndRange.Any(n => n == null)) throw new Exception("Numbers were not correctly parsed.");
            var sections = new List<int>();
            for (var i = startEndRange[0]; i <= startEndRange[1]; i++)
            {
                sections.Add(i.Value);
            }
            return sections.ToArray();
        }

        public int ElfNo { get; }
        public int[] AssignedSections { get; }

        
    }
}