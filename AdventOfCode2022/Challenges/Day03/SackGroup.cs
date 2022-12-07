#region License Information

// **********************************************************************************************************************************
// SackGroup.cs
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