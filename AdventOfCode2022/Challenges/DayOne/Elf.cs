#region License Information

// **********************************************************************************************************************************
// Elf.cs
// Last Modified: 2022/12/02 12:20 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Challenges.DayOne
{
    public interface IElf
    {
        int ElfId { get; }
        int SnackCount { get; }
        int SnackCaloriesTotal { get; }
        void AddNewSnackCalories(int calories);
        IEnumerable<int> GetAllSnackCalories();
    }

    public class Elf : IElf
    {
        private readonly int _id;
        private readonly IList<int> _snackCalories = new List<int>();

        public Elf(int id)
        {
            _id = id;
        }

        #region Implementation of IElf

        public int ElfId => _id;
        public int SnackCount => _snackCalories.Count;
        public int SnackCaloriesTotal => _snackCalories.Sum();

        public void AddNewSnackCalories(int calories)
        {
            _snackCalories.Add(calories);
        }

        public IEnumerable<int> GetAllSnackCalories() => _snackCalories.ToArray();

        #endregion
    }
}